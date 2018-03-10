using System;
using Microsoft.Win32;

namespace SiccoloWebServiceEventProcessor
{
    /// <summary>
    /// Summary description for NTServiceInfo.
    /// </summary>
    public class NTServiceInfo
    {
        private string _serviceName = "";
        private string _machineName = "";

        public NTServiceInfo(string NTServiceName, string machineName)
        {
            _serviceName = NTServiceName;
            _machineName = machineName;
        }

        public string PathToExecutable()
        {
            //HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services.
            string RegistryKey = "SYSTEM\\CurrentControlSet\\Services\\" + _serviceName;
            //string RegistryKey = "HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\" + this.m_ServiceName;


            string Path = ReadRegestryKey(RegistryKey, out string ErrorInfo);
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

            if (_machineName != "")
                Key = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, _machineName).OpenSubKey(SystemRootKey);
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
                    if (_machineName != "")
                        Key = Microsoft.Win32.RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, this._machineName).OpenSubKey(RegistryKey);
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
