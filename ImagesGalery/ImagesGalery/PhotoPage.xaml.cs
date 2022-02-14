using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImagesGalery
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotoPage : ContentPage
    {
        public string PhotoPath { get; set; }
        public string Name { get; set; }
        public PhotoPage(DBContext.Images image)
        {
            InitializeComponent();
            PhotoPath = image.Path;
            Name = image.Name;
            BindingContext = this;
        }
    }
}