using System;
using Apteka.Helpers;
using Apteka.Plus.Logic.BLL;
using BLToolkit.Data;
using BLToolkit.DataAccess;
using Apteka.Plus.Satelite.Logic.BLL.Entities;

namespace Apteka.Plus.Logic.DAL
{
    public class PriceChangesGateway
    {
        private readonly static Logger log = new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        Apteka.Plus.Logic.BLL.Entities.MyStore _myStore;


        public PriceChangesGateway(Apteka.Plus.Logic.BLL.Entities.MyStore myStore)
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
                return db.SetCommand(@"select max(id_izm) FROM 
                                изменения"
                             ).ExecuteScalar<long>();  

        }


        public int Insert(PriceChangeRow priceChangeRow)
        {
            using (DbManager db = new DbManager(_myStore.Name))
            {
                return Insert(db, priceChangeRow);
            }
        }


        public int Insert(DbManager db ,PriceChangeRow priceChangeRow)
        {
            log.InfoFormat(@"Вставка записи в таблицу Изменения цен  
                                ID: {0}
                                DateAccepted: {1}
                                LocalBillsRowID: {2}
                                Count: {3}
                                NewPrice: {4}
                                Difference: {5}",
                                priceChangeRow.ID,
                                priceChangeRow.DateAccepted,
                                priceChangeRow.LocalBillsRowID,
                                priceChangeRow.Count ,
                                priceChangeRow.NewPrice ,
                                priceChangeRow.Difference
                                );

            
            int affectedRows = db.SetCommand(@"INSERT INTO 
                                            изменения (
                                                        id_izm,
                                                        [date],
                                                        id_pos,
                                                        kol,
                                                        raznica,
                                                        n_cena
                                                        ) 
                                            VALUES
                                                    (
                                                       @id,
                                                       @dateAccepted, 
                                                       @localBillRowID,
                                                       @Count,
                                                       @Difference,
                                                       @newPrice
                                                    )",
                                                          db.Parameter("@ID",priceChangeRow.ID),
                                                          db.Parameter("@dateAccepted", priceChangeRow.DateAccepted ),
                                                          db.Parameter("@localBillRowID", priceChangeRow.LocalBillsRowID),
                                                          db.Parameter("@Count", priceChangeRow.Count),
                                                          db.Parameter("@Difference", priceChangeRow.Difference),
                                                          db.Parameter("@newPrice", priceChangeRow.NewPrice)
                                                          ).
                                                          ExecuteNonQuery();
            
            

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
