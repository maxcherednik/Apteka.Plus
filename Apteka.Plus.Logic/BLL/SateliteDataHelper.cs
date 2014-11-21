using System;
using System.Collections.Generic;
using System.IO;
using Apteka.Helpers;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;

namespace Apteka.Plus.Logic.BLL
{
    public class SateliteDataHelper
    {
        private readonly static Logger log = new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Office

        public static string PrepareDataForMyStore(MyStore myStore)
        {

            log.Info("Подготовка данных для отправки в пункт");
            log.InfoFormat("Пункт id: {0} name: {1} ip: {2}", myStore.ID, myStore.Name, myStore.IP);
            DirectoryInfo di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "DataTransfer");
            if (!di.Exists)
                di.Create();

            DirectoryInfo diDate = new DirectoryInfo(di.FullName + "\\" + DateTime.Now.ToShortDateString());
            if (!diDate.Exists)
                diDate.Create();

            using (DbManager dbSatelite = new DbManager(myStore.Name))
            {

                LocalBillsAccessor lba = LocalBillsAccessor.CreateInstance<LocalBillsAccessor>(dbSatelite);
                RemoteActionAccessor raa = RemoteActionAccessor.CreateInstance<RemoteActionAccessor>(dbSatelite);
                EmployeesAccessor ea = EmployeesAccessor.CreateInstance<EmployeesAccessor>(dbSatelite);
                PropertyAccessor pa = PropertyAccessor.CreateInstance<PropertyAccessor>(dbSatelite);
                SalesAccessor sa = SalesAccessor.CreateInstance<SalesAccessor>(dbSatelite);
                LocalBillsTransfersAccessor lbta = LocalBillsTransfersAccessor.CreateInstance<LocalBillsTransfersAccessor>(dbSatelite);
                PriceChangesAccessor pca = PriceChangesAccessor.CreateInstance<PriceChangesAccessor>(dbSatelite);
                SuppliesReturnHistoryAccessor srha = SuppliesReturnHistoryAccessor.CreateInstance<SuppliesReturnHistoryAccessor>(dbSatelite);
                ClientAccessor clientAccessor = ClientAccessor.CreateInstance<ClientAccessor>();

                log.Info("Читаем oLocalBillsRows");
                List<LocalBillsRowEx> liLocalBillsRows = lba.GetUnsyncedRows();
                log.InfoFormat("oLocalBillsRows: {0} позиций", liLocalBillsRows.Count);

                log.Info("Читаем liRemoteActions");
                List<RemoteAction> liRemoteActions = raa.GetUnsyncedRows();
                log.InfoFormat("liRemoteActions: {0} позиций", liRemoteActions.Count);

                log.Info("Читаем liProperties");
                IList<Property> liProperties = pa.GetAllRows();
                log.InfoFormat("liProperties: {0} позиций", liProperties.Count);

                log.Info("Читаем liEmployees");
                List<Employee> liEmployees = ea.GetAllActiveEmployees();
                log.InfoFormat("liEmployees: {0} позиций", liEmployees.Count);

                log.Info("Читаем liMyStores");
                List<MyStore> liMyStores = MyStoresCollection.AllStores;
                log.InfoFormat("liMyStores: {0} позиций", liMyStores.Count);

                log.Info("Читаем Clients");
                List<Client> liClients = clientAccessor.Query.SelectAll();
                log.InfoFormat("liClients: {0} позиций", liClients.Count);

                #region Получение информации по таблицам
                log.Info("Получение информации по таблицам");

                long maxLocalBillsTransferID = lbta.GetMaxRowID();
                long maxSalesRowID = sa.GetMaxRowID();
                long maxPriceChangesRowID = pca.GetMaxRowID();
                long maxSuppliesReturnHistoryRowID = srha.GetMaxRowID();

                log.InfoFormat("maxLocalBillsTransferID: {0}", maxLocalBillsTransferID);
                log.InfoFormat("maxSalesRowID: {0}", maxSalesRowID);
                log.InfoFormat("maxPriceChangesRowID: {0}", maxPriceChangesRowID);
                log.InfoFormat("maxSuppliesReturnHistoryRowID: {0}", maxSuppliesReturnHistoryRowID);

                List<TableInfo> liTablesInfo = new List<TableInfo>(4);

                liTablesInfo.Add(new TableInfo("Sales", maxSalesRowID));
                liTablesInfo.Add(new TableInfo("PriceChanges", maxPriceChangesRowID));
                liTablesInfo.Add(new TableInfo("LocalBillsTransfers", maxLocalBillsTransferID));
                liTablesInfo.Add(new TableInfo("SuppliesReturnHistory", maxSuppliesReturnHistoryRowID));

                #endregion

                log.Info("Сериализация...");
                SerializeHelper.SerializeObjectToFile(liLocalBillsRows, diDate.FullName + "\\LocalBillsRows.xml");
                SerializeHelper.SerializeObjectToFile(liRemoteActions, diDate.FullName + "\\RemoteActions.xml");
                SerializeHelper.SerializeObjectToFile((List<Property>)liProperties, diDate.FullName + "\\Properties.xml");
                SerializeHelper.SerializeObjectToFile(liEmployees, diDate.FullName + "\\Employees.xml");
                SerializeHelper.SerializeObjectToFile(liTablesInfo, diDate.FullName + "\\TablesInfo.xml");
                SerializeHelper.SerializeObjectToFile(liMyStores, diDate.FullName + "\\MyStores.xml");
                SerializeHelper.SerializeObjectToFile(liClients, diDate.FullName + "\\Clients.xml");

            }

