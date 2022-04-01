// Реализация взята с https://metanit.com/sharp/wpf/22.3.php
using System;
using System.Windows.Input;

namespace UdpHost.MVVM.Services
{
    /// <summary>
    /// Определяет реализацию команды.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        /// <summary>
        /// Происходит при изменении состояния возможности выполнения команды.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса RelayCommand.
        /// </summary>
        /// <param name="execute">Метод, выполняемый командой.</param>
        /// <param name="canExecute">Метод проверки возможности выполения команды.</param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Определяет может ли в данный момент выполнится команда.
        /// </summary>
        /// <param name="parameter">Параметр команды (может быть null).</param>
        /// <returns>true - команда может быть выполнена, false - команда не может быть выполнена.</returns>
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        /// <summary>
        /// Определяет метод, выполняемый командой.
        /// </summary>
        /// <param name="parameter">Параметр команды (может быть null).</param>
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
