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

        private object _stock;
        public object stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        public MainViewModel()
        {
            JournalVM journalVM = new JournalVM();
            journal = journalVM;

            StockVM stockVm = new StockVM();
            stock = stockVm;
        }
    }
}
