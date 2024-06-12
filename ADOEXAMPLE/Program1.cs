//using System;
//using System.Data;
//using System.Data.SqlClient;

//namespace ADOEXAMPLE
//{
//    internal class Program1
//    {
//        static string? connectionString = "data source=(localdb)\\MSSQLLocalDB; database=AddressBook; user id=sa; password=Renuka@123; integrated security=SSPI ;";
//        static SqlDataAdapter? adapter;
//        static DataSet dataSet;

//        public void UpdateDatabase()
//        {
//            SqlCommandBuilder? builder = new SqlCommandBuilder(adapter);
//            adapter.Update(dataSet, "Contact");
//            Console.WriteLine("Database Updated Successfully.");
//            Console.WriteLine(builder.GetDeleteCommand().CommandText);
//        }

//        public void AddUser()
//        {
//            DataTable? dt = dataSet.Tables["Contact"];
//            DataRow? newRow = dt.NewRow();
//            Contact? c = new Contact();
//            c.GetUserInfo();
//            newRow["FirstName"] = c.FirstName;
//            newRow["LastName"] = c.LastName;
//            newRow["Address"] = c.Address;
//            newRow["City"] = c.City;
//            newRow["State"] = c.State;
//            newRow["ZipCode"] = c.ZipCode;
//            newRow["Email"] = c.Email;
//            newRow["PhoneNumber"] = c.PhoneNumber;
//            dt.Rows.Add(newRow);
//            UpdateDatabase();

//        }

//        public void DisplayData()
//        {
//            Console.WriteLine("\nContact List:");
//            DataTable? dataTable = dataSet.Tables["Contact"];
//            foreach (DataRow row in dataTable.Rows)
//            {
//                Console.WriteLine(" FirstName :{0} \n LastName : {1}\n Address: {2}\n City: {3}\n State : {4}\n ZipCode : {5}\n Email : {6}\n PhoneNumber : {7}\n", row["FirstName"], row["LastName"], row["Address"], row["City"], row["State"], row["ZipCode"], row["Email"], row["PhoneNumber"]);
//            }
//        }

//        //IF your table doesnt have primary key

//        public void DeleteData()
//        {
//            //Console.WriteLine("Enter the FirstName to delete:");
//            //string nameToDelete = Console.ReadLine();

//            //using (SqlConnection connection = new SqlConnection(connectionString))
//            //{
//            //    string deleteQuery = "DELETE FROM Contact WHERE FirstName = @FirstName";
//            //    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
//            //    deleteCommand.Parameters.AddWithValue("@FirstName", nameToDelete);

//            //    SqlDataAdapter adapter = new SqlDataAdapter();
//            //    adapter.DeleteCommand = deleteCommand;

//            //    DataTable dataTable = dataSet.Tables["Contact"];
//            //    DataRow[] rowsToDelete = dataTable.Select($"FirstName = '{nameToDelete}'");

//            //    if (rowsToDelete.Length > 0)
//            //    {
//            //        foreach (DataRow row in rowsToDelete)
//            //        {
//            //            row.Delete();
//            //        }

//            //        adapter.Update(dataSet, "Contact"); // Apply changes to the database
//            //        Console.WriteLine($"Deleted {rowsToDelete.Length} contact(s) with FirstName '{nameToDelete}'.");
//            //    }
//            //    else
//            //    {
//            //        Console.WriteLine("Contact not found.");
//            //    }
//            //}

//            //With primary key

//            Console.WriteLine("Enter the FirstName to delete:");
//            string? nameToDelete = Console.ReadLine();

//            DataTable? dataTable = dataSet.Tables["Contact"];
//            DataRow[]? rowsToDelete = dataTable.Select($"FirstName = '{nameToDelete}'");

//            if (rowsToDelete.Length > 0)
//            {
//                foreach (DataRow row in rowsToDelete)
//                {
//                    row.Delete();
//                }
//                UpdateDatabase();
//                Console.WriteLine($"Deleted {rowsToDelete.Length} contact(s) with FirstName '{nameToDelete}'.");
//            }
//            else
//            {
//                Console.WriteLine("Contact not found.");
//            }
//        }

//        public void UpdateData()
//        {
//            //Console.WriteLine("Enter the FirstName to update:");
//            //string name = Console.ReadLine();

//            //DataTable dataTable = dataSet.Tables["Contact"];
//            //DataRow[] rows = dataTable.Select($"FirstName = '{name}'");

//            //if (rows.Length == 1)
//            //{
//            //    DataRow row = rows[0];
//            //    Console.WriteLine("Enter the new ZipCode:");
//            //    int newZipCode = Convert.ToInt32(Console.ReadLine());
//            //    row["ZipCode"] = newZipCode;
//            //        using (SqlConnection connection = new SqlConnection(connectionString))
//            //        {
//            //            string updateQuery = "UPDATE Contact SET ZipCode = @ZipCode WHERE FirstName = @FirstName";
//            //            SqlDataAdapter adapter = new SqlDataAdapter();
//            //            adapter.UpdateCommand = new SqlCommand(updateQuery, connection);
//            //            adapter.UpdateCommand.Parameters.AddWithValue("@ZipCode", newZipCode);
//            //            adapter.UpdateCommand.Parameters.AddWithValue("@FirstName", name);

//            //            connection.Open();
//            //            adapter.UpdateCommand.ExecuteNonQuery();
//            //            connection.Close();

//            //            Console.WriteLine("Contact updated successfully.");
//            //        }

//            //}
//            //else
//            //{
//            //    Console.WriteLine("Contact not found.");
//            //}

//            //With Primary Key
//            Console.WriteLine("Enter the FirstName to update:");
//            string? name = Console.ReadLine();

//            DataTable? dataTable = dataSet.Tables["Contact"];
//            DataRow[] rows = dataTable.Select($"FirstName = '{name}'");

//            if (rows.Length == 1)
//            {
//                DataRow? row = rows[0];
//                Console.WriteLine("Enter the new ZipCode:");
//                int? newZipCode = Convert.ToInt32(Console.ReadLine());
//                row["ZipCode"] = newZipCode;

//                // Update the database
//                UpdateDatabase();
//            }
//            else
//            {
//                Console.WriteLine("Contact not found.");
//            }
//        }

//        static void Main(string[] args)
//        {
//            dataSet = new DataSet();
//            adapter = new SqlDataAdapter("Select * from Contact", connectionString);
//            adapter.Fill(dataSet, "Contact");
//            Program1? p = new Program1();
//            while (true)
//            {
//                Console.WriteLine("\nChoose the option ");
//                Console.WriteLine("Type 1 to Add Contact ");
//                Console.WriteLine("Type 2 to Update Contact ");
//                Console.WriteLine("Type 3 to Delete Contact ");
//                Console.WriteLine("Type 4 to Display Contact ");
//                Console.WriteLine("Type 0 to Exit ");
//                int? option = Convert.ToInt32(Console.ReadLine());

//                switch (option)
//                {
//                    case 1:
//                        p.AddUser();
//                        break;
//                    case 2:
//                        p.UpdateData();
//                        break;
//                    case 3:
//                        p.DeleteData();
//                        break;
//                    case 4:
//                        p.DisplayData();
//                        break;
//                    case 0:
//                        Environment.Exit(0);
//                        break;
//                    default:
//                        Console.WriteLine("Invalid option.");
//                        break;
//                }
//            }
//        }
//    }
//}

