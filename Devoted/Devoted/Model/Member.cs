using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoted.Model
{
    public class Member
    {
        public int MemberId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateJoined { get; set; }
        public int IsAdmin { get; set; }

        // Constructor
        public Member(int memberId, string firstname, string lastname, string email, string username, string password, DateTime dateJoined, int isAdmin)
        {
            MemberId = memberId;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Username = username;
            Password = password;
            DateJoined = dateJoined;
            IsAdmin = isAdmin;
        }

        // Insert Query
        public string GetInsertQuery()
        {
            return $"INSERT INTO Members (firstname, lastname, email, username, password, date_joined, is_admin) " +
                   $"VALUES ('{Firstname}', '{Lastname}', '{Email}', '{Username}', '{Password}', '{DateJoined.ToString("yyyy-MM-dd HH:mm:ss")}', {IsAdmin});";
        }

        // Update Query
        public string GetUpdateQuery()
        {
            return $"UPDATE Members SET firstname = '{Firstname}', lastname = '{Lastname}', email = '{Email}', " +
                   $"username = '{Username}', password = '{Password}', date_joined = '{DateJoined.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                   $"is_admin = {IsAdmin} WHERE member_id = {MemberId};";
        }

        // Delete Query
        public string GetDeleteQuery()
        {
            return $"DELETE FROM Members WHERE member_id = {MemberId};";
        }
    }

}
