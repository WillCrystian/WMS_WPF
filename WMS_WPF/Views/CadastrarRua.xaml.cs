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
using WMS_WPF.Model;
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
           
            if (txt_numeroRua.Text.Trim() == "" || cb_quantidadePosicoes.Text == "")
            {
                MessageBox.Show("Preencher todos os campos.", "Mensagem Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Rua rua = new Rua();
            rua.QuantidadePosicao = Convert.ToInt32(cb_quantidadePosicoes.Text);
            rua.NumeroRua = Convert.ToInt32(txt_numeroRua.Text.Trim());

            RuaDAO ruaDAO = new RuaDAO();

            var existeRuaCadastrada = ruaDAO.List().Exists(x => x.NumeroRua == rua.NumeroRua);
            if (existeRuaCadastrada)
            {
                MessageBox.Show($"Rua {rua.NumeroRua} já existe.", "Mensagem Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {       
                ruaDAO.Insert(rua);
                MessageBox.Show($"Rua {rua.NumeroRua} cadastrado com sucesso.", "Mensagem Sucesso", MessageBoxButton.OK);
            }

            txt_numeroRua.Text = "";
            cb_quantidadePosicoes.Text = "";
            this.Close();
        }
    }
}
