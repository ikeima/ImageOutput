using System;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ImageOutput
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();  
            Initizialise();
        }

        public void Initizialise()
        {
            using (MarathonEntities db = new MarathonEntities())
            {
                db.Charity.Load();

                BitmapImage bitmapImage = new BitmapImage();
                dgCharity.ItemsSource = db.Charity.Local.ToBindingList();
            }
        }

        private void SetImage(object sender, RoutedEventArgs e)
        {
            string fileName = FileLoader.Fileload();
            tblFileName.Text = fileName;

            try
            {
                Bitmap bitmap = new Bitmap(fileName);
                BitmapImage bitmapImage = new BitmapImage(new Uri(fileName));

                image.Source = bitmapImage;
            }
            catch
            {
                MessageBox.Show("Картинку то выбери");
            }
            
        }

        private void AddNew(object sender, RoutedEventArgs e)
        {
            string fileName = FileLoader.fileName;

            using (MarathonEntities db = new MarathonEntities())
            {
                Charity newCharity = new Charity()
                {
                    CharityName = "asdasd",
                    CharityLogo = ImageConverter.ConvertToByte(fileName)
                };
                db.Charity.Add(newCharity);
                db.SaveChanges();
            }
        }
    }
}
