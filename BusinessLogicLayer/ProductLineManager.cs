using DataTransfertObject;
using System.Collections.ObjectModel;
using System.Linq;

namespace BusinessLogicLayer
{
    public class ProductLineManager
    {
        public int SetTheProductLineId(Invoice ticket)
        {
            int value = ticket.ProductLines.Count == 0 ? 0 : ticket.ProductLines.Last().ProductLineJoinId + 1;
            return value;
        }

        public ProductLine SetAProductLine(Invoice ticket, ObservableCollection<ProductLine> productLinesList)
        {
            ProductLine productLine = null;
            foreach (ProductLine productLineToSearch in ticket.ProductLines)
            {
                productLine = productLineToSearch;
                productLinesList.Add(productLine);
            }
            return productLine;
        }
    }
}
