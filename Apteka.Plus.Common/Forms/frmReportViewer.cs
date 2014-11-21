using System.Collections;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Apteka.Plus.Forms
{
    public partial class frmReportViewer : Form
    {
        public frmReportViewer(string reportName)
        {
            InitializeComponent();
            FindAndInitReportDefinition(reportName);
        }

        private void FindAndInitReportDefinition(string reportLocation)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = reportLocation;
        }

        public void SetParameters(params ReportParameter[] parameters)
        {
            reportViewer1.LocalReport.SetParameters(parameters);
        }

        public void SetDataSource(string name, object dataSource)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rds = new ReportDataSource(name, dataSource);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }
    }
}
