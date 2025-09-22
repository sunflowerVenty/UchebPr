using Avalonia.Controls;
using UchebPr.Data;
using UchebPr.ViewModels;

namespace UchebPr.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var createAndChangeUserWindow = new CreateAndChangeUser();
            await createAndChangeUserWindow.ShowDialog(this);

            var viewModel = DataContext as MainWindowViewModel;
            viewModel.RefreshData();
        }

        private async void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            var selectedUser = MainDataGridUsers.SelectedItem as User;
            if (selectedUser == null) return;

            var createAndChangeUserWindow = new CreateAndChangeUser(selectedUser);
            await createAndChangeUserWindow.ShowDialog(this);

            var viewModel = DataContext as MainWindowViewModel;
            viewModel.RefreshData();
        }
    }
}