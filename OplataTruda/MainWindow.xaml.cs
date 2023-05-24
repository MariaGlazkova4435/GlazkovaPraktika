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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OplataTruda
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DG.ItemsSource = SotrudnikiEntities1.GetContext().Sotrudnik.ToList();
            BtnNext.IsEnabled = false;
           
        }
        Reaschet reaschet;
        int id; string fam, ps, nam;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var item = DG.SelectedItem as Sotrudnik;
            St2.Visibility = Visibility.Visible;
            id = item.idSotr; fam = item.Surname; ps = item.Post; nam = item.Name;
            reaschet = new Reaschet(id, fam, nam, ps);
            St1.Visibility = Visibility.Hidden;
        }

        private void DG_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (DG.SelectedItems.Count == 1)
                BtnNext.IsEnabled = true;
            else
                BtnNext.IsEnabled = false;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            St2.Visibility = Visibility.Hidden;
            St1.Visibility = Visibility.Visible;
        }

        private void Oklad(object sender, RoutedEventArgs e)
        {
            reaschet.Show();
            reaschet.Oklad.Visibility = Visibility.Visible;
            reaschet.Chas.Visibility = Visibility.Hidden;
            Close();
        }

        private void Chas(object sender, RoutedEventArgs e)
        {
            reaschet.Show();
            reaschet.Oklad.Visibility = Visibility.Hidden;
            reaschet.Chas.Visibility = Visibility.Visible;
            Close();
        }
    }
    
}
