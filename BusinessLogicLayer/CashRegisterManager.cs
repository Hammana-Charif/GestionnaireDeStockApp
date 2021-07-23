using DataTransfertObject;
using DataTransfertObject.DataGridView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BusinessLogicLayer
{
    public class CashRegisterManager
    {
        public ObservableCollection<InvoiceView> InvoiceViewsList { get; set; } = new ObservableCollection<InvoiceView>();
        public ObservableCollection<ProductLine> ProductLinesList { get; set; } = new ObservableCollection<ProductLine>();
        public ObservableCollection<Discount> TotalDiscountsList { get; set; } = new ObservableCollection<Discount>();
        public ObservableCollection<PaymentMethod> PaymentMethodsList { get; set; } = new ObservableCollection<PaymentMethod>();


        public void MakeASalesCycle(ProductView productView,
                                    CashRegisterManager cashRegisterManager,
                                    InvoiceManager invoiceManager,
                                    ProductLineManager productLineManager,
                                    DiscountManager discountManager,
                                    double quantity,
                                    double pourcentDTxtBox,
                                    double discountTxtBox)
        {
            _ = invoiceManager.MakeAInvoice(productView, cashRegisterManager, productLineManager, discountManager, quantity, pourcentDTxtBox, discountTxtBox);
            _ = productLineManager.SetAProductLine(invoiceManager.Ticket, ProductLinesList);
            _ = discountManager.SetADiscount(invoiceManager.Ticket, TotalDiscountsList);
            JoinProductLineWithDiscount();
        }

        public void JoinProductLineWithDiscount()
        {
            InvoiceViewManager invoiceViewManager = new InvoiceViewManager();
            IEnumerable<InvoiceView> Join = from d in TotalDiscountsList
                                            join p in ProductLinesList
                                               on d.DiscountJoinId equals p.ProductLineJoinId
                                            select new InvoiceView
                                            {
                                                Name = p.Product.Name,
                                                Price = Math.Round(p.Product.Price, 2),
                                                Quantity = Math.Round(p.Quantity, 2),
                                                TotalDiscount = Math.Round(-d.TotalDiscount, 2),
                                                FinalTotalPrice = Math.Round(p.FinalTotalPrice, 2)
                                            };
            _ = invoiceViewManager.SetAProductLine(Join, InvoiceViewsList);
        }

        public double CalculateAPrice(ProductView productView, double quantity)
        {
            double sum = productView.Price * quantity;
            return sum;
        }

        public double CalculateAPourcentDiscount(double pourcentDTxtBox, double sum)
        {
            double pourcentDiscountValue = sum * (Convert.ToDouble(pourcentDTxtBox) / 100);
            return pourcentDiscountValue;
        }

        public double CalculateADiscount(double discountTxtBox)
        {
            double discount = Convert.ToDouble(discountTxtBox);
            return discount;
        }

        public double CalculateTotalPourcentDAndDiscount(double pourcentDiscount, double discount)
        {
            double totalDiscount = pourcentDiscount + discount;
            return totalDiscount;
        }

        public double CalculateADiscountPrice(double totalToPay, double globalDiscount)
        {
            double totalDiscountPrice = totalToPay - globalDiscount;
            return totalDiscountPrice;
        }

        public double CalculateTheTotalInvoiceDiscount(Invoice ticket)
        {
            double totalInvoiceDiscountSum = 0;

            foreach (ProductLine productLineToAttribute in ticket.ProductLines)
            {
                foreach (Discount discount in productLineToAttribute.Discounts)
                {
                    totalInvoiceDiscountSum += discount.TotalDiscount;
                }
            }
            return totalInvoiceDiscountSum;
        }

        public void DeleteProductToSell(InvoiceView invoiceView, Invoice ticket)
        {
            foreach (InvoiceView productLineToDelete in InvoiceViewsList)
            {
                if (productLineToDelete.InvoiceId == invoiceView.InvoiceId)
                {
                    ticket.Recipe -= productLineToDelete.FinalTotalPrice;
                    ticket.TotalToPay -= productLineToDelete.FinalTotalPrice;
                    RemoveInvoiceProductLine(invoiceView, ticket);
                    RemoveProductLineFromProductLinesList(invoiceView);
                    RemoveDiscountFromDiscountsList(invoiceView);
                    _ = InvoiceViewsList.Remove(productLineToDelete);
                    break;
                }
            }
        }

        private static void RemoveInvoiceProductLine(InvoiceView invoiceView, Invoice ticket)
        {
            foreach (ProductLine invoiceProductLine in ticket.ProductLines)
            {
                if (invoiceProductLine.ProductLineId == invoiceView.InvoiceId)
                {
                    _ = ticket.ProductLines.Remove(invoiceProductLine);
                    break;
                }
            }
        }

        private void RemoveProductLineFromProductLinesList(InvoiceView invoiceView)
        {
            foreach (ProductLine productLine in ProductLinesList)
            {
                if (productLine.ProductLineId == invoiceView.InvoiceId)
                {
                    _ = ProductLinesList.Remove(productLine);
                    break;
                }
            }
        }

        private void RemoveDiscountFromDiscountsList(InvoiceView invoiceView)
        {
            foreach (Discount discount in TotalDiscountsList)
            {
                if (discount.DiscountId == invoiceView.InvoiceId)
                {
                    _ = TotalDiscountsList.Remove(discount);
                    break;
                }
            }
        }
    }
}
