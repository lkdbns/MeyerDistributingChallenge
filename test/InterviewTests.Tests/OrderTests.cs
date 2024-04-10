using System.Reflection;
using InterviewTest.Customers;
using InterviewTest.Orders;
using InterviewTest.Products;
using InterviewTest.Returns;

namespace InterviewTests.Tests
{
    public class OrderTests
    {
        [Fact]
        public void BasicOrderTest()
        {
            // Create repositories
            OrderRepository orderRepo = new OrderRepository();
            ReturnRepository returnRepo = new ReturnRepository();

            // Create customer
            ICustomer customer = new TruckAccessoriesCustomer(orderRepo, returnRepo);

            // Create order
            string orderNumber = "123";
            IOrder order = new Order(orderNumber, customer);

            // Create and add product
            IProduct product = new ReplacementBumper();
            order.AddProduct(product);

            // Assert
            Assert.Equal(orderNumber, order.OrderNumber);
            Assert.Equal(customer.GetName(), order.Customer.GetName());
            Assert.True(DateTime.UtcNow > order.OrderDate);
            Assert.Equal(1, order.Products.Count);
            Assert.Equal(product.GetProductNumber(), order.Products.First().Product.GetProductNumber());
        }

        [Fact]
        public void OrderMultipleProducts() {
            OrderRepository orderRepo = new OrderRepository();
            ReturnRepository returnRepo = new ReturnRepository();

            // Create customer
            ICustomer customer = new TruckAccessoriesCustomer(orderRepo, returnRepo);

            // Create order
            string orderNumber = "123";
            IOrder order = new Order(orderNumber, customer);

            // Create and add products
            IProduct product1 = new ReplacementBumper();
            order.AddProduct(product1);
            IProduct product2 = new ReplacementBumper();
            order.AddProduct(product2);
            IProduct product3 = new HitchAdapter();
            order.AddProduct(product3);
            customer.CreateOrder(order);

            // Assert
            Assert.Equal(3, order.Products.Count);
            Assert.Equal(product1.GetSellingPrice() + 
                         product2.GetSellingPrice() + 
                         product3.GetSellingPrice(), customer.GetTotalSales());
        }

        [Fact]
        public void EmptyOrder() {
            OrderRepository orderRepo = new OrderRepository();
            ReturnRepository returnRepo = new ReturnRepository();

            // Create customer
            ICustomer customer = new TruckAccessoriesCustomer(orderRepo, returnRepo);

            // Create order
            string orderNumber = "123";
            IOrder order = new Order(orderNumber, customer);

            // Assert
            Assert.Equal(0, order.Products.Count);
            Assert.Equal(0, customer.GetTotalSales());
        }
    }
}