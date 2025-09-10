using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;

namespace Bolek_i_Lolek;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private readonly string[] _imagePaths =
    {
        "avares://Bolek i Lolek/Assets/Bolek.webp",
        "avares://Bolek i Lolek/Assets/Lolek.webp"
    };
    
    
    private void MyComboBox_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (MyComboBox.SelectedIndex >= 0)
        {
            var path = _imagePaths[MyComboBox.SelectedIndex];
            ShowImage.Source = new Bitmap(path);
        }
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        string nazwaZadania = Zadanie.Text?.Trim() ?? "";
        if(string.IsNullOrWhiteSpace(nazwaZadania))
            return;

        string priotytety = "normalny";
        if (NiskiPriorytet.IsChecked == true) priotytety = "niski";
        else if(WysokiPriorytet.IsChecked == true) priotytety = "wysoki";
        
        string bohater = (MyComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ??  "Nie znany lub nie wybrany bohater";

        string zadanieBoh = $"{bohater} - {nazwaZadania} - {priotytety}";
        
        ListaZadan.Items.Add(zadanieBoh);
        
        Zadanie.Text = "";
    }

    private void Usun_OnClick(object? sender, RoutedEventArgs e)
    {
        if (ListaZadan.SelectedItem != null)
        {
            ListaZadan.Items.Remove(ListaZadan.SelectedItem);
        }
    }
}