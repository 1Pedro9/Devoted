using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoted.Model
{
    public class Plan
    {
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; }

        // Constructor
        public Plan(int planId, string planName, DateTime dateCreated, int createdBy)
        {
            PlanId = planId;
            PlanName = planName;
            DateCreated = dateCreated;
            CreatedBy = createdBy;
        }

        // Insert Query
        public string GetInsertQuery()
        {
            return $"INSERT INTO Plans (plan, date_created, created_by) " +
                   $"VALUES ('{PlanName}', '{DateCreated.ToString("yyyy-MM-dd HH:mm:ss")}', {CreatedBy});";
        }

        // Update Query
        public string GetUpdateQuery()
        {
            return $"UPDATE Plans SET plan = '{PlanName}', date_created = '{DateCreated.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                   $"created_by = {CreatedBy} WHERE plan_id = {PlanId};";
        }

        // Delete Query
        public string GetDeleteQuery()
        {
            return $"DELETE FROM Plans WHERE plan_id = {PlanId};";
        }
    }

}
