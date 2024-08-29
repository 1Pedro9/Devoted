using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoted.Model
{
    public class Stock
    {
        public int StockId { get; set; }
        public DateTime Date { get; set; }
        public string Exchange { get; set; }
        public string Symbol { get; set; }
        public float BuyAt { get; set; }
        public float CurrentValue { get; set; }
        public int MemberID { get; set; }
        public int ManagerID { get; set; }
        public int listID { get; set; }

        public Stock(int StockID, DateTime Date, string Exchange, string Symbol, float BuyAt, float CurrentValue, int MemberID, int ManagerID, int ListID) 
        { 
            this.StockId = StockID;
            this.Date = Date;
            this.Exchange = Exchange;
            this.Symbol = Symbol;
            this.BuyAt = BuyAt;
            this.CurrentValue = CurrentValue;
            this.ManagerID = ManagerID;
            this.listID = ListID;
            this.MemberID = MemberID;
        }

        public string getDate()
        {
            return this.Date.Year.ToString() + "/" + this.Date.Month.ToString() + "/" + this.Date.Day.ToString();
        }
        public string getTime()
        {
            return this.Date.Hour.ToString() + ":" + this.Date.Minute.ToString();
        }
    }
}
