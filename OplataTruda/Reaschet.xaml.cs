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
    /// Логика взаимодействия для Reaschet.xaml
    /// </summary>
    public partial class Reaschet : Window
    {
        Proverka proverka = new Proverka();
        public Reaschet(int idSotr, string f, string n, string p)
        {
            InitializeComponent();
            id = idSotr;
            TbName.Text = $"{f} {n} - {p}";
        }
        int id; double Rezult = 0;
        private void Rasch(object sender, RoutedEventArgs e)
        { 
            if (!proverka.NullStr(Okl.Text) && !proverka.NullStr(PlanDays.Text) && !proverka.NullStr(FactDays.Text))
            {
                Rezult = Math.Round(proverka.SchetPoOkladu(Okl.Text, PlanDays.Text, FactDays.Text),2);
                if (Rezult == 0)
                    MessageBox.Show("Данные введены некорректно", "Ошибка получения данных", MessageBoxButton.OK, MessageBoxImage.Warning);
                Rez.Text = $"Выплата = {Rezult} руб.";
            }
            else
                MessageBox.Show("Введите значения во все поля", "Ошибка получения данных", MessageBoxButton.OK, MessageBoxImage.Exclamation);

        }

        private void Vnos(object sender, RoutedEventArgs e)
        {
            using (var context = new MyDbContext())
            {
                var w = new List<PaymentHistory>()
                    {
                        new PaymentHistory(){ idSotr = id, Summa = Rezult, Date = DateTime.Now }
                    };
                context.P.AddRange(w);
                context.SaveChanges();
                MessageBox.Show("Выплата добавлена в историю выплат", "Окно расчета", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            Okl.Text = ""; PlanDays.Text = ""; FactDays.Text = ""; Rez.Text = "";
        }

        private void Rasch2(object sender, RoutedEventArgs e)
        {

            if (!proverka.NullStr(Ch.Text) && !proverka.NullStr(Stavka.Text))
            {
                Rezult = Math.Round(proverka.SchetPoOChasam(Stavka.Text, Ch.Text), 2);
                if (Rezult == 0)
                    MessageBox.Show("Данные введены некорректно", "Ошибка получения данных", MessageBoxButton.OK, MessageBoxImage.Warning);
                Rez1.Text = $"Выплата = {Rezult} руб.";
            }
            else
                MessageBox.Show("Введите значения во все поля", "Ошибка получения данных", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void Vnos2(object sender, RoutedEventArgs e)
        {
            using (var context = new MyDbContext())
            {
                var w = new List<PaymentHistory>()
                    {
                        new PaymentHistory(){ idSotr = id, Summa = Rezult, Date = DateTime.Now }
                    };
                context.P.AddRange(w);
                context.SaveChanges();
                MessageBox.Show("Выплата добавлена в историю выплат", "Окно расчета", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            Ch.Text = ""; Stavka.Text = ""; Rez1.Text = "";
        }
        MainWindow mainWindow = new MainWindow();
        private void Back(object sender, RoutedEventArgs e)
        {

            mainWindow.Show();
            mainWindow.St2.Visibility = Visibility.Hidden;
            mainWindow.St1.Visibility = Visibility.Visible;
            Close();
        }
    }
}
