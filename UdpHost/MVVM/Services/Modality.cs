using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UdpHost.MVVM.Services
{
    /// <summary>
    /// Определяет модальность окна.
    /// </summary>
    internal enum Modality
    {
        /// <summary>
        /// Модальное окно.
        /// </summary>
        Modal,

        /// <summary>
        /// Параллельное окно.
        /// </summary>
        Parallel
    }
}
