using DataLayer;
using DataTransfertObject;
using System.Linq;

namespace BusinessLogicLayer
{
    public class ProductStockManager
    {
        public void EditProductQuantity(InvoiceManager invoiceManager)
        {
            Invoice ticket = invoiceManager.Ticket;
            foreach (ProductLine productLine in ticket.ProductLines)
            {
                StockContext dbContext = new StockContext();
                Product productToCheck = dbContext.Products.Where(p => p.Name == productLine.Product.Name).FirstOrDefault();

                if (productToCheck != null)
                {
                    ProductStock newProductQuantity = dbContext.ProductStocks.Where(p => p.ProductStockId == productToCheck.ProductId).FirstOrDefault();
                    newProductQuantity.Quantity -= productLine.Quantity;
                    _ = dbContext.SaveChanges();
                }
            }
        }
    }
}