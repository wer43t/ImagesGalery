using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ImagesGalery
{
    public partial class MainPage : ContentPage
    {
        DBContext.Images myImage;
        public MainPage()
        {
            InitializeComponent();
            UpdateList();
        }

        private async void btnGalery_Clicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                myImage = new DBContext.Images();
                myImage.Name = photo.FileName;
                myImage.Path = photo.FullPath;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }

        private async void btnCamera_Clicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });

                myImage = new DBContext.Images();
                myImage.Name = photo.FileName;
                myImage.Path = photo.FullPath;


            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }

        void UpdateList()
        {
            imgList.ItemsSource = App.Database.GetItems();

        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            if (entryName.Text != null)
                myImage.Name = entryName.Text;
            App.Database.SaveItem(myImage);
            UpdateList();
        }

        private async void imgList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new PhotoPage(imgList.SelectedItem as DBContext.Images));
        }
    }
}
