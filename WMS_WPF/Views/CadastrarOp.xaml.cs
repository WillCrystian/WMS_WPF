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
        try
        {           
            if (txt_numeroOp.Text.Trim() == "" || txt_quantidadeItem.Text.Trim() == "")
            {
                MessageBox.Show("Preencher todos os campos.", "Mensagem Erro", MessageBoxButton.OK);
                return;
            }
            OP op = new OP();

            op.NumeroOp = Convert.ToInt32(txt_numeroOp.Text.Trim());
            op.QuantidadeItem = Convert.ToInt32(txt_quantidadeItem.Text.Trim());

            OPDAO opdao = new OPDAO();
            bool existOp = opdao.ExistsOP(op.NumeroOp);

            if (existOp)
            {
                MessageBox.Show($"A OP {txt_numeroOp.Text.Trim()} já está cadastrada.", "Messagem Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                opdao.Insert(op);
                MessageBox.Show("Cadastrado com sucesso.", "", MessageBoxButton.OK);
            }

            txt_numeroOp.Text = "";
            txt_quantidadeItem.Text = "";
            this.Close();
        }
        catch (Exception ex)
        {
            throw;
        }
       
    }
}
