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
    public partial class UserManagementForm : Form
    {
        private System.Windows.Forms.UserControl userControl;

        public UserManagementForm()
        {
            InitializeComponent();
            userControl = new System.Windows.Forms.UserControl();
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Manage Users";
            this.Size = new System.Drawing.Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            // DataGridView hiển thị danh sách người dùng
            DataGridView userGrid = new DataGridView
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(540, 200),
                ReadOnly = true
            };
            userGrid.Columns.Add("Id", "ID");
            userGrid.Columns.Add("Username", "Username");
            userGrid.Columns.Add("Role", "Role");
            LoadUsers(userGrid);
            this.Controls.Add(userGrid);

            // Nút chỉnh sửa người dùng
            Button editButton = new Button
            {
                Text = "Edit User",
                Location = new System.Drawing.Point(20, 230),
                Size = new System.Drawing.Size(100, 30)
            };
            editButton.Click += (s, e) =>
            {
                if (userGrid.SelectedRows.Count > 0)
                {
                    int userId = Convert.ToInt32(userGrid.SelectedRows[0].Cells["Id"].Value);
                    string newUsername = Prompt.ShowDialog("Enter new username:", "Edit User");
                    userControl.UpdateUser(userId, newUsername);
                    LoadUsers(userGrid);
                }
                else
                {
                    MessageBox.Show("Please select a user!");
                }
            };
            this.Controls.Add(editButton);
        }

        private void LoadUsers(DataGridView grid)
        {
            grid.Rows.Clear();
            var users = userControl.GetUsers();
            foreach (var user in users)
            {
                string role = user is Admin ? "Admin" : "Customer";
                grid.Rows.Add(user.Id, user.Username, role);
            }
        }
    }
}
