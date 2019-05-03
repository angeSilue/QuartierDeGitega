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
	public partial class IpadContentPage : ContentPage
	{
		public IpadContentPage (string titre, string membres)
		{
			InitializeComponent ();

            InitControlle(titre, membres);
        }

        Label typeLabel;
        Picker typeIpadPicker;

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

            Label typeLlabel = new Label
            {
                Text = " Le type de Ipad selectionné est :",
                TextColor = Color.Red,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center
            };

            Label typeSelectLabel = new Label
            {
                Text = "Selectionné un type de Ipad :",
                TextColor = Color.Red,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center
            };

            typeLabel = new Label
            {                
                TextColor = Color.Green,
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center
            };

            var ipadlist = new List<string>()            
            {
             "Ipad",
             "Ipad 2",
             "Ipad 3rd",
             "Ipad mini",
             "Ipar 4th",
             "Ipad Air",
             "Ipad mini1",
             "Ipad Pro 12.9in",
             "Ipad Pro 9.3in"
            };

            typeIpadPicker = new Picker
            {
                ItemsSource = ipadlist,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            typeIpadPicker.SelectedIndexChanged += TypeIpadPicker_SelectedIndexChanged;            


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
                    typeLlabel,
                    typeLabel,
                    typeSelectLabel,
                    typeIpadPicker,                   
                    pagePrecedenteButton,
                    membreLabel
                }
            };

            pagePrecedenteButton.Clicked += PagePrecedenteButton_Clicked;
        }

        private void TypeIpadPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            typeLabel.Text = typeIpadPicker.SelectedItem.ToString();
        }

        async void PagePrecedenteButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    
    }
}