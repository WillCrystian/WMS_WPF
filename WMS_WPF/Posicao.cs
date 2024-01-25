using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WMS_WPF;

public class Posicao
{
    private int[] Profundidade = new int[] { 170, 110, 50};
    public Button button { get; private set; }
    public Label label { get; private set; }
    public Posicao(int numeroRua, int altura, int profundidade) 
    {
        CretePosition(numeroRua, altura, profundidade);
    }

    private void CretePosition(int numeroRua, int altura, int profundidade)
    {
        button = new Button();
        button.Width = 50;
        button.Height = 50;
        //button.Margin = new Thickness(10, 10, 0, 0);
        button.HorizontalAlignment = HorizontalAlignment.Left;
        button.VerticalAlignment = VerticalAlignment.Top;
        Canvas.SetTop(button, altura);
        Canvas.SetLeft(button, Profundidade[profundidade]);

        label = new Label();
        label.Content = "Rua " + numeroRua.ToString();
        Canvas.SetTop(label, altura+17);
        Canvas.SetLeft(label, 5);
    }
}
