using System;
using System.Collections.Generic;
using System.Data;
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.DAL.Accessors
{
    public abstract class SalesAccessor:DataAccessor<SalesRow>
    {
        public abstract List<SalesRow> GetRowsByDateAndBelowNPercent(DateTime date,double Percent);
        public abstract List<SalesRow> GetRowsByDateAndAboveNPercent(DateTime date, double Percent);
        public abstract List<SalesRow> GetRowsByDateAndBetweenNMPercent(DateTime date, double LowPercent, double HighPercent);

        public abstract List<SalesRow> GetRowsByDate(DateTime date);
        public abstract SalesRow GetRowByID(long ID); 
        public abstract List<SalesRow> GetRowsByClientID(string clientID);
        public abstract List<SalesRow> FindRowsByName(string name);

        
        public abstract int GetMaxCustomerNumber(DateTime date);

        public abstract DataTable GetSummary(DateTime date);

        public DataTable GetSalesStatistics(DbManager db,DateTime startDate, DateTime endDate)
        {
            

            string queryPart1 = "select fpi.ProductName as Название, fpi.PackageName as Фасовка ,prod.*,Amounts.Amount as Остаток " + 
                " From " + 
                "( " + 
                "select " + 
                "    [FullProductInfoID], ";

            string queryPart2 = " From ( " + 
                                "SELECT " + 
                    "               [FullProductInfoID], ";

            string queryPart3 = " as [date_format], " + 
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
                

            string queryPart4 = ") ps " + 
                " PIVOT ( " + 
                " sum (prodano) FOR [date_format] IN " + 
                " ( ";

            string queryPart5 = ")) as pvt) as prod " +
                    " inner join [sklad].[dbo].[связь] fpi " +
                    "     on fpi.id =prod.FullProductInfoID " +
                    " left join Amounts " +
                    " on Amounts.FullProductInfoID=prod.FullProductInfoID " +
                    " order by fpi.ProductName, fpi.PackageName";
            string columnNames = GetColumnNames(startDate, endDate);
            string dateFormat = " Cast(Year([продажа].date)as varchar(4)) + '_' + Cast(month([продажа].date)as varchar(2)) ";

            string commandText = queryPart1 + columnNames + queryPart2 + dateFormat + queryPart3 + dateFormat + queryPart4 + columnNames + queryPart5;

            return db.SetCommand(commandText,
                                      db.Parameter("@startDate", startDate),
                                      db.Parameter("@endDate", endDate)
                            ).ExecuteDataTable();
                        
        }
        
        public abstract int Insert(SalesRow salesRow);

        public abstract long GetMaxRowID();

        public abstract List<SalesRow> GetUnsyncedRows();

        private SqlQuery<SalesRow> _query;
        public SqlQuery<SalesRow> Query
        {
            get
            {
                if (_query == null)
                    _query = new SqlQuery<SalesRow>(DbManager);
                return _query;
            }
        }

        
        
        public abstract int ChangeAmount(long id, int count);

        public abstract int DeleteByKey(long id);

        private string GetColumnNames(DateTime startDate, DateTime endDate)
        {
            string  resultString="";

            DateTime curDate=startDate;

//Do
//    If queryType = "month" Then
        do
        {
        resultString = resultString + "[" + curDate.Year  + "_" + curDate.Month + "],";
        curDate = curDate.AddMonths(1);
    //ElseIf queryType = "week" Then
    //    resultString = resultString & "[" & Year(curDate) & "_" & Month(curDate) & "_" & Format(curDate, "ww") & "],"
    //    curDate = DateAdd("d", 7, curDate)
    //ElseIf queryType = "day" Then
    //    resultString = resultString & "[" & Year(curDate) & "_" & Month(curDate) & "_" & Day(curDate) & "],"
    //    curDate = DateAdd("d", 1, curDate)
    //End If
          
        }
        while (endDate >= curDate);
        
            resultString=resultString.Substring(0,resultString.Length -1);

            return resultString;

        }

        
        
    }

}

