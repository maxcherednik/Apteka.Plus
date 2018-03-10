using System;
using System.Collections.Generic;
using Apteka.Plus.Properties;

namespace Apteka.Plus.SettingsUtils
{
    public class UserSettings
    {

        public static string GetOverridedIpById(int id)
        {
            var dictIps = GetAllOverridedIps();

            string ip = string.Empty;
            dictIps.TryGetValue(id, out ip);

            return ip;
        }

        public static Dictionary<int, string> GetAllOverridedIps()
        {
            Dictionary<int, String> dictIps = new Dictionary<int, string>();
            var ips = Settings.Default.OverridedIPs;
            if (string.IsNullOrEmpty(ips)) return dictIps;
            var items = ips.Split(new string[] { ";;" }, StringSplitOptions.None);

            if (items.Length == 1 && items[0].Length == 0) return dictIps;
            foreach (var item in items)
            {
                var id_ip = item.Split(';');
                dictIps.Add(int.Parse(id_ip[0]), id_ip[1]);
            }

            return dictIps;
        }

        internal static void SaveOverridedIps(Dictionary<int, string> dictIps)
        {
            string ips = null;
            foreach (var item in dictIps)
            {
                ips += item.Key + ";" + item.Value + ";;";
            }

            if (!string.IsNullOrEmpty(ips))
                ips = ips.Remove(ips.Length - 2);

            Settings.Default.OverridedIPs = ips;
            Settings.Default.Save();
        }
    }
}
