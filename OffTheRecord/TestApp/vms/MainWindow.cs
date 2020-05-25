using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.vms
{
    public class MainWindow : ViewModelBase
    {

        private string _content;
        public string Content

        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }
    }
}
