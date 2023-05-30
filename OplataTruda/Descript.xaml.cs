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

namespace OplataTruda
{
    /// <summary>
    /// Логика взаимодействия для Descript.xaml
    /// </summary>
    public partial class Descript : Window
    {
        public Descript(int id, string Sur, string Nam)
        {
            InitializeComponent();
            idS = id;
            s = Sur; n = Nam;
        }
        int idS; string s, n;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var sotr = SotrudnikiEntities1.GetContext().Sotrudnik.Where(q => q.idSotr == idS);
            if (MessageBox.Show($"Вы точно хотите удалить сотрудника?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            { 
                using (var context = new MyDbContext())
                {
                    var w = new List<SotrHistory>()
                    {
                        new SotrHistory(){ FullName = $"{s} {n}", idTypeAct = 1, Description = Desc.Text, Date = DateTime.Now}
                    };
                    context.SH.AddRange(w);
                    context.SaveChanges();
                }
                SotrudnikiEntities1.GetContext().Sotrudnik.RemoveRange(sotr);
                SotrudnikiEntities1.GetContext().SaveChanges();

                MessageBox.Show("Данные удалены", "Главное окно", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
        }
        private void Otmena(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
