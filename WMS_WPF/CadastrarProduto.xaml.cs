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

namespace WMS_WPF;

/// <summary>
/// Interaction logic for CadastrarProduto.xaml
/// </summary>
public partial class CadastrarProduto : Window
{
    public CadastrarProduto()
    {
        InitializeComponent();
       
    }

    private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        var textBox = sender as TextBox;
        e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
    }

    private void btn_cadastrarProduto_Click(object sender, RoutedEventArgs e)
    {
        string sql = "";
        string numeroOp = cb_numeroOp.Text;
        string item = txt_item.Text.Trim();

        if (numeroOp == "" || item == "")
        {
            MessageBox.Show("Preencher todos os campos.", "Mensagem Erro", MessageBoxButton.OK);
            return;
        }

        sql = $"SELECT * FROM Op Where numeroOp={numeroOp}";
        DataTable dt = BancodeDados.SelectDb(sql);       
        var opId = dt.Rows[0]["id"];
        int quantidadeItem = Convert.ToInt32(dt.Rows[0]["quantidadeItem"]);

        sql = $"SELECT * FROM Produto WHERE opId = {opId} AND item= {item}";       
        if (BancodeDados.GetSomeSelectDb(sql))
        {
            MessageBox.Show($"O item {item} da OP {numeroOp} já existe.", "Mensagem Erro", MessageBoxButton.OK);
            return;
        }
        else
        {
            sql = $"SELECT * FROM Produto WHERE opId = {opId}";
            DataTable d = BancodeDados.SelectDb(sql);
            if (d.Rows.Count >= quantidadeItem)
            {
                MessageBox.Show($"O limite de item para a OP {numeroOp} já estorou.", "Mensagem Erro", MessageBoxButton.OK);
                return;
            }
            sql = $"INSERT INTO Produto (opId, item) VALUES ({opId}, {item})";
            BancodeDados.InsertDb(sql);
            MessageBox.Show($"O Produto da OP {numeroOp} item {item} cadastrado com sucesso", "", MessageBoxButton.OK);
        }

        cb_numeroOp.Text = "";
        txt_item.Text = "";
        this.Hide();
    }

    private void Load(object sender, RoutedEventArgs e)
    {
        string sql = $"SELECT * FROM Op ORDER BY numeroOp";
        DataTable dt = BancodeDados.SelectDb(sql);
        foreach (DataRow dr in dt.Rows)
        {
            cb_numeroOp.Items.Add(dr["numeroOp"]);
        }
    }
}
