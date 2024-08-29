using Devoted.Controller;
using Devoted.Model;
using Devoted.ViewModel.Pages;
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

namespace Devoted.View.Pages
{
    /// <summary>
    /// Interaction logic for stock_page.xaml
    /// </summary>
    public partial class stock_page : UserControl
    {
        private Member member;
        private Plan plan;
        private ModelController controller;
        private List<int> row_no_touch = new List<int>();
        private string StockManager = "Easy Equities";
        public stock_page()
        {
            InitializeComponent();
            controller = new ModelController();

            help_setup_filter();
            show_stock(StockManager, controller.stocks());
            UpdateScrollViewerHeight();
            // update_row_selected(1);
        }

        private void help_setup_filter()
        {
            int[] month_day = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            for (int i = 0; i < 12; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = (i + 1).ToString();
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
                item.Content = (2024 - (i)).ToString();
                FilterYear.Items.Add(item);

            }

        }

        private void UpdateScrollViewerHeight()
        {
            double headerHeight = (Table_container.RowDefinitions[0].ActualHeight);
            double availableHeight = 430 - headerHeight;

            Scrollviewer.MaxHeight = availableHeight;
        }
        private void toggle_filter(object sender, RoutedEventArgs e)
        {
            if (FilterContainer.Visibility == Visibility.Collapsed)
            {
                FilterContainer.Visibility = Visibility.Visible;
            }
            else
            {
                FilterContainer.Visibility = Visibility.Collapsed;
            }
        }

        private void filter(object sender, RoutedEventArgs e)
        {
            /*
            List<stock> list = controller.stocks();
            List<stock> new_arr = new List<stock>();

            int min_amount = int.Parse(filter_min.Text);
            int max_amount = int.Parse(filter_max.Text);
            string details = filter_details.Text;
            string years = FilterYear.SelectedItem is ComboBoxItem yearItem ? yearItem.Content.ToString() : "All Years";
            string months = FilterMonth.SelectedItem is ComboBoxItem monthItem ? monthItem.Content.ToString() : "All Months";
            string days = FilterDay.SelectedItem is ComboBoxItem dayItem ? dayItem.Content.ToString() : "All Days";

            foreach (stock stock in list)
            {
                if ((stock.Amount <= max_amount && stock.Amount >= min_amount) || (min_amount == 0 && max_amount == 0))
                {
                    if (stock.getYear().ToString() == years || years == "All Years")
                    {
                        if (stock.getMonth().ToString() == months || months == "All Months")
                        {
                            if (stock.getDay().ToString() == days || days == "All Days")
                            {
                                if (stock.Details == details || details == "")
                                {
                                    new_arr.Add(stock);
                                }
                            }
                        }
                    }
                }
            }
            */
            // Table.Children.Clear();
            // Table.RowDefinitions.Clear();
            // show_stock(stockType, new_arr);
            // update_row_selected(0);
        }

        private void show_easy(object sender, RoutedEventArgs e)
        {

        }
        private void show_iq(object sender, RoutedEventArgs e)
        {

        }
        private void show_robin(object sender, RoutedEventArgs e)
        {

        }

        private void show_stock(string StockManager, List<Stock> list)
        {
            List<Stock> stocks = list;
            int count = 0;
            if (stocks.Count > 0)
            {
                string prev = stocks[0].Date.Year.ToString() + "-" + stocks[0].Date.Month.ToString();
                Stock prev_stock = stocks[0];
                string current = "";
                float total_month = 0;
                foreach (Stock stock in stocks)
                {
                    if (stock.ManagerID == 1)
                    {
                        current = stock.Date.Year.ToString() + "-" + stock.Date.Month.ToString();
                        count++;
                        // Console.WriteLine(current + "---" + prev);

                        if (current != prev)
                        {
                            show_total(count, stock, total_month);
                            total_month = 0;
                            row_no_touch.Add(count);
                            row_no_touch.Add(count + 1);
                            count += 2;
                        }

                        total_month += stock.CurrentValue;
                        show_row(count, stock);

                        prev = current;
                        prev_stock = stock;
                    }
                }
                show_total(count + 1, prev_stock, total_month);
                row_no_touch.Add(count + 1);
            }
        }
        private void show_row(int row, Stock stock)
        {
            Table.RowDefinitions.Add(new RowDefinition());
            Button action = new Button();
            action.Content = row.ToString();
            action.Cursor = Cursors.Hand;
            action.Background = Brushes.White;
            action.Margin = new Thickness(0);
            Grid.SetRow(action, row);

            Table.Children.Add(action);

            string[] array = { stock.getDate(), stock.getTime(), stock.Exchange, stock.Symbol, stock.BuyAt.ToString(), stock.CurrentValue.ToString() };

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
                Table.Children.Add(label);
            }
        }

        private void show_total(int row, Stock stock, float total_month)
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
            string[] array = { stock.getDate(), DateTime.Now.Hour.ToString() + ":00", "", "", "0", "", "1" };

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

            string[] array2 = { stock.getDate(), DateTime.Now.Hour.ToString() + ":00", month_day[stock.Date.Month - 1].ToString(), "", total_month.ToString(), "", "" };

            /*for (int i = 0; i < array.Length; i++)
            {*/
            System.Windows.Controls.Label labela = new System.Windows.Controls.Label();
            labela.Content = array2[4];
            Grid.SetColumn(labela, 4 + 1);
            Grid.SetRow(labela, row + 1);
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
    }
}
