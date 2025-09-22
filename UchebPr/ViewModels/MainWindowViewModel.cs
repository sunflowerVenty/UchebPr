using System.Collections.Generic;
using System.Linq;
using UchebPr.Data;

namespace UchebPr.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public List<User> Users { get; set; }
        public List<Role> Roles { get; set; }
        public MainWindowViewModel()
        {
            RefreshData();
        }

        public void RefreshData()
        {
            Users = App.DbContext.Users.ToList();
            OnPropertyChanged(nameof(Users));

            Roles = App.DbContext.Roles.ToList();
            OnPropertyChanged(nameof(Roles));
        }
            
    }
}
