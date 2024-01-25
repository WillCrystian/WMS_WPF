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
using WMS_WPF.Screens;

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
        CriarBancoDeDados();
        CreatePositionScreen();
    }

    private void CriarBancoDeDados()
    {
        BancodeDados.CreateDb();
        string sql = @"CREATE TABLE IF NOT EXISTS Op (
                        id INTEGER PRIMARY KEY AUTOINCREMENT, 
                        numeroOp INTERGER NOT NULL UNIQUE, 
                        quantidadeItem INTERGER NOT NULL);";
        BancodeDados.CreateTableDb(sql);
        sql = @"CREATE TABLE IF NOT EXISTS Produto (
                id INTEGER PRIMARY KEY AUTOINCREMENT, 
                opId INTERGER, 
                item INTERGER NOT NULL, 
                FOREIGN KEY (opId) REFERENCES Op(id) ON DELETE CASCADE);";
        BancodeDados.CreateTableDb(sql);
        sql = @"CREATE TABLE IF NOT EXISTS Rua (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                numeroRua INTERGER NOT NULL,
                quantidadePosicoes INTERGER NOT NULL)";
        BancodeDados.CreateTableDb(sql);
    }

    private void btn_cadastrarOp_Click(object sender, RoutedEventArgs e)
    {
        cadastrarOp.Show();
    }

    private void btn_cadastrarProduto_Click(object sender, RoutedEventArgs e)
    {
        cadastrarProduto.Show();
    }

    private void btn_cadastrarRua_Click(object sender, RoutedEventArgs e)
    {
        cadastrarRua.Show();
    }

    private void CreatePositionScreen()
    {
        string sql = "SELECT * FROM Rua";
        DataTable dt = BancodeDados.SelectDb(sql);
        int altura = 100;
        int espacamentoAltura = 60;

        foreach (DataRow dr in dt.Rows)
        {
            int quantidadePosicoes = Convert.ToInt32(dr["quantidadePosicoes"]);
            int numeroRua = Convert.ToInt32(dr["numeroRua"]);

            for (int i = 0; i < quantidadePosicoes; i++)
            {
                Posicao posicao = new Posicao(numeroRua, altura, i);
                myCanvas.Children.Add(posicao.button);
                myCanvas.Children.Add(posicao.label);
            }
            altura += espacamentoAltura;
        }
    }

}

