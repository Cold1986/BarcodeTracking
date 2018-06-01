using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices;

namespace BarcodeTracking.Biz
{
    public class ADBiz
    {
        private string Hostname;
        private string AdminUser;
        private string AdminPassword;
        private string BaseDN;
        private string GroupEntry;

        public ADBiz()
        {
            Hostname = System.Configuration.ConfigurationManager.AppSettings["Hostname"];
            AdminUser = System.Configuration.ConfigurationManager.AppSettings["AdminUser"];
            AdminPassword = System.Configuration.ConfigurationManager.AppSettings["AdminPassword"];
            BaseDN = System.Configuration.ConfigurationManager.AppSettings["BaseDN"];
            GroupEntry = System.Configuration.ConfigurationManager.AppSettings["GroupEntry"];
        }

        public bool Authenticate(string userName, string password)
        {
            bool passed = false;
            DirectoryEntry entry = new DirectoryEntry("LDAP://" + Hostname, userName, password);

            try
            {
                object nativeObject = entry.NativeObject;
                passed = true;
            }
            catch (DirectoryServicesCOMException ex)
            {
                //Console.WriteLine(ex);
                //LogError("Authenticate(): Failed to authenticate.");
            }
            entry.Close();
            return passed;
        }
    }
}
