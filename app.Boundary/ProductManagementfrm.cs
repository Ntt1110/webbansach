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
    public partial class ProductManagementfrm : Form
    {
        private ProductControl productControl;

        public ProductManagementfrm()
        {
            InitializeComponent();
            productControl = new ProductControl();
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Manage Products";
            this.Size = new System.Drawing.Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            // DataGridView hiển thị danh sách sản phẩm
            DataGridView productGrid = new DataGridView
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(540, 200),
                ReadOnly = true
            };
            productGrid.Columns.Add("Id", "ID");
            productGrid.Columns.Add("Name", "Name");
            productGrid.Columns.Add("Price", "Price");
            LoadProducts(productGrid);
            this.Controls.Add(productGrid);

            // Nút thêm sản phẩm
            Button addButton = new Button
            {
                Text = "Add Product",
                Location = new System.Drawing.Point(20, 230),
                Size = new System.Drawing.Size(100, 30)
            };
            addButton.Click += (s, e) =>
            {
                string name = Prompt.ShowDialog("Enter product name:", "Add Product");
                string priceText = Prompt.ShowDialog("Enter product price:", "Add Product");
                string  idtext = Prompt.ShowDialog("Enter product id", "Add Product");
                if (decimal.TryParse(priceText, out decimal price ) && int.TryParse(idtext, out int id))
                {
                    productControl.AddProduct(new Product(id, name, price, ""));
                    LoadProducts(productGrid);
                }
                else
                {
                    MessageBox.Show("Invalid price format!");
                }
            };
            this.Controls.Add(addButton);
        }

        private void LoadProducts(DataGridView grid)
        {
            grid.Rows.Clear();
            var products = productControl.GetProducts();
            foreach (var product in products)
            {
                grid.Rows.Add(product.ProductId, product.Name, product.Price);
            }
        }
    }

    // Helper class để hiển thị dialog nhập liệu
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 240 };
            Button confirmation = new Button() { Text = "OK", Left = 160, Width = 100, Top = 80, DialogResult = DialogResult.OK };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