            log.Info("Архивация...");
            string archiveName = di.FullName + "\\to" + myStore.ID + ".zip";
            ZipHelper.ZipFile(diDate.FullName, archiveName);

            log.InfoFormat("Результирующий архив: {0}", archiveName);
            return archiveName;
        }

        public static string PrepareDataForInitializeSatelite(MyStore myStore)
        {
            throw new NotImplementedException();
        }

        public static void ProcessNewDataFromSatelite(MyStore myStore, Stream fsStream)
        {
            log.Info("Обработка данных из пункта");
            log.InfoFormat("Пункт id: {0} name: {1} ip: {2}", myStore.ID, myStore.Name, myStore.IP);
            log.Info("Разархивация..");
            DirectoryInfo diDestination = Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Temp\\" + Guid.NewGuid().ToString() + ".ext");
            ZipHelper.Unzip(fsStream, diDestination);

            log.Info("Десериализация");
            List<PriceChangeRow> liPriceChangeRow = SerializeHelper.DeserializeObjectFromFile<List<PriceChangeRow>>(diDestination.FullName + "\\PriceChangeRows.xml");
            List<SalesRow> liSalesRow = SerializeHelper.DeserializeObjectFromFile<List<SalesRow>>(diDestination.FullName + "\\SalesRows.xml");
            List<LocalBillsTransferRow> liLocalBillsTransferRow = SerializeHelper.DeserializeObjectFromFile<List<LocalBillsTransferRow>>(diDestination.FullName + "\\LocalBillsTransferRows.xml");
            List<SuppliesReturnHistoryRow> liSuppliesReturnHistoryRows = SerializeHelper.DeserializeObjectFromFile<List<SuppliesReturnHistoryRow>>(diDestination.FullName + "\\SuppliesReturnHistory.xml");
            List<TableInfo> liTablesInfo = SerializeHelper.DeserializeObjectFromFile<List<TableInfo>>(diDestination.FullName + "\\TablesInfo.xml");

            DbManager dbSatelite = new DbManager(myStore.Name);
            DbManager dbSklad = new DbManager();

            try
            {
                log.Info("Открываем транзакции...");
                dbSatelite.BeginTransaction();
                dbSklad.BeginTransaction();

                LocalBillsAccessor lba = LocalBillsAccessor.CreateInstance<LocalBillsAccessor>(dbSatelite);
                RemoteActionAccessor raa = RemoteActionAccessor.CreateInstance<RemoteActionAccessor>(dbSatelite);
                EmployeesAccessor ea = EmployeesAccessor.CreateInstance<EmployeesAccessor>(dbSatelite);
                PropertyAccessor pa = PropertyAccessor.CreateInstance<PropertyAccessor>(dbSatelite);
                SalesAccessor sa = SalesAccessor.CreateInstance<SalesAccessor>(dbSatelite);
                LocalBillsTransfersAccessor lbta = LocalBillsTransfersAccessor.CreateInstance<LocalBillsTransfersAccessor>(dbSatelite);
                PriceChangesAccessor pca = PriceChangesAccessor.CreateInstance<PriceChangesAccessor>(dbSatelite);
                SuppliesReturnHistoryAccessor srha =
                    SuppliesReturnHistoryAccessor.CreateInstance<SuppliesReturnHistoryAccessor>(dbSatelite);

                #region SalesRows

                long SalesRowMaxID = sa.GetMaxRowID();
                foreach (SalesRow varSalesRow in liSalesRow)
                {
                    if (varSalesRow.ID > SalesRowMaxID)
                    {
                        lba.ChangeAmount(varSalesRow.LocalBillsRow.ID, -1 * varSalesRow.Count);
                        sa.Insert(varSalesRow);
                    }

                }
                #endregion

                #region SuppliesReturnHistoryRows

                long SuppliesReturnHistoryMaxID = srha.GetMaxRowID();
                foreach (SuppliesReturnHistoryRow suppliesReturnHistoryRow in liSuppliesReturnHistoryRows)
                {
                    if (suppliesReturnHistoryRow.ID > SuppliesReturnHistoryMaxID)
                    {
                        lba.ChangeAmount(suppliesReturnHistoryRow.LocalBillsRow.ID, -1 * suppliesReturnHistoryRow.Amount);
                        srha.Insert(suppliesReturnHistoryRow);
                    }
                }

                #endregion

                #region TransferRows

                long LocalBillsTransferRowMaxID = lbta.GetMaxRowID();
                foreach (LocalBillsTransferRow varLocalBillsTransferRow in liLocalBillsTransferRow)
                {
                    if (varLocalBillsTransferRow.ID > LocalBillsTransferRowMaxID)
                    {
                        lba.ChangeAmount(varLocalBillsTransferRow.LocalBillsRow.ID, -1 * varLocalBillsTransferRow.Count);
                        lbta.Insert(varLocalBillsTransferRow);

                    }

                }
                #endregion

                #region PriceChangesRows

                long PriceChangesRowMaxID = pca.GetMaxRowID();
                foreach (PriceChangeRow varPriceChangeRow in liPriceChangeRow)
                {
                    if (varPriceChangeRow.ID > PriceChangesRowMaxID)
                    {
                        pca.Insert(varPriceChangeRow);
                        lba.UpdatePrice(varPriceChangeRow.LocalBillsRowID, varPriceChangeRow.NewPrice);

                    }
                }
                #endregion

                #region Очитска
                foreach (TableInfo tableInfo in liTablesInfo)
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

                log.Info("Завершаем транзакции...");
                dbSatelite.CommitTransaction();
                dbSklad.CommitTransaction();

            }
            catch (Exception e)
            {
                log.Error("Ошибка при обработке данных из пункта " + myStore.ID, e);
                log.Info("Откатываем транзакции...");
                dbSatelite.RollbackTransaction();
                dbSklad.RollbackTransaction();

                throw e;
            }

            log.InfoFormat("Удаляем директорию {0}", diDestination.Name);
            diDestination.Delete(true);
        }

