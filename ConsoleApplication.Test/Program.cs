using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Apteka.Plus.Satelite.Logic;
using Apteka.Plus.Logic;
using System.ServiceModel;
using System.IO;

namespace ConsoleApplication.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new WCFServer<SateliteServer>();
            server.Start();
            
            
            ChannelFactory<ISatelite> fact = new ChannelFactory<ISatelite>("SateliteServer");
            var endpoint = new EndpointAddress("net.tcp://localhost:7879/SateliteServer");
            fact.Endpoint.Address = endpoint;
            ISatelite mgr = fact.CreateChannel();
            byte[] data = mgr.GetSateliteData(0);
            
            Console.ReadLine();
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

    }
}
