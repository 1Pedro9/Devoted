using Devoted.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoted.Controller
{
    internal class ModelController
    {

        public ModelController() 
        { 
            
        }

        public List<Member> members()
        {
            List<Member> members = new List<Member>();

            members.Add(new Member(1, "Pedro", "Basson", "basson.pedro@gmail.com", "Pedro", "Pedro01", DateTime.Now, 1));
            members.Add(new Member(2, "Admin", "Admin", "admin@gmail.com", "Admin", "Admin01", DateTime.Now, 1));

            return members;
        }

        public List<Plan> plans()
        {
            List<Plan> plans = new List<Plan>();

            plans.Add(new Plan(1, "Capitec", DateTime.Now, 1));
            plans.Add(new Plan(2, "ABSA", DateTime.Now, 1));

            return plans;
        }

        public List<Category> categories()
        {
            List<Category> categories = new List<Category>();

            categories.Add(new Category(1, "Default", DateTime.Now, 1));

            return categories;
        }

        public List<Journal> journals()
        {
            List<Journal> journals = new List<Journal>();
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../Devoted/Database/Journals.csv");

            try
            {
                // Read all lines from the CSV file
                var lines = File.ReadAllLines(filePath);

                // Skip the header line and parse the data
                foreach (var line in lines.Skip(1))
                {
                    var values = line.Split(',');

                    int journalId = int.Parse(values[0]);
                    DateTime date = DateTime.ParseExact(values[1], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                    string details = values[2];
                    float amount = float.Parse(values[3]);
                    string diverseDetails = values[4];
                    string journalType = values[5];
                    int memberId = int.Parse(values[6]);
                    int planId = int.Parse(values[7]);
                    int categoryId = int.Parse(values[8]);

                    // Create a new Journal object and add it to the list
                    journals.Add(new Journal(journalId, date, details, amount, diverseDetails, journalType, memberId, planId, categoryId));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the CSV file: {ex.Message}");
            }

            return journals;
        }


        public List<Stock> stocks()
        {
            List<Stock> stocks = new List<Stock>();
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../Devoted/Database/Stocks.csv");

            try
            {
                // Read all lines from the CSV file
                var lines = File.ReadAllLines(filePath);

                // Skip the header line and parse the data
                foreach (var line in lines.Skip(1))
                {
                    var values = line.Split(',');

                    int stockId = int.Parse(values[0]);
                    DateTime date = DateTime.ParseExact(values[1], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                    string exchange = values[2];
                    string symbol = values[3];
                    float BuyAt = int.Parse(values[4]);
                    float CurrentValue = int.Parse(values[5]);
                    int memberId = int.Parse(values[6]);
                    int managerID = int.Parse(values[7]);
                    int listID = int.Parse(values[8]);

                    // Create a new Journal object and add it to the list
                    stocks.Add(new Stock(stockId, date, exchange, symbol, BuyAt, CurrentValue, memberId, managerID, listID));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the CSV file: {ex.Message}");
            }

            return stocks;
        }
    }
}
