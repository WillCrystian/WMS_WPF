using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WMS_WPF.Model;
using WMS_WPF.Sistemas;

namespace WMS_WPF.Views;

/// <summary>
/// Interaction logic for CadastrarProduto.xaml
/// </summary>
public partial class CadastrarProduto : Window
{
    Produto produto;
    public CadastrarProduto()
    {
        InitializeComponent();
        Loaded += CadastrarProduto_Loaded; ;
       
    }

    private void CadastrarProduto_Loaded(object sender, RoutedEventArgs e)
    {
        produto = new Produto();
    }

    private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        var textBox = sender as TextBox;
        e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
    }

    private void btn_cadastrarProduto_Click(object sender, RoutedEventArgs e)
    {        
        if (cb_numeroOp.SelectedItem.ToString() == "" || txt_item.Text.Trim() == "")
        {
            MessageBox.Show("Preencher todos os campos.", "Mensagem Erro", MessageBoxButton.OK);
            return;
        }

        produto.Nome = "Rolo";
        produto.Op = cb_numeroOp.SelectedItem as OP;
        produto.Item = Convert.ToInt32(txt_item.Text);
        
        //verificar se o item da op já existe
        
        ProdutoDAO produtoDAO = new ProdutoDAO();

        var p = produtoDAO.List().Exists(x => x.Op.Id == produto.Op.Id && x.Item == produto.Item);
        if (p)
        {
            MessageBox.Show($"O item {produto.Item} da OP {produto.Op.NumeroOp} já existe.", "Mensagem Erro", MessageBoxButton.OK);
            return;
        }
        else
        {
            var quantidadeProdutoPorOP = produtoDAO.List().Where(x => x.Op == produto.Op).ToList();
            if (quantidadeProdutoPorOP.Count() >= produto.Op.QuantidadeItem)
            {
                MessageBox.Show($"O limite de item para a OP {produto.Op.NumeroOp} já estorou.", "Mensagem Erro", MessageBoxButton.OK);
                return;
            }

            produtoDAO.Insert(produto);
            MessageBox.Show($"O Produto da OP {produto.Op.NumeroOp} item {produto.Item} cadastrado com sucesso", "", MessageBoxButton.OK);
        }

        cb_numeroOp.Text = "";
        txt_item.Text = "";
        this.Close();
    }


    private void Load(object sender, RoutedEventArgs e)
    {        
        OPDAO opdao = new OPDAO();
        cb_numeroOp.ItemsSource = opdao.List();
    }

    
}
