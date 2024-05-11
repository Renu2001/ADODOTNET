using System.Data.SqlClient;

namespace ADOEXAMPLE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contact contact = new Contact
            {
                FirstName = "Alice",
                LastName = "Smith",
                Address = "456 Elm St",
                City = "Sometown",
                State = "CA",
                ZipCode = 90210,
                Email = "alicesmith@example.com",
                PhoneNumber = 1876543211
            };
            using (SqlConnection connection = new SqlConnection("data source=(localdb)\\MSSQLLocalDB; database=AddressBook; integrated security=SSPI"))
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
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine("Inserted Rows = " + rowsAffected);
               

            }

        }
    }
}