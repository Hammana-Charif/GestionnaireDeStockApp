using DataLayer;
using DataTransfertObject;
using DataTransfertObject.DataGridView;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer
{
    public static class ProductManager
    {
        public static InvoiceView SelectedProductLine { get; private set; }

        public static Product AddANewProductByRefChecking(string newProductRef,
                                                          string newProductName,
                                                          string newProductExclTaxPrice,
                                                          string newProductPrice,
                                                          string newProductQuantity)
        {
            Product newProduct = null;
            StockContext dbContext = new StockContext();
            newProduct = dbContext.Products.Where(c => c.Reference == newProductRef).FirstOrDefault();
            if (newProduct == null)
            {
                Product product = new Product
                {
                    Reference = newProductRef,
                    Name = newProductName,
                    ExclTaxPrice = Convert.ToDouble(newProductExclTaxPrice),
                    Price = Convert.ToDouble(newProductPrice),
                    ProductStocks = new List<ProductStock>
                    {
                        new ProductStock
                        {
                            Quantity = Convert.ToDouble(newProductQuantity)
                        }
                    }
                };
                _ = dbContext.Products.Add(product);
                _ = dbContext.SaveChanges();
                newProduct = product;
            }
            return newProduct;
        }

        public static List<ProductView> GetProductByPriceInterval(string textBoxMin, string textBoxMax)
        {
            List<ProductView> productViewsList = new List<ProductView>();
            List<ProductView> productsList = ProductViewManager.JoinProductAndProductStockTables();

            foreach (ProductView product in productsList)
            {
                if (product.Price >= Convert.ToDouble(textBoxMin) && product.Price <= Convert.ToDouble(textBoxMax))
                {
                    productViewsList.Add(new ProductView
                    {
                        Reference = product.Reference,
                        Name = product.Name,
                        ExclTaxPrice = product.ExclTaxPrice,
                        Price = product.Price,
                        Quantity = product.Quantity
                    });
                }
            }
            return productViewsList;
        }

        public static List<ProductView> GetProductByGlobalResearch(string input)
        {
            List<ProductView> productViewsList = new List<ProductView>();
            List<ProductView> productsList = ProductViewManager.JoinProductAndProductStockTables();

            foreach (ProductView product in productsList)
            {
                if (product.Reference.ToLowerInvariant().Contains(input.ToLowerInvariant())
                    || product.Name.ToLowerInvariant().Contains(input.ToLowerInvariant())
                    || product.Price.ToString().ToLowerInvariant().Contains(input.ToLowerInvariant())
                    || product.Quantity.ToString().ToLowerInvariant().Contains(input.ToLowerInvariant()))
                {
                    productViewsList.Add(new ProductView
                    {
                        Reference = product.Reference,
                        Name = product.Name,
                        ExclTaxPrice = product.ExclTaxPrice,
                        Price = product.Price,
                        Quantity = product.Quantity
                    });
                }
            }
            return productViewsList;
        }

        public static InvoiceView SelectAselectedProductLine(object selectedRow)
        {
            return SelectedProductLine = (InvoiceView)selectedRow;
        }

        public static void RemoveAProductToDataBase(ProductView selectedItem)
        {
            Product productToDelete = null;
            ProductStock productStockToDelete = null;

            StockContext dbContext = new StockContext();
            productToDelete = dbContext.Products.Where(c => c.ProductId == selectedItem.ProductId).FirstOrDefault();
            productStockToDelete = dbContext.ProductStocks.Where(c => c.ProductStockId == selectedItem.ProductId).FirstOrDefault();
            if (productToDelete != null && productStockToDelete != null)
            {
                _ = dbContext.Remove(productToDelete);
                _ = dbContext.Remove(productStockToDelete);
                _ = dbContext.SaveChanges();
            }
        }

        public static void UpdateAProduct(ProductView selectedItem)
        {
            Product productToEdit = null;
            ProductStock productStockToEdit = null;

            StockContext dbContext = new StockContext();
            productToEdit = dbContext.Products.Where(c => c.Reference == selectedItem.Reference).FirstOrDefault();
            productStockToEdit = dbContext.ProductStocks.Where(c => c.ProductStockId == selectedItem.ProductId).FirstOrDefault();

            if (productToEdit != null && productStockToEdit != null)
            {
                productToEdit.Reference = selectedItem.Reference;
                productToEdit.Name = selectedItem.Name;
                productToEdit.ExclTaxPrice = selectedItem.ExclTaxPrice;
                productToEdit.Price = selectedItem.Price;
                productStockToEdit.Quantity = selectedItem.Quantity;
                _ = dbContext.Update(productStockToEdit);
                _ = dbContext.Update(productToEdit);
                _ = dbContext.SaveChanges();
            }
        }
    }
}
