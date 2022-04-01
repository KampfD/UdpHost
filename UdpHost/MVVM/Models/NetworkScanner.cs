using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace UdpHost.MVVM.Models
{
    class NetworkScanner
    {
        /// <summary>
        /// Возвращает имя локального хоста.
        /// </summary>
        /// <returns>Имя локального хоста.</returns>
        public string GetHostName()
        {
            return Dns.GetHostName();
        }

        /// <summary>
        /// Возвращает список активных IP-адресов локального хоста.
        /// </summary>
        /// <returns>Список активных IP-адресов.</returns>
        public List<string> GetCurrentIPAddres()
        {
            string host = GetHostName();
            return Dns.GetHostAddresses(host).Select(ip => ip.ToString()).ToList();
        }
    }
}
