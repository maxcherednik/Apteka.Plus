using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Apteka.Plus.Logic.OrderConverter.BLL;
using Apteka.Plus.Logic.OrderConverter.DAL;

namespace Apteka.Plus.Forms
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
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (liFirms.SelectedIndex == -1)
            {
                MessageBox.Show(@"Вы не выбрали фирму", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IList<IForeignOrderConverter> foreignOrderRows;

                var gwForeignOrderAccessor = new DbfFileReader(openFileDialog1.FileName);

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
                            MessageBox.Show(@"Произошла ошибка. Не нашел обработчика для накладных фирмы " + liFirms.Text, @"Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                }

                var liLocalOrderRows = foreignOrderRows.Select(iForeignOrderRow => iForeignOrderRow.ConvertToLocalOrder()).ToList();

                var file = new FileInfo(openFileDialog1.FileName);

                var di = file.Directory;
                foreach (var fileInfo in di.GetFiles("*.dbf"))
                {
                    if (fileInfo.CreationTime < DateTime.Today.AddDays(-2))
                        fileInfo.Delete();
                }

                FileName = file.Name;

                SupplierName = liFirms.Text;
                ConvertedOrder = liLocalOrderRows;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}