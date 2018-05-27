using Apteka.Plus.Logic.OrderConverter.BLL;
using Apteka.Plus.Logic.OrderConverter.DAL;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apteka.Plus.Forms
{
    public partial class frmExternalOrderMapEditor : Form
    {
        private ExternalOrderSupplier _externalOrderSupplier;
        private readonly IExternalOrderMappingAccessor _externalOrderMappingAccessor;

        private static List<ExternalOrderMappingRow> LocalNameToLocalNameUIMapping = new List<ExternalOrderMappingRow>
                {
                    new ExternalOrderMappingRow { LocalNameUI = "Название", LocalName ="SupplierProductName" },
                    new ExternalOrderMappingRow { LocalNameUI = "Код", LocalName ="SupplierProductID" },
                    new ExternalOrderMappingRow { LocalNameUI = "Кол-во", LocalName ="Count" },
                    new ExternalOrderMappingRow { LocalNameUI = "Цена поставщика с НДС", LocalName ="SupplierPriceWithNDS" },
                    new ExternalOrderMappingRow { LocalNameUI = "Цена производителя с НДС",  LocalName ="VendorPriceWithNDS" },
                    new ExternalOrderMappingRow { LocalNameUI = "Цена производителя без НДС",  LocalName ="VendorPriceWithoutNDS" },
                    new ExternalOrderMappingRow { LocalNameUI = "Штрих-код",  LocalName ="EAN13" },
                    new ExternalOrderMappingRow { LocalNameUI = "НДС",  LocalName ="NDS" },
                    new ExternalOrderMappingRow { LocalNameUI = "Серия",  LocalName ="Series" },
                    new ExternalOrderMappingRow { LocalNameUI = "Срок годности",  LocalName ="ExpirationDate" },
                    new ExternalOrderMappingRow { LocalNameUI = "Реестр",  LocalName ="PriceReestr" },
                    new ExternalOrderMappingRow { LocalNameUI = "Производитель",  LocalName ="Producer" },
                    new ExternalOrderMappingRow { LocalNameUI = "Страна",  LocalName ="Country" },
                    new ExternalOrderMappingRow { LocalNameUI = "Жизненноважный",  LocalName ="IsLifeImportant" }
                };

        public frmExternalOrderMapEditor(IExternalOrderMappingAccessor externalOrderMappingAccessor)
        {
            InitializeComponent();
            _externalOrderMappingAccessor = externalOrderMappingAccessor;
        }

        public frmExternalOrderMapEditor(IExternalOrderMappingAccessor externalOrderMappingAccessor, ExternalOrderSupplier externalOrderSupplier) : this(externalOrderMappingAccessor)
        {
            _externalOrderSupplier = externalOrderSupplier;
        }

        private void btnLoadExternalOrder_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var foreignOrderAccessor = new DbfFileReader(openFileDialog1.FileName);

                var externalOrderDataTable = foreignOrderAccessor.GetOrderRowsAsIs();

                dgvExternalOrder.DataSource = externalOrderDataTable;
            }
        }

        private void copyHeaderName_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(dgvExternalOrder.CurrentCell.OwningColumn.Name);
        }

        private void pasteHeaderName_Click(object sender, EventArgs e)
        {
            var columnName = Clipboard.GetText();
            var orderMappingRow = (ExternalOrderMappingRow)dgvExternalOrderMapping.CurrentRow.DataBoundItem;
            orderMappingRow.ExternalName = columnName;

            dgvExternalOrderMapping.InvalidateRow(dgvExternalOrderMapping.CurrentRow.Index);
        }

        private void frmExternalOrderMapEditor_Load(object sender, EventArgs e)
        {
            IList<ExternalOrderMappingRow> mapping;

            if (_externalOrderSupplier == null)
            {
                _externalOrderSupplier = new ExternalOrderSupplier();

                mapping = LocalNameToLocalNameUIMapping;
            }
            else
            {
                tbSupplierName.Text = _externalOrderSupplier.Name;

                mapping = _externalOrderMappingAccessor.GetMappingFor(_externalOrderSupplier);

                EnrichWithLocalNameUI(mapping);
            }

            dgvExternalOrderMapping.DataSource = mapping;
        }

        private void EnrichWithLocalNameUI(IList<ExternalOrderMappingRow> mappings)
        {
            foreach (var mapping in mappings)
            {
                var itemFromCollection = LocalNameToLocalNameUIMapping.FirstOrDefault(item => item.LocalName == mapping.LocalName);
                if(itemFromCollection!=null)
                {
                    mapping.LocalNameUI = itemFromCollection.LocalNameUI;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _externalOrderSupplier.Name = tbSupplierName.Text;
            _externalOrderMappingAccessor.Save(_externalOrderSupplier, (IList<ExternalOrderMappingRow>)dgvExternalOrderMapping.DataSource);

            Close();
        }
    }
}