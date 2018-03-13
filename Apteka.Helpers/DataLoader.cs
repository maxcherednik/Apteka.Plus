using System;
using System.ComponentModel;
using System.Threading;

namespace Apteka.Helpers
{
    public class DataLoader<TResult>
    {
        private readonly BackgroundWorker _bgwDataLoader;
        private bool _needRequery;
        private readonly Func<TResult> _dataSource;
        private readonly int _timeoutInMilliseconds;
        private readonly SynchronizationContext _syncContext;
        private TimeSpan _previousRequestTime = TimeSpan.MaxValue;

        public DataLoader(Func<TResult> dataSource, int timeoutInMilliseconds)
        {
            _syncContext = SynchronizationContext.Current;
            _dataSource = dataSource;
            _timeoutInMilliseconds = timeoutInMilliseconds;
            _bgwDataLoader = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };

            _bgwDataLoader.DoWork += _bgwDataLoader_DoWork;
            _bgwDataLoader.RunWorkerCompleted += _bgwDataLoader_RunWorkerCompleted;
        }

        private void _bgwDataLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
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

        private void _bgwDataLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            var startTime = DateTime.Now;
            var worker = (BackgroundWorker)sender;

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

        public object SyncRoot { get; } = new object();

        public event EventHandler<RequestCompletedEventArgs> RequestCompleted;

        protected virtual void OnRequestCompleted(TResult liResults)
        {
            RequestCompleted?.Invoke(this, new RequestCompletedEventArgs(liResults));
        }

        public class RequestCompletedEventArgs : EventArgs
        {
            public RequestCompletedEventArgs(TResult results)
            {
                Results = results;
            }

            public TResult Results { get; }
        }

        public event EventHandler<ErrorGeneratedEventArgs> ErrorGenerated;

        protected virtual void OnErrorGenerated(Exception exc)
        {
            ErrorGenerated?.Invoke(this, new ErrorGeneratedEventArgs(exc));
        }

        public class ErrorGeneratedEventArgs : EventArgs
        {
            public ErrorGeneratedEventArgs(Exception exc)
            {
                Exception = exc;
            }

            public Exception Exception { get; }
        }

        public event EventHandler<ItsGonnaTakeAWhileEventArgs> ItsGonnaTakeAWhile;

        protected virtual void OnItsGonnaTakeAWhile()
        {
            var itsGonnaTakeAWhile = ItsGonnaTakeAWhile;
            if (itsGonnaTakeAWhile != null)
            {
                _syncContext.Post(obj =>
                {
                    itsGonnaTakeAWhile(this, new ItsGonnaTakeAWhileEventArgs());
                }, null);
            }
        }

        public class ItsGonnaTakeAWhileEventArgs : EventArgs { }
    }
}
