using Avalonia.Controls;
using Avalonia.Interactivity;

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
    
    string comboBoxValue = (MyComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "No selection";
    
    private void ShowBolekLolek(object sender, RoutedEventArgs e)
    {
        try
        {
            if
        }
    }
}