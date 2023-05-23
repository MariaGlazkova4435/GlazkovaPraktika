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
        public Reaschet(int idSotr, string f, string n, string p)
        {
            InitializeComponent();
            id = idSotr;
            TbName.Text = $"{f} {n} - {p}";
        }
        int id;
        private void Rasch(object sender, RoutedEventArgs e)
        { 
            double Rezult = 0;
            if (f(Okl.Text) && f(PlanDays.Text) && f(FactDays.Text))
            {
                Rezult = Math.Round(Convert.ToDouble(Okl.Text) / Convert.ToDouble(PlanDays.Text) * Convert.ToDouble(FactDays.Text),2);
                Rez.Text = $"Выплата = {Rezult}";
            }
            else
                MessageBox.Show("Введите значения во все поля", "Ошибка получения данных");

        }

        public bool f(string a)
        {
            if (!String.IsNullOrWhiteSpace(a))
                return true;
            else
                return false;
        }

        private void Vnos(object sender, RoutedEventArgs e)
        {

        }

        private void Rasch2(object sender, RoutedEventArgs e)
        {
            double Rezult = 0;
            if (f(Ch.Text) && f(Stavka.Text))
            {
                Rezult = Math.Round(Convert.ToDouble(Ch.Text) * Convert.ToDouble(Stavka.Text), 2);
                Rez1.Text = $"Выплата = {Rezult}";
            }
            else
                MessageBox.Show("Введите значения во все поля", "Ошибка получения данных");
        }

        private void Vnos2(object sender, RoutedEventArgs e)
        {

        }
    }
}
