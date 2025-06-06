using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.data;
using appentity;

namespace app.control
{
    public class OrderControl
    {
        private OrderData orderData;

        public OrderControl()
        {
            orderData = new OrderData();
        }

        public List<Order> GetOrders()
        {
            return orderData.GetAllOrders();
        }

        public void UpdateOrderStatus(int orderId, string status)
        {
            orderData.UpdateOrderStatus(orderId, status);
        }
    }
}
