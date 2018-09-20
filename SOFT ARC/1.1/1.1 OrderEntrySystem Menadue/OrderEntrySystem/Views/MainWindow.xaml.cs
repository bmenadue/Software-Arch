using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrderEntrySystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.DisplayName = "order entry system - Menadue (via mainwindow)";
        }

        /// <summary>
        /// Gets or sets the Display Name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The event handler associated with the newProductButton.
        /// </summary>
        /// <param name="sender">The sender Object.</param>
        /// <param name="e">The associated argument.</param>
        private void newProductButton_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as MainWindowViewModel).CreateNewProduct();
        }
    }
}
