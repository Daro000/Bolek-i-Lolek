using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Bolek_i_Lolek;

public partial class PodsumowanieDnia : Window
{
    public PodsumowanieDnia(string date , List<string> zadania)
    {
        InitializeComponent();
        DateText.Text = $"zadania na {date}";

        foreach (var item in zadania)
        {
            SummaryList.Items.Add(item);
        }
    }
}