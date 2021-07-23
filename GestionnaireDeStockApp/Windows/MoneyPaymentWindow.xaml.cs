using DataTransfertObject;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GestionnaireDeStockApp
{
    /// <summary>
    /// Logique d'interaction pour CreditCardPaymentWindow.xaml
    /// </summary>
    public partial class MoneyPaymentWindow : Window
    {
        public bool CloseWithPayment { get; set; }
        public double MoneyAmount1 { get; set; }

        public MoneyPaymentWindow(Payment payment)
        {
            InitializeComponent();

            MoneyTxtBox.Text = Math.Round(payment.TotalToPay, 2).ToString();
            _ = MoneyTxtBox.Focus();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ValidateButton_Click(object sender, RoutedEventArgs e)
        {
            CloseWithPayment = true;
            SetAMoneyAmount();
            Close();
        }

        private void MoneyTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CloseWithPayment = true;
                SetAMoneyAmount();
                Close();
            }
        }

        private void MoneyTxtBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            SelectContentOnFocus(MoneyTxtBox);
        }

        private void MoneyTxtBox_GotMouseCapture(object sender, MouseEventArgs e)
        {
            SelectContentOnFocus(MoneyTxtBox);
        }

        private void SelectContentOnFocus(TextBox textBox)
        {
            if (textBox.Text != null)
            {
                textBox.SelectAll();
            }
        }

        private void SetAMoneyAmount()
        {
            try
            {
                _ = CheckInputService.CheckDoubleTypeInput(MoneyTxtBox);
                if (CheckInputService.CorrectPickedChara == false || MoneyTxtBox.Text == "")
                {
                    MoneyAmount1 = 0;
                }
                else
                {
                    SalesManagementPage.Payment.MoneyPayment = Convert.ToDouble(MoneyTxtBox.Text);
                    MoneyAmount1 = Convert.ToDouble(MoneyTxtBox.Text);
                }
            }
            catch (Exception exception)
            {
                _ = MessageBox.Show(exception.Message);
            }
        }

        private void MoneyTxtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
