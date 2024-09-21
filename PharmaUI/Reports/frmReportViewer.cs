using Microsoft.Reporting.WinForms;
using PharmaBusiness;
using PharmaBusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PharmaUI
{
    public partial class frmReportViewer : Form
    {
        IApplicationFacade applicationFacade;
        
        public frmReportViewer()
        {
            InitializeComponent();
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
           
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            appPath = appPath.Replace(@"bin\Debug", string.Empty);

            string reportPath = Path.Combine(appPath, "Reports");
            string reportName = "SaleInvoice.rdlc";
            this.reportViewer2.Reset();
            this.reportViewer2.LocalReport.ReportPath = Path.Combine(reportPath, reportName);
            this.reportViewer2.LocalReport.DataSources.Clear();

            //this.reportViewer1.
            DataTable saleInvoice =applicationFacade.GetSaleInvoiceData(5);
            //DataTable firmProperties = applicationFacade.GetFirmProperties(2);

            ReportDataSource dtSaleInvoice = new ReportDataSource("SaleInvoice", saleInvoice);
           // ReportDataSource dtFirmProperties = new ReportDataSource("FirmProperties", firmProperties);

            this.reportViewer2.LocalReport.DataSources.Add(dtSaleInvoice);
            //this.reportViewer1.LocalReport.DataSources.Add(dtFirmProperties);
            this.reportViewer2.RefreshReport();

            this.reportViewer2.Visible = true;
            this.reportViewer2.RenderingComplete += ReportViewer1_RenderingComplete;
        }


        private void ReportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            //DialogResult result = this.reportViewer1.PrintDialog();
            //this.Close();
        }
    }
}
