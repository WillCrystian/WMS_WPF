using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WMS_WPF;

public class BancodeDados
{
    public static SQLiteConnection conn;
    public static string pathDb = Directory.GetCurrentDirectory() + $"\\wms.db";

    public static SQLiteConnection DbConnection()
    {
        conn = new SQLiteConnection($"Data Source={pathDb};Version=3;");

        try
        {
            conn.Open();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao fazer conexão ao banco de dados. Error: {ex}", "Messagem Erro", MessageBoxButton.OK);
        }
        return conn;
    }
    public static void CreateDb()
    {
        try
        {
            if (!File.Exists(pathDb))
            {
                SQLiteConnection.CreateFile(pathDb);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível criar o banco de dados. Error: {ex}", "Messagem Erro", MessageBoxButton.OK);
        }
    }

    public static void CreateTableDb(string sql)
    {
        try
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                //$"CREATE TABLE IF NOT EXISTS {nomeTable} (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT NOT NULL UNIQUE);"
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                DbConnection().Close();
            }
        }
        catch (Exception ex)
        {
            var nameTable = sql.Split(' ');
            MessageBox.Show($"Não foi possível criar a tabela {nameTable[5]}. Error: {ex}", "Messagem Erro", MessageBoxButton.OK);
        }
    }

    public static void InsertDb(string sql)
    {
        try
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                //$"INSERT INTO {nomeTable} (nome) VALUES ('{marca}')"
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                DbConnection().Close();
            }
        }
        catch (Exception ex)
        {
            var nameTable = sql.Split(" ");
            MessageBox.Show($"Não foi possível inserir dados na tabela {nameTable[2]}. Error: {ex}", "Messagem Erro", MessageBoxButton.OK);
        }
    }

    public static void UpdateDb(string sql)
    {
        try
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                //$"UPDATE {nomeTable} SET nome = '{novoNome}' WHERE id = {id};"
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                DbConnection().Close();
            }
        }
        catch (Exception ex)
        {
            var nameTable = sql.Split(" ");
            MessageBox.Show($"Não foi possível atualizar a tabela {nameTable[1]}. Error: {ex}", "Messagem Erro", MessageBoxButton.OK);
        }
    }

    public static void DeleteDb(string sql)
    {
        try
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                //$"DELETE FROM {nomeTable} WHERE id = {id};"
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                DbConnection().Close();
            }
        }
        catch (Exception ex)
        {
            var nameTable = sql.Split(" ");
            MessageBox.Show($"Não foi possível excluir dados da tabela {nameTable[2]}. Error: {ex}", "Messagem Erro", MessageBoxButton.OK);
        }
    }

    public static DataTable SelectDb(string sql)
    {
        SQLiteDataAdapter da = null;
        DataTable dt = new DataTable();
        try
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                //$"SELECT * FROM {nomeTabela} Where nome='{nome}';"
                cmd.CommandText = sql;
                da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                da.Fill(dt);
                DbConnection().Close();
            }
        }
        catch (Exception ex)
        {
            var nameTable = sql.Split(" ");
            MessageBox.Show($"Não foi possível Consultar dados da tabela {nameTable[3]}. Error: {ex}", "Messagem Erro", MessageBoxButton.OK);
        }
        return dt;
    }

    public static bool GetSomeSelectDb(string sql)
    {
        DataTable dt = SelectDb(sql);

        if (dt.Rows.Count > 0)
            return true;
        return false;
    }
}
