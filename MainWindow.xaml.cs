using System;
using System.Collections.Generic;
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
            
        }

        public void Initizialise()
        {
            //using (MarathonEntities db = new MarathonEntities())
            //{
            //    db.Charity.Load();

            //    BitmapImage bitmapImage = new BitmapImage();
            //    dgCharity.ItemsSource = db.Charity.Local.ToBindingList();
            //}
        }

        private void SetImage(object sender, RoutedEventArgs e)
        {
            string[] fileNames = FileLoader.Fileload();

            using (ImageEntities db = new ImageEntities())
            {
                for (int i = 0; i < fileNames.Length; i++)
                {
                    imagePathTable image = new imagePathTable
                    {
                        img = ImageConverter.ConvertToByte(fileNames[i])
                    };

                    db.imagePathTable.Add(image);
                }

                db.SaveChanges();
            }

            BitmapImage[] images = new BitmapImage[10]; 
            for (int i = 0; i < fileNames.Length; i++)
            {
                images[i] = new BitmapImage(new Uri(fileNames[i])); // Загрузка в каждый элемент массива 
            }

            imageList.ItemsSource = images;
        }

        private void AddNew(object sender, RoutedEventArgs e)
        {
            //string fileName = FileLoader.fileName;

            //using (MarathonEntities db = new MarathonEntities())
            //{
            //    Charity newCharity = new Charity()
            //    {
            //        CharityName = "asdasd",
            //        CharityLogo = ImageConverter.ConvertToByte(fileName)
            //    };
            //    db.Charity.Add(newCharity);
            //    db.SaveChanges();
            //}
        }
    }
}
