using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.Windows.Controls;

namespace UdpHost.MVVM.Views
{
    class DisplayTextBoxBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.AssociatedObject.TextChanged += OnTextChanged;
        }

        protected override void OnDetaching()
        {
            base.AssociatedObject.TextChanged -= OnTextChanged;
        }

        void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            textBox.ScrollToEnd();
        }
    }
}
