using System;
using System.Collections.Generic;
using System.Data;
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.DAL.Accessors
{
    public abstract class SalesAccessor : DataAccessor<SalesRow>
    {
        public abstract List<SalesRow> GetRowsByDateAndBelowNPercent(DateTime date, double Percent);

        public abstract List<SalesRow> GetRowsByDateAndAboveNPercent(DateTime date, double Percent);

        public abstract List<SalesRow> GetRowsByDateAndBetweenNMPercent(DateTime date, double LowPercent, double HighPercent);

        public abstract List<SalesRow> GetRowsByDate(DateTime date);

        public abstract SalesRow GetRowByID(long ID);

        public abstract List<SalesRow> GetRowsByClientID(string clientID);

        public abstract List<SalesRow> FindRowsByName(string name);

        public abstract int GetMaxCustomerNumber(DateTime date);

        public abstract DataTable GetSummary(DateTime date);

        public DataTable GetSalesStatistics(DbManager db, DateTime startDate, DateTime endDate)
        {
            const string queryPart1 = "select fpi.ProductName as Название, fpi.PackageName as Фасовка ,prod.*,Amounts.Amount as Остаток " +
                                      " From " +
                                      "( " +
                                      "select " +
                                      "    [FullProductInfoID], ";

            const string queryPart2 = " From ( " +
                                      "SELECT " +
                                      "               [FullProductInfoID], ";

            const string queryPart3 = " as [date_format], " +
                                      "      sum([продажа].[kol]) As prodano " +
                                      "    From " +
                                      "        [продажа] inner join накладные " +
                                      "            on [продажа].id_pos = накладные.id_pos " +
                                      "         inner join [sklad].[dbo].[sklad] " +
                                      "            on sklad.id_prih = накладные.id_prih " +
                                      "    Where " +
                                      "         [продажа].Date Between @startDate and @endDate " +
                                      " Group By " +
                                      " [FullProductInfoID], ";


            const string queryPart4 = ") ps " +
                                      " PIVOT ( " +
                                      " sum (prodano) FOR [date_format] IN " +
                                      " ( ";

            const string queryPart5 = ")) as pvt) as prod " +
                                      " inner join [sklad].[dbo].[связь] fpi " +
                                      "     on fpi.id =prod.FullProductInfoID " +
                                      " left join Amounts " +
                                      " on Amounts.FullProductInfoID=prod.FullProductInfoID " +
                                      " order by fpi.ProductName, fpi.PackageName";
            var columnNames = GetColumnNames(startDate, endDate);
            const string dateFormat = " Cast(Year([продажа].date)as varchar(4)) + '_' + Cast(month([продажа].date)as varchar(2)) ";

            var commandText = queryPart1 + columnNames + queryPart2 + dateFormat + queryPart3 + dateFormat + queryPart4 + columnNames + queryPart5;

            return db.SetCommand(commandText,
                                      db.Parameter("@startDate", startDate),
                                      db.Parameter("@endDate", endDate)
                            ).ExecuteDataTable();

        }

        public abstract int Insert(SalesRow salesRow);

        public abstract long GetMaxRowID();

        public abstract List<SalesRow> GetUnsyncedRows();

        private SqlQuery<SalesRow> _query;
        public SqlQuery<SalesRow> Query => _query ?? (_query = new SqlQuery<SalesRow>(DbManager));

        public abstract int ChangeAmount(long id, int count);

        public abstract int DeleteByKey(long id);

        private static string GetColumnNames(DateTime startDate, DateTime endDate)
        {
            var resultString = "";

            var curDate = startDate;

            do
            {
                resultString = resultString + "[" + curDate.Year + "_" + curDate.Month + "],";
                curDate = curDate.AddMonths(1);
            }
            while (endDate >= curDate);

            resultString = resultString.Substring(0, resultString.Length - 1);

            return resultString;
        }
    }
}

