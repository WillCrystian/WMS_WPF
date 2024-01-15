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
/// Interaction logic for CadastrarOp.xaml
/// </summary>
public partial class CadastrarOp : Window
{
    public CadastrarOp()
    {
        InitializeComponent();
    }

    private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        var textBox = sender as TextBox;
        e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
    }

    private void btn_cadastrarOp_Click(object sender, RoutedEventArgs e)
    {
        string numeroOp = txt_numeroOp.Text.Trim();
        string quantidadeItem = txt_quantidadeItem.Text.Trim(); 
        
        if(numeroOp == "" ||quantidadeItem == "")
        {
            MessageBox.Show("Preencher todos os campos.");
            return;
        }
        string sql = $"SELECT * FROM Op Where numeroOp='{numeroOp}'";
        bool existOp = BancodeDados.GetSomeSelectDb(sql);
        if(existOp)
        {
            MessageBox.Show($"A OP {numeroOp} já está cadastrada.", "Messagem Erro", MessageBoxButton.OK);
        }
        else
        {
            sql = $"INSERT INTO Op (numeroOp, quantidadeItem) VALUES ({numeroOp}, {quantidadeItem})";
            BancodeDados.InsertDb(sql);
            MessageBox.Show("Cadastrado com sucesso.", "", MessageBoxButton.OK);
        }

        txt_numeroOp.Text = "";
        txt_quantidadeItem.Text = "";
        this.Hide();
    }
}