        #endregion

        #region Satelite

        public static string PrepareDataFromSateliteToBase()
        {
            log.Info("Подготовка данных для выгрузки на главный компьютер");

            DirectoryInfo di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Download");
            if (!di.Exists)
                di.Create();

            string pathToArchiveName = Guid.NewGuid().ToString();
            DirectoryInfo diPathToArchive = new DirectoryInfo(di.FullName + "\\" + pathToArchiveName);
            diPathToArchive.Create();
            log.InfoFormat("Создана директория {0}", diPathToArchive.Name);

            List<PriceChangeRow> liPriceChangeRow = null;
            List<SalesRow> liSalesRow = null;
            List<LocalBillsTransferRow> liLocalBillsTransferRow = null;
            List<SuppliesReturnHistoryRow> liSuppliesReturnHistoryRows = null;
            List<TableInfo> liTableInfos = new List<TableInfo>();

            using (DbManager db = new DbManager())
            {
                try
                {
                    db.BeginTransaction();
                    log.Info("Транзакция в базу открыта");

                    log.Info("Подготовка данных");
                    LocalBillsAccessor lba = LocalBillsAccessor.CreateInstance<LocalBillsAccessor>(db);
                    PriceChangesAccessor pca = PriceChangesAccessor.CreateInstance<PriceChangesAccessor>(db);
                    SalesAccessor sa = SalesAccessor.CreateInstance<SalesAccessor>(db);
                    LocalBillsTransfersAccessor lbta = LocalBillsTransfersAccessor.CreateInstance<LocalBillsTransfersAccessor>(db);
                    RemoteActionAccessor raa = RemoteActionAccessor.CreateInstance<RemoteActionAccessor>(db);

                    SuppliesReturnHistoryAccessor srha = SuppliesReturnHistoryAccessor.CreateInstance<SuppliesReturnHistoryAccessor>(db);

                    liPriceChangeRow = pca.GetUnsyncedRows();
                    liSalesRow = sa.GetUnsyncedRows();
                    liLocalBillsTransferRow = lbta.GetUnsyncedRows();
                    liSuppliesReturnHistoryRows = srha.GetUnsyncedRows();

                    long maxLocalBillsRowID = lba.GetMaxRowID();
                    long lastRemoteActionID = raa.GetMaxRowID();

                    liTableInfos.Add(new TableInfo("LocalBillsMaxRowID", maxLocalBillsRowID));
                    liTableInfos.Add(new TableInfo("RemoteActionsMaxID", lastRemoteActionID));

                    db.CommitTransaction();
                    log.Info("Транзакция в базу закрыта");

                }
                catch (Exception e)
                {
                    log.Error("Ошибка при подготовке данных из пункта в центральную базу", e);
                    log.Info("Транзакция в базу отменяется...");
                    db.RollbackTransaction();
                    log.Info("Транзакция в базу отменена");
                    throw e;
                }

                log.Info("Сериализация данных...");
                SerializeHelper.SerializeObjectToFile(liPriceChangeRow, diPathToArchive.FullName + "\\PriceChangeRows.xml");
                SerializeHelper.SerializeObjectToFile(liSalesRow, diPathToArchive.FullName + "\\SalesRows.xml");
                SerializeHelper.SerializeObjectToFile(liLocalBillsTransferRow, diPathToArchive.FullName + "\\LocalBillsTransferRows.xml");
                SerializeHelper.SerializeObjectToFile(liTableInfos, diPathToArchive.FullName + "\\TablesInfo.xml");
                SerializeHelper.SerializeObjectToFile(liSuppliesReturnHistoryRows, diPathToArchive.FullName + "\\SuppliesReturnHistory.xml");

                log.Info("Архивация...");
                string zipSateliteData = di.FullName + "\\" + pathToArchiveName + ".zip";
                ZipHelper.ZipFile(diPathToArchive.FullName, zipSateliteData);
                log.InfoFormat("Создан архив {0}", zipSateliteData);

                diPathToArchive.Delete(true);
                log.InfoFormat("Удалена директория {0}", diPathToArchive.Name);

                return zipSateliteData;

            }
        }

