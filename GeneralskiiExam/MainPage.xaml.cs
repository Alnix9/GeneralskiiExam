using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace GeneralskiiExam
{
    public partial class MainPage : ContentPage
    {
        string mainDir = FileSystem.Current.AppDataDirectory;
        ObservableCollection<Abonent> abonents;
        public MainPage()
        {
            InitializeComponent();
            abonents = new ObservableCollection<Abonent>();
  
            abonents.Add(new Abonent
            { FIO = "Хачетрян А. Н.", Number = 832358392, adress = "ул. Шабулина" });
            abonents.Add(new Abonent
            { FIO = "Косов Д. О.", Number = 832358392, adress = "ул. Магистральная" });
            abonents.Add(new Abonent
            { FIO = "Харапудько Р. Р.", Number = 832478392, adress = "ул. Первомайская" });
            abonents.Add(new Abonent
            { FIO = "Томилин А. Д.", Number = 863478392, adress = "ул. Политаева" });
            abonents.Add(new Abonent
            { FIO = "Топоркина А. А.", Number = 873578392, adress = "ул. Политаева" });
            abonentsList.ItemsSource = abonents;
        }
        private void btnSave_Clicked(object sender, EventArgs e)
        {
            string jsonString = JsonSerializer.Serialize(abonents);
            StreamWriter sw = new StreamWriter(Path.Combine(mainDir, "abonents.txt"));
            sw.WriteLine(jsonString);
            sw.Close();
        }

        private void btnOpen_Clicked(object sender, EventArgs e)
        {
            StreamReader sw = new StreamReader(Path.Combine(mainDir, "workers.txt"));
            string jsonString = sw.ReadLine();
            abonents = JsonSerializer.Deserialize<ObservableCollection<Abonent>>(jsonString);
            sw.Close();
            abonentsList.ItemsSource = abonents;
        }
        private void workersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Abonent selectedItem;
            if (e.SelectedItem != null)
            {
                selectedItem = (Abonent)e.SelectedItem;
                lbSelectedText.Text = selectedItem.FIO + " " + selectedItem.Number + " " + selectedItem.adress;
                abonentsList.ItemsSource = abonents;
            }
        }
        private async void btnEdit_Clicked(object sender, EventArgs e)
        {
            Abonent selectedItem;
            if (abonentsList.SelectedItem != null)
            {
                selectedItem = (Abonent)abonentsList.SelectedItem;
                Data.abonent = selectedItem;
                EditPage editPage = new EditPage();
                Navigation.PushModalAsync(editPage);

            }
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Data.add == true)
            {
                abonents.Add(Data.abonent);
                Data.add = false;
            }
            abonentsList.ItemsSource = null;
            abonentsList.ItemsSource = abonents;
        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            AddPage addPage = new AddPage();
            Navigation.PushModalAsync(addPage);
        }

        private void btnDel_Clicked(object sender, EventArgs e)
        {
            Abonent abonent = (Abonent)abonentsList.SelectedItem;
            if (abonent != null)
            {
                abonents.Remove(abonent);
            }
            abonentsList.ItemsSource = null;
            abonentsList.ItemsSource = abonents;
        }
    }
}
