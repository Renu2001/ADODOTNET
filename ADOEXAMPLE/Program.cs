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

        static void Main(string[] args)
        {
            Program p = new Program();

            while (true)
            {
                Console.WriteLine("\nChoose the option ");
                Console.WriteLine("Type 1 to Add Contact ");
                
                Console.WriteLine("Type 0 to Exit ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        p.AddData();
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

