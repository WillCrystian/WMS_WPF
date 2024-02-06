using Microsoft.VisualBasic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WMS_WPF.Model;
using WMS_WPF.Views;
using WMS_WPF.Sistemas;
using WMS_WPF.Helpers;

namespace WMS_WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    CadastrarOp cadastrarOp = new CadastrarOp();
    CadastrarProduto cadastrarProduto = new CadastrarProduto();
    CadastrarRua cadastrarRua = new CadastrarRua();
    
    public MainWindow()
    {
            
        InitializeComponent();
        Loaded += MainWindow_Loaded;        
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        Helper.CriarBancoDeDados();
        txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
    }

    

    private void CreatePositionScreen()
    {
        string query = "SELECT * FROM Rua";
        DataTable dt = BancodeDados.SelectDb(query);
        int alturaPosicionamentoPosicao = 100;
        int espacamentoAltura = 60;

        foreach (DataRow dr in dt.Rows)
        {
            int quantidadePosicoes = Convert.ToInt32(dr["quantidadePosicoes"]);
            int numeroRua = Convert.ToInt32(dr["numeroRua"]);

            for (int i = 0; i < quantidadePosicoes; i++)
            {
                //Posicao posicao = new Posicao(numeroRua, i, alturaPosicionamentoPosicao);
                //myCanvas.Children.Add(posicao.button);
                //myCanvas.Children.Add(posicao.label);
                //espacamentoAltura = Convert.ToInt32(posicao.button.Height) + 10;
            }
            alturaPosicionamentoPosicao += espacamentoAltura;
        }
    }

    private void LoadScreen(object sender, RoutedEventArgs e)
    {
        CreatePositionScreen();
    }
    private void Selec_CadastrarOp(object sender, RoutedEventArgs e)
    {
        cadastrarOp.ShowDialog();
    }

    private void Selec_CadastrarProduto(object sender, RoutedEventArgs e)
    {
        cadastrarProduto.ShowDialog();
    }

    private void Selec_CadastrarRua(object sender, RoutedEventArgs e)
    {
        cadastrarRua.ShowDialog();
    }
}

