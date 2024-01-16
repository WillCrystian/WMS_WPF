﻿using Microsoft.VisualBasic;
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

namespace WMS_WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    CadastrarOp cadastrarOp = new CadastrarOp();
    CadastrarProduto CadastrarProduto = new CadastrarProduto();
    public MainWindow()
    {
        InitializeComponent();
        CriarBancoDeDados();
    }

    private void CriarBancoDeDados()
    {
        BancodeDados.CreateDb();
        string sql = "CREATE TABLE IF NOT EXISTS Op (id INTEGER PRIMARY KEY AUTOINCREMENT, numeroOp INTERGER NOT NULL UNIQUE, quantidadeItem INTERGER NOT NULL);";
        BancodeDados.CreateTableDb(sql);
        sql = "CREATE TABLE IF NOT EXISTS Produto (id INTEGER PRIMARY KEY AUTOINCREMENT, opId INTERGER, numeroOp INTERGER NOT NULL, item INTERGER NOT NULL, FOREIGN KEY (opId) REFERENCES Op(id) ON DELETE CASCADE);";
        BancodeDados.CreateTableDb(sql);
    }

    private void btn_cadastrarOp_Click(object sender, RoutedEventArgs e)
    {
        cadastrarOp.Show();
    }

    private void btn_cadastrarProduto_Click(object sender, RoutedEventArgs e)
    {
        CadastrarProduto.Show();
    }
}