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

namespace WMS_WPF.Model
{
    internal class ProdutoDAO : IDAO<Produto>
    {
        public void Delete(Produto t)
        {
            try
            {
                using (var cmd = BancodeDados.DbConnection().CreateCommand())
                {
                    cmd.CommandText = $"DELETE FROM Produto WHERE id = {t.Id};";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível deletar dados na tabela Produto. Error: {ex}", "Messagem Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                BancodeDados.Close();
            }
        }

        public Produto GetById(int id)
        {
            Produto produto = new Produto(); ;
            try
            {
                using (var cmd = BancodeDados.DbConnection().CreateCommand())
                {
                    cmd.CommandText = $"SELECT * FROM Produto Where id='{id}';";
                    cmd.CommandType = CommandType.Text;
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            produto.Id = Convert.ToInt32(reader["id"]);
                            produto.Nome = Convert.ToString(reader["nome"]);
                            produto.Op = reader["opFK"] as OP;
                            produto.Item = Convert.ToInt32(reader["item"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível Consultar dados da tabela Produto. Error: {ex}", "Messagem Erro", MessageBoxButton.OK);
            }
            finally
            {
                BancodeDados.Close();
            }
            return produto;
        }

        public void Insert(Produto t)
        {
            try
            {
                using (var cmd = BancodeDados.DbConnection().CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO Produto (nome, opFK, item) VALUES ('{t.Nome}', {t.Op.Id}, {t.Item})";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível inserir dados na tabela Produto. Error: {ex}", "Messagem Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                BancodeDados.Close();
            }
        }

        public List<Produto> List()
        {
            List<Produto> list = new List<Produto>();
            try
            {
                using (var cmd = BancodeDados.DbConnection().CreateCommand())
                {
                    cmd.CommandText = $"SELECT * FROM Produto";
                    cmd.CommandType = CommandType.Text;

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produto produto = new Produto();
                            OP op = new OP();

                            produto.Id = Convert.ToInt32(reader["id"]);
                            produto.Nome = Convert.ToString(reader["nome"]);                            
                            produto.Op = new OPDAO().GetById(Convert.ToInt32(reader["opFK"]));
                            produto.Item = Convert.ToInt32(reader["item"]);
                            list.Add(produto);
                        }
                    }
                    BancodeDados.DbConnection().Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível Consultar dados da tabela Produto. Error: {ex}", "Messagem Erro", MessageBoxButton.OK);
            }
            finally
            {
                BancodeDados.Close();
            }

            return list;
        }

        public void Update(Produto t)
        {
            try
            {
                using (var cmd = BancodeDados.DbConnection().CreateCommand())
                {
                    cmd.CommandText = $"UPDATE Produto SET nome = {t.Nome}, opFK = {t.Op.Id}, numeroItem = {t.Item} WHERE id = {t.Id};";
                    cmd.ExecuteNonQuery();
                    BancodeDados.DbConnection().Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível atualizar dados na tabela Produto. Error: {ex}", "Messagem Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                BancodeDados.Close();
            }
        }
    }
}
