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
	public partial class MacbookContentPage : ContentPage
	{
		public MacbookContentPage (string titre, string membres)
		{
			InitializeComponent ();

            InitControlle(titre, membres);
		}

        Entry intelEntry;
        Entry tailleEcranEntry;
        Label PrixLabel;

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

            Label tailleEcranLabel = new Label
            {
                Text = "Taille ecran: ",
                TextColor = Color.Red,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Start
            };

            tailleEcranEntry = new Entry
            {
                //Text = memoireString,
                TextColor = Color.Green,
                FontSize = 16,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            Label intelLabel = new Label
            {
                Text = "Numero processeur Intel: ",
                TextColor = Color.Red,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Start
            };

            intelEntry = new Entry
            {
                //Text = memoireString,
                TextColor = Color.Green,
                FontSize = 16,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            Label PrixLlabel = new Label
            {
                Text = "Prix sans Taxe ",
                TextColor = Color.Red,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Start
            };

            PrixLabel = new Label
            {
                //Text = memoireString,
                TextColor = Color.Green,
                FontSize = 16,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            Button calculerButton = new Button
            {
                Text = "Calculer Prix",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Fill
            };
            calculerButton.Clicked += CalculerButton_Clicked;

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
                    tailleEcranLabel,
                    tailleEcranEntry,
                    intelLabel,
                    intelEntry,
                    calculerButton,
                    PrixLlabel,
                    PrixLabel,
                    pagePrecedenteButton,
                    membreLabel
                }
            };

            pagePrecedenteButton.Clicked += PagePrecedenteButton_Clicked;
        }

        async void CalculerButton_Clicked(object sender, EventArgs e)
        {
            double resultat = 0.0;
            double tailleEcran = 0.0;
            int processeur = 0;

            try
            {
                tailleEcran = double.Parse(tailleEcranEntry.Text);
                processeur = int.Parse(intelEntry.Text);

                resultat = tailleEcran * processeur * 35;
                PrixLabel.Text = resultat.ToString("C2");

            }
            catch (Exception ex)
            {
                await DisplayAlert("Erreur", ex.ToString(), "Annulé");
            }

            //throw new NotImplementedException();
        }

        async void PagePrecedenteButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}