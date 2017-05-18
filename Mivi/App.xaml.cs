using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace Mivi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Bootstrapper bt = new Bootstrapper();
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            bt.Run();
        }
    }
}
