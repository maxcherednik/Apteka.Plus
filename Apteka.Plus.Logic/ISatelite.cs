
using System.ServiceModel;
namespace Apteka.Plus.Logic
{
    [ServiceContract]
    public interface ISatelite
    {
        [OperationContract]
        void InsertNewData(int sateliteID, byte[] file);

        [OperationContract]
        byte[] GetSateliteData(int sateliteID);
    }
}
