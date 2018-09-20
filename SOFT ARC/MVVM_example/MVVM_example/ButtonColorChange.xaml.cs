using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MVVM_example
{
    /// <summary>
    /// Interaction logic for ButtonColorChange.xaml
    /// </summary>
    public partial class ButtonColorChange : Window
    {
        public string ColorText { get; set; } = "not set";

        private Color color;

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                ColorText = color.ToString();
                OnPropertyChange();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public ButtonColorChange()
        {
            InitializeComponent();
        }

        private void btnColorChange_Click(object sender, RoutedEventArgs e)
        {
            NewColor(color);
        }

        private void NewColor(Color clr)
        {
            if (clr == Colors.Blue)
            {
                Color = Colors.Purple;
            }
            else
            {
                Color = Colors.Yellow;
            }
        }
    }
}
