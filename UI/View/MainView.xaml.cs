using PH.CheckSum.UI.ViewModel;
using System.Windows;
namespace PH.CheckSum.UI.View
{
    /// <summary>
    /// MainView.xaml 的互動邏輯
    /// </summary>
    public partial class MainView : Window
    {
        MainViewModel ViewModel = new MainViewModel();
        public MainView()
        {
            InitializeComponent();
            DataContext = ViewModel;

        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            ViewModel.ItemDroped(sender, e);
        }
    }
}
