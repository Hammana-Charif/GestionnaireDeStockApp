using DataLayer;
using DataTransfertObject;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BusinessLogicLayer
{
    public class InvoiceManager
    {
        public ObservableCollection<PaymentMethod> PaymentMethods { get; set; } = new ObservableCollection<PaymentMethod>();
        public StockContext Invoices { get; set; } = new StockContext();
        public Invoice Ticket { get; set; } = new Invoice();

        public List<Invoice> LoadInvoiceDataBase()
        {
            InvoiceRepository invoiceList = new InvoiceRepository();
            return invoiceList.GetAll().ToList();
        }

        public Invoice SaveInvoiceToDataBase()
        {
            StockContext dbContext = Invoices;
            DbSet<Invoice> invoiceList = dbContext.Invoices;
            _ = invoiceList.Add(Ticket);
            _ = dbContext.SaveChanges();
            return Ticket;
        }

        public Invoice MakeAInvoice(ProductView productView,
                                    CashRegisterManager cashRegisterManager,
                                    ProductLineManager productLineManager,
                                    DiscountManager discountManager,
                                    double quantity,
                                    double pourcentDTxtBox,
                                    double discountTxtBox)
        {
            ClearAllInvoiceSetup(cashRegisterManager);

            double sum = cashRegisterManager.CalculateAPrice(productView, quantity);
            double pourcentDiscountValue = cashRegisterManager.CalculateAPourcentDiscount(pourcentDTxtBox, sum);
            double discountValue = cashRegisterManager.CalculateADiscount(discountTxtBox);
            double totalDiscountValue = cashRegisterManager.CalculateTotalPourcentDAndDiscount(pourcentDiscountValue, discountValue);
            double totalDiscountPriceValue = cashRegisterManager.CalculateADiscountPrice(sum, totalDiscountValue);

            Ticket.NameSeller = LoginManager.LoginSession.UserName;
            Ticket.Recipe += totalDiscountPriceValue;
            Ticket.TotalToPay += totalDiscountPriceValue;
            Ticket.CreationDate = DateTime.Now;

            Ticket.ProductLines.Add(new ProductLine
            {
                ProductLineJoinId = productLineManager.SetTheProductLineId(Ticket),
                Product = new Product
                {
                    Name = productView.Name,
                    Price = productView.Price,
                },
                Quantity = quantity,
                FinalTotalPrice = totalDiscountPriceValue,
                Discounts = new List<Discount>
                {
                    new Discount
                    {
                        DiscountJoinId = discountManager.SetTheDiscountId(Ticket),
                        Type = DiscountType.SubTotalDiscount,
                        Value = totalDiscountValue,
                        TotalDiscount = totalDiscountValue
                    }
                }
            });
            return Ticket;
        }

        public void MakeTheTicketPaymentsMethod()
        {
            foreach (PaymentMethod paymentMethod in PaymentMethods)
            {
                Ticket.PaymentMethods.Add(paymentMethod);
            }
        }

        public int CalculateTicketNumber()
        {
            List<Invoice> invoicesList = LoadInvoiceDataBase();
            Invoice lastTicket = invoicesList.Last();
            string refToSum = lastTicket.TicketRef.Substring(11);
            int newTicketRef = Convert.ToInt32(refToSum) + 1;
            Ticket.TicketRef = newTicketRef.ToString();
            return newTicketRef;
        }

        public void ClearAllInvoiceSetup(CashRegisterManager cashRegisterManager)
        {
            cashRegisterManager.InvoiceViewsList.Clear();
            cashRegisterManager.ProductLinesList.Clear();
            cashRegisterManager.TotalDiscountsList.Clear();
            cashRegisterManager.PaymentMethodsList.Clear();
        }
    }
}
