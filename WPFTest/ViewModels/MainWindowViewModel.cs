using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mivi.ViewModels
{
    public class MainWindowViewModel:BindableBase
    {
        IRegionManager _regionManager;
        public DelegateCommand<string> NavigateCommand { get; set; }
        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string uri)
        {
            _regionManager.RequestNavigate("MainRegion", uri);
        }
    }
}
