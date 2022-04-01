using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UdpHost.MVVM.Models;
using UdpHost.MVVM.Services;

namespace UdpHost.MVVM.ViewModels
{
    public class ExchangeViewModel : ObservableObject
    {
        private IDialogService dialogService = new DefaultDialogService();
        private UdpTransceiver udpServer = new UdpTransceiver();
        private System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

        private string _serverSocketButtonContent = "Открыть";
        private string _localSocket;
        private string _remoteSocket;
        private string _receivedData = String.Empty;
        private string _transmitData = String.Empty;
        private bool _isServerAlive;
        private bool? _isDisplayedTime = false;
        private bool? _isDisplayedSourse = false;
        private bool? _isBytes = false;
        private bool? _isParseBytes = false;
        private List<string> messageList = new List<string>();

        private RelayCommand _openCloseServerSocket;
        private RelayCommand _send;
        private RelayCommand _clearText;

        public RelayCommand ClearText
        {
            get
            {
                return _clearText ?? (_clearText = new RelayCommand(obj =>
                {
                    switch (obj.ToString())
                    {
                        case "Transmit": 
                            TransmitData = String.Empty; 
                            break;
                        case "Receive":
                            messageList.Clear();
                            ReceivedData = String.Empty; 
                            break;
                    }
                }));
            }
        }

        public RelayCommand Send
        {
            get
            {
                return _send ?? (_send = new RelayCommand(obj =>
                {
                    string[] attributes = obj.ToString().Split(':');
                    if (IsParseBytes == false)
                    {
                        try
                        {
                            udpServer.Send(TransmitData, attributes[0], Int32.Parse(attributes[1]));
                        }
                        catch (System.Net.Sockets.SocketException se)
                        {
                            dialogService.ShowMessage(MessageType.Error, se.Message, "Ошибка сокета");
                        }
                    }
                    else
                    {
                        string[] words = TransmitData.Split(' ')
                            .Where(w => w[0] == '0' && w[1] == 'x')
                            .Select(w => w.Substring(2, w.Length - 2))
                            .ToArray();
                        byte b;
                        byte[] data = new byte[0];
                        for (int i = 0; i < words.Length; i++)
                        {
                            try
                            {
                                b = Byte.Parse(words[i], System.Globalization.NumberStyles.HexNumber);
                            }
                            catch (FormatException) { continue; }
                            Array.Resize(ref data, data.Length + 1);
                            data[data.Length - 1] = b;
                        }
                        try
                        {
                            udpServer.Send(data, attributes[0], Int32.Parse(attributes[1]));
                        }
                        catch (System.Net.Sockets.SocketException se)
                        {
                            dialogService.ShowMessage(MessageType.Error, se.Message, "Ошибка сокета");
                        }
                    }
                }));
            }
        }

        public RelayCommand OpenCloseServerSocket
        {
            get
            {
                return _openCloseServerSocket ?? (_openCloseServerSocket = new RelayCommand(obj =>
                {
                    if (!udpServer.IsServerAlive)
                    {
                        string[] attributes = obj.ToString().Split(':');
                        try
                        {
                            udpServer.Start(attributes[0], Int32.Parse(attributes[1]));
                        }
                        catch (System.Net.Sockets.SocketException se)
                        {
                            dialogService.ShowMessage(MessageType.Error, se.Message, "Ошибка сокета");
                        }
                        //udpServer.Start("172.16.101.114", 9000);
                        //udpServer.Start("192.168.0.103", 9000);
                    }
                    else
                    {
                        udpServer.Stop();
                    }
                    Task.Factory.StartNew(() =>
                    {
                        System.Threading.Thread.Sleep(10);
                        if (udpServer.IsServerAlive)
                        {
                            ServerSocketButtonContent = "Закрыть";
                            IsServerAlive = true;
                        }
                        else
                        {
                            ServerSocketButtonContent = "Открыть";
                            IsServerAlive = false;
                        }
                    });
                }));
            }
        }

        public bool? IsParseBytes
        {
            get { return _isParseBytes; }
            set { _isParseBytes = value; OnPropertyChanged(() => IsParseBytes); }
        }

        public bool? IsBytes
        {
            get { return _isBytes; }
            set { _isBytes = value; OnPropertyChanged(() => IsBytes); }
        }

        public bool? IsDisplayedSourse
        {
            get { return _isDisplayedSourse; }
            set { _isDisplayedSourse = value; OnPropertyChanged(() => IsDisplayedSourse); }
        }

        public bool? IsDisplayedTime
        {
            get { return _isDisplayedTime; }
            set 
            {
                stopwatch.Restart();
                _isDisplayedTime = value; 
                OnPropertyChanged(() => IsDisplayedTime); 
            }
        }

        public bool IsServerAlive
        {
            get { return _isServerAlive; }
            set { _isServerAlive = value; OnPropertyChanged(() => IsServerAlive); }
        }

        public string TransmitData
        {
            get { return _transmitData; }
            set { _transmitData = value; OnPropertyChanged(() => TransmitData); }
        }

        public string ReceivedData
        {
            get { return _receivedData; }
            set { _receivedData = value; OnPropertyChanged(() => ReceivedData); }
        }

        public string RemoteSocket
        {
            get { return _remoteSocket; }
            set { _remoteSocket = value; OnPropertyChanged(() => RemoteSocket); }
        }

        public string LocalSocket
        {
            get { return _localSocket; }
            set { _localSocket = value; OnPropertyChanged(() => LocalSocket); }
        }

        public string ServerSocketButtonContent
        {
            get { return _serverSocketButtonContent; }
            set { _serverSocketButtonContent = value; OnPropertyChanged(() => ServerSocketButtonContent); }
        }

        public ExchangeViewModel()
        {
            udpServer.DataReceived += OnServerDataReceived;
            udpServer.ErrorInSocket += OnErrorInSocket;
        }

        void OnServerDataReceived(object sender, EventArgs e)
        {
            var server = sender as UdpTransceiver;
            string message = String.Empty;
            if (IsDisplayedSourse == true) message += String.Format("[{0}] ", server.LastRemoteEndPoint);
            if (IsDisplayedTime == true) message += String.Format("{0:HH:mm:ss.fff}", DateTime.Now);
            if (IsDisplayedSourse == true || IsDisplayedTime == true) message += " --> ";

            if (IsBytes == false) message += server.Message;
            else foreach (var item in server.Data) message += String.Format("0x{0} ", item.ToString("X2"));

            messageList.Add(message);
            string outStr = String.Empty;
            foreach (var item in messageList) outStr += item + "\n";
            ReceivedData = outStr;
        }

        void OnErrorInSocket(object sender, EventArgs e)
        {
            dialogService.ShowMessage(
                MessageType.Information,
                (sender as UdpTransceiver).ErrorInSocketMessage,
                "Ошибка в сокете");
        }
    }
}
