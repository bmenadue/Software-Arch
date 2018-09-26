using System.Windows;

namespace OrderEntrySystem
{
    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// This method will overwrite the OnStartup method.
        /// </summary>
        /// <param name="e">Argument associated with the method.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow window = new MainWindow();
            window.Show();

            window.DataContext = new MainWindowViewModel();
        }
    }
}