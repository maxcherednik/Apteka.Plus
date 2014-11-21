using System;
using System.ComponentModel;
using System.Threading;

namespace Apteka.Helpers
{
    public class DataLoader<TResult>
    {
        #region Private fields
        private BackgroundWorker _bgwDataLoader;
        private bool _needRequery;
        private Func<TResult> _dataSource;
        private readonly object _syncRoot = new object();
        private int _timeoutInMilliseconds;
        private SynchronizationContext _syncContext;
        private TimeSpan _previousRequestTime = TimeSpan.MaxValue;
        #endregion

        #region Constructor
        public DataLoader(Func<TResult> dataSource, int timeoutInMilliseconds)
        {
            _syncContext = SynchronizationContext.Current;
            _dataSource = dataSource;
            _timeoutInMilliseconds = timeoutInMilliseconds;
            _bgwDataLoader = new BackgroundWorker();
            _bgwDataLoader.WorkerSupportsCancellation = true;
            _bgwDataLoader.DoWork += new DoWorkEventHandler(_bgwDataLoader_DoWork);
            _bgwDataLoader.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bgwDataLoader_RunWorkerCompleted);
        }
        #endregion

        #region Backgroundworker handlers
        void _bgwDataLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (e.Cancelled || worker.CancellationPending)// we only cancel when we need to start another search 
            {
                MakeRequest();
            }
            else if (e.Error != null) // we've got error here 
            {
                OnErrorGenerated(e.Error);
            }
            else // we are finished 
            {

                OnRequestCompleted((TResult)e.Result);

                if (_needRequery)
                {
                    _needRequery = false;
                    MakeRequest();
                }
            }
        }

        void _bgwDataLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            var startTime = DateTime.Now;
            BackgroundWorker worker = sender as BackgroundWorker;

            var asyncResult = _dataSource.BeginInvoke(null, null);
            if (_previousRequestTime.TotalMilliseconds > _timeoutInMilliseconds)
            {
                OnItsGonnaTakeAWhile();
            }
            else
            {
                if (!asyncResult.AsyncWaitHandle.WaitOne(_timeoutInMilliseconds))
                {
                    OnItsGonnaTakeAWhile();
                }
            }

            e.Result = _dataSource.EndInvoke(asyncResult);
            _previousRequestTime = DateTime.Now - startTime;
            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region Public methods
        public void MakeRequest()
        {
            if (_bgwDataLoader.IsBusy)
            {
                _needRequery = true;
                _bgwDataLoader.CancelAsync();

            }
            else
            {
                _bgwDataLoader.RunWorkerAsync();
            }
        }
        #endregion

        #region Public properties
        public object SyncRoot
        {
            get { return _syncRoot; }
        }
        #endregion

        #region Events
        #region RequestCompleted
        public event EventHandler<RequestCompletedEventArgs> RequestCompleted;

        protected virtual void OnRequestCompleted(TResult liResults)
        {
            if (RequestCompleted != null)
            {
                RequestCompleted(this, new RequestCompletedEventArgs(liResults));
            }
        }

        public class RequestCompletedEventArgs : EventArgs
        {
            public RequestCompletedEventArgs(TResult Results)
            {
                this.Results = Results;
            }
            public TResult Results { get; private set; }
        }
        #endregion

        #region ErrorGenerated
        public event EventHandler<ErrorGeneratedEventArgs> ErrorGenerated;

        protected virtual void OnErrorGenerated(Exception exc)
        {
            if (ErrorGenerated != null)
            {
                ErrorGenerated(this, new ErrorGeneratedEventArgs(exc));
            }
        }

        public class ErrorGeneratedEventArgs : EventArgs
        {
            public ErrorGeneratedEventArgs(Exception exc)
            {
                this.Exception = exc;
            }
            public Exception Exception { get; private set; }
        }
        #endregion

        #region It's gonna take a while event
        public event EventHandler<ItsGonnaTakeAWhileEventArgs> ItsGonnaTakeAWhile;

        protected virtual void OnItsGonnaTakeAWhile()
        {
            var itsGonnaTakeAWhile = ItsGonnaTakeAWhile;
            if (itsGonnaTakeAWhile != null)
            {
                _syncContext.Post(obj =>
                {
                    itsGonnaTakeAWhile(this, new ItsGonnaTakeAWhileEventArgs());
                },null);
            }
        }

        public class ItsGonnaTakeAWhileEventArgs : EventArgs { }
        #endregion

        #endregion

    }
}
