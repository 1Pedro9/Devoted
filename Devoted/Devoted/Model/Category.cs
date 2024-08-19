using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoted.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; }

        // Constructor
        public Category(int categoryId, string categoryName, DateTime dateCreated, int createdBy)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            DateCreated = dateCreated;
            CreatedBy = createdBy;
        }

        // Insert Query
        public string GetInsertQuery()
        {
            return $"INSERT INTO Categories (category, date_created, created_by) " +
                   $"VALUES ('{CategoryName}', '{DateCreated.ToString("yyyy-MM-dd HH:mm:ss")}', {CreatedBy});";
        }

        // Update Query
        public string GetUpdateQuery()
        {
            return $"UPDATE Categories SET category = '{CategoryName}', date_created = '{DateCreated.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                   $"created_by = {CreatedBy} WHERE category_id = {CategoryId};";
        }

        // Delete Query
        public string GetDeleteQuery()
        {
            return $"DELETE FROM Categories WHERE category_id = {CategoryId};";
        }
    }

}
