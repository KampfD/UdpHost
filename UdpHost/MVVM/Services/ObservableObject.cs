using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.ComponentModel;

namespace UdpHost.MVVM.Services
{
    /// <summary>
    /// Реализует сервис уведомлений объектов-подписчиков об изменении свойства.
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// Происходит при изменении свойства.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Вызывает уведомление подписанных объектов об изменении свойства.
        /// </summary>
        /// <typeparam name="T">Тип изменённого свойства.</typeparam>
        /// <param name="changedProperty">Делегат, в который передаётся изменённое свойство.</param>
        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> changedProperty)
        {
            if (PropertyChanged != null)
            {
                string name = ((MemberExpression)changedProperty.Body).Member.Name;
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        /// <summary>
        /// Изменяет значение инкапсулированного свойством поля и вызывает
        /// уведомление подписанных объектов об изменении свойства.
        /// </summary>
        /// <typeparam name="T">Тип изменённого свойства (поля).</typeparam>
        /// <param name="field">Ссылка на инкапсулированное свойством поле.</param>
        /// <param name="value">Новое значение свойства.</param>
        /// <param name="changedProperty">Делегат, в который передаётся изменённое свойство.</param>
        protected virtual void SetAndNotify<T>(ref T field, T value, Expression<Func<T>> changedProperty)
        {
            if (!Object.ReferenceEquals(field, value))
            {
                field = value;
                OnPropertyChanged(changedProperty);
            }
        }
    }
}
