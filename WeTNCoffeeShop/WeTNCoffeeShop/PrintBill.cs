using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeTNCoffeeShop.tdo;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
namespace WeTNCoffeeShop
{
    public partial class PrintBill : Form
    {
        private List<BillModel> billModels;
        private long total = 0;
        private string nameCustomer = "";
        private int id;
        private string discount = "";
        private string surcharge = "";
        private string reason = "";
        public PrintBill(List<BillModel> billModels, long total, int id, string nameCustomer, string discount, string surcharge, string reason)
        {
            InitializeComponent();
            this.billModels = billModels;
            this.total = total; 
            this.nameCustomer = nameCustomer;
            this.id = id;
            this.discount = discount;  
            this.surcharge = surcharge;
            this.reason = reason;
        }

        private void PrintBill_Load(object sender, EventArgs e)
            
        {
            this.reportViewer1.ProcessingMode =
    Microsoft.Reporting.WinForms.ProcessingMode.Local;
            bindingSource1.DataSource = billModels;
            ReportParameter ptotal = new Microsoft.Reporting.WinForms.ReportParameter("total", total.ToString());
            ReportParameter pdate = new Microsoft.Reporting.WinForms.ReportParameter("Date", DateTime.Now.ToString());
            ReportParameter pname = new Microsoft.Reporting.WinForms.ReportParameter("NameCustomer", nameCustomer.ToString());
            ReportParameter pid = new Microsoft.Reporting.WinForms.ReportParameter("ID", id.ToString());
            ReportParameter pdiscount = new Microsoft.Reporting.WinForms.ReportParameter("Discount", discount.ToString());
            ReportParameter psurcharge = new Microsoft.Reporting.WinForms.ReportParameter("Surcharge", surcharge.ToString());
            ReportParameter preason = new Microsoft.Reporting.WinForms.ReportParameter("Reason", reason.ToString());
            this.reportViewer1.LocalReport.SetParameters(ptotal);
            this.reportViewer1.LocalReport.SetParameters(pdate);
            this.reportViewer1.LocalReport.SetParameters(pname);
            this.reportViewer1.LocalReport.SetParameters(pid);
            this.reportViewer1.LocalReport.SetParameters(pdiscount);
            this.reportViewer1.LocalReport.SetParameters(psurcharge);
            this.reportViewer1.LocalReport.SetParameters(preason);
            ReportDataSource n = new ReportDataSource("dtPrintBill" ,bindingSource1);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(n);
            this.reportViewer1.RefreshReport();
            
        }
    }
}
