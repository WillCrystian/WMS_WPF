using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
using WMS_WPF.Sistemas;

namespace WMS_WPF.Views
{
    /// <summary>
    /// Interaction logic for CadastrarRua.xaml
    /// </summary>
    public partial class CadastrarRua : Window
    {
        public CadastrarRua()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void btn_cadastrarRua_Click(object sender, RoutedEventArgs e)
        {
            string numeroRua = txt_numeroRua.Text.Trim();
            string quantidadePosicoes = cb_quantidadePosicoes.Text;

            if (numeroRua == "" || quantidadePosicoes == "")
            {
                MessageBox.Show("Preencher todos os campos.", "Mensagem Erro", MessageBoxButton.OK);
                return;
            }

            string sql = $"SELECT * FROM Rua WHERE numeroRua = '{numeroRua}'";
            if (BancodeDados.GetSomeSelectDb(sql))
            {
                MessageBox.Show($"Rua {numeroRua} já existe.", "Mensagem Erro", MessageBoxButton.OK);
                return;
            }
            else
            {
                sql = $"INSERT INTO Rua (numeroRua, quantidadePosicoes) VALUES ({numeroRua}, {quantidadePosicoes})";
                BancodeDados.InsertDb(sql);
                MessageBox.Show($"Rua {numeroRua} cadastrado com sucesso.", "Mensagem Sucesso", MessageBoxButton.OK);               
            }

            txt_numeroRua.Text = "";
            cb_quantidadePosicoes.Text = "";
            this.Close(); 
        }
    }
}
