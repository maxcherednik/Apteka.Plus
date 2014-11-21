using System;
using Apteka.Helpers;
using Apteka.Plus.Logic.BLL;
using BLToolkit.Data;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Satelite.Logic.BLL.Entities;

namespace Apteka.Plus.Logic.DAL
{
    public class ProductsDefectGateway
    {
        private readonly static Logger log = new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        Apteka.Plus.Logic.BLL.Entities.MyStore _myStore;

        public ProductsDefectGateway(Apteka.Plus.Logic.BLL.Entities.MyStore myStore)
        {
            _myStore = myStore;            
        }

        public long Insert(DefectRow defectRow)
        {
            using (DbManager db = new DbManager(_myStore.Name))
            {
                return Insert(db,defectRow);
            }
        }

        public long Insert(DbManager db ,DefectRow defectRow)
        {
            log.InfoFormat(@"Вставка записи в таблицу Дефектура  
                                ID: {0}
                                DateAccepted: {1}                                
                                LocalBillRowId: {2}",
                                defectRow.ID,
                                defectRow.DateAccepted,
                                defectRow.LocalBillsRowID
                                );    
            int affectedRows = db.SetCommand(@"insert into
                                        defect(
                                        id,
                                        id_pos,
                                        date_defect
                                        )
                                 values(
                                        @id,
                                        @localBillsRowID,
                                        @dateAccepted
                                        )",
                                          db.CreateParameters(defectRow)
                             ).ExecuteNonQuery();

            log.InfoFormat("Вставлено {0} строк", affectedRows);
            if (affectedRows != 1)
            {
                log.ErrorFormat("Ошибка вставки запаси в талицу. Вставлено {0} строк", affectedRows);
                throw new Exception("Ошибка вставки запаси в талицу");
            }

            return affectedRows;
            
        }

        public long GetMaxRowID(DbManager db)
        {
            return db.SetCommand(@"select max(id) FROM 
                                defect"
                             ).ExecuteScalar<long>();
        }

        public long GetMaxRowID()
        {
            using (DbManager db = new DbManager(_myStore.Name))
            {
                return GetMaxRowID(db);
            }            
        }
    }
}
