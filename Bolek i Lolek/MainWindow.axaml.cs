using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

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
        if (MyComboBox.SelectedIndex < 0)
            return;

        try
        {
            var path = _imagePaths[MyComboBox.SelectedIndex];
            
            using var stream = AssetLoader.Open(new Uri(path));
            ShowImage.Source = new Bitmap(stream);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd ładowania obrazu: {ex.Message}");
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

        string dodatki = "";
        if (NaDworze.IsChecked == true) dodatki += "Na dworze ";
        if (PotrzebnySprzet.IsChecked == true) dodatki += "Potrzebny sprzęt ";
        if (UdzialKolegow.IsChecked == true) dodatki += "Z udziałem kolegów ";
        if (PoSzkole.IsChecked == true) dodatki += "Po szkole ";
        if (Dorosly.IsChecked == true) dodatki += "Z dorosłym ";
        
        string data = EgzamCalendar.SelectedDate?.ToString("dd.MM.yyyy") ?? "brak daty";
        
        string bohater = (MyComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ??  "Nie znany lub nie wybrany bohater";

        string zadanieBoh = $"{bohater} - {nazwaZadania} - {priotytety} - {data} - {dodatki} ";
        
        ListaZadan.Items.Add(zadanieBoh);
        
        Zadanie.Text = "";

        NiskiPriorytet.IsChecked = false; 
        NormalnyPriorytet.IsChecked = false; 
        WysokiPriorytet.IsChecked = false; 
        
        NaDworze.IsChecked = false;
        PotrzebnySprzet.IsChecked = false;
        UdzialKolegow.IsChecked = false;
        PoSzkole.IsChecked = false;
        Dorosly.IsChecked = false;

    }

    private void Usun_OnClick(object? sender, RoutedEventArgs e)
    {
        if (ListaZadan.SelectedItem != null)
        {
            ListaZadan.Items.Remove(ListaZadan.SelectedItem);
        }
    }

    private void SumarryOpen_OnClick(object? sender, RoutedEventArgs e)
    {
        if (EgzamCalendar.SelectedDate == null)
            return;
        
        string wybranaData = EgzamCalendar.SelectedDate.Value.ToString("dd.MM.yyyy");

        var zadaniaNaDzis = new List<string>();

        foreach (var zadania in ListaZadan.Items)
        {
            if (zadania is string task && task.Contains(wybranaData))
            {
                zadaniaNaDzis.Add(task);
            }
        }
        
        var summaryWindow = new PodsumowanieDnia(wybranaData, zadaniaNaDzis);
        summaryWindow.Show();
    }
}
