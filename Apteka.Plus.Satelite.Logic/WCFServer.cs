
using System.ServiceModel;
using Apteka.Helpers;
namespace Apteka.Plus.Satelite.Logic
{
    public class WCFServer<T>
    {
        private readonly static Logger log = new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static ServiceHost _customerServiceHost;

        public void Start()
        {
            _customerServiceHost = new ServiceHost(typeof(T));
            _customerServiceHost.Open();

            foreach (var item in _customerServiceHost.ChannelDispatchers)
            {
                log.InfoFormat("Server address: {0}", item.Listener.Uri);
            }
        }

        public void Stop()
        {
            _customerServiceHost.Close();
        }
    }
}
