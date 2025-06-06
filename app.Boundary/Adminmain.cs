using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app.Boundary
{
    public partial class Adminmain : Form
    {

        private void Adminmain_Load(object sender, EventArgs e)
        {
            // Để trống hoặc thêm logic nếu cần
        }
        public AdminMainForm()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Admin Dashboard";
            this.Size = new System.Drawing.Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // MenuStrip cho điều hướng
            MenuStrip menuStrip = new MenuStrip();
            ToolStripMenuItem manageMenu = new ToolStripMenuItem("Manage");

            // Menu con: Quản lý sản phẩm
            ToolStripMenuItem manageProducts = new ToolStripMenuItem("Products");
            manageProducts.Click += (s, e) =>
            {
                ProductManagementfrm productForm = new ProductManagementfrm();
                productForm.ShowDialog();
            };
            manageMenu.DropDownItems.Add(manageProducts);

            // Menu con: Quản lý đơn hàng
            ToolStripMenuItem manageOrders = new ToolStripMenuItem("Orders");
            manageOrders.Click += (s, e) =>
            {
                OrderManagementForm orderForm = new OrderManagementForm();
                orderForm.ShowDialog();
            };
            manageMenu.DropDownItems.Add(manageOrders);

            // Menu con: Quản lý người dùng
            ToolStripMenuItem manageUsers = new ToolStripMenuItem("Users");
            manageUsers.Click += (s, e) =>
            {
                UserManagementForm userForm = new UserManagementForm();
                userForm.ShowDialog();
            };
            manageMenu.DropDownItems.Add(manageUsers);

            menuStrip.Items.Add(manageMenu);
            this.Controls.Add(menuStrip);

            // Label chào mừng
            Label welcomeLabel = new Label
            {
                Text = "Welcome, Admin!",
                Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(20, 50),
                Size = new System.Drawing.Size(300, 30)
            };
            this.Controls.Add(welcomeLabel);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // AdminMainForm
            // 
            ClientSize = new Size(282, 253);
            Name = "AdminMainForm";
            Load += Adminmain_Load;
            ResumeLayout(false);

        }
       

        
    }
    

    }

