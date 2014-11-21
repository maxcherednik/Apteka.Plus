using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Apteka.Plus.Forms;
using OrderConverter.BLL;
using OrderConverter.DAL;
using Apteka.Plus.Logic.OrderConverter.BLL;

namespace OrderConverter
{
    public partial class frmConvertOrder : Form
    {
        public frmConvertOrder()
        {
            InitializeComponent();
        }

        public List<LocalOrder> ConvertedOrder;
        public string SupplierName;
        public string FileName;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (liFirms.SelectedIndex == -1)
            {
                MessageBox.Show("Вы не выбрали фирму", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IList<IForeignOrderConverter> foreignOrderRows;
                // ConfigurationSettings.   
                #region Choosing Foreign Order Gateway

                DBFFileReader gwForeignOrderAccessor = new DBFFileReader(openFileDialog1.FileName);

                switch (liFirms.Text.ToLower())
                {
                    case "катрен":
                    case "сиа":
                    case "надежда":
                    case "генезис":
                    case "норман":
                    case "фармкомплект":
                        {
                            foreignOrderRows = gwForeignOrderAccessor.GetOrderRows<SIAOrder>().Cast<IForeignOrderConverter>().ToList();
                            break;
                        }
                    case "топ":
                        {
                            foreignOrderRows = gwForeignOrderAccessor.GetOrderRows<TopOrder>().Cast<IForeignOrderConverter>().ToList();
                            break;
                        }
                    case "протек":
                        {
                            foreignOrderRows = gwForeignOrderAccessor.GetOrderRows<ProtekOrder>().Cast<IForeignOrderConverter>().ToList();
                            break;
                        }
                    case "пульс":
                        {
                            foreignOrderRows = gwForeignOrderAccessor.GetOrderRows<PulseOrder>().Cast<IForeignOrderConverter>().ToList();
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Произошла ошибка. Не нашел обработчика для накладных фирмы " + liFirms.Text, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;

                        }
                }

                List<LocalOrder> liLocalOrderRows = new List<LocalOrder>();
                foreach (IForeignOrderConverter iForeignOrderRow in foreignOrderRows)
                {
                    LocalOrder localOrderRow = iForeignOrderRow.ConvertToLocalOrder();
                    liLocalOrderRows.Add(localOrderRow);
                }

                #endregion

                FileInfo file = new FileInfo(openFileDialog1.FileName);

                #region Clean Old Files

                DirectoryInfo di= file.Directory;
                foreach (FileInfo fileInfo in di.GetFiles("*.dbf"))
                {
                    if(fileInfo.CreationTime<DateTime.Today.AddDays(-2))
                        fileInfo.Delete();
                }

                #endregion

                FileName = file.Name;
                
                SupplierName = liFirms.Text;
                frmForeignOrderViewer frmForeignOrderViewer = new frmForeignOrderViewer(liLocalOrderRows);
                ConvertedOrder = liLocalOrderRows;
                this.DialogResult = DialogResult.OK;
                this.Close();
                
            }
        }
    }
}