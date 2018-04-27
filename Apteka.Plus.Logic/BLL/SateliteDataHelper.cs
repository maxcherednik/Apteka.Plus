using Apteka.Helpers;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.BLL
{
    public class SateliteDataHelper
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Office

        public static string PrepareDataForMyStore(MyStore myStore)
        {
            Log.Info("Подготовка данных для отправки в пункт");
            Log.InfoFormat("Пункт id: {0} name: {1} ip: {2}", myStore.ID, myStore.Name, myStore.IP);
            var di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "DataTransfer");
            if (!di.Exists)
                di.Create();

            var diDate = new DirectoryInfo(di.FullName + "\\" + DateTime.Now.ToShortDateString());
            if (!diDate.Exists)
                diDate.Create();

            using (var dbSatelite = new DbManager(myStore.Name))
            {
                var lba = DataAccessor.CreateInstance<LocalBillsAccessor>(dbSatelite);
                var raa = DataAccessor.CreateInstance<RemoteActionAccessor>(dbSatelite);
                var ea = DataAccessor.CreateInstance<EmployeesAccessor>(dbSatelite);
                var pa = DataAccessor.CreateInstance<PropertyAccessor>(dbSatelite);
                var sa = DataAccessor.CreateInstance<SalesAccessor>(dbSatelite);
                var lbta = DataAccessor.CreateInstance<LocalBillsTransfersAccessor>(dbSatelite);
                var pca = DataAccessor.CreateInstance<PriceChangesAccessor>(dbSatelite);
                var srha = DataAccessor.CreateInstance<SuppliesReturnHistoryAccessor>(dbSatelite);
                var clientAccessor = DataAccessor.CreateInstance<ClientAccessor>();
                var fpia = DataAccessor.CreateInstance<FullProductInfoAccessor>();

                Log.Info("Читаем oLocalBillsRows");
                var liLocalBillsRows = lba.GetUnsyncedRows();
                Log.InfoFormat("oLocalBillsRows: {0} позиций", liLocalBillsRows.Count);

                Log.Info("Читаем liRemoteActions");
                var liRemoteActions = raa.GetUnsyncedRows();
                Log.InfoFormat("liRemoteActions: {0} позиций", liRemoteActions.Count);

                Log.Info("Читаем liProperties");
                var liProperties = pa.GetAllRows();
                Log.InfoFormat("liProperties: {0} позиций", liProperties.Count);

                Log.Info("Читаем liEmployees");
                var liEmployees = ea.GetAllActiveEmployees();
                Log.InfoFormat("liEmployees: {0} позиций", liEmployees.Count);

                Log.Info("Читаем liMyStores");
                var liMyStores = MyStoresCollection.AllStores;
                Log.InfoFormat("liMyStores: {0} позиций", liMyStores.Count);

                Log.Info("Читаем Clients");
                var liClients = clientAccessor.Query.SelectAll();
                Log.InfoFormat("liClients: {0} позиций", liClients.Count);

                Log.Info("Читаем Products");
                var liFullProductInfo = fpia.GetAllActiveProductInfos();
                Log.InfoFormat("FullProductInfo: {0} позиций", liFullProductInfo.Count);

                #region Получение информации по таблицам
                Log.Info("Получение информации по таблицам");

                var maxLocalBillsTransferId = lbta.GetMaxRowID();
                var maxSalesRowId = sa.GetMaxRowID();
                var maxPriceChangesRowId = pca.GetMaxRowID();
                var maxSuppliesReturnHistoryRowId = srha.GetMaxRowID();

                Log.InfoFormat("maxLocalBillsTransferID: {0}", maxLocalBillsTransferId);
                Log.InfoFormat("maxSalesRowID: {0}", maxSalesRowId);
                Log.InfoFormat("maxPriceChangesRowID: {0}", maxPriceChangesRowId);
                Log.InfoFormat("maxSuppliesReturnHistoryRowID: {0}", maxSuppliesReturnHistoryRowId);

                var liTablesInfo = new List<TableInfo>(4)
                {
                    new TableInfo("Sales", maxSalesRowId),
                    new TableInfo("PriceChanges", maxPriceChangesRowId),
                    new TableInfo("LocalBillsTransfers", maxLocalBillsTransferId),
                    new TableInfo("SuppliesReturnHistory", maxSuppliesReturnHistoryRowId)
                };

                #endregion

                Log.Info("Сериализация...");
                SerializeHelper.SerializeObjectToFile(liLocalBillsRows, diDate.FullName + "\\LocalBillsRows.xml");
                SerializeHelper.SerializeObjectToFile(liRemoteActions, diDate.FullName + "\\RemoteActions.xml");
                SerializeHelper.SerializeObjectToFile((List<Property>)liProperties, diDate.FullName + "\\Properties.xml");
                SerializeHelper.SerializeObjectToFile(liEmployees, diDate.FullName + "\\Employees.xml");
                SerializeHelper.SerializeObjectToFile(liTablesInfo, diDate.FullName + "\\TablesInfo.xml");
                SerializeHelper.SerializeObjectToFile(liMyStores, diDate.FullName + "\\MyStores.xml");
                SerializeHelper.SerializeObjectToFile(liClients, diDate.FullName + "\\Clients.xml");
                SerializeHelper.SerializeObjectToFile(liFullProductInfo, diDate.FullName + "\\ProductInfo.xml");
            }

            Log.Info("Архивация...");
            var archiveName = di.FullName + "\\to" + myStore.ID + ".zip";
            ZipHelper.ZipFile(diDate.FullName, archiveName);

            Log.InfoFormat("Результирующий архив: {0}", archiveName);
            return archiveName;
        }

        public static string PrepareDataForInitializeSatelite(MyStore myStore)
        {
            throw new NotImplementedException();
        }

        public static void ProcessNewDataFromSatelite(MyStore myStore, Stream fsStream)
        {
            Log.Info("Обработка данных из пункта");
            Log.InfoFormat("Пункт id: {0} name: {1} ip: {2}", myStore.ID, myStore.Name, myStore.IP);
            Log.Info("Разархивация..");
            var diDestination = Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Temp\\" + Guid.NewGuid().ToString() + ".ext");
            ZipHelper.Unzip(fsStream, diDestination);

            Log.Info("Десериализация");
            var liPriceChangeRow = SerializeHelper.DeserializeObjectFromFile<List<PriceChangeRow>>(diDestination.FullName + "\\PriceChangeRows.xml");
            var liSalesRow = SerializeHelper.DeserializeObjectFromFile<List<SalesRow>>(diDestination.FullName + "\\SalesRows.xml");
            var liLocalBillsTransferRow = SerializeHelper.DeserializeObjectFromFile<List<LocalBillsTransferRow>>(diDestination.FullName + "\\LocalBillsTransferRows.xml");
            var liSuppliesReturnHistoryRows = SerializeHelper.DeserializeObjectFromFile<List<SuppliesReturnHistoryRow>>(diDestination.FullName + "\\SuppliesReturnHistory.xml");
            var liTablesInfo = SerializeHelper.DeserializeObjectFromFile<List<TableInfo>>(diDestination.FullName + "\\TablesInfo.xml");

            var dbSatelite = new DbManager(myStore.Name);
            var dbSklad = new DbManager();

            try
            {
                Log.Info("Открываем транзакции...");
                dbSatelite.BeginTransaction();
                dbSklad.BeginTransaction();

                var lba = DataAccessor.CreateInstance<LocalBillsAccessor>(dbSatelite);
                var raa = DataAccessor.CreateInstance<RemoteActionAccessor>(dbSatelite);
                var sa = DataAccessor.CreateInstance<SalesAccessor>(dbSatelite);
                var lbta = DataAccessor.CreateInstance<LocalBillsTransfersAccessor>(dbSatelite);
                var pca = DataAccessor.CreateInstance<PriceChangesAccessor>(dbSatelite);
                var srha = DataAccessor.CreateInstance<SuppliesReturnHistoryAccessor>(dbSatelite);

                #region SalesRows

                var salesRowMaxId = sa.GetMaxRowID();
                foreach (var varSalesRow in liSalesRow)
                {
                    if (varSalesRow.ID > salesRowMaxId)
                    {
                        lba.ChangeAmount(varSalesRow.LocalBillsRow.ID, -1 * varSalesRow.Count);
                        sa.Insert(varSalesRow);
                    }
                }
                #endregion

                #region SuppliesReturnHistoryRows

                var suppliesReturnHistoryMaxId = srha.GetMaxRowID();
                foreach (var suppliesReturnHistoryRow in liSuppliesReturnHistoryRows)
                {
                    if (suppliesReturnHistoryRow.ID > suppliesReturnHistoryMaxId)
                    {
                        lba.ChangeAmount(suppliesReturnHistoryRow.LocalBillsRow.ID, -1 * suppliesReturnHistoryRow.Amount);
                        srha.Insert(suppliesReturnHistoryRow);
                    }
                }

                #endregion

                #region TransferRows

                var localBillsTransferRowMaxId = lbta.GetMaxRowID();
                foreach (var varLocalBillsTransferRow in liLocalBillsTransferRow)
                {
                    if (varLocalBillsTransferRow.ID > localBillsTransferRowMaxId)
                    {
                        lba.ChangeAmount(varLocalBillsTransferRow.LocalBillsRow.ID, -1 * varLocalBillsTransferRow.Count);
                        lbta.Insert(varLocalBillsTransferRow);
                    }

                }
                #endregion

                #region PriceChangesRows

                var priceChangesRowMaxId = pca.GetMaxRowID();
                foreach (var varPriceChangeRow in liPriceChangeRow)
                {
                    if (varPriceChangeRow.ID > priceChangesRowMaxId)
                    {
                        pca.Insert(varPriceChangeRow);
                        lba.UpdatePrice(varPriceChangeRow.LocalBillsRowID, varPriceChangeRow.NewPrice);
                    }
                }
                #endregion

                #region Очитска
                foreach (var tableInfo in liTablesInfo)
                {
                    if (tableInfo.Name == "LocalBillsMaxRowID")
                    {
                        lba.MarkSyncedBeforeID(tableInfo.MaxID);
                    }
                    else if (tableInfo.Name == "RemoteActionsMaxID")
                    {
                        raa.MarkSyncedBeforeID(tableInfo.MaxID);
                    }
                }

                #endregion

                Log.Info("Завершаем транзакции...");
                dbSatelite.CommitTransaction();
                dbSklad.CommitTransaction();
            }
            catch (Exception e)
            {
                Log.Error("Ошибка при обработке данных из пункта " + myStore.ID, e);
                Log.Info("Откатываем транзакции...");
                dbSatelite.RollbackTransaction();
                dbSklad.RollbackTransaction();

                throw;
            }

            Log.InfoFormat("Удаляем директорию {0}", diDestination.Name);
            diDestination.Delete(true);
        }

        #endregion

        #region Satelite

        public static string PrepareDataFromSateliteToBase()
        {
            Log.Info("Подготовка данных для выгрузки на главный компьютер");

            var di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Download");
            if (!di.Exists)
                di.Create();

            var pathToArchiveName = Guid.NewGuid().ToString();
            var diPathToArchive = new DirectoryInfo(di.FullName + "\\" + pathToArchiveName);
            diPathToArchive.Create();
            Log.InfoFormat("Создана директория {0}", diPathToArchive.Name);

            var liTableInfos = new List<TableInfo>();

            using (var db = new DbManager())
            {
                List<PriceChangeRow> liPriceChangeRow;
                List<SalesRow> liSalesRow;
                List<LocalBillsTransferRow> liLocalBillsTransferRow;
                List<SuppliesReturnHistoryRow> liSuppliesReturnHistoryRows;
                try
                {
                    db.BeginTransaction();
                    Log.Info("Транзакция в базу открыта");

                    Log.Info("Подготовка данных");
                    var lba = DataAccessor.CreateInstance<LocalBillsAccessor>(db);
                    var pca = DataAccessor.CreateInstance<PriceChangesAccessor>(db);
                    var sa = DataAccessor.CreateInstance<SalesAccessor>(db);
                    var lbta = DataAccessor.CreateInstance<LocalBillsTransfersAccessor>(db);
                    var raa = DataAccessor.CreateInstance<RemoteActionAccessor>(db);

                    var srha = DataAccessor.CreateInstance<SuppliesReturnHistoryAccessor>(db);

                    liPriceChangeRow = pca.GetUnsyncedRows();
                    liSalesRow = sa.GetUnsyncedRows();
                    liLocalBillsTransferRow = lbta.GetUnsyncedRows();
                    liSuppliesReturnHistoryRows = srha.GetUnsyncedRows();

                    var maxLocalBillsRowId = lba.GetMaxRowID();
                    var lastRemoteActionId = raa.GetMaxRowID();

                    liTableInfos.Add(new TableInfo("LocalBillsMaxRowID", maxLocalBillsRowId));
                    liTableInfos.Add(new TableInfo("RemoteActionsMaxID", lastRemoteActionId));

                    db.CommitTransaction();
                    Log.Info("Транзакция в базу закрыта");
                }
                catch (Exception e)
                {
                    Log.Error("Ошибка при подготовке данных из пункта в центральную базу", e);
                    Log.Info("Транзакция в базу отменяется...");
                    db.RollbackTransaction();
                    Log.Info("Транзакция в базу отменена");
                    throw;
                }

                Log.Info("Сериализация данных...");
                SerializeHelper.SerializeObjectToFile(liPriceChangeRow, diPathToArchive.FullName + "\\PriceChangeRows.xml");
                SerializeHelper.SerializeObjectToFile(liSalesRow, diPathToArchive.FullName + "\\SalesRows.xml");
                SerializeHelper.SerializeObjectToFile(liLocalBillsTransferRow, diPathToArchive.FullName + "\\LocalBillsTransferRows.xml");
                SerializeHelper.SerializeObjectToFile(liTableInfos, diPathToArchive.FullName + "\\TablesInfo.xml");
                SerializeHelper.SerializeObjectToFile(liSuppliesReturnHistoryRows, diPathToArchive.FullName + "\\SuppliesReturnHistory.xml");

                Log.Info("Архивация...");
                var zipSateliteData = di.FullName + "\\" + pathToArchiveName + ".zip";
                ZipHelper.ZipFile(diPathToArchive.FullName, zipSateliteData);
                Log.InfoFormat("Создан архив {0}", zipSateliteData);

                diPathToArchive.Delete(true);
                Log.InfoFormat("Удалена директория {0}", diPathToArchive.Name);

                return zipSateliteData;
            }
        }

        public static void InsertNewData(Stream fileStream)
        {
            Log.Info("Обработка новых данных с главного компьютера");

            Log.Info("Разархивация..");
            var diDestination = Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Temp\\" + Guid.NewGuid().ToString() + ".ext");
            ZipHelper.Unzip(fileStream, diDestination);

            Log.Info("Десериализация данных...");
            var liLocalBillRows = SerializeHelper.DeserializeObjectFromFile<List<LocalBillsRowEx>>(diDestination.FullName + "\\LocalBillsRows.xml");
            var liRemoteActions = SerializeHelper.DeserializeObjectFromFile<List<RemoteAction>>(diDestination.FullName + "\\RemoteActions.xml");
            var liEmployees = SerializeHelper.DeserializeObjectFromFile<List<Employee>>(diDestination.FullName + "\\Employees.xml");
            var liProperties = SerializeHelper.DeserializeObjectFromFile<List<Property>>(diDestination.FullName + "\\Properties.xml");
            var liTablesInfo = SerializeHelper.DeserializeObjectFromFile<List<TableInfo>>(diDestination.FullName + "\\TablesInfo.xml");
            var liMyStores = SerializeHelper.DeserializeObjectFromFile<List<MyStore>>(diDestination.FullName + "\\MyStores.xml");
            var liClients = SerializeHelper.DeserializeObjectFromFile<List<Client>>(diDestination.FullName + "\\Clients.xml");
            var liFullProductInfo = SerializeHelper.DeserializeObjectFromFile<List<FullProductInfo>>(diDestination.FullName + "\\ProductInfo.xml");


            using (var db = new DbManager())
            {
                try
                {
                    db.BeginTransaction();
                    Log.Info("Транзакция в базу открыта");

                    var msra = DataAccessor.CreateInstance<MainStoreRowsAccessor>(db);
                    var lba = DataAccessor.CreateInstance<LocalBillsAccessor>(db);
                    var pa = DataAccessor.CreateInstance<PropertyAccessor>(db);
                    var ea = DataAccessor.CreateInstance<EmployeesAccessor>(db);
                    var tia = DataAccessor.CreateInstance<TablesInfoAccessor>(db);
                    var msa = DataAccessor.CreateInstance<MyStoresAccessor>(db);
                    var fpia = DataAccessor.CreateInstance<FullProductInfoAccessor>(db);
                    var supa = DataAccessor.CreateInstance<SuppliersAccessor>(db);
                    var clientAccessor = DataAccessor.CreateInstance<ClientAccessor>(db);

                    #region Update Clients

                    var liSateliteClients = clientAccessor.Query.SelectAll();
                    foreach (var client in liSateliteClients)
                    {
                        var clientFind = liClients.Find(c => c.Id == client.Id);

                        Log.InfoFormat("Client id: {0} discount: {1}", client.Id, client.Discount);

                        if (clientFind == null)
                        {
                            clientAccessor.Query.Delete(client);
                        }
                        else
                        {
                            if (clientFind.Discount != client.Discount)
                            {
                                clientAccessor.Query.Update(clientFind);
                            }
                        }
                    }

                    liSateliteClients = clientAccessor.Query.SelectAll();
                    foreach (var client in liClients)
                    {
                        var clientFind = liSateliteClients.Find(c => c.Id == client.Id);

                        Log.InfoFormat("Client id: {0} discount: {1}", client.Id, client.Discount);

                        if (clientFind == null)
                        {
                            clientAccessor.Query.Insert(client);
                        }
                    }

                    #endregion

                    #region Update MyStores

                    foreach (var myStore in liMyStores)
                    {
                        Log.InfoFormat("MyStore : {0} value: {1}", myStore.ID, myStore.Name);

                        var myStoreFind = msa.Query.SelectByKey(db, myStore.ID);
                        if (myStoreFind == null)
                        {
                            msa.Insert(myStore);
                        }
                        else
                        {
                            msa.Query.Update(myStore);
                        }

                    }
                    #endregion

                    #region Update Tables ID
                    tia.UpdateTables(db, liTablesInfo);
                    #endregion


                    #region Update FullProductInfo
                    foreach (var productInfo in liFullProductInfo)
                    {
                        var fpi = fpia.SelectByKey(productInfo.ID);
                        if (fpi == null)
                        {
                            fpia.Insert(productInfo);
                        }
                        else if (!fpi.Equals(productInfo))
                        {
                            fpia.Query.Update(productInfo);
                        }
                    }

                    #endregion

                    #region Update Dictionaries

                    var liFullProductInfos = new List<FullProductInfo>();
                    var liSuppliers = new List<Supplier>();
                    var liMainStoreRows = new List<MainStoreRow>();

                    if (liLocalBillRows.Count > 0)
                    {
                        var localBillsMaxRowId = lba.GetMaxRowID();

                        foreach (var localBillsRow in liLocalBillRows)
                        {
                            if (localBillsRow.ID > localBillsMaxRowId)
                            {
                                if (!liFullProductInfos.Contains(localBillsRow.MainStoreRow.FullProductInfo))
                                {
                                    var fpi = fpia.SelectByKey(localBillsRow.MainStoreRow.FullProductInfo.ID);
                                    if (fpi == null)
                                    {
                                        fpia.Insert(localBillsRow.MainStoreRow.FullProductInfo);
                                    }
                                    else if (!fpi.Equals(localBillsRow.MainStoreRow.FullProductInfo))
                                    {
                                        fpia.Query.Update(localBillsRow.MainStoreRow.FullProductInfo);
                                    }

                                    liFullProductInfos.Add(localBillsRow.MainStoreRow.FullProductInfo);
                                }

                                if (!liSuppliers.Contains(localBillsRow.MainStoreRow.Supplier))
                                {
                                    var supplier = supa.Query.SelectByKey(db, localBillsRow.MainStoreRow.Supplier.ID);
                                    if (supplier == null)
                                    {
                                        supa.Insert(localBillsRow.MainStoreRow.Supplier);
                                    }
                                    else if (!supplier.Equals(localBillsRow.MainStoreRow.Supplier))
                                    {
                                        supa.Query.Update(localBillsRow.MainStoreRow.Supplier);
                                    }

                                    liSuppliers.Add(localBillsRow.MainStoreRow.Supplier);
                                }

                                if (!liMainStoreRows.Contains(localBillsRow.MainStoreRow))
                                {
                                    var mainStoreRow = msra.GetRowByID(localBillsRow.MainStoreRow.ID);
                                    if (mainStoreRow == null)
                                    {
                                        msra.Insert(localBillsRow.MainStoreRow);
                                    }

                                    liMainStoreRows.Add(localBillsRow.MainStoreRow);
                                }

                                lba.Insert(localBillsRow);
                            }

                        }
                    }
                    #endregion

                    #region Update Employees

                    foreach (var employee in liEmployees)
                    {
                        var employeeFind = ea.Query.SelectByKey(db, employee.ID);
                        if (employeeFind == null)
                        {
                            ea.Insert(employee);
                        }
                        else if (!employee.Equals(employeeFind))
                        {
                            ea.Query.Update(employee);
                        }
                    }
                    #endregion

                    #region Update Properties
                    foreach (var property in liProperties)
                    {
                        Log.InfoFormat("Параметр: {0} value: {1}", property.Name, property.Value);
                        pa.Query.Delete(db, property);
                        pa.Query.Insert(db, property);
                    }
                    #endregion

                    #region Process Remote Actions
                    lba.ProcessRemoteActions(db, liRemoteActions);
                    #endregion

                    db.CommitTransaction();
                    Log.Info("Транзакция в базу закрыта");
                }
                catch (Exception e)
                {
                    Log.Error("Ошибка при обработке новых данных с главного компьютера", e);
                    Log.Info("Транзакция в базу отменяется...");
                    db.RollbackTransaction();
                    Log.Info("Транзакция в базу отменена");
                    throw;
                }
            }

            diDestination.Delete(true);
        }
        #endregion
    }
}