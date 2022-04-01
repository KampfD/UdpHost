using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Windows.Controls.Primitives;

namespace UdpHost.Themes.CustomWindow
{
    public partial class CustomizedWindow
    {
        // Обработчик события клика на кнопку сворачивания окна
        private void HideWindow(object sender, RoutedEventArgs e)
        {
            var parentWindow = (sender as FrameworkElement).TemplatedParent as Window;
            parentWindow.WindowState = System.Windows.WindowState.Minimized;
        }

        // Обработчик события клика на кнопку-переключатель разверачивания/сворачивания в окно
        private void ChangeWindowState(object sender, RoutedEventArgs e)
        {
            var parentWindow = (sender as FrameworkElement).TemplatedParent as Window;
            parentWindow.WindowState = parentWindow.WindowState == WindowState.Normal
                ? parentWindow.WindowState = WindowState.Maximized
                : parentWindow.WindowState = WindowState.Normal;
        }

        // Обработчик события клика на кнопку закрытия окна
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            var parentWindow = (sender as FrameworkElement).TemplatedParent as Window;
            parentWindow.Close();
        }

        // Обработчик события перетаскивания окна за обасть заголовка
        // При двойном клике меняет сотояние окна
        private void OnWindowHeaderLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var parentWindow = (sender as FrameworkElement).TemplatedParent as Window;
            parentWindow.DragMove();
            if (e.ClickCount == 2) ChangeWindowState(sender, new RoutedEventArgs());
        }

        // Перетаскивание окна за заголовок
        private void OnWindowHeaderMouseMove(object sender, MouseEventArgs e)
        {
            var parentWindow = (sender as FrameworkElement).TemplatedParent as Window;
            if (parentWindow.WindowState == WindowState.Maximized && e.LeftButton == MouseButtonState.Pressed)
                parentWindow.WindowState = WindowState.Normal;
        }

        // Изменение размера окна З
        private void WestDragDelta(object sender, DragDeltaEventArgs e)
        {
            var parentWindow = (sender as FrameworkElement).TemplatedParent as Window;
            if (parentWindow.WindowState == WindowState.Maximized) return;
            if (parentWindow.Width + e.HorizontalChange > 0)
            {
                if (parentWindow.Width - e.HorizontalChange > 0 &&
                    parentWindow.Width - e.HorizontalChange > parentWindow.MinWidth)
                {
                    parentWindow.Left += e.HorizontalChange; 
                    parentWindow.Width -= e.HorizontalChange;
                }
            }
        }

        // Изменение размера окна СЗ
        private void NorthWestDragDelta(object sender, DragDeltaEventArgs e)
        {
            NorthDragDelta(sender, e); 
            WestDragDelta(sender, e);
        }

        // Изменение размера окна С
        private void NorthDragDelta(object sender, DragDeltaEventArgs e)
        {
            var parentWindow = (sender as FrameworkElement).TemplatedParent as Window;
            if (parentWindow.WindowState == WindowState.Maximized) return;
            if (parentWindow.Height - e.VerticalChange > 0 &&
                parentWindow.Height - e.VerticalChange > parentWindow.MinHeight)
            {
                parentWindow.Top += e.VerticalChange;
                parentWindow.Height -= e.VerticalChange;
            }
        }

        // Изменение размера окна СВ
        private void NorthEastDragDelta(object sender, DragDeltaEventArgs e)
        {
            NorthDragDelta(sender, e);
            EastDragDelta(sender, e);
        }

        // Изменение размера окна В
        private void EastDragDelta(object sender, DragDeltaEventArgs e) 
        { 
            var parentWindow = (sender as FrameworkElement).TemplatedParent as Window;
            if (parentWindow.WindowState == WindowState.Maximized) return;
            if (parentWindow.Width + e.HorizontalChange > 0)
                parentWindow.Width += e.HorizontalChange;
        }

        // Изменение размера окна ЮВ
        private void SouthEastDragDelta(object sender, DragDeltaEventArgs e)
        {
            SouthDragDelta(sender, e);
            EastDragDelta(sender, e);
        }

        // Изменение размера окна Ю
        private void SouthDragDelta(object sender, DragDeltaEventArgs e)
        {
            var parentWindow = (sender as FrameworkElement).TemplatedParent as Window;
            if (parentWindow.WindowState == WindowState.Maximized) return;
            if (parentWindow.Height + e.VerticalChange > 0)
                parentWindow.Height += e.VerticalChange;
        }

        // Изменение размера окна ЮЗ
        private void SouthWestDragDelta(object sender, DragDeltaEventArgs e)
        {
            SouthDragDelta(sender, e);
            WestDragDelta(sender, e);
        }

        // Реализует взаимодействие с иконкой
        private void IconMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;   // Сброс маршрутизации события во избежание конфликта с перетаскивнием за заголовок
            if (e.ClickCount > 1)
                ((sender as FrameworkElement).TemplatedParent as Window).Close();
            else
            {
                var parentWindow = (sender as FrameworkElement).TemplatedParent as Window;
                var handle = new WindowInteropHelper(parentWindow).Handle;
                SendMessage(handle, (uint)Msg.WM_SYSCOMMAND, (IntPtr)Msg.SC_KEYMENU, (IntPtr)' ');
            }
        }

        #region P/Invoke (WinAPI)
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        // Определяет сообщение для SendMessage
        private enum Msg : uint
        {
            WM_SYSCOMMAND = 0x112,
            SC_CLOSE = 0xF060,
            SC_MAXIMIZE = 0xF030,
            SC_MINIMIZE = 0xF020,
            SC_MOVE = 0xF010,
            SC_SIZE = 0xF000,
            SC_KEYMENU = 0xF100
        }
        #endregion
    }
}
