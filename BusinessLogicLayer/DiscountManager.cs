using DataTransfertObject;
using System.Collections.ObjectModel;
using System.Linq;

namespace BusinessLogicLayer
{
    public class DiscountManager
    {
        public int SetTheDiscountId(Invoice ticket)
        {
            int value = 0;
            foreach (ProductLine producLine in ticket.ProductLines)
            {
                value = producLine.Discounts.Count == 0 ? 0 : producLine.Discounts.Last().DiscountJoinId + 1;
            }
            return value;
        }

        public Discount SetADiscount(Invoice ticket, ObservableCollection<Discount> totalDiscountsList)
        {
            Discount discount = null;
            foreach (ProductLine producLine in ticket.ProductLines)
            {
                foreach (Discount discountToAdd in producLine.Discounts)
                {
                    discount = discountToAdd;
                    totalDiscountsList.Add(discount);
                }
            }
            return discount;
        }
    }
}
