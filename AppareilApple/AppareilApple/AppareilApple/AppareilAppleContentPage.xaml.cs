using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppareilApple
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppareilAppleContentPage : ContentPage
    {
        Label titreLabel;
        Label membreLabel;

        string titre;
        string membre;

        public AppareilAppleContentPage()
        {
            InitializeComponent();

            InitControles();
            
        }

        public void InitControles()
        {

            var fsTitre = new FormattedString();
            fsTitre.Spans.Add(new Span { Text = "Appareil Apple", ForegroundColor = Color.Red, FontSize = 30 });
            var fsMembre = new FormattedString();
            fsMembre.Spans.Add(new Span { Text = "Ange-Christian" + Environment.NewLine + "Briand leblanc", ForegroundColor = Color.Yellow, FontSize = 40 });



            titreLabel = new Label()
            {
                FormattedText = fsTitre,
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center
                
            };

            membreLabel = new Label()
            {
                FormattedText = fsMembre,
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center
            };


            Button IphoneButton = new Button
            {
                Image = "images/resizeiphone.jpg",
                Text = "Iphone",
                //VerticalOptions = LayoutOptions.Fill,
                WidthRequest = 180,
                HeightRequest = 100,
                HorizontalOptions = LayoutOptions.Center

            };

            Button MacBookButton = new Button()
            {
                Image = "resizemacbook.jpg",
                Text = "MacBook",
                HorizontalOptions = LayoutOptions.Center,
                //VerticalOptions = LayoutOptions.Fill,
                WidthRequest = 180,
                HeightRequest = 100

            };

            Button accessoriesButton = new Button()
            {
                Image = "resizeAccessoire.jpg",
                Text = "Accessoires",
                HorizontalOptions = LayoutOptions.Center,
                //VerticalOptions = LayoutOptions.Fill,
                WidthRequest = 180,
                HeightRequest = 100

            };

            Button IpadButton = new Button()
            {
                Image = "resizeipad.jpg",
                Text = "Ipad",
                HorizontalOptions = LayoutOptions.Center,
               // VerticalOptions = LayoutOptions.Fill,
                WidthRequest = 180,
                HeightRequest = 100

            };

            this.Content = new StackLayout
            {
                Children =
                {
                    titreLabel,
                    IphoneButton,
                    MacBookButton,
                    accessoriesButton,
                    IpadButton,
                    membreLabel
                }
            };

            IphoneButton.Clicked += AppleButton_Clicked;
            MacBookButton.Clicked += AppleButton_Clicked;
            accessoriesButton.Clicked += AppleButton_Clicked;
            IpadButton.Clicked += AppleButton_Clicked;
        }

        async void AppleButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Assigner la variable au niveau de la classe (bien sûr, on perd le formatage)
                Button clickedButton = sender as Button;
                if (clickedButton == null)
                    return;

                if(clickedButton.Text == "Iphone")
                {
                    titre = clickedButton.Text.ToString();
                    membre = membreLabel.FormattedText.ToString();

                    // Passer la variable au niveau de la classe comme paramètre
                    await Navigation.PushAsync(new IphoneContentPage(titre, membre));
                }
                if (clickedButton.Text == "MacBook")
                {
                    titre = clickedButton.Text.ToString();
                    membre = membreLabel.FormattedText.ToString();

                    // Passer la variable au niveau de la classe comme paramètre
                    await Navigation.PushAsync(new MacbookContentPage(titre, membre));
                }
                if (clickedButton.Text == "Accessoires")
                {
                    titre = clickedButton.Text.ToString();
                    membre = membreLabel.FormattedText.ToString();

                    // Passer la variable au niveau de la classe comme paramètre
                    await Navigation.PushAsync(new AccessoiresContentPage(titre, membre));
                }
                if (clickedButton.Text == "Ipad")
                {
                    titre = clickedButton.Text.ToString();
                    membre = membreLabel.FormattedText.ToString();

                    // Passer la variable au niveau de la classe comme paramètre
                    await Navigation.PushAsync(new IpadContentPage(titre, membre));
                }
               
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erreur", ex.ToString(), "Annulé");
            }
        }
    }

    
}