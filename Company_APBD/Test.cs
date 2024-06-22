namespace Company_APBD;

using System;
using Npgsql;

class Test
{
    static void Main()
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=postgres;";

        using (var conn = new NpgsqlConnection(connectionString))
        {
            try
            {
                conn.Open();
                Console.WriteLine("Connection successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection failed: {ex.Message}");
            }
        }

        Console.ReadLine();
    }
}
