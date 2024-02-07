using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WMS_WPF.Views;
using WMS_WPF.Sistemas;

namespace WMS_WPF.Model;

public class Posicao
{
    public Posicao()
    {        
    }
    public Posicao(Rua rua, int profundidade)
    {
        Rua = rua;
        Profundidade = profundidade;
        Ocupado = false;
    }

    public int Id { get; set; }
    public Rua Rua { get; set; }
    public int Profundidade { get; set; }
    public bool Ocupado { get; set; }
    


    //private int[] profundidade = new int[] { 170, 110, 50 };
    //public Button button { get; private set; }
    //public Label label { get; private set; }

    //public InfoPosicao infoPosicao = new InfoPosicao();

    //public Posicao(int numeroRua, int profundidade, int alturaPosicionamentoPosicao)
    //{
    //    NumeroRua = numeroRua;
    //    Profundidade = profundidade;

    //    CretePosition(numeroRua, profundidade, alturaPosicionamentoPosicao);
    //}

    //private void CretePosition(int numeroRua, int profundidade, int alturaPosicionamentoPosicao)
    //{
    //    button = new Button();
    //    button.Width = 50;
    //    button.Height = 50;
    //    //button.Margin = new Thickness(10, 10, 0, 0);
    //    button.HorizontalAlignment = HorizontalAlignment.Left;
    //    button.VerticalAlignment = VerticalAlignment.Top;
    //    button.Click += new RoutedEventHandler(Button_Click);
    //    Canvas.SetTop(button, alturaPosicionamentoPosicao);
    //    Canvas.SetLeft(button, this.profundidade[profundidade]);

    //    label = new Label();
    //    label.Content = "Rua " + numeroRua.ToString();
    //    Canvas.SetTop(label, alturaPosicionamentoPosicao);
    //    Canvas.SetLeft(label, 5);

    //    string query = $"INSERT INTO Posicao (Ocupado, NumeroRua, Profundidade) VALUES ({Ocupado}, {numeroRua}, {profundidade});";
    //    BancodeDados.InsertDb(query);
    //}

    //private void Button_Click(object sender, RoutedEventArgs e)
    //{

    //    infoPosicao.ShowDialog();

    //}
}
