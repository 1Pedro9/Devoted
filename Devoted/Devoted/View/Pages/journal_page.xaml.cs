using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
using Devoted.Controller;
using Devoted.Model;

namespace Devoted.View.Pages
{
    /// <summary>
    /// Interaction logic for journal_page.xaml
    /// </summary>
    public partial class journal_page : UserControl
    {

        private Member member;
        private Plan plan;
        private ModelController controller;
        public journal_page()
        {
            InitializeComponent();
            controller = new ModelController();
            
            show_journal();
            UpdateScrollViewerHeight();
        }

        private void show_journal()
        {
            List<Journal> journals = controller.journals();
            int count = 0;
            foreach (Journal journal in journals)
            {
                count++;
                Console.WriteLine(journal.JournalId);    
                show_row(count, journal);
            }
        }

        private void show_row(int row, Journal journal)
        {
            Table.RowDefinitions.Add(new RowDefinition());
            Button action = new Button();
            action.Content = journal.JournalId.ToString();
            action.Cursor = Cursors.Hand;
            action.Background = Brushes.White;
            Grid.SetRow(action, row);

            Table.Children.Add(action);

            string[] array = { journal.getYear(), journal.getMonth(), journal.getDay(), journal.Details.ToString(), journal.Amount.ToString(), journal.DiverseDetails.ToString() };

            for (int i = 0; i < array.Length; i++)
            {
                TextBox label = new TextBox();
                label.Text = array[i];
                Grid.SetColumn(label, i+1);
                Grid.SetRow(label, row);
                label.FontSize = 20;
                label.FontWeight = FontWeights.DemiBold;
                label.Padding = new Thickness(10, 5, 10, 5);
                Table.Children.Add(label);
            }
        }
        private void UpdateScrollViewerHeight()
        {
            double headerHeight = (Table_container.RowDefinitions[0].ActualHeight);
            double availableHeight = 390 - headerHeight;

            Scrollviewer.MaxHeight = availableHeight;
        }

        

    }
}
