using Microsoft.Maui.Controls;

namespace GeneralskiiExam;

public partial class AddPage : ContentPage
{
	public AddPage()
    {
		InitializeComponent();
        Data.abonent = new Abonent();
    }
    private async void btnAdd_Clicked(object sender, EventArgs e)
    {
        Data.abonent.FIO = entFIO.Text;
        Data.abonent.Number = Convert.ToInt32(entNumber.Text);
        Data.abonent.adress = entAdress.Text;
        Data.add = true;
        await Navigation.PopModalAsync();
    }
    private async void btnBack_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}