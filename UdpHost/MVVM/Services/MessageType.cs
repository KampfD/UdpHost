using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UdpHost.MVVM.Services
{
    /// <summary>
    /// Определяет тип сообщения в варианты ответа пользователя.
    /// </summary>
    internal enum MessageType
    {
        /// <summary>
        /// Информационное сообщение.
        /// </summary>
        Information,

        /// <summary>
        /// Сообщение об ошибке.
        /// </summary>
        Error,

        /// <summary>
        /// Предупреждение.
        /// </summary>
        Warning,

        /// <summary>
        /// Вопрос пользователю.
        /// </summary>
        Question,

        /// <summary>
        /// Вопрос пользователю с предупреждением.
        /// </summary>
        WarningQuestion
    }
}
