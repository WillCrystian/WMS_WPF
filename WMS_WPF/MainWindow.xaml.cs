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

