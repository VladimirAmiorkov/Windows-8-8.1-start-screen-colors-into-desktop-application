using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GetStartScreenColors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnGetColorsButtonClick(object sender, RoutedEventArgs e)
        {
            this.SetColor(this.AccentColorResultRectangle, this.AccentColorResultTextBox, ImmersiveColors.ImmersiveStartSelectionBackground);
            this.SetColor(this.MainColorResultRectangle, this.MainColorResultTextBox, ImmersiveColors.ImmersiveStartPrimaryText);
            this.SetColor(this.BackgroundColorResultRectangle, this.BackgroundColorResultTextBox, ImmersiveColors.ImmersiveStartBackground);
        }

        private void SetColor(Rectangle rectangle, TextBox textBox, ImmersiveColors immersiveColor)
        {
            IntPtr pElementName = Marshal.StringToHGlobalUni(immersiveColor.ToString());
            Color color = GetColor(pElementName);
            rectangle.Fill = new SolidColorBrush(color);
            textBox.Text = color.ToString();
        }

        private static Color GetColor(IntPtr pElementName)
        {
            var colourset = StarScreenColorsHelper.GetImmersiveUserColorSetPreference(false, false);
            uint type = StarScreenColorsHelper.GetImmersiveColorTypeFromName(pElementName);
            Marshal.FreeCoTaskMem(pElementName);
            uint colourdword = StarScreenColorsHelper.GetImmersiveColorFromColorSetEx((uint)colourset, type, false, 0);
            byte[] colourbytes = new byte[4];
            colourbytes[0] = (byte)((0xFF000000 & colourdword) >> 24); // A
            colourbytes[1] = (byte)((0x00FF0000 & colourdword) >> 16); // B
            colourbytes[2] = (byte)((0x0000FF00 & colourdword) >> 8); // G
            colourbytes[3] = (byte)(0x000000FF & colourdword); // R
            Color color = Color.FromArgb(colourbytes[0], colourbytes[3], colourbytes[2], colourbytes[1]);
            return color;
        }
    }
}
