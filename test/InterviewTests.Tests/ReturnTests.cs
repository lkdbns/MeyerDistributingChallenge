using System.Reflection;
using InterviewTest.Customers;
using InterviewTest.Orders;
using InterviewTest.Products;
using InterviewTest.Returns;

namespace InterviewTests.Tests
{
    public class ReturnTests
    {
        [Fact]
        public void BasicReturnTest()
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

            //Create return
            string returnNumber = "456";
            IReturn rga = new Return(returnNumber, order);
            rga.AddProduct(order.Products.First());

            // Assert
            Assert.Equal(returnNumber, rga.ReturnNumber);
            Assert.Equal(order.OrderNumber, rga.OriginalOrder.OrderNumber);
            Assert.Equal(1, rga.ReturnedProducts.Count);
            Assert.Equal(product.GetProductNumber(), rga.ReturnedProducts.First().OrderProduct.Product.GetProductNumber());
        }

        [Fact]
        public void ReturnMultipleProducts() {
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

            //Create return
            string returnNumber = "456";
            IReturn rga = new Return(returnNumber, order);
            rga.AddProduct(order.Products[0]);
            rga.AddProduct(order.Products[1]);
            rga.AddProduct(order.Products[2]);
            customer.CreateReturn(rga);

            // Assert
            Assert.Equal(3, rga.ReturnedProducts.Count);
            Assert.Equal(product1.GetSellingPrice() + 
                         product2.GetSellingPrice() + 
                         product3.GetSellingPrice(), customer.GetTotalReturns());
        }

        [Fact]
        public void EmptyReturn() {
            OrderRepository orderRepo = new OrderRepository();
            ReturnRepository returnRepo = new ReturnRepository();

            // Create customer
            ICustomer customer = new TruckAccessoriesCustomer(orderRepo, returnRepo);

            // Create order
            string orderNumber = "123";
            IOrder order = new Order(orderNumber, customer);
            
            //Create return
            string returnNumber = "456";
            IReturn rga = new Return(returnNumber, order);

            // Assert
            Assert.Equal(0, rga.ReturnedProducts.Count);
            Assert.Equal(0, customer.GetTotalReturns());
        }
    }
}