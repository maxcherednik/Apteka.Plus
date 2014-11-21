using System;
using Microsoft.Win32;

namespace SiccoloWebServiceEventProcessor
{
    /// <summary>
    /// Summary description for NTServiceInfo.
    /// </summary>
    public class NTServiceInfo
    {
        private string m_ServiceName = "";
        private string m_MachineName = "";

        public NTServiceInfo(string NTServiceName, string MachineName)
        {
            m_ServiceName = NTServiceName;
            m_MachineName = MachineName;
        }

        public string PathToExecutable()
        {

            //HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services.
            string RegistryKey = "SYSTEM\\CurrentControlSet\\Services\\" + this.m_ServiceName;
            //string RegistryKey = "HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\" + this.m_ServiceName;

            string ErrorInfo = "";

            string Path = this.ReadRegestryKey(RegistryKey, out ErrorInfo);
            if (Path.IndexOf("%") > 0)
            {
                Path = ExpandEnvironmentString(Path);
            }

            Path = Path.Replace("\"", "");

            return Path;
        }

        private string ExpandEnvironmentString(string Path)
        {
            string SystemRootKey = "Software\\Microsoft\\Windows NT\\CurrentVersion\\";
            RegistryKey Key;

            if (this.m_MachineName != "")
                Key = Microsoft.Win32.RegistryKey.OpenRemoteBaseKey(
                    RegistryHive.LocalMachine, this.m_MachineName
                        ).OpenSubKey(SystemRootKey);
            else
                Key = Registry.LocalMachine.OpenSubKey(SystemRootKey);

            string ExpandedSystemRoot = "";
            ExpandedSystemRoot = Key.GetValue("SystemRoot").ToString();
            Key.Close();

            Path = Path.Replace("%SystemRoot%", ExpandedSystemRoot);

            return Path;
        }

        private string ReadRegestryKey(string RegistryKey, out string ErrorInfo)
        {
            try
            {
                string Value = "";
                ErrorInfo = "";

                RegistryKey Key;
                RegistryKey KeyHKLM = Registry.LocalMachine;
                try
                {
                    if (this.m_MachineName != "")
                        Key = Microsoft.Win32.RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, this.m_MachineName).OpenSubKey(RegistryKey);
                    else
                        Key = KeyHKLM.OpenSubKey(RegistryKey);

                    Value = Key.GetValue("ImagePath").ToString();
                    Key.Close();
                }

                catch (Exception ex_open_key)
                {
                    ErrorInfo = "Error Accessing Registry [" + ex_open_key.ToString() + "]";
                    return "";
                }

                return Value;
            }
            catch (Exception ex_read_registry)
            {
                ErrorInfo = ex_read_registry.Message;
                return "";
            }
        }

    }
}
