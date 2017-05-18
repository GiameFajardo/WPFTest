using Mivi.Events;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mivi.ViewModels
{
    public class StudentsViewModel:BindableBase
    {
        IEventAggregator _eventAggregator;
        public StudentsViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<UpdatedEvent>().Subscribe(Updated);
        }

        private void Updated(string param)
        {
            Message = param;
        }
        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

    }
}
