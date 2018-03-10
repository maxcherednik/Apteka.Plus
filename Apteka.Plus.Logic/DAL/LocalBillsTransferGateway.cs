
using System;
using Apteka.Helpers;
using Apteka.Plus.Logic.BLL;
using BLToolkit.Data;
using Apteka.Plus.Satelite.Logic.BLL.Entities;

namespace Apteka.Plus.Logic.DAL
{
    public class LocalBillsTransferGateway
    {
        private readonly static Logger log = new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        Apteka.Plus.Logic.BLL.Entities.MyStore _myStore;

        public LocalBillsTransferGateway(Apteka.Plus.Logic.BLL.Entities.MyStore myStore)
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
             return db.SetCommand(@"select max(id_pered) FROM 
                                передача"
                             ).ExecuteScalar<long>();           

        }

        public long Insert(LocalBillsTransferRow localBillsTransferRow)
        {
            using (DbManager db = new DbManager(_myStore.Name))
            {
                return Insert(db, localBillsTransferRow);
            }

        }

        public long Insert(DbManager db ,LocalBillsTransferRow localBillsTransferRow)
        {
            log.InfoFormat(@"Вставка записи в таблицу Передача  
                                ID: {0}
                                LocalBillRowId: {1}
                                DateAccepted: {2}
                                Count: {3}
                                Price: {4}
                                EmployeeID: {5}",
                                localBillsTransferRow.ID,
                                localBillsTransferRow.LocalBillsRowID ,
                                localBillsTransferRow.DateAccepted ,
                                localBillsTransferRow.Count ,
                                localBillsTransferRow.Price,
                                localBillsTransferRow.EmployeeID
                                );    

            int affectedRows =db.SetCommand(@"insert into  
                                передача
                                    (
                                        id_pered,
                                        [date],
                                        id_pos,
                                        kol,        
                                        z_cena,
                                        id_smena,
                                        obrabotano
                                    )
                                 values
                                    (
                                        @id,
                                        @dateAccepted,
                                        @localBillRowId,
                                        @count,        
                                        @price,
                                        @employeeId,
                                        'false'
                                    )",db.Parameter("@id",localBillsTransferRow.ID),
                                      db.Parameter("@dateAccepted", localBillsTransferRow.DateAccepted.Date),//TODO
                                      db.Parameter("@localBillRowId", localBillsTransferRow.LocalBillsRowID),
                                      db.Parameter("@count", localBillsTransferRow.Count),
                                      db.Parameter("@price", localBillsTransferRow.Price),
                                      db.Parameter("@employeeId", localBillsTransferRow.EmployeeID)                                                                            
                             ).ExecuteNonQuery();

            log.InfoFormat("Вставлено {0} строк", affectedRows);
            if (affectedRows != 1)
            {
                log.ErrorFormat("Ошибка вставки записи в талицу. Вставлено {0} строк", affectedRows);
                throw new Exception("Ошибка вставки записи в талицу");
            }

            return affectedRows;

        }
    }
}



