using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoted.Model
{
    public class Journal
    {
        public int JournalId { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public float Amount { get; set; }
        public string DiverseDetails { get; set; }
        public string JournalType { get; set; }
        public int MemberId { get; set; }
        public int PlanId { get; set; }
        public int CategoryId { get; set; }

        // Constructor
        public Journal(int journalId, DateTime date, string details, float amount, string diverseDetails, string journalType, int memberId, int planId, int categoryId)
        {
            JournalId = journalId;
            Date = date;
            Details = details;
            Amount = amount;
            DiverseDetails = diverseDetails;
            JournalType = journalType;
            MemberId = memberId;
            PlanId = planId;
            CategoryId = categoryId;
        }

        // Insert Query
        public string GetInsertQuery()
        {
            return $"INSERT INTO Journal (date, details, amount, diverse_details, journal, member_id, plan_id, category_id) " +
                   $"VALUES ('{Date.ToString("yyyy-MM-dd HH:mm:ss")}', '{Details}', {Amount}, '{DiverseDetails}', '{JournalType}', {MemberId}, {PlanId}, {CategoryId});";
        }

        // Update Query
        public string GetUpdateQuery()
        {
            return $"UPDATE Journal SET date = '{Date.ToString("yyyy-MM-dd HH:mm:ss")}', details = '{Details}', amount = {Amount}, " +
                   $"diverse_details = '{DiverseDetails}', journal = '{JournalType}', member_id = {MemberId}, " +
                   $"plan_id = {PlanId}, category_id = {CategoryId} WHERE journal_id = {JournalId};";
        }

        // Delete Query
        public string GetDeleteQuery()
        {
            return $"DELETE FROM Journal WHERE journal_id = {JournalId};";
        }

        public string getYear()
        {
            return this.Date.Year.ToString();
        }

        public string getMonth()
        {
            return this.Date.Month.ToString();
        }

        public string getDay()
        {
            return this.Date.Day.ToString();
        }
    }

}
