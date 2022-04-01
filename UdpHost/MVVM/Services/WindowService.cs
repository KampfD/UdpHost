using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Reflection;

using UdpHost.MVVM.Views;

namespace UdpHost.MVVM.Services
{
    /// <summary>
    /// Реализует сервис управления окнами в приложении.
    /// </summary>
    internal class WindowService : IWindowService
    {        
        // Хранит имя сборки
        private string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

        #region Singleton
        private static WindowService _instance;
        private static readonly object syncRoot = new Object();

        protected WindowService() { }

        /// <summary>
        /// Получает единственный экземпляр класса WindowService.
        /// </summary>
        public static WindowService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        return _instance ?? (_instance = new WindowService());
                    }
                }
                return _instance;
            }
        }
        #endregion

        #region Реализация IWindowService
        public void ShowWindow(Modality modality, string windowName, object viewModel)
        {
            if (CheckWindowExistence(windowName))
                throw new ArgumentException("Такое окно уже открыто.", "windowName");
            Type type = Type.GetType(assemblyName + ".MVVM.Views." + windowName);
            if (type == null)
                throw new ArgumentException("Указанное имя не является именем представления.", "windowName");
            Window window = Activator.CreateInstance(type) as Window;
            window.DataContext = viewModel;
            if (modality == Modality.Modal)
                window.ShowDialog();
            else
                window.Show();
        }

        public void ShowWindow(Modality modality, string windowName, string windowOwnerName, object viewModel)
        {
            if (CheckWindowExistence(windowName))
                throw new ArgumentException("Такое окно уже открыто.", "windowName");
            Type type = Type.GetType(assemblyName +".MVVM.Views."+ windowName);
            if (type == null)
                throw new ArgumentException("Указанное имя не является именем представления.", "windowName");
            Window window = Activator.CreateInstance(type) as Window;
            window.DataContext = viewModel;
            Window ownerWindow = GetWindow(windowOwnerName);
            if (ownerWindow != null)
            {
                window.Owner = ownerWindow;
                if (modality == Modality.Modal)
                    window.ShowDialog();
                else
                    window.Show();
            }
            else throw new ArgumentException("Окна-владельца с таким именем не существует.", "windowOwnerName");
        }

        public void ShowWindowWithActiveOwner(Modality modality, string windowName, object viewModel)
        {
            if (CheckWindowExistence(windowName))
                throw new ArgumentException("Такое окно уже открыто.", "windowName");
            Type type = Type.GetType(assemblyName + ".MVVM.Views." + windowName);
            if (type == null)
                throw new ArgumentException("Указанное имя не является именем представления.", "windowName");
            Window window = Activator.CreateInstance(type) as Window;
            Window ownerWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            window.DataContext = viewModel;
            window.Owner = ownerWindow;
            if (modality == Modality.Modal) 
                window.ShowDialog();
            else 
                window.Show();
        }

        public void CloseWindow(string windowName)
        {
            Window window = GetWindow(windowName);
            if (window != null) window.Close();
            else throw new ArgumentException("Окно с таким именем не было открыто или не существует.", "windowName");
        }

        public bool CheckWindowExistence(string windowName)
        {
            string fullName = assemblyName + ".MVVM.Views." + windowName;
            return Application.Current.Windows.OfType<Window>().Any(w => w.ToString() == fullName);
        }
        #endregion

        // Возвращает окно с указанным именем из списка открытых окнон в приложении.
        private Window GetWindow(string windowName)
        {
            try
            {
                return Application.Current.Windows.OfType<Window>().SingleOrDefault(w =>
                {
                    string[] fullNameSegments = w.ToString().Split('.');
                    string name = fullNameSegments[fullNameSegments.Length - 1];
                    if (name == windowName) return true;
                    else return false;
                });
            }
            // Найдено более одного окна.
            catch (InvalidOperationException) { throw; }
        }
    }
}
