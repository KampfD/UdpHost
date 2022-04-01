using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace UdpHost.MVVM.Models
{
    class UdpTransceiver : IDisposable
    {
        private UdpClient udpClient;
        private Thread readerThread;

        private byte[] _data = new byte[1024];
        private string _message;
        private string _lastRemoteEndPoint;
        private bool _isServerAlive;

        /// <summary>
        /// Происходит при получении новой датаграммы.
        /// </summary>
        public event EventHandler DataReceived;

        /// <summary>
        /// Происходит при возниковении исключения в сокете.
        /// </summary>
        public event EventHandler ErrorInSocket;

        /// <summary>
        /// Описание последней ошибки в сокете.
        /// </summary>
        public string ErrorInSocketMessage { get; private set; }

        /// <summary>
        /// Получает значение открыт ли сокет.
        /// </summary>
        public bool IsServerAlive
        {
            get { return _isServerAlive; }
            private set { _isServerAlive = value; }
        }

        /// <summary>
        /// Получает атрибуты удалённой точки из последней принятой датаграммы.
        /// </summary>
        public string LastRemoteEndPoint
        {
            get { return _lastRemoteEndPoint; }
            private set { _lastRemoteEndPoint = value; }
        }

        /// <summary>
        /// Получает даные последней принятой датаграммы в виде строки.
        /// </summary>
        public string Message
        {
            get { return _message; }
            private set { _message = value; }
        }

        /// <summary>
        /// Получает даные последней принятой датаграммы в виде байтов.
        /// </summary>
        public byte[] Data
        {
            get { return _data; }
            private set { _data = value; }
        }

        /// <summary>
        /// Открывает UDP-сокет и читает датаграммы.
        /// </summary>
        /// <param name="localAddress">Локальный IP-адрес.</param>
        /// <param name="port">Локальный порт.</param>
        public void Start(string localAddress, int port)
        {
            byte[] octets = localAddress.Split('.').Select(s => Convert.ToByte(s)).ToArray();
            var localIPEndPoint = new IPEndPoint(new IPAddress(octets), port);
            try
            {
                udpClient = new UdpClient(localIPEndPoint);
            }
            catch (SocketException) { throw; }
            readerThread = new Thread(() =>
            {
                IsServerAlive = true;
                while (true)
                {
                    IPEndPoint remoteEndPoint = null;
                    try
                    {
                        Data = udpClient.Receive(ref remoteEndPoint);
                    }
                    catch (SocketException ex)
                    {
                        ErrorInSocketMessage = ex.Message;
                        if (ErrorInSocket != null) ErrorInSocket.Invoke(this, new EventArgs());
                        continue;
                    }
                    Message = Encoding.ASCII.GetString(Data, 0, Data.Length);
                    LastRemoteEndPoint = remoteEndPoint.ToString();
                    if (DataReceived != null) DataReceived(this, new EventArgs());
                }
            });
            readerThread.IsBackground = true;
            readerThread.Start();
        }

        /// <summary>
        /// Закрывает сокет.
        /// </summary>
        public void Stop()
        {
            IsServerAlive = false;
            udpClient.Close();
            if (readerThread.IsAlive == true)
                readerThread.Abort();
        }

        /// <summary>
        /// Отправляет датаграмму с сообщением на удалённый узел.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="remoteAddress">Удалённый IP-адрес.</param>
        /// <param name="port">Удалённый порт.</param>
        /// <returns>Успешность передачи датаграмма.</returns>
        public bool Send(string message, string remoteAddress, int port)
        {
            byte[] data = Encoding.Default.GetBytes(message);
            //var localIPEndPoint = new IPEndPoint(IPAddress.Any, port);
            IPAddress remoteIPAddress = IPAddress.Parse(remoteAddress);
            var remoteIPEndPoint = new IPEndPoint(remoteIPAddress, port);
            int sendedBytesCount;
            try
            {
                sendedBytesCount = udpClient.Send(data, data.Length, remoteIPEndPoint);
            }
            catch (SocketException) { throw; }
            if (sendedBytesCount == data.Length) return true;
            else return false;
        }

        /// <summary>
        /// Отправляет датаграмму с сообщением на удалённый узел.
        /// </summary>
        /// <param name="data">Массив байтов.</param>
        /// <param name="remoteAddress">Удалённый IP-адрес.</param>
        /// <param name="port">Удалённый порт.</param>
        /// <returns>Успешность передачи датаграмма.</returns>
        public bool Send(byte[] data, string remoteAddress, int port)
        {
            //var localIPEndPoint = new IPEndPoint(IPAddress.Any, port);
            IPAddress remoteIPAddress = IPAddress.Parse(remoteAddress);
            var remoteIPEndPoint = new IPEndPoint(remoteIPAddress, port);
            int sendedBytesCount;
            try
            {
                sendedBytesCount = udpClient.Send(data, data.Length, remoteIPEndPoint);
            }
            catch (SocketException) { throw; }
            if (sendedBytesCount == data.Length) return true;
            else return false;
 
        }

        /// <summary>
        /// Очищает ресурсы сокета.
        /// </summary>
        public void Dispose()
        {
            udpClient.Close();
        }
    }
}
