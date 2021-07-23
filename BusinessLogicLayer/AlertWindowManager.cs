using DataLayer;
using DataTransfertObject;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer
{
    public class AlertWindowManager
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductStock> _stockRepository;

        public AlertWindowManager()
        {
            _productRepository = new ProductRepository();
            _stockRepository = new StockRepository();
        }

        public IEnumerable<IEnumerable<ProductView>> AddProductsInRows()
        {
            return _stockRepository.GetAll()
                                   .Where(s => s.Quantity <= 10)
                                   .Select(s => _productRepository.GetAll()
                                   .Where(p => p.ProductId.Equals(s.ProductStockId))
                                   .Select(p => new ProductView
                                   {
                                       ProductId = p.ProductId,
                                       Reference = p.Reference,
                                       Name = p.Name,
                                       Price = p.Price,
                                       Quantity = s.Quantity
                                   }));
        }
    }
}