        public static void InsertNewData(Stream fileStream)
        {
            log.Info("Обработка новых данных с главного компьютера");

            log.Info("Разархивация..");
            DirectoryInfo diDestination = Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Temp\\" + Guid.NewGuid().ToString() + ".ext");
            ZipHelper.Unzip(fileStream, diDestination);

            log.Info("Десериализация данных...");
            List<LocalBillsRowEx> liLocalBillRows = SerializeHelper.DeserializeObjectFromFile<List<LocalBillsRowEx>>(diDestination.FullName + "\\LocalBillsRows.xml");
            List<RemoteAction> liRemoteActions = SerializeHelper.DeserializeObjectFromFile<List<RemoteAction>>(diDestination.FullName + "\\RemoteActions.xml");
            List<Employee> liEmployees = SerializeHelper.DeserializeObjectFromFile<List<Employee>>(diDestination.FullName + "\\Employees.xml");
            List<Property> liProperties = SerializeHelper.DeserializeObjectFromFile<List<Property>>(diDestination.FullName + "\\Properties.xml");
            List<TableInfo> liTablesInfo = SerializeHelper.DeserializeObjectFromFile<List<TableInfo>>(diDestination.FullName + "\\TablesInfo.xml");
            List<MyStore> liMyStores = SerializeHelper.DeserializeObjectFromFile<List<MyStore>>(diDestination.FullName + "\\MyStores.xml");
            List<Client> liClients = SerializeHelper.DeserializeObjectFromFile<List<Client>>(diDestination.FullName + "\\Clients.xml");

            using (DbManager db = new DbManager())
            {
                try
                {
                    db.BeginTransaction();
                    log.Info("Транзакция в базу открыта");

                    MainStoreRowsAccessor msra = MainStoreRowsAccessor.CreateInstance<MainStoreRowsAccessor>(db);
                    LocalBillsAccessor lba = LocalBillsAccessor.CreateInstance<LocalBillsAccessor>(db);
                    PropertyAccessor pa = PropertyAccessor.CreateInstance<PropertyAccessor>(db);
                    EmployeesAccessor ea = EmployeesAccessor.CreateInstance<EmployeesAccessor>(db);
                    TablesInfoAccessor tia = TablesInfoAccessor.CreateInstance<TablesInfoAccessor>(db);
                    RemoteActionAccessor ra = RemoteActionAccessor.CreateInstance<RemoteActionAccessor>(db);
                    MyStoresAccessor msa = MyStoresAccessor.CreateInstance<MyStoresAccessor>(db);
                    FullProductInfoAccessor fpia = FullProductInfoAccessor.CreateInstance<FullProductInfoAccessor>(db);
                    SuppliersAccessor supa = SuppliersAccessor.CreateInstance<SuppliersAccessor>(db);
                    ClientAccessor clientAccessor = ClientAccessor.CreateInstance<ClientAccessor>(db);

                    #region Update Clients

                    List<Client> liSateliteClients = clientAccessor.Query.SelectAll();
                    foreach (Client client in liSateliteClients)
                    {
                        Client clientFind = liClients.Find(delegate(Client c)
                        {
                            return c.Id == client.Id;
                        });

                        log.InfoFormat("Client id: {0} discount: {1}", client.Id, client.Discount);

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
                    foreach (Client client in liClients)
                    {
                        Client clientFind = liSateliteClients.Find(delegate(Client c)
                        {
                            return c.Id == client.Id;
                        });

                        log.InfoFormat("Client id: {0} discount: {1}", client.Id, client.Discount);

                        if (clientFind == null)
                        {
                            clientAccessor.Query.Insert(client);
                        }

                    }

                    #endregion

                    #region Update MyStores

                    foreach (MyStore myStore in liMyStores)
                    {
                        log.InfoFormat("MyStore : {0} value: {1}", myStore.ID, myStore.Name);

                        MyStore myStoreFind = msa.Query.SelectByKey(db, myStore.ID);
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

                    #region Update Dictionaries
                    List<FullProductInfo> liFullProductInfos = new List<FullProductInfo>();
                    List<Supplier> liSuppliers = new List<Supplier>();
                    List<MainStoreRow> liMainStoreRows = new List<MainStoreRow>();

                    if (liLocalBillRows.Count > 0)
                    {
                        long LocalBillsMaxRowID = lba.GetMaxRowID();

                        foreach (LocalBillsRowEx localBillsRow in liLocalBillRows)
                        {
                            if (localBillsRow.ID > LocalBillsMaxRowID)
                            {
                                if (!liFullProductInfos.Contains(localBillsRow.MainStoreRow.FullProductInfo))
                                {
                                    FullProductInfo fpi = fpia.SelectByKey(localBillsRow.MainStoreRow.FullProductInfo.ID);
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
                                    Supplier supplier = supa.Query.SelectByKey(db, localBillsRow.MainStoreRow.Supplier.ID);
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
                                    MainStoreRow mainStoreRow = msra.GetRowByID(localBillsRow.MainStoreRow.ID);
                                    if (mainStoreRow == null)
                                    {
                                        msra.Insert(localBillsRow.MainStoreRow);
                                    }
                                    //else if (!supplier.Equals(localBillsRow.MainStoreRow.Supplier))
                                    //{
                                    //    supa.Query.Update(localBillsRow.MainStoreRow.Supplier);
                                    //}

                                    liMainStoreRows.Add(localBillsRow.MainStoreRow);
                                }

                                lba.Insert(localBillsRow);
                            }

                        }
                    }
                    #endregion

                    #region Update Employees

                    foreach (Employee employee in liEmployees)
                    {
                        Employee employeeFind = ea.Query.SelectByKey(db, employee.ID);
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
                    foreach (Property property in liProperties)
                    {
                        log.InfoFormat("Параметр: {0} value: {1}", property.Name, property.Value);
                        pa.Query.Delete(db, property);
                        pa.Query.Insert(db, property);
                    }
                    #endregion

                    #region Process Remote Actions
                    lba.ProcessRemoteActions(db, liRemoteActions);
                    #endregion

                    db.CommitTransaction();
                    log.Info("Транзакция в базу закрыта");
                }
                catch (Exception e)
                {
                    log.Error("Ошибка при обработке новых данных с главного компьютера", e);
                    log.Info("Транзакция в базу отменяется...");
                    db.RollbackTransaction();
                    log.Info("Транзакция в базу отменена");
                    throw e;
                }

            }

            diDestination.Delete(true);
        }
        #endregion
    }
}

