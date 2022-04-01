using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UdpHost.MVVM.Models;
using UdpHost.MVVM.Services;

namespace UdpHost.MVVM.ViewModels
{
    public class InfoViewModel : ObservableObject
    {
        private NetworkScanner scanner = new NetworkScanner();
        private string _infoText;
        private RelayCommand _loaded;

        public string InfoText
        {
            get { return _infoText; }
            set { _infoText = value; OnPropertyChanged(() => InfoText); }
        }

        public RelayCommand Loaded
        {
            get
            {
                return _loaded ?? (_loaded = new RelayCommand(obj =>
                {
                    string hostName = scanner.GetHostName();
                    var list = scanner.GetCurrentIPAddres();
                    string infoStr = String.Empty;
                    infoStr = "Имя локального хоста: " + hostName + "\n" +
                               "IP-адреса хоста:" + "\n";
                    foreach (var item in list)
                    {
                        infoStr += "    " + item + "\n";
                    }
                    InfoText = infoStr;
                }));
            }
        }
    }
}
