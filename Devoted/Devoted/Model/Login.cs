using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoted.Model
{
    public class Login
    {
        public int LoginId { get; set; }
        public string Ip { get; set; }
        public int MemberId { get; set; }
        public DateTime DateLogin { get; set; }

        // Constructor
        public Login(int loginId, string ip, int memberId, DateTime dateLogin)
        {
            LoginId = loginId;
            Ip = ip;
            MemberId = memberId;
            DateLogin = dateLogin;
        }

        // Insert Query
        public string GetInsertQuery()
        {
            return $"INSERT INTO Login (ip, member_id, date_login) " +
                   $"VALUES ('{Ip}', {MemberId}, '{DateLogin.ToString("yyyy-MM-dd HH:mm:ss")}');";
        }

        // Update Query
        public string GetUpdateQuery()
        {
            return $"UPDATE Login SET ip = '{Ip}', member_id = {MemberId}, date_login = '{DateLogin.ToString("yyyy-MM-dd HH:mm:ss")}' " +
                   $"WHERE login_id = {LoginId};";
        }

        // Delete Query
        public string GetDeleteQuery()
        {
            return $"DELETE FROM Login WHERE login_id = {LoginId};";
        }
    }

}
