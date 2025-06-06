using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using app.control;
using appentity;

namespace app.Boundary
{
    public partial class OrderManagementForm : Form
    {
        private OrderControl orderControl;

        public OrderManagementForm()
        {
            InitializeComponent();
            orderControl = new OrderControl();
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Manage Orders";
            this.Size = new System.Drawing.Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            // DataGridView hiển thị danh sách đơn hàng
            DataGridView orderGrid = new DataGridView
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(540, 200),
                ReadOnly = true
            };
            orderGrid.Columns.Add("Id", "ID");
            orderGrid.Columns.Add("CustomerId", "Customer ID");
            orderGrid.Columns.Add("Status", "Status");
            LoadOrders(orderGrid);
            this.Controls.Add(orderGrid);

            // Nút cập nhật trạng thái
            Button updateButton = new Button
            {
                Text = "Update Status",
                Location = new System.Drawing.Point(20, 230),
                Size = new System.Drawing.Size(120, 30)
            };
            updateButton.Click += (s, e) =>
            {
                if (orderGrid.SelectedRows.Count > 0)
                {
                    int orderId = Convert.ToInt32(orderGrid.SelectedRows[0].Cells["Id"].Value);
                    string newStatus = Prompt.ShowDialog("Enter new status:", "Update Order Status");
                    orderControl.UpdateOrderStatus(orderId, newStatus);
                    LoadOrders(orderGrid);
                }
                else
                {
                    MessageBox.Show("Please select an order!");
                }
            };
            this.Controls.Add(updateButton);
        }

        private void LoadOrders(DataGridView grid)
        {
            grid.Rows.Clear();
            var orders = orderControl.GetOrders();
            foreach (var order in orders)
            {
                grid.Rows.Add(order.Id, order.CustomerId, order.Status);
            }
        }
    }
}