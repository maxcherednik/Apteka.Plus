﻿using System.Collections.Generic;
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.DAL.Accessors
{
    public abstract class RemoteActionAccessor : DataAccessor<RemoteAction>
    {
        private SqlQuery<RemoteAction> _query;
        public SqlQuery<RemoteAction> Query => _query ?? (_query = new SqlQuery<RemoteAction>(DbManager));

        public abstract List<RemoteAction> GetUnsyncedRows();

        public abstract int MarkSyncedBeforeID(long id);

        public abstract long GetMaxRowID();

        public abstract void DeleteAll();

        public abstract int Insert(RemoteAction remoteAction);

        public abstract int Update(long @ID);
    }
}
