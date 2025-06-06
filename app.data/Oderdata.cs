using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appentity;


namespace app.data
{
    public class OrderData
    {
        private List<Order> orders;

        public OrderData() => orders = new List<Order>
            {
                new() { Id = 1, CustomerId = 1, Status = "Pending" },
                new() { Id = 2, CustomerId = 2, Status = "Shipped" }
            };

        public List<Order> GetAllOrders()
        {
            return orders;
        }

        public void UpdateOrderStatus(int orderId, string status)
        {
            var order = orders.Find(o => o.Id == orderId);
            if (order != null)
            {
                order.Status = status;
            }
        }
    }
}
