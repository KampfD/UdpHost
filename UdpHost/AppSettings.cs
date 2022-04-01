using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;

namespace UdpHost.Properties
{
    /// <summary>
    /// Представляет службу чтения/сохранения настроек приложения.
    /// </summary>
    internal sealed class AppSettings
    {
        /// <summary>
        /// Получает доступ к текущим настройкам приложения.
        /// </summary>
        public static SerializableProperties Settings { get; private set; }

        // Инициализирует свойство доступа к настройками со значениями по умолчанию.
        static AppSettings()
        {
            Settings = new SerializableProperties();
        }

        /// <summary>
        /// Сохраняет текущие настройки в файл.
        /// </summary>
        public static void Save()
        {
            string path = AppDomain.CurrentDomain.FriendlyName + ".cfg";
            string json = JsonConvert.SerializeObject(Settings, Formatting.Indented);
            string oldJson = File.ReadAllText(path);
            if (!json.Equals(oldJson)) 
                File.WriteAllText(path, json);
        }

        /// <summary>
        /// Загружает настройки из файла. 
        /// Если файл отсутствует, то создаёт его выставляет значения по умолчанию.
        /// </summary>
        public static void Load()
        {
            string path = AppDomain.CurrentDomain.FriendlyName + ".cfg";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                Settings = JsonConvert.DeserializeObject<SerializableProperties>(json);
            }
            else
            {
                Settings = new SerializableProperties();
                string defaultJson = JsonConvert.SerializeObject(Settings, Formatting.Indented);
                File.WriteAllText(path, defaultJson);
            }
        }

        /// <summary>
        /// Устанавливает значения настроек по умолчанию.
        /// </summary>
        public static void ResetToDefault()
        {
            Settings = new SerializableProperties();
        }

        /// <summary>
        /// Реализует настройки приложения.
        /// </summary>
        [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
        internal class SerializableProperties : DependencyObject
        {
            [JsonProperty]
            public bool IsDisplayedTime { get; set; }
            [JsonProperty]
            public bool IsDisplayedSourse { get; set; }
            [JsonProperty]
            public bool IsBytes { get; set; }
            [JsonProperty]
            public bool IsParseBytes { get; set; }
            [JsonProperty]
            public string LocalSocket { get; set; }
            [JsonProperty]
            public string RemoteSocket { get; set; }


            #region DependencyProperties
            [JsonProperty]
            public double Top
            {
                get { return (double)GetValue(TopProperty); }
                set { SetValue(TopProperty, value); }
            }

            public static readonly DependencyProperty TopProperty =
                DependencyProperty.Register("Top", typeof(double), typeof(SerializableProperties), new UIPropertyMetadata(300.0));

            [JsonProperty]
            public double Left
            {
                get { return (double)GetValue(LeftProperty); }
                set { SetValue(LeftProperty, value); }
            }

            public static readonly DependencyProperty LeftProperty =
                DependencyProperty.Register("Left", typeof(double), typeof(SerializableProperties), new UIPropertyMetadata(350.0));

            [JsonProperty]
            public double Width
            {
                get { return (double)GetValue(WidthProperty); }
                set { SetValue(WidthProperty, value); }
            }

            public static readonly DependencyProperty WidthProperty =
                DependencyProperty.Register("Width", typeof(double), typeof(SerializableProperties), new UIPropertyMetadata(450.0));

            [JsonProperty]
            public double Height
            {
                get { return (double)GetValue(HeightProperty); }
                set { SetValue(HeightProperty, value); }
            }

            public static readonly DependencyProperty HeightProperty =
                DependencyProperty.Register("Height", typeof(double), typeof(SerializableProperties), new UIPropertyMetadata(400.0));
            #endregion
        }
    }
}
