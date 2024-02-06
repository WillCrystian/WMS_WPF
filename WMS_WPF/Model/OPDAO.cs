using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WMS_WPF.Interface;
using WMS_WPF.Sistemas;

namespace WMS_WPF.Model;

public class OPDAO : IDAO<OP>
{
    public void Delete(OP t)
    {
        try
        {
            using (var cmd = BancodeDados.DbConnection().CreateCommand())
            {
                cmd.CommandText = $"DELETE FROM Op WHERE id = {t.Id};";
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível deletar dados na tabela Op. Error: {ex}", "Messagem Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        finally
        {
            BancodeDados.Close();
        }
    }

    public OP GetById(int id)
    {
        OP op = new OP(); ;
        try
        {
            using (var cmd = BancodeDados.DbConnection().CreateCommand())
            {
                cmd.CommandText = $"SELECT * FROM Op Where id='{id}';";
                cmd.CommandType = CommandType.Text;
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        op.Id = Convert.ToInt32(reader["id"]);
                        op.NumeroOp = Convert.ToInt32(reader["numeroOp"]);
                        op.QuantidadeItem = Convert.ToInt32(reader["quantidadeItem"]);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível Consultar dados da tabela Op. Error: {ex}", "Messagem Erro", MessageBoxButton.OK);
        }
        finally
        {
            BancodeDados.Close();
        }
        return op;
    }    

    public void Insert(OP t)
    {
        try
        {
            using (var cmd = BancodeDados.DbConnection().CreateCommand())
            {
                cmd.CommandText = $"INSERT INTO Op (numeroOp, quantidadeItem) VALUES ({t.NumeroOp}, {t.QuantidadeItem})";
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {           
            MessageBox.Show($"Não foi possível inserir dados na tabela Op. Error: {ex}", "Messagem Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        finally
        {
            BancodeDados.Close();
        }
    }

    public List<OP> List()
    {
        List<OP> list = new List<OP>();
        try
        {
            using (var cmd = BancodeDados.DbConnection().CreateCommand())
            {
                cmd.CommandText = $"SELECT * FROM Op";
                cmd.CommandType = CommandType.Text;

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OP op = new OP();
                        op.Id = Convert.ToInt32(reader["id"]);
                        op.NumeroOp = Convert.ToInt32(reader["numeroOp"]);
                        op.QuantidadeItem = Convert.ToInt32(reader["quantidadeItem"]);
                        list.Add(op);
                    }
                }
                BancodeDados.DbConnection().Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível Consultar dados da tabela Op. Error: {ex}", "Messagem Erro", MessageBoxButton.OK);
        }
        finally
        {
            BancodeDados.Close();
        }

        return list;
    }

    public bool ExistsOP(int numeroOp)
    {
        List<OP> list = new List<OP>();
        try
        {
            using (var cmd = BancodeDados.DbConnection().CreateCommand())
            {
                cmd.CommandText = $"SELECT * FROM Op WHERE numeroOp={numeroOp}";
                cmd.CommandType = CommandType.Text;

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OP op = new OP();
                        op.Id = Convert.ToInt32(reader["id"]);
                        op.NumeroOp = Convert.ToInt32(reader["numeroOp"]);
                        op.QuantidadeItem = Convert.ToInt32(reader["quantidadeItem"]);
                        list.Add(op);
                    }
                }
                BancodeDados.DbConnection().Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível Consultar dados da tabela Op. Error: {ex}", "Messagem Erro", MessageBoxButton.OK);
        }
        finally
        {
            BancodeDados.Close();
        }

        if (list.Count > 0)
            return true;
        return false;
    }

    public void Update(OP t)
    {
        try
        {
            using (var cmd = BancodeDados.DbConnection().CreateCommand())
            {
                cmd.CommandText = $"UPDATE Rua SET numeroOp = {t.NumeroOp}, quantidadeItem = {t.QuantidadeItem} WHERE id = {t.Id};";
                cmd.ExecuteNonQuery();
                BancodeDados.DbConnection().Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível atualizar os dados na tabela Op. Error: {ex}", "Messagem Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        finally
        {
            BancodeDados.Close();
        }
    }
}
