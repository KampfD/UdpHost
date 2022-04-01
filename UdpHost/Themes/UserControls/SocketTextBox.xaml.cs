using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UdpHost.Themes.UserControls
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class SocketTextBox : UserControl
    {
        public event EventHandler SocketChanged;

        private string octet1LastText;
        private string octet2LastText;
        private string octet3LastText;
        private string octet4LastText;
        private string portLastText;

        public string Socket
        {
            get { return (string)GetValue(SocketProperty); }
            set 
            { 
                SetValue(SocketProperty, value); 
            }
        }

        public static readonly DependencyProperty SocketProperty =
            DependencyProperty.Register(
                "Socket",
                typeof(string),
                typeof(SocketTextBox),
                new PropertyMetadata(null, new PropertyChangedCallback(OnSocketPropertyChangedCallback)));
  
        public SocketTextBox()
        {
            InitializeComponent();
        }

        private static void OnSocketPropertyChangedCallback(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var stb = o as SocketTextBox;
            if (stb != null) stb.OnSocketPropertyChanged();
        }

        private void OnSocketPropertyChanged()
        {
            if (Socket != null)
            {
                try
                {
                    string[] items = Socket.Split('.', ':');
                    this.tbxOctet1.Text = items[0];
                    this.tbxOctet2.Text = items[1];
                    this.tbxOctet3.Text = items[2];
                    this.tbxOctet4.Text = items[3];
                    this.tbxPort.Text = items[4];
                }
                catch
                {
                    throw new ArgumentException("Неверный формат атрибутов сокета.");
                }
            }
        }

        private void OnOctetTextBoxPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            string str = textBox.Text.Insert(textBox.CaretIndex, e.Text);
            byte result;
            if (str.Any(ch => !Char.IsDigit(ch)))
            {
                e.Handled = true;
            }
            else if (!Byte.TryParse(str, out result))
            {
                e.Handled = true;
            }
        }

        private void OnPortTextBoxPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            string str = textBox.Text.Insert(textBox.CaretIndex, e.Text);
            int result;
            if (str.Any(ch => !Char.IsDigit(ch)))
            {
                e.Handled = true;
            }
            else if (!Int32.TryParse(str, out result) || !(result >= 0) || !(result <= 65535))
            {
                e.Handled = true;
            }
        }  


        private void OnOctetTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == String.Empty) return;
            byte result;
            // Дополнительная при вставке текста
            if (!Byte.TryParse(textBox.Text, out result))
            {
                SetLastValueInTextBox(textBox.Name);
            }
            else if (textBox.Text.Length >= 3)
            {
                NextFocus(textBox.Name);
                UpdateSocketProperty();
            }
            else
            {
                RememberLastValue(textBox.Name);
                UpdateSocketProperty();
            }
        }

        private void OnPortTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == String.Empty) return;
            int result;
            // Дополнительная проверка при вставке текста
            if (!Int32.TryParse(textBox.Text, out result))
            {
                SetLastValueInTextBox(textBox.Name);
            }
            else if (textBox.Text.Length >= 3)
            {
                NextFocus(textBox.Name);
                UpdateSocketProperty();
            }
            else
            {
                RememberLastValue(textBox.Name);
                UpdateSocketProperty();
            }
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;
            if (e.Key == Key.Space)
            {
                e.Handled = true;
                return;
            }
            switch (textBox.Name)
            {
                case "tbxOctet1":
                    if (e.Key == Key.Right && textBox.CaretIndex == textBox.Text.Length)
                    {
                        this.tbxOctet2.Focus();
                        this.tbxOctet2.CaretIndex = 0;
                        e.Handled = true;
                    }
                    break;
                case "tbxOctet2":
                    if (e.Key == Key.Right && textBox.CaretIndex == textBox.Text.Length)
                    {
                        this.tbxOctet3.Focus();
                        this.tbxOctet2.CaretIndex = 0;
                        e.Handled = true;
                    }
                    else if (e.Key == Key.Left && textBox.CaretIndex == 0)
                    {
                        this.tbxOctet1.Focus();
                        this.tbxOctet1.CaretIndex = this.tbxOctet1.Text.Length;
                        e.Handled = true;
                    }
                    else if (e.Key == Key.Back && textBox.CaretIndex == 0)
                    {
                        this.tbxOctet1.Focus();
                        this.tbxOctet1.CaretIndex = this.tbxOctet1.Text.Length;
                        e.Handled = true;
                    }
                    break;
                case "tbxOctet3":
                    if (e.Key == Key.Right && textBox.CaretIndex == textBox.Text.Length)
                    {
                        this.tbxOctet4.Focus();
                        this.tbxOctet4.CaretIndex = 0;
                        e.Handled = true;
                    }
                    else if (e.Key == Key.Left && textBox.CaretIndex == 0)
                    {
                        this.tbxOctet2.Focus();
                        this.tbxOctet2.CaretIndex = this.tbxOctet2.Text.Length;
                        e.Handled = true;
                    }
                    else if (e.Key == Key.Back && textBox.CaretIndex == 0)
                    {
                        this.tbxOctet2.Focus();
                        this.tbxOctet2.CaretIndex = this.tbxOctet2.Text.Length;
                        e.Handled = true;
                    }
                    break;
                case "tbxOctet4":
                    if (e.Key == Key.Right && textBox.CaretIndex == textBox.Text.Length)
                    {
                        this.tbxPort.Focus();
                        this.tbxPort.CaretIndex = 0;
                        e.Handled = true;
                    }
                    else if (e.Key == Key.Left && textBox.CaretIndex == 0)
                    {
                        this.tbxOctet3.Focus();
                        this.tbxOctet3.CaretIndex = this.tbxOctet3.Text.Length;
                        e.Handled = true;
                    }
                    else if (e.Key == Key.Back && textBox.CaretIndex == 0)
                    {
                        this.tbxOctet3.Focus();
                        this.tbxOctet3.CaretIndex = this.tbxOctet3.Text.Length;
                        e.Handled = true;
                    }
                    break;
                case "tbxPort":
                    if (e.Key == Key.Left && textBox.CaretIndex == 0)
                    {
                        this.tbxOctet4.Focus();
                        this.tbxOctet4.CaretIndex = this.tbxOctet4.Text.Length;
                        e.Handled = true;
                    }
                    else if (e.Key == Key.Back && textBox.CaretIndex == 0)
                    {
                        this.tbxOctet4.Focus();
                        this.tbxOctet4.CaretIndex = this.tbxOctet4.Text.Length;
                        e.Handled = true;
                    }
                    break;
            }
        }

        private void RememberLastValue(string controlName)
        {
            if (controlName == "tbxOctet1") octet1LastText = this.tbxOctet1.Text;
            else if (controlName == "tbxOctet2") octet2LastText = this.tbxOctet2.Text;
            else if (controlName == "tbxOctet3") octet3LastText = this.tbxOctet3.Text;
            else if (controlName == "tbxOctet4") octet4LastText = this.tbxOctet4.Text;
            else if (controlName == "tbxPort") portLastText = this.tbxPort.Text;
        }

        private void SetLastValueInTextBox(string controlName)
        {
            if (controlName == "tbxOctet1") this.tbxOctet1.Text = octet1LastText;
            else if (controlName == "tbxOctet2") this.tbxOctet2.Text = octet2LastText;
            else if (controlName == "tbxOctet3") this.tbxOctet3.Text = octet3LastText;
            else if (controlName == "tbxOctet4") this.tbxOctet4.Text = octet4LastText;
            else if (controlName == "tbxPort") this.tbxPort.Text = portLastText;
        }

        private void NextFocus(string controlName)
        {
            if (controlName == "tbxOctet1")
            {
                this.tbxOctet2.Focus();
                this.tbxOctet2.SelectAll();
            }
            else if (controlName == "tbxOctet2")
            {
                this.tbxOctet3.Focus();
                this.tbxOctet3.SelectAll();
            }
            else if (controlName == "tbxOctet3")
            {
                this.tbxOctet4.Focus();
                this.tbxOctet4.SelectAll();
            }
            else if (controlName == "tbxOctet4")
            {
                this.tbxPort.Focus();
                this.tbxPort.SelectAll();
            }
        }

        private void UpdateSocketProperty()
        {
            Socket = this.tbxOctet1.Text + "." +
                     this.tbxOctet2.Text + "." +
                     this.tbxOctet3.Text + "." +
                     this.tbxOctet4.Text + ":" +
                     this.tbxPort.Text;
            if (SocketChanged != null) SocketChanged(this, new EventArgs());
        }
    }
}
