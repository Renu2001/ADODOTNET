using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOEXAMPLE
{
    internal class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        public void GetUserInfo()
        {
            Console.WriteLine("\nPlease enter your details :");
            Console.Write("FirstName :  ");
            this.FirstName = Console.ReadLine();
            Console.Write("LastName :  ");
            this.LastName = Console.ReadLine();
            Console.Write("Address :  ");
            this.Address = Console.ReadLine();
            Console.Write("City :  ");
            this.City = Console.ReadLine();
            Console.Write("State :  ");
            this.State = Console.ReadLine();
            try
            {
                Console.Write("ZipCode :  ");
                this.ZipCode = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Enter number");
            }
            Console.Write("Email :  ");
            this.Email = Console.ReadLine();
            try
            {
                Console.Write("PhoneNumber :  ");
                this.PhoneNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Enter number");
            }

        }


    }
}
