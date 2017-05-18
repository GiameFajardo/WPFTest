using CrystalDecisions.Shared;
using Mivi.Models;
using Mivi.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mivi.Views
{
    /// <summary>
    /// Interaction logic for DepartmentsView.xaml
    /// </summary>
    /// 

    public partial class DepartmentsView : UserControl
    {
        
        public DepartmentsView()
        {
            InitializeComponent();
        }

        private void ViewLoaded(object sender, RoutedEventArgs e)
        {
            DepartmentsReport report = new DepartmentsReport();

            var conn = new ConnectionInfo()
            {
                ServerName = "gmcrls-pc",
                DatabaseName = "School",
                UserID = "sa",
                Password = "Fhons2011"
            };
            //FROM DBSET
            report.Load("@DepartmentsReport");
            report.SetDatabaseLogon(conn.UserID, conn.Password, conn.ServerName, conn.DatabaseName);
            
            reportViewer.ViewerCore.ReportSource = report;


            //FROM DB
            //Departments rep = new Departments();
            //rep.Load("@Departments");
            //rep.SetDatabaseLogon(conn.UserID, conn.Password, conn.ServerName, conn.DatabaseName);

            //reportViewer.ViewerCore.ReportSource = rep;
        }
    }
}
