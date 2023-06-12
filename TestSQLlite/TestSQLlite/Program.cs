using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSQLlite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hi");
            PokemonDB samp = new PokemonDB();
            samp.CreateDatabaseAndTable();

            //samp.ClearDB();

            Console.Write("Add Name      :");
            string name = Console.ReadLine();

            Console.Write("Add LastName  :");
            string lastname = Console.ReadLine();

            samp.AddData(name, lastname);

            Console.WriteLine("*************************");
            samp.SelectData();

            Console.ReadLine();
        }

      
    }
}
