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
    /// Логика взаимодействия для AddEdit.xaml
    /// </summary>
    public partial class AddEdit : Window
    {
        public AddEdit(Sotrudnik selectedSotr)
        {
            InitializeComponent();
            if (selectedSotr != null)
            { _currentSotr = selectedSotr; cal.DisplayDate = _currentSotr.Birth.Value; }

            DataContext = _currentSotr;
            //CpVidProd.ItemsSource = ZooMagazinCopy2Entities.GetContext().TypeProducts.ToList();
            //CpVidAnim.ItemsSource = ZooMagazinCopy2Entities.GetContext().TypeAnimals.ToList();
        }
        private Sotrudnik _currentSotr = new Sotrudnik();

        private void Save(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentSotr.Name))
                errors.AppendLine("Не введено имя сотрудника\nУкажите имя");
            if (string.IsNullOrWhiteSpace(_currentSotr.Surname))
                errors.AppendLine("Не введена фамилия сотрудника\nУкажите фамилию");
            if (string.IsNullOrWhiteSpace(_currentSotr.Post))
                errors.AppendLine("Не введена должность сотрудника\nУкажите должность");
            if (string.IsNullOrWhiteSpace(_currentSotr.Birth.ToString()))
                errors.AppendLine("Не выбрана дата рождения сотрудника\nУкажите дату рождения");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка получения данных");
                return;
            }

            if (_currentSotr.idSotr == 0)
            {
                SotrudnikiEntities1.GetContext().Sotrudnik.Add(_currentSotr);
                using (var context = new MyDbContext())
                {
                    var w = new List<SotrHistory>()
                    {
                        new SotrHistory(){ FullName = $"{_currentSotr.Surname} {_currentSotr.Name}", idTypeAct = 2, Description = Desc.Text, Date = DateTime.Now}
                    };
                    context.SH.AddRange(w);
                    context.SaveChanges();
                }
                MessageBox.Show("Сотрудник добавлен", "Окно редактора", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                using (var context = new MyDbContext())
                {
                    var w = new List<SotrHistory>()
                    {
                        new SotrHistory(){ FullName = $"{_currentSotr.Surname} {_currentSotr.Name}", idTypeAct = 3, Description = Desc.Text, Date = DateTime.Now}
                    };
                    context.SH.AddRange(w);
                    context.SaveChanges();
                }
                MessageBox.Show("Данные о сотруднике отредактированы", "Окно редактора", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            try
            {
                SotrudnikiEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена", "Окно редактирования");
                MainWindow forAdministrators = new MainWindow();
                forAdministrators.Show();
                Close();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }


        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow forAdministrators = new MainWindow();
            forAdministrators.Show();
            Close();
        }

        private void cal_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            Bir.Text = cal.SelectedDate.ToString();
            Bir.Focus();
        }
    }
}
