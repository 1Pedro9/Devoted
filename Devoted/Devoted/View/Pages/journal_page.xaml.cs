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
        private List<int> row_no_touch = new List<int>();
        private string JournalType = "CRJ";
        public journal_page()
        {
            InitializeComponent();
            controller = new ModelController();
            
            help_setup_filter();
            show_journal(JournalType, controller.journals());
            UpdateScrollViewerHeight();
            update_row_selected(1);
            
        }

        private void help_setup_filter()
        {
            int[] month_day = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            for(int i = 0; i < 12; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = (i+1).ToString();
                FilterMonth.Items.Add(item);
                
            }
            for (int j = 0; j < month_day[0]; j++)
            {
                ComboBoxItem month = new ComboBoxItem();
                month.Content = (j + 1).ToString();
                FilterDay.Items.Add(month);
            }
            for (int i = 0; i < 24; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = (2024-(i)).ToString();
                FilterYear.Items.Add(item);

            }

        }

        private void show_journal(String a, List<Journal> list)
        {
            List<Journal> journals = list;
            int count = 0;
            if(journals.Count > 0)
            {
                string prev = journals[0].Date.Year.ToString() + "-" + journals[0].Date.Month.ToString();
                Journal prev_journal = journals[0];
                string current = "";
                float total_month = 0;
                foreach (Journal journal in journals)
                {
                    if(journal.JournalType == a)
                    {
                        current = journal.Date.Year.ToString() + "-" + journal.Date.Month.ToString();
                        count++;
                        // Console.WriteLine(current + "---" + prev);

                        if(current != prev)
                        {
                            show_total(count, journal, total_month);
                            total_month = 0;
                            row_no_touch.Add(count);
                            row_no_touch.Add(count+1);
                            count += 2;
                        }
                    
                        total_month += journal.Amount;
                        show_row(count, journal);

                        prev = current;
                        prev_journal = journal;
                    }
                }
                show_total(count+1, prev_journal, total_month);
                row_no_touch.Add(count + 1);
            }
            
        }

        private void show_row(int row, Journal journal)
        {
            Table.RowDefinitions.Add(new RowDefinition());
            Button action = new Button();
            action.Content = row.ToString();
            action.Cursor = Cursors.Hand;
            action.Background = Brushes.White;
            action.Margin = new Thickness(0);
            Grid.SetRow(action, row);

            Table.Children.Add(action);

            string[] array = { journal.getYear(), journal.getMonth(), journal.getDay(), journal.Details.ToString(), journal.Amount.ToString(), journal.DiverseDetails.ToString() };

            for (int i = 0; i < array.Length; i++)
            {
                TextBox label = new TextBox();
                label.Text = array[i];
                Grid.SetColumn(label, i+1);
                Grid.SetRow(label, row);
                label.FontSize = 15;
                label.FontWeight = FontWeights.DemiBold;
                label.Padding = new Thickness(10, 5, 10, 5);
                label.Margin = new Thickness(0);
                label.GotFocus += row_clicked;
                Table.Children.Add(label);
            }
        }

        private void show_total(int row, Journal journal, float total_month)
        {
            Table.RowDefinitions.Add(new RowDefinition());
            Table.RowDefinitions.Add(new RowDefinition());
            Button action = new Button();
            action.Content = row.ToString();
            action.Cursor = Cursors.Hand;
            action.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ddd"));
            action.Margin = new Thickness(0);
            Grid.SetRow(action, row);

            Table.Children.Add(action);

            int[] month_day = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            string[] array = { journal.getYear(), journal.getMonth(), journal.getDay(), "", "0", "" };

            for (int i = 0; i < array.Length; i++)
            {
                TextBox label = new TextBox();
                label.Text = array[i];
                Grid.SetColumn(label, i + 1);
                Grid.SetRow(label, row);
                label.FontSize = 15;
                label.FontWeight = FontWeights.DemiBold;
                label.Padding = new Thickness(10, 5, 10, 5);
                label.Margin = new Thickness(0);
                label.GotFocus += row_clicked;
                label.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ddd"));
                Table.Children.Add(label);
            }

            string[] array2 = { journal.getYear(), journal.getMonth(), month_day[int.Parse(journal.getMonth()) - 1].ToString(), "", total_month.ToString(), "" };

            /*for (int i = 0; i < array.Length; i++)
            {*/
            System.Windows.Controls.Label labela = new System.Windows.Controls.Label();
            labela.Content = array2[4];
            Grid.SetColumn(labela, 4 + 1);
            Grid.SetRow(labela, row+1);
            labela.FontSize = 15;
            labela.FontWeight = FontWeights.DemiBold;
            labela.Padding = new Thickness(10, 5, 10, 5);
            labela.Margin = new Thickness(0, 0, 0, 30);
            labela.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));
            labela.Foreground = Brushes.White;
            labela.GotFocus += row_clicked;
            Table.Children.Add(labela);
            // }

        }


        private void UpdateScrollViewerHeight()
        {
            double headerHeight = (Table_container.RowDefinitions[0].ActualHeight);
            double availableHeight = 430 - headerHeight;

            Scrollviewer.MaxHeight = availableHeight;
        }

        private void update_row_selected(int row)
        {
            foreach (var child in Table.Children)
            {
                if (child is Control control)
                {
                    int a = Grid.GetRow(control);
                    bool is_valid = false;
                    foreach (int b in row_no_touch)
                    {

                        if (b == a)
                        {
                            is_valid = true;
                            break;
                        }
                    }
                    if (a > 0 && a != row && !is_valid)
                    {
                        if (a % 2 == 0)
                        {
                            control.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffeeee"));
                        }
                        else
                        {
                            control.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#eeeeff"));
                        }
                        continue;
                    }
                    else if (a == row && !is_valid)
                    {
                        control.Background = Brushes.GreenYellow;
                        continue;
                    }
                    
                    
                }
            }
        }
        private void row_clicked(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement clickedElement)
            {
                int row = Grid.GetRow(clickedElement);

                update_row_selected((int)row);
            }

        }

        private void toggle_filter(object sender, RoutedEventArgs e)
        {
            if(FilterContainer.Visibility == Visibility.Collapsed)
            {
                FilterContainer.Visibility = Visibility.Visible;
            }
            else
            {
                FilterContainer.Visibility = Visibility.Collapsed;
            }
        }

        private void CRJ_Show(object sender, RoutedEventArgs e)
        {
            CRJ_Button.BorderThickness = new Thickness(0, 0, 0, 1);
            CPJ_Button.BorderThickness = new Thickness(0, 0, 0, 0);
            GL_Button.BorderThickness = new Thickness(0, 0, 0, 0);
            Table.Children.Clear();
            Table.RowDefinitions.Clear();
            show_journal("CRJ", controller.journals());
            JournalType = "CRJ";
            update_row_selected(0);
        }

        private void CPJ_Show(object sender, RoutedEventArgs e)
        {
            CRJ_Button.BorderThickness = new Thickness(0, 0, 0, 0);
            CPJ_Button.BorderThickness = new Thickness(0, 0, 0, 1);
            GL_Button.BorderThickness = new Thickness(0, 0, 0, 0);
            Table.Children.Clear();
            Table.RowDefinitions.Clear();
            show_journal("CPJ", controller.journals());
            JournalType = "CPJ";
            update_row_selected(0);
        }

        private void GL_Show(object sender, RoutedEventArgs e)
        {
            CRJ_Button.BorderThickness = new Thickness(0, 0, 0, 0);
            CPJ_Button.BorderThickness = new Thickness(0, 0, 0, 0);
            GL_Button.BorderThickness = new Thickness(0, 0, 0, 1);
            Table.Children.Clear();
            Table.RowDefinitions.Clear();
            JournalType = "GL";
            // show_journal("GL");
        }

        private void filter(object sender, RoutedEventArgs e)
        {
            List<Journal> list = controller.journals();
            List<Journal> new_arr = new List<Journal>();

            int min_amount = int.Parse(filter_min.Text);
            int max_amount = int.Parse(filter_max.Text);
            string details = filter_details.Text;
            string years = FilterYear.SelectedItem is ComboBoxItem yearItem ? yearItem.Content.ToString() : "All Years";
            string months = FilterMonth.SelectedItem is ComboBoxItem monthItem ? monthItem.Content.ToString() : "All Months";
            string days = FilterDay.SelectedItem is ComboBoxItem dayItem ? dayItem.Content.ToString() : "All Days";

            foreach (Journal journal in list)
            {
                if ((journal.Amount <= max_amount && journal.Amount >= min_amount) || (min_amount == 0 && max_amount == 0))
                {
                    if (journal.getYear().ToString() == years || years == "All Years")
                    {
                        if (journal.getMonth().ToString() == months || months == "All Months")
                        {
                            if (journal.getDay().ToString() == days || days == "All Days")
                            {
                                if (journal.Details == details || details == "")
                                {
                                    new_arr.Add(journal);
                                }
                            }
                        }
                    }
                }
            }
            Table.Children.Clear();
            Table.RowDefinitions.Clear();
            show_journal(JournalType, new_arr);
            update_row_selected(0);
        }
    }
}
