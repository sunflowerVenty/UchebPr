using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Linq;
using UchebPr.Data;
using UchebPr.ViewModels;

namespace UchebPr;

public partial class CreateAndChangeUser : Window
{
    User thisSelectedUser;
    public CreateAndChangeUser()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();

    }

    public CreateAndChangeUser(User user)
    {
        InitializeComponent();
        FullNameText.Text = user.Name;
        PhoneNumberText.Text = user.PhoneNumber;
        DescriptionText.Text = user.Description;
        RolesCmb.SelectedItem = user.Role;
        thisSelectedUser = user;
        DataContext = new MainWindowViewModel();

    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var newUser = new User()
        {
            Name = FullNameText.Text,
            Description = DescriptionText.Text,
            PhoneNumber = PhoneNumberText.Text,
            Role = RolesCmb.SelectedItem as Role
        };
        
        if (thisSelectedUser == null)
        {
            
            App.DbContext.Users.Add(newUser);
            
        }
        else
        {
            var userDb = App.DbContext.Users.FirstOrDefault(x => x.IdUser == thisSelectedUser.IdUser);
            userDb.Name = FullNameText.Text;
            userDb.PhoneNumber = PhoneNumberText.Text;
            userDb.Description = DescriptionText.Text;
            userDb.Role = RolesCmb.SelectedItem as Role;
        }
        App.DbContext.SaveChanges();
        this.Close();
    }


}