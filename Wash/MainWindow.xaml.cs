using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Wash.Properties;

namespace Wash
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


        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var date = DateTime.Now;
            var settingDateStart = Settings.Default.DateTimeStart;
            var settingDateFinish = Settings.Default.DateTimeFinish;
            var hours = (settingDateFinish.TimeOfDay.TotalHours - settingDateStart.TimeOfDay.TotalHours);
            if (hours > 12 || hours < 0 || hours == 0)
            {
                Settings.Default.DateTimeStart = DateTime.Now;
                Settings.Default.DateTimeFinish = DateTime.Now;
                Settings.Default.Code = 0;
                Settings.Default.Save();
            }
            var user = Helper.GetContext().Staffs.FirstOrDefault(x => x.Login == TbLogin.Text && x.Password == PbPassword.Password);
            if (user == null)
            {
                MessageBox.Show("Данного пользователя нет в системе.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            Helper.s_staff = user;
            switch (user.RoleId)
            {
                case 1:
                    WorkerWindow workerWindow = new WorkerWindow();
                    workerWindow.Show();
                    break;
                case 2:
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    break;
            }
            Close();
        }
    }
}
