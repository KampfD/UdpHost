using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

using UdpHost.MVVM.Models;
using UdpHost.MVVM.Services;

namespace UdpHost.MVVM.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private IWindowService windowService = WindowService.Instance;
        private IDialogService dialogService = new DefaultDialogService();

        private object _currentView;
        private bool _rbExchangeIsChecked = false;
        private RelayCommand _setView;
        private RelayCommand _loaded;
        private RelayCommand _closed;

        public RelayCommand Loaded
        {
            get
            {
                return _loaded ?? (_loaded = new RelayCommand(obj =>
                {
                    ExchangeVM.LocalSocket = UdpHost.Properties.AppSettings.Settings.LocalSocket;
                    ExchangeVM.RemoteSocket = UdpHost.Properties.AppSettings.Settings.RemoteSocket;
                    ExchangeVM.IsDisplayedTime = UdpHost.Properties.AppSettings.Settings.IsDisplayedTime;
                    ExchangeVM.IsDisplayedSourse = UdpHost.Properties.AppSettings.Settings.IsDisplayedSourse;
                    ExchangeVM.IsBytes = UdpHost.Properties.AppSettings.Settings.IsBytes;
                    ExchangeVM.IsParseBytes = UdpHost.Properties.AppSettings.Settings.IsParseBytes;

                }));
            }
        }

        public RelayCommand Closed
        {
            get
            {
                return _closed ?? (_closed = new RelayCommand(obj =>
                {
                    UdpHost.Properties.AppSettings.Settings.LocalSocket = ExchangeVM.LocalSocket;
                    UdpHost.Properties.AppSettings.Settings.RemoteSocket = ExchangeVM.RemoteSocket;
                    UdpHost.Properties.AppSettings.Settings.IsDisplayedTime = (bool)ExchangeVM.IsDisplayedTime;
                    UdpHost.Properties.AppSettings.Settings.IsDisplayedSourse = (bool)ExchangeVM.IsDisplayedSourse;
                    UdpHost.Properties.AppSettings.Settings.IsBytes = (bool)ExchangeVM.IsBytes;
                    UdpHost.Properties.AppSettings.Settings.IsParseBytes = (bool)ExchangeVM.IsParseBytes;
                }));
            }
        }

        public RelayCommand SetView
        {
            get
            {
                return _setView ?? (_setView = new RelayCommand(obj =>
                {
                    string parameter = obj.ToString();
                    switch (parameter)
                    {
                        case "Exchange": CurrentView = ExchangeVM; break;
                        case "Info": CurrentView = InfoVM; break;
                    }
                }));
            }
        }

        public bool RBExchangeIsChecked
        {
            get { return _rbExchangeIsChecked; }
            set { _rbExchangeIsChecked = value; OnPropertyChanged(() => RBExchangeIsChecked); }
        }

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(() => CurrentView); }
        }

        public ExchangeViewModel ExchangeVM { get; set; }
        public InfoViewModel InfoVM { get; set; }

        public MainWindowViewModel()
        {
            ExchangeVM = new ExchangeViewModel();
            InfoVM = new InfoViewModel();

            RBExchangeIsChecked = true;
            SetView.Execute("Exchange");
        }
    }
}
