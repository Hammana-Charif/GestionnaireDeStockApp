﻿using DataTransfertObject;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GestionnaireDeStockApp
{
    /// <summary>
    /// Logique d'interaction pour ChequePaymentWindow.xaml
    /// </summary>
    public partial class ChequePaymentWindow : Window
    {
        public bool CloseWithPayment { get; set; }

        public double ChequeAmount { get; set; }

        public ChequePaymentWindow(Payment payment)
        {
            InitializeComponent();

            ChqTxtBox.Text = Math.Round(payment.TotalToPay, 2).ToString();
            _ = ChqTxtBox.Focus();
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
            SetAChequeAmount();
            Close();
        }

        private void ChqTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CloseWithPayment = true;
                SetAChequeAmount();
                Close();
            }
        }

        private void ChqTxtBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            SelectContentOnFocus(ChqTxtBox);
        }

        private void ChqTxtBox_GotMouseCapture(object sender, MouseEventArgs e)
        {
            SelectContentOnFocus(ChqTxtBox);
        }

        private void SelectContentOnFocus(TextBox textBox)
        {
            if (textBox.Text != null)
            {
                textBox.SelectAll();
            }
        }

        private void SetAChequeAmount()
        {
            try
            {
                _ = CheckInputService.CheckDoubleTypeInput(ChqTxtBox);
                if (CheckInputService.CorrectPickedChara == false || ChqTxtBox.Text == "")
                {
                    ChequeAmount = 0;
                }
                else
                {
                    SalesManagementPage.Payment.ChequePayment = Convert.ToDouble(ChqTxtBox.Text);
                    ChequeAmount = Convert.ToDouble(ChqTxtBox.Text);
                }
            }
            catch (Exception exception)
            {
                _ = MessageBox.Show(exception.Message);
            }
        }

        private void ChqTxtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
