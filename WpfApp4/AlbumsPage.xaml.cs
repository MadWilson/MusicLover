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

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для AlbumsPage.xaml
    /// </summary>
    public partial class AlbumsPage : Page
    {
        public AlbumsPage()
        {
            InitializeComponent();

            var allGenres = MusicEntities.GetContext().Genre.ToList();
            allGenres.Insert(0, new Genre { name_genre = "Все жанры" });
            ComboType.ItemsSource = allGenres;

           
            ComboType.SelectedIndex = 0;

            UpdateAlbums();

            //var currentAlbums = MusicEntities.GetContext().Tour.ToList();
            //LViewAlbums.ItemsSource = currentAlbums;
        }

        private void UpdateAlbums()
        {
            var currentAlbums = MusicEntities.GetContext().Album.ToList();

            

        }
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAlbums();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAlbums();
        }

        private void CheckActual_Checked(object sender, RoutedEventArgs e)
        {
            UpdateAlbums();
        }
    }
}
