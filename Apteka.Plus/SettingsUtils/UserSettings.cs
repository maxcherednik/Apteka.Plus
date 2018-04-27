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

            return dictIps.TryGetValue(id, out var ip) ? ip : string.Empty;
        }

        public static Dictionary<int, string> GetAllOverridedIps()
        {
            var dictIps = new Dictionary<int, string>();
            var ips = Settings.Default.OverridedIPs;
            if (string.IsNullOrEmpty(ips)) return dictIps;
            var items = ips.Split(new[] { ";;" }, StringSplitOptions.None);

            if (items.Length == 1 && items[0].Length == 0) return dictIps;
            foreach (var item in items)
            {
                var idIp = item.Split(';');
                dictIps.Add(int.Parse(idIp[0]), idIp[1]);
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
