namespace SWAD_Team4_assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customerList = new List<Customer>();
            InitCustomerList(customerList);
            ListCustomers(customerList);
        }

        static void InitCustomerList(List<Customer> customerList)
        {
            ShippingAddr addr1 = new ShippingAddr("Singapore", "Clementi Road");
            ShippingAddr addr2 = new ShippingAddr("Hong Kong", "Mong Kok Road");
            ShippingAddr addr3 = new ShippingAddr("Malaysia", "Malacca Road");

            Customer customer1 = new Customer("John Tan", "98501111", addr1);
            Customer customer2 = new Customer("Amy Lim", "99991111", addr2);
            Customer customer3 = new Customer("Tony Tay", "91112222", addr3);

            customerList.Add(customer1);
            customerList.Add(customer2);
            customerList.Add(customer3);
        }

        static void ListCustomers(List<Customer> customerList)
        {
            Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15}", "Name", "Tel", "Country", "Street");

            foreach (Customer customer in customerList)
            {
                Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15}",
                                  customer.Name, customer.Tel, customer.Addr.Country, customer.Addr.Street);
            }
        }
    }
}

