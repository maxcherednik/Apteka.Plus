using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Forms
{
    public partial class frmDefecturaNewList : Form
    {
        public string NewListName { get; private set; }

        public DefectList NewDefectList { get; set; }

        private readonly List<DefectListCriteria> _liCriteria = new List<DefectListCriteria>();

        public frmDefecturaNewList()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() == "")
            {
                MessageBox.Show(@"Название листа не может быть путым!", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbName.Focus();

                return;
            }

            NewListName = tbName.Text;

            if (NewDefectList == null)
            {
                NewDefectList = new DefectList
                {
                    Name = NewListName,
                    IsSmartList = chkbIsSmartList.Checked
                };

                using (var db = new DbManager())
                {
                    var defectListCriteriaAccessor = DataAccessor.CreateInstance<DefectListCriteriaAccessor>(db);
                    var defectListsAccessor = DataAccessor.CreateInstance<DefectListsAccessor>(db);

                    NewDefectList.ID = defectListsAccessor.Insert(NewDefectList);

                    foreach (var criteria in _liCriteria)
                    {
                        criteria.DefectListID = NewDefectList.ID;
                        defectListCriteriaAccessor.Query.Insert(criteria);
                    }
                }
            }
            else
            {
                if (NewDefectList.Name != NewListName)
                {
                    NewDefectList.Name = NewListName;

                    using (var db = new DbManager())
                    {
                        var defectListsAccessor = DataAccessor.CreateInstance<DefectListsAccessor>(db);
                        defectListsAccessor.Query.Update(NewDefectList);
                    }
                }
            }
        }

        private void frmDefecturaNewList_Load(object sender, EventArgs e)
        {
            defectListCriteriaBindingSource.DataSource = _liCriteria;

            if (NewDefectList != null)
            {
                btnDelList.Visible = true;
                tbName.Text = NewDefectList.Name;
                chkbIsSmartList.Checked = NewDefectList.IsSmartList;
                chkbIsSmartList.Enabled = false;

                if (NewDefectList.IsSmartList)
                {
                    List<DefectListCriteria> liCriteria;
                    using (var db = new DbManager())
                    {
                        var defectListCriteriaAccessor = DataAccessor.CreateInstance<DefectListCriteriaAccessor>(db);

                        liCriteria = defectListCriteriaAccessor.SelectByKey(NewDefectList.ID);
                    }

                    defectListCriteriaBindingSource.DataSource = liCriteria;
                }
            }
        }

        private void btnAddCriteria_Click(object sender, EventArgs e)
        {
            var criteria = new DefectListCriteria
            {
                FieldName = cboCriteria.Text,
                SearchValue = tbSearchValue.Text
            };

            defectListCriteriaBindingSource.Add(criteria);

            if (NewDefectList != null)
            {
                using (var db = new DbManager())
                {
                    var defectListCriteriaAccessor = DataAccessor.CreateInstance<DefectListCriteriaAccessor>(db);
                    criteria.DefectListID = NewDefectList.ID;
                    defectListCriteriaAccessor.Query.Insert(criteria);
                }
            }
        }

        private void chkbIsSmartList_CheckedChanged(object sender, EventArgs e)
        {
            gbCriteriaManager.Enabled = ((CheckBox)sender).Checked;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var value = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            if (value == "Удалить")
            {
                if (NewDefectList != null)
                {
                    var criteria = (DefectListCriteria)dgv.Rows[e.RowIndex].DataBoundItem;
                    using (var db = new DbManager())
                    {
                        var defectListCriteriaAccessor = DataAccessor.CreateInstance<DefectListCriteriaAccessor>(db);
                        defectListCriteriaAccessor.Query.Delete(criteria);
                    }
                }

                dgv.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void btnDelList_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show($@"Вы уверены, что хотите удалить лист {NewDefectList.Name}?", @"Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                using (var db = new DbManager())
                {
                    var defectListsAccessor = DataAccessor.CreateInstance<DefectListsAccessor>(db);
                    defectListsAccessor.Query.Delete(NewDefectList);
                }
                Close();
            }
        }
    }
}
