using Devoted.Model;
using Devoted.ViewModel.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoted.ViewModel
{
    internal class MainViewModel
    {
        private object _journal;
        public object journal
        {
            get { return _journal; }
            set { _journal = value; }
        }

        public MainViewModel()
        {
            JournalVM journalVM = new JournalVM();
            journal = journalVM;
        }
    }
}
