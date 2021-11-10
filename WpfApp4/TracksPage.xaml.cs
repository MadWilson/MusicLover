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
    /// Логика взаимодействия для tracksPage.xaml
    /// </summary>
    public partial class TracksPage : Page
    {
        public TracksPage()
        {
            InitializeComponent();
            DGridtracks.ItemsSource = MusicEntities.GetContext().Track.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manage.MainFrame.Navigate(new AddEditPage(null));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manage.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Track));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manage.MainFrame.Navigate(new AddEditPage(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var tracksForRemoving = DGridtracks.SelectedItems.Cast<Track>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {tracksForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    MusicEntities.GetContext().Track.RemoveRange(tracksForRemoving);
                    MusicEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                MusicEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridtracks.ItemsSource = MusicEntities.GetContext().Track.ToList();
            }
        }
    }
}
