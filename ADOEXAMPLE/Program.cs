using System.Data.SqlClient;

namespace ADOEXAMPLE
{
    internal class Program
    {
        int rowsAffected;
        string connectionString = "data source=(localdb)\\MSSQLLocalDB; database=AddressBook; integrated security=SSPI";
        Contact contact = new Contact();
        public SqlConnection GetConnect()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        public void AddData()
        {
            SqlConnection connection = null;
            contact.GetUserInfo();
            using (connection = GetConnect())
            {
                SqlCommand cmd = new SqlCommand("insert into Contact VALUES (@FirstName, @LastName, @Address, @City, @State, @ZipCode, @Email, @PhoneNumber)", connection);
                cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
                cmd.Parameters.AddWithValue("@LastName", contact.LastName);
                cmd.Parameters.AddWithValue("@Address", contact.Address);
                cmd.Parameters.AddWithValue("@City", contact.City);
                cmd.Parameters.AddWithValue("@State", contact.State);
                cmd.Parameters.AddWithValue("@ZipCode", contact.ZipCode);
                cmd.Parameters.AddWithValue("@Email", contact.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);
                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine("Inserted Rows = " + rowsAffected);

            }
        }
        public void UpdateData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("update Contact set ZipCode = @ZipCode where FirstName = @FirstName", connection);
                Console.WriteLine("Enter the Name to be chnaged");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the Zipcode");
                int code = Convert.ToInt32(Console.ReadLine());
                cmd.Parameters.AddWithValue("@FirstName", name);
                cmd.Parameters.AddWithValue("@ZipCode", code);
                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine("Updated Rows = " + rowsAffected);

            }

        }

        public void DeleteData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Delete from Contact where FirstName = @FirstName", connection);
                Console.WriteLine("Enter the Name of contact to be Deleted");
                string name = Console.ReadLine();
                cmd.Parameters.AddWithValue("@FirstName", name);
                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine("Deleted = " + rowsAffected);

            }

        }

        static void Main(string[] args)
        {
            Program p = new Program();

            while (true)
            {
                Console.WriteLine("\nChoose the option ");
                Console.WriteLine("Type 1 to Add Contact ");
                Console.WriteLine("Type 2 to Update Contact ");
                Console.WriteLine("Type 3 to Delete Contact ");



                Console.WriteLine("Type 0 to Exit ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        p.AddData();
                        break;
                    case 2:
                        p.UpdateData();
                        break;
                    case 3:
                        p.DeleteData();
                        break;

                    default:
                        break;
                }
                if (option == 0)
                    break;

            }




        }
    }
}

