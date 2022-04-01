using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace UdpHost.MVVM.Services
{
    /// <summary>
    /// Реализует интерфейс INotifyPropertyChanged.
    /// </summary>
    internal abstract class PropertyChangedBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Происходит изменении свойства.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Уведомляет привязанные объекты об изменении свойства.
        /// </summary>
        /// <param name="propertyName">Имя изменённого свойства.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
