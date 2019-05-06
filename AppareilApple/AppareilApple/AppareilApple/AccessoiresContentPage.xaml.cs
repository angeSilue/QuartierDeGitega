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
	public partial class AccessoiresContentPage : ContentPage
	{
		public AccessoiresContentPage(string titre, string membres)
        {
			InitializeComponent ();

            InitControlle(titre, membres);
        }

        Label dateLivraisonLabel;
        TimePicker livraisonTimePicker;
        DatePicker livraisonDatePicker;

        public void InitControlle(string titre, string membres)
        {
            Label titreLabel = new Label()
            {
                Text = titre,
                BackgroundColor = Color.Black,
                FontSize = 60,
                TextColor = Color.Red,
                HorizontalOptions = LayoutOptions.Center

            };

            Label membreLabel = new Label()
            {
                FormattedText = membres,
                BackgroundColor = Color.Black,
                FontSize = 60,
                TextColor = Color.Yellow,
                HorizontalOptions = LayoutOptions.Center
            };

            Label livraisonLabel = new Label
            {
                Text = "Quand voulez vous etre livrer? ",
                TextColor = Color.Red,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Start
            };

            livraisonDatePicker = new DatePicker
            {
               
                HorizontalOptions = LayoutOptions.Center
            };

            livraisonDatePicker.DateSelected += LivraisonDatePicker_DateSelected;
            

            dateLivraisonLabel = new Label
            {
                //Text = "Numero processeur Intel: ",
                TextColor = Color.Green,
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Start
            };

            livraisonTimePicker = new TimePicker
            {
                
                HorizontalOptions = LayoutOptions.Center
            };

            //faire afficher la bonne Date(faire fonctionner le time picker)

            livraisonTimePicker.PropertyChanged += LivraisonTimePicker_PropertyChanged; 


            // Bouton revenir à la page précédente            
            Button pagePrecedenteButton = new Button
            {
                Text = "Page précédente",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Fill
            };

            this.Content = new StackLayout
            {
                Children =
                {
                    titreLabel,
                    livraisonLabel,
                    dateLivraisonLabel,
                    livraisonDatePicker,
                    livraisonTimePicker,                   
                    pagePrecedenteButton,
                    membreLabel
                }
            };

            pagePrecedenteButton.Clicked += PagePrecedenteButton_Clicked;
        }

        private void LivraisonTimePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            dateLivraisonLabel.Text = livraisonDatePicker.Date.ToLongDateString() +" "+ livraisonTimePicker.Time.ToString("t");
            //dateLivraisonLabel.Text = livraisonDatePicker.t + " ";
            //throw new NotImplementedException();
        }

        private void LivraisonDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            dateLivraisonLabel.Text = livraisonDatePicker.Date.ToLongDateString() + " " + livraisonTimePicker.Time.ToString("t"); ;            
            
        }

        async void PagePrecedenteButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}