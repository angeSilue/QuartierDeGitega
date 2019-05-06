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
	public partial class IphoneContentPage : ContentPage
	{
		public IphoneContentPage (string titre, string membres)
		{
			InitializeComponent ();

            InitControlle(titre, membres);

        }

        Label ApplecareLlabel;
        Label memoireLlabel;
        Label ApplecareLabel;
        Label memoireLabel;
        

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

            ApplecareLabel = new Label
            {
                //Text = ApplecareString,
                TextColor = Color.Green,
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Start
            };

            memoireLabel = new Label
            {
                //Text = memoireString,
                TextColor = Color.Green,
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Start
            };

            ApplecareLlabel = new Label
            {
                Text = "voulez vous l'assurance Apple Care?",
                TextColor = Color.Red,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Start
            };

            memoireLlabel = new Label
            {
                Text = "capacitée(entre 64Gb et 1000Gb)",
                TextColor = Color.Red,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Start

            };

            Switch ouinonSwitch = new Switch()
            {       
                IsToggled = false,
                HorizontalOptions = LayoutOptions.Center
            };
            ouinonSwitch.Toggled += OuinonSwitch_Toggled;
            

            Slider memoireSlider = new Slider(64,1000,64)
            {
                WidthRequest = 200,                
                HorizontalOptions = LayoutOptions.Center
            };
            memoireSlider.ValueChanged += MemoireSlider_ValueChanged;
            
            
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
                    ApplecareLlabel,
                    ApplecareLabel,
                    ouinonSwitch,
                    memoireLlabel,
                    memoireLabel,
                    memoireSlider,
                    pagePrecedenteButton,
                    membreLabel
                }
            };

            pagePrecedenteButton.Clicked += PagePrecedenteButton_Clicked;
        }

        private void MemoireSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            memoireLabel.Text = e.NewValue.ToString();
            //throw new NotImplementedException();
        }

        private void OuinonSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == true)
                ApplecareLabel.Text = "Oui";
            else
                ApplecareLabel.Text = "Non";
            //throw new NotImplementedException();
        }

        async void PagePrecedenteButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }
}