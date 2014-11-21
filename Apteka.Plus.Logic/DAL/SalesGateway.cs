using System;
using Apteka.Helpers;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Satelite.Logic.BLL.Entities;
using BLToolkit.Data;



namespace Apteka.Plus.Logic.DAL
{
    public class SalesGateway
    {
        private readonly static Logger log = new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        Apteka.Plus.Logic.BLL.Entities.MyStore _myStore;
        public SalesGateway(Apteka.Plus.Logic.BLL.Entities.MyStore myStore)
        {
            _myStore = myStore;            
        }

        public long GetMaxRowsID()
        {
            using (DbManager db = new DbManager(_myStore.Name))
            {
                return GetMaxRowsID(db);                
            }
            
        }

        public long GetMaxRowsID(DbManager db)
        {
            return db.SetCommand(@"select max(id_prod) FROM 
                                продажа"
                             ).ExecuteScalar<long>();          

        }


        public long Insert(SalesRow salesRow)
        {
            using (DbManager db = new DbManager(_myStore.Name))
            {

                return Insert(db, salesRow);
                
            }

        }

        
        public void WriteType(string text)
        {

        }
        
        public long Insert(DbManager db ,SalesRow salesRow)
        {
            log.InfoFormat(@"Вставка записи в таблицу Продажа  
                                ID: {0}
                                LocalBillsRowID: {1}, 
                                Price: {2} 
                                PriceWithDiscount: {3}
                                Count: {4}                                
                                CustomerCount: {5}
                                DateAccepted: {6}
                                EmployeeID: {7}", 
                                salesRow.ID, 
                                salesRow.LocalBillsRowID , 
                                salesRow.Price, 
                                salesRow.PriceDiscount,
                                salesRow.Count,
                                salesRow.CustomerCount,
                                salesRow.DateAccepted,
                                salesRow.EmployeeID 
                                );    
            int affectedRows= db.SetCommand(@"insert into  
                                продажа
                                    (
                                        id_prod,
                                        pokupatel,       
                                        id_pos,
                                        [date],
                                        cena,
                                        cena_skidka,
                                        kol,
                                        vremya,
                                        id_smena
                                    )
                                 values
                                    (
                                        @id,
                                        @customerCount,       
                                        @localBillsRowId,
                                        @dateAccepted,
                                        @price,
                                        @priceDiscount,
                                        @count,
                                        @hour,
                                        @employeeId
                                    )",
                                      db.Parameter("@ID",salesRow.ID),
                                      db.Parameter("@customerCount", salesRow.CustomerCount ),
                                      db.Parameter("@localBillsRowId", salesRow.LocalBillsRowID),
                                      db.Parameter("@dateAccepted", salesRow.DateAccepted.Date), // вставляет только дату
                                      db.Parameter("@Count", salesRow.Count),
                                      db.Parameter("@priceDiscount", salesRow.PriceDiscount),
                                      db.Parameter("@price", salesRow.Price),
                                      db.Parameter("@hour", salesRow.DateAccepted.Hour),
                                      db.Parameter("@employeeId", salesRow.EmployeeID)
                                      
                             ).ExecuteNonQuery();
                log.InfoFormat("Вставлено {0} строк", affectedRows);
                if (affectedRows != 1)
                {
                    log.ErrorFormat("Ошибка вставки запаси в талицу. Вставлено {0} строк", affectedRows);
                    throw new Exception("Ошибка вставки запаси в талицу");
                }

                return affectedRows;

        }
    }
}
