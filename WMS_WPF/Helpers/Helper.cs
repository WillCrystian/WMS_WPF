using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS_WPF.Sistemas;

namespace WMS_WPF.Helpers;

public static class Helper
{
    public static void CriarBancoDeDados()
    {
        BancodeDados.CreateDb();

        string query = @"CREATE TABLE IF NOT EXISTS Op (
                        id INTEGER PRIMARY KEY AUTOINCREMENT, 
                        numeroOp INTERGER, 
                        quantidadeItem INTERGER);";
        BancodeDados.CreateTableDb(query);
        query = @"CREATE TABLE IF NOT EXISTS Produto (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                nome TEXT,
                opFK INTERGER, 
                item INTERGER);";
        BancodeDados.CreateTableDb(query);
        query = @"CREATE TABLE IF NOT EXISTS Rua (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                numeroRua INTERGER,
                quantidadePosicoes INTERGER)";
        BancodeDados.CreateTableDb(query);
        query = @"CREATE TABLE IF NOT EXISTS Posicao (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                ruaFK INTEGER,
                profundidade INTEGER,
                ocupado BOOL)";
        BancodeDados.CreateTableDb(query);
    }
}
