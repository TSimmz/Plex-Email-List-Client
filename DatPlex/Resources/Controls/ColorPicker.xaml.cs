using DevX.Common;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DevX.Resources.Controls
{
    /// <summary>
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : UserControl
    {

        public string ColorPicker_Label
        {
            get
            {
                return (string)GetValue(ColorPicker_Label_Property);
            }
            set
            {
                SetValue(ColorPicker_Label_Property, value);
            }
        }
        public static readonly DependencyProperty ColorPicker_Label_Property =
            DependencyProperty.Register("ColorPicker_Label", typeof(string),
              typeof(ColorPicker), new PropertyMetadata(default(string)));

        private bool _isDark=false;
        public bool isDark
        {
            get { return _isDark; }
            set { _isDark = value;
                BackgroundColor = "";
                ForegroundColor = "";
            }
        }

        public string BackgroundColor
        {
            get
            {
                if(isDark)
                    return "#FF0B0525";
                return "#FFFFFFFF";
            }
            set { SetValue(Background_Property, BackgroundColor); }
        }
        public static readonly DependencyProperty Background_Property =
            DependencyProperty.Register("Background", typeof(string),
              typeof(ColorPicker), new PropertyMetadata(default(string)));

        public string ForegroundColor
        {
            get
            {   
                if (isDark)
                    return "#FFFFFFFF";
                return "#FF000000";
            }
            set { SetValue(Background_Property, ForegroundColor); }
        }
        public static readonly DependencyProperty Foreground_Property =
            DependencyProperty.Register("Foreground", typeof(string),
              typeof(ColorPicker), new PropertyMetadata(default(string)));

        public string ColorPicker_Hex
        {
            get
            {
                return (string)GetValue(ColorPicker_Hex_Property);
            }
            set
            {
                Regex r = new Regex("[^a-f0-9]", RegexOptions.IgnoreCase);
                string newColor = r.Replace(value, "") + "000000";
                newColor = newColor.Substring(0, (newColor.Length > 6) ? 6 : newColor.Length);

                Color color = (Color)ColorConverter.ConvertFromString("#FF" + newColor);
                ClrPcker_Background.SelectedColor = color;
                //SetValue(ColorPicker_Hex_Property, color);
            }
        }
        public static readonly DependencyProperty ColorPicker_Hex_Property =
            DependencyProperty.Register("ColorPicker_Hex", typeof(string),
              typeof(ColorPicker), new PropertyMetadata(default(string)));

        private void ClrPcker_Background_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            string hexTemp = "#" + ClrPcker_Background.SelectedColor.Value.R.ToString("X2") +
                ClrPcker_Background.SelectedColor.Value.G.ToString("X2") +
                ClrPcker_Background.SelectedColor.Value.B.ToString("X2");

            SetValue(ColorPicker_Hex_Property, hexTemp);
        }

        public ColorPicker()
        {
            InitializeComponent();
            ElementRoot.DataContext = this;

            List<ListBoxItemDevX> StyleList = new List<ListBoxItemDevX>();
            StyleList.Add(new ListBoxItemDevX("/DevX;component/Images/Style_1.png", "1"));
            StyleList.Add(new ListBoxItemDevX("/DevX;component/Images/Style_2.png", "2"));
            StyleList.Add(new ListBoxItemDevX("/DevX;component/Images/Style_3.png", "3"));
            StyleList.Add(new ListBoxItemDevX("/DevX;component/Images/Style_4.png", "4"));
            StyleList.Add(new ListBoxItemDevX("/DevX;component/Images/Style_5.png", "5"));
            StyleList.Add(new ListBoxItemDevX("/DevX;component/Images/Style_6.png", "6"));
            StyleBox.ItemsSource = StyleList;

            List<ListBoxItemDevX> DotList = new List<ListBoxItemDevX>();
            DotList.Add(new ListBoxItemDevX("/DevX;component/Images/Style_Dot_Off.png", "Off"));
            DotList.Add(new ListBoxItemDevX("/DevX;component/Images/Style_Dot_On.png", "On"));

            DotBox.ItemsSource = DotList;
        }
    }
}
