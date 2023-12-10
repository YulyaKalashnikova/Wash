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
using System.Windows.Shapes;

namespace Wash
{
    /// <summary>
    /// Логика взаимодействия для AddEmpoyeeWindow.xaml
    /// </summary>
    public partial class AddEmpoyeeWindow : Window
    {
        public AddEmpoyeeWindow()
        {
            InitializeComponent();
            //DataContext = new Staff();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var role = CbRole.IsChecked == true ? 2 : 1;
            Staff staff = new Staff()
            {
                FirstName=TbFirstName.Text,
                LastName=TbLastName.Text,
                MiddleName=TbMiddleName.Text,
                Login=TbLogin.Text,
                Password=TbPassword.Text,
                RoleId=role,
            };
            Helper.GetContext().Staffs.Add(staff);
            //var staff = DataContext as Staff;
            //staff.RoleId = role;
            Helper.GetContext().SaveChanges();
            Close();
        }
    }
}
