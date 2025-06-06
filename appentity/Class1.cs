namespace appentity
{
    // Lớp User trừu tượng cho Customer và Admin
    public abstract class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public User(int userId, string username, string email, string passwordHash)
        {
            UserId = userId;
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
        }

        // Phương thức tìm kiếm sản phẩm (áp dụng cho cả Guest và Customer)
        public virtual List<Product> SearchProduct(string keyword)
        {
            // Logic tìm kiếm sản phẩm sẽ được triển khai ở lớp con hoặc controller
            return new List<Product>();
        }
    }

    // Lớp Customer kế thừa từ User
    public class Customer : User
    {
        public Cart Cart { get; set; }

        public Customer(int userId, string username, string email, string passwordHash)
            : base(userId, username, email, passwordHash)
        {
            Cart = new Cart(userId);
        }

        // Ghi đè phương thức tìm kiếm nếu cần logic đặc thù
        public override List<Product> SearchProduct(string keyword)
        {
            // Triển khai logic tìm kiếm cho Customer
            return new List<Product>();
        }

        public Order CreateOrder()
        {
            // Tạo đơn hàng từ giỏ hàng
            return new Order(this.UserId);
        }
    }

    // Lớp Admin kế thừa từ User
    public class Admin : User
    {
        public Admin(int userId, string username, string email, string passwordHash)
            : base(userId, username, email, passwordHash)
        {
        }

        // Phương thức quản lý sản phẩm
        public void AddProduct(Product product)
        {
            // Logic thêm sản phẩm
        }

        public void UpdateOrderStatus(Order order, string status)
        {
            // Logic cập nhật trạng thái đơn hàng
            order.Status = status;
        }
    }

    // Lớp Product
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public Product(int productId, string name, decimal price, string description)
        {
            this.ProductId = productId;
           this. Name = name;
            this.Price = price;
            this.Description = description;
        }
        public Product() { }
    }
}

    // Lớp Cart
    public class Cart
    {
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public List<CartItem> Items { get; set; }

        public Cart(int customerId)
        {
            CustomerId = customerId;
            Items = new List<CartItem>();
        }

        public void AddItem(Product product, int quantity)
        {
            Items.Add(new CartItem(product, quantity));
        }
    }

    // Lớp CartItem
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }

    // Lớp Order
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public List<OrderItem> Items { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Id { get; set; }

        public Order(int customerId)
        {
            CustomerId = customerId;
            Items = new List<OrderItem>();
            Status = "Pending";
            CreatedAt = DateTime.Now;
        }

        public Order()
        {
        }
    }

    // Lớp OrderItem
    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
