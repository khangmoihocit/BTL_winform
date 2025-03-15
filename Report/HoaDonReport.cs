using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Report
{
    public partial class HoaDonReport: Form
    {
        public HoaDonReport()
        {
            InitializeComponent();
        }

        public void showReport(string reportFilePath, string reportTitle, string recordFilter)
        {
            ReportDocument rpt = new ReportDocument();
            rpt.Load(reportFilePath);

            TableLogOnInfo tableLogonInfo = new TableLogOnInfo();
            tableLogonInfo.ConnectionInfo.ServerName = "KHANG\\SQLEXPRESS02";
            tableLogonInfo.ConnectionInfo.DatabaseName = "QuanLyThuPhiCapNuocSach";
            tableLogonInfo.ConnectionInfo.UserID = "khang";
            tableLogonInfo.ConnectionInfo.Password = "123";

            foreach (Table t in rpt.Database.Tables)
            {
                t.ApplyLogOnInfo(tableLogonInfo);
            }

            rpt.RecordSelectionFormula = recordFilter;
            rpt.SummaryInfo.ReportTitle = reportTitle;
            crystalReportViewer_Hoadon.ReportSource = rpt;
        }
    }
}
