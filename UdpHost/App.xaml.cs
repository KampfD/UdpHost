using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Diagnostics;

using UdpHost.MVVM.Services;
using UdpHost.MVVM.Views;
using UdpHost.MVVM.ViewModels;
using UdpHost.Properties;

namespace UdpHost
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            string currentProcessName = Process.GetCurrentProcess().ProcessName;
            if (CheckDuplicateApp(currentProcessName))
            {
                MessageBox.Show(
                    "Приложение " + AppDomain.CurrentDomain.FriendlyName + " уже запущено.",
                    currentProcessName,
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                this.Shutdown();
            }
            base.OnStartup(e);
            AppSettings.Load();
            IWindowService windowService = WindowService.Instance;
            windowService.ShowWindow(Modality.Parallel, "MainWindow", new MainWindowViewModel());
        }

        protected override void OnExit(ExitEventArgs e)
        {
            AppSettings.Save();
            base.OnExit(e);
        }

        private bool CheckDuplicateApp(string processName)
        {
            var processes = Process.GetProcesses();
            int identicalProcessesCount = processes.Count(p => p.ProcessName == processName);
            if (identicalProcessesCount > 1) return true;
            else return false;
        }
    }
}
