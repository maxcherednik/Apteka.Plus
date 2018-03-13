using Apteka.Plus.Logic.BLL.Collections;
using BLToolkit.Data;
using System;
using System.Data.SqlClient;

namespace Apteka.Plus.Logic.DAL
{
    public class Dal
    {
        public static void InitStoresConnectionStrings(string connectionStringStoreTemplate, string dbHost, string dbUser, string dbPassword)
        {
            foreach (var myStore in MyStoresCollection.AllStores)
            {
                var storeConnectionString = string.Format(connectionStringStoreTemplate, dbHost, dbUser, dbPassword, myStore.ID);
                DbManager.AddConnectionString(myStore.Name, storeConnectionString);
            }
        }

        public static bool IsConnectionFine(string connectionStringSatelite)
        {
            try
            {
                using (var sqlClient = new SqlConnection(connectionStringSatelite))
                {
                    sqlClient.Open();
                }
            }
            catch (SqlException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            return true;
        }

        public static void InitConnectionString(string connectionString)
        {
            DbManager.AddConnectionString(connectionString);
        }
    }
}
