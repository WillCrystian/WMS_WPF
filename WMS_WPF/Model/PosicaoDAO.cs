﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WMS_WPF.Interface;
using WMS_WPF.Sistemas;
using System.Windows.Documents;

namespace WMS_WPF.Model;

public class PosicaoDAO : IDAO<Posicao>
{
    public void Delete(Posicao t)
    {
        try
        {
            using (var cmd = BancodeDados.DbConnection().CreateCommand())
            {
                cmd.CommandText = $"DELETE FROM Posicao WHERE id = {t.Id};";
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível deletar dados na tabela Posicao. Error: {ex}", "Messagem Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        finally
        {
            BancodeDados.Close();
        }
    }

    public Posicao GetById(int id)
    {
        Posicao posicao = new Posicao();
        try
        {
            using (var cmd = BancodeDados.DbConnection().CreateCommand())
            {
                cmd.CommandText = $"SELECT * FROM Posicao Where id='{id}';";
                cmd.CommandType = CommandType.Text;
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {                       
                        posicao.Id = Convert.ToInt32(reader["id"]);
                        posicao.Rua = new RuaDAO().GetById(Convert.ToInt32(reader["ruaFK"])); ;
                        posicao.Profundidade = Convert.ToInt32(reader["profundidade"]);
                        posicao.Ocupado = Convert.ToBoolean(reader["ocupado"]);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível Consultar dados da tabela Posição. Error: {ex}", "Messagem Erro", MessageBoxButton.OK);
        }
        finally
        {
            BancodeDados.Close();
        }
        return posicao;
    }

    public void Insert(Posicao t)
    {
        var existeDados = List().Exists(x => x.Rua.Id == t.Rua.Id && x.Profundidade == t.Profundidade);
        if (existeDados)                   
            return;

        try
        {
            using (var cmd = BancodeDados.DbConnection().CreateCommand())
            {
                cmd.CommandText = $"INSERT INTO Posicao (ruaFK, profundidade, ocupado) VALUES ({t.Rua.Id}, {t.Profundidade},{t.Ocupado})";
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível inserir dados na tabela Posicao. Error: {ex}", "Messagem Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        finally
        {
            BancodeDados.Close();
        }
    }

    public List<Posicao> List()
    {
        List<Posicao> list = new List<Posicao>();
        try
        {
            using (var cmd = BancodeDados.DbConnection().CreateCommand())
            {
                cmd.CommandText = $"SELECT * FROM Posicao";
                cmd.CommandType = CommandType.Text;

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Posicao posicao = new Posicao();
                        
                        posicao.Id = Convert.ToInt32(reader["id"]);
                        posicao.Rua = new RuaDAO().GetById(Convert.ToInt32(reader["ruaFK"])); 
                        posicao.Profundidade = Convert.ToInt32(reader["profundidade"]);
                        posicao.Ocupado = Convert.ToBoolean(reader["ocupado"]);

                        list.Add(posicao);
                    }
                }
                BancodeDados.DbConnection().Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível Consultar dados da tabela Posição. Error: {ex}", "Messagem Erro", MessageBoxButton.OK);
        }
        finally
        {
            BancodeDados.Close();
        }

        return list;
    }

    public void Update(Posicao t)
    {
        try
        {
            using (var cmd = BancodeDados.DbConnection().CreateCommand())
            {
                cmd.CommandText = $"UPDATE Rua SET ocupado = {t.Ocupado}, rua = {t.Rua}, posicao = {t.Profundidade} WHERE id = {t.Id};";
                cmd.ExecuteNonQuery();
                BancodeDados.DbConnection().Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível atualizar os dados na tabela Posição. Error: {ex}", "Messagem Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        finally
        {
            BancodeDados.Close();
        }
    }
}
