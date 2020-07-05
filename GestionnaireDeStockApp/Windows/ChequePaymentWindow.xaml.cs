﻿using BusinessLogicLayer;
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
        public ChequePaymentWindow(InvoiceManager invoiceManager)
        {
            InitializeComponent();

            ChqTxtBox.Text = Math.Round(invoiceManager.Ticket.TotalToPay, 2).ToString();
            ChqTxtBox.Focus();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ValidateButton_Click(object sender, RoutedEventArgs e)
        {
            SetAChequeAmount();
            Close();
        }

        private void ChqTxtBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void ChqTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
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
                textBox.SelectAll();
        }

        private double SetAChequeAmount()
        {
            try
            {
                CheckInputService.CheckDoubleTypeInput(ChqTxtBox);
                if (CheckInputService.CorrectPickedChara == false || ChqTxtBox.Text == "")
                    return 0;
                else
                {
                    return SalesManagementPage.Payment.ChequePayment = Convert.ToDouble(ChqTxtBox.Text);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return 0;
            }
        }
    }
}
