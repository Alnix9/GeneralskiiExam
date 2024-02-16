namespace GeneralskiiExam;

public partial class EditPage : ContentPage
{
	public EditPage()
	{
		InitializeComponent();
        entFIO.Text = Data.abonent.FIO;
        entNumber.Text = Convert.ToString(Data.abonent.Number);
        entAdress.Text = Data.abonent.adress;
    }

    private async void btnEdit_Clicked(object sender, EventArgs e)
    {
        Data.abonent.FIO = entFIO.Text;
        Data.abonent.Number = Convert.ToInt32(entNumber.Text);
        Data.abonent.adress = entAdress.Text;

        await Navigation.PopModalAsync();
    }
    private async void btnBack_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}