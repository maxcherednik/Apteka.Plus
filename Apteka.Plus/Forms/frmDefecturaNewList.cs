using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;

namespace Apteka.Plus.Forms
{
    public partial class frmDefecturaNewList : Form
    {
        private string _newListName;

        DefectList _newDefectList;

        public string NewListName
        {
            get { return _newListName; }            
        }

        public DefectList NewDefectList
        {
            get { return _newDefectList; }
            set { _newDefectList=value; }
        }

        List<DefectListCriteria> _liCriteria=new List<DefectListCriteria>();

        public frmDefecturaNewList()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() == "")
            {
                MessageBox.Show("Название листа не может быть путым!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbName.Focus();
                
                return;   
            }
            _newListName = tbName.Text;
            if (_newDefectList == null)
            {
                _newDefectList = new DefectList();
                _newDefectList.Name = _newListName;
                _newDefectList.IsSmartList = chkbIsSmartList.Checked;

                using (DbManager db = new DbManager())
                {
                    DefectListCriteriaAccessor DefectListCriteriaAccessor = DefectListCriteriaAccessor.CreateInstance<DefectListCriteriaAccessor>(db);
                    DefectListsAccessor DefectListsAccessor = DefectListsAccessor.CreateInstance<DefectListsAccessor>(db);

                    _newDefectList.ID = DefectListsAccessor.Insert(_newDefectList);

                    foreach (DefectListCriteria criteria in _liCriteria)
                    {
                        criteria.DefectListID = _newDefectList.ID;
                        DefectListCriteriaAccessor.Query.Insert(criteria);
                    }

                }

            }
            else
            {
                if (_newDefectList.Name != _newListName)
                {
                    _newDefectList.Name = _newListName;

                    using (DbManager db = new DbManager())
                    {
                        
                        DefectListsAccessor DefectListsAccessor = DefectListsAccessor.CreateInstance<DefectListsAccessor>(db);
                        DefectListsAccessor.Query.Update(_newDefectList);

                    }
                }

            }
        }

       
        private void frmDefecturaNewList_Load(object sender, EventArgs e)
        {
            frmDefectura frm = this.Owner as frmDefectura;

            defectListCriteriaBindingSource.DataSource = _liCriteria;

            if (_newDefectList != null)
            {
                btnDelList.Visible = true;
                tbName.Text = _newDefectList.Name;
                chkbIsSmartList.Checked = _newDefectList.IsSmartList;
                chkbIsSmartList.Enabled = false;

                if (_newDefectList.IsSmartList)
                {
                    List<DefectListCriteria> liCriteria;
                    using (DbManager db = new DbManager())
                    {
                        DefectListCriteriaAccessor DefectListCriteriaAccessor = DefectListCriteriaAccessor.CreateInstance<DefectListCriteriaAccessor>(db);

                        liCriteria = DefectListCriteriaAccessor.SelectByKey(_newDefectList.ID);
                    }

                    defectListCriteriaBindingSource.DataSource = liCriteria;

                }
            }

        }

        private void btnAddCriteria_Click(object sender, EventArgs e)
        {
            DefectListCriteria criteria = new DefectListCriteria();

            criteria.FieldName = cboCriteria.Text;
            criteria.SearchValue = tbSearchValue.Text;

            defectListCriteriaBindingSource.Add(criteria);

            if (_newDefectList != null)
            {
                
                using (DbManager db = new DbManager())
                {
                    DefectListCriteriaAccessor DefectListCriteriaAccessor = DefectListCriteriaAccessor.CreateInstance<DefectListCriteriaAccessor>(db);
                    criteria.DefectListID = _newDefectList.ID;
                    DefectListCriteriaAccessor.Query.Insert(criteria);
                }
            }

        }

        private void chkbIsSmartList_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox  box = sender as CheckBox;

            if (box.Checked == true)
            {
                gbCriteriaManager.Enabled  = true;
                
            }
            else
            {
                gbCriteriaManager.Enabled = false;

                
            }
                        
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            string value  = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() ;
            if (value == "Удалить")
            {
                if (_newDefectList != null)
                {
                    DefectListCriteria criteria = dgv.Rows[e.RowIndex].DataBoundItem as DefectListCriteria;
                    using (DbManager db = new DbManager())
                    {
                        DefectListCriteriaAccessor DefectListCriteriaAccessor = DefectListCriteriaAccessor.CreateInstance<DefectListCriteriaAccessor>(db);
                        DefectListCriteriaAccessor.Query.Delete(criteria);
                    }
                }

                dgv.Rows.RemoveAt(e.RowIndex);
            }
        }

       

        private void btnDelList_Click(object sender, EventArgs e)
        {
             DialogResult res = MessageBox.Show("Вы уверены, что хотите удалить лист " + _newDefectList.Name + "?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

             if (res == DialogResult.Yes)
             {
                 using (DbManager db = new DbManager())
                 {
                     DefectListsAccessor DefectListsAccessor = DefectListsAccessor.CreateInstance<DefectListsAccessor>(db);
                     DefectListsAccessor.Query.Delete(_newDefectList);
                 }
                 this.Close();
             }
        }
    }
}
