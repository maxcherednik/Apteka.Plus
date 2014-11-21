using System;
using System.Data.SqlClient;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.Data;

namespace Apteka.Plus.Logic.DAL
{
    public class DAL
    {
        public static void InitConnectionStrings(string ConnectionStringSatelite)
        {
            foreach (MyStore myStore in MyStoresCollection.AllStores)
            {
                DbManager.AddConnectionString(myStore.Name, ConnectionStringSatelite + myStore.ID);
            }
        }

        public static bool IsConnectionFine(string connectionStringSatelite)
        {
            try
            {
                using (SqlConnection sqlClient = new SqlConnection(connectionStringSatelite))
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
