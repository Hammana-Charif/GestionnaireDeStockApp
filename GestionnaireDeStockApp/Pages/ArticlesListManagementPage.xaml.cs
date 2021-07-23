using BusinessLogicLayer;
using DataTransfertObject;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GestionnaireDeStockApp
{
    /// <summary>
    /// Logique d'interaction pour ArticlesListPage.xaml
    /// </summary>
    public partial class ArticlesListManagementPage : Page
    {
        public ArticlesListManagementPage()
        {
            InitializeComponent();
            _ = SearchTextBox.Focus();
            ProductsDataGrid.ItemsSource = ProductViewManager.JoinProductAndProductStockTables();
        }

        private void AddANewArticleButton_Click(object sender, RoutedEventArgs e)
        {
            AddAnArticleWindow addAnArticleWindow = new AddAnArticleWindow();
            _ = addAnArticleWindow.ShowDialog();
            ReloadDataGrid();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            ReloadDataGrid();
        }

        private void EditAnArticleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProductViewManager productViewManager = new ProductViewManager();
                _ = productViewManager.SelectAProductByRow((ProductView)ProductsDataGrid.CurrentCell.Item);
                EditAnArticleWindow editAnArticleWindow = new EditAnArticleWindow();
                _ = editAnArticleWindow.ShowDialog();
                ReloadDataGrid();
            }
            catch (Exception exception)
            {
                _ = MessageBox.Show(exception.Message);
            }
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = string.Empty;
            SearchTextBox.Foreground = new SolidColorBrush(Colors.White);
            SearchTextBox.GotFocus += SearchTextBox_GotFocus;
            if (SearchTextBox.Text == string.Empty)
            {
                ReloadDataGrid();
            }
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchAnArticle();
            }
        }

        private void SearchMinPriceTxtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchMinPriceTxtBox.Text = string.Empty;
            SearchMinPriceTxtBox.Foreground = new SolidColorBrush(Colors.White);
            SearchMinPriceTxtBox.GotFocus += SearchMinPriceTxtBox_GotFocus;
            if (SearchMinPriceTxtBox.Text == string.Empty)
            {
                ReloadDataGrid();
            }
        }

        private void SearchMaxPriceTxtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchMaxPriceTxtBox.Text = string.Empty;
            SearchMaxPriceTxtBox.Foreground = new SolidColorBrush(Colors.White);
            SearchMaxPriceTxtBox.GotFocus += SearchMaxPriceTxtBox_GotFocus;
            if (SearchMaxPriceTxtBox.Text == string.Empty)
            {
                ReloadDataGrid();
            }
        }

        private void PriceSearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchByPriceInterval();
        }

        private void SearchMinPriceTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchByPriceInterval();
            }
        }

        private void SearchMaxPriceTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchByPriceInterval();
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchAnArticle();
        }

        public void ReloadDataGrid()
        {
            ProductsDataGrid.ItemsSource = ProductViewManager.JoinProductAndProductStockTables();
        }

        private void SearchAnArticle()
        {
            try
            {
                bool input = CheckInputService.CheckStringTypeInput(SearchTextBox);
                if (input)
                {
                    ProductsDataGrid.ItemsSource = ProductManager.GetProductByGlobalResearch(SearchTextBox.Text);
                }
            }
            catch (Exception exception)
            {
                _ = MessageBox.Show(exception.Message);
            }
        }

        private void SearchByPriceInterval()
        {
            try
            {
                bool priceChecked = CheckInputService.CheckDoubleIntervalNumber(SearchMinPriceTxtBox, SearchMaxPriceTxtBox);
                if (priceChecked)
                {
                    ProductsDataGrid.ItemsSource = ProductManager.GetProductByPriceInterval(SearchMinPriceTxtBox.Text, SearchMaxPriceTxtBox.Text);
                }
            }
            catch (Exception exception)
            {
                _ = MessageBox.Show(exception.Message);
            }
        }

        private void DeleteAnArticleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Etes-vous sûr de vouloir supprimer cet article?", "DataGridView", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ProductViewManager productViewManager = new ProductViewManager();
                    ProductManager.RemoveAProductToDataBase(productViewManager.SelectAProductByRow(ProductsDataGrid.CurrentCell.Item));
                }
                ReloadDataGrid();
            }
            catch (Exception exception)
            {
                _ = MessageBox.Show(exception.Message);
            }
        }
    }
}
