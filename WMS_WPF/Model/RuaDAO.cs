using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Xml;
using WMS_WPF.Interface;
using WMS_WPF.Sistemas;

namespace WMS_WPF.Model
{
    internal class RuaDAO : IDAO<Rua>
    {
        public void Delete(Rua t)
        {
            try
            {
                using (var cmd = BancodeDados.DbConnection().CreateCommand())
                {
                    cmd.CommandText = $"DELETE FROM Rua WHERE id = {t.Id};";
                    cmd.ExecuteNonQuery();                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível deletar dados na tabela Rua. Error: {ex}", "Messagem Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                BancodeDados.Close();
            }
        }

        public Rua GetById(int id)
        {
            Rua rua = new Rua(); ;
            try
            {
                using (var cmd = BancodeDados.DbConnection().CreateCommand())
                {
                    cmd.CommandText = $"SELECT * FROM Rua Where id='{id}';";
                    cmd.CommandType = CommandType.Text;
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rua.Id = Convert.ToInt32(reader["id"]);
                            rua.NumeroRua = Convert.ToInt32(reader["numeroRua"]);
                            rua.QuantidadePosicao = Convert.ToInt32(reader["numeroRua"]);                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {                
                MessageBox.Show($"Não foi possível Consultar dados da tabela Rua. Error: {ex}", "Messagem Erro", MessageBoxButton.OK);
            }
            finally
            {
                BancodeDados.Close();
            }
            return rua;
        }

        public void Insert(Rua t)
        {
            try
            {
                using (var cmd = BancodeDados.DbConnection().CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO Rua (numeroRua, quantidadePosicao) VALUES ({t.NumeroRua}, {t.QuantidadePosicao})";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show($"Não foi possível inserir dados na tabela Rua. Error: {ex}", "Messagem Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                BancodeDados.Close();
            }
        }

        public List<Rua> List()
        {
            List<Rua> list = new List<Rua>();
            try
            {
                using (var cmd = BancodeDados.DbConnection().CreateCommand())
                {                    
                    cmd.CommandText = $"SELECT * FROM Rua";                   
                    cmd.CommandType = CommandType.Text;

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Rua rua = new Rua();
                            rua.Id = Convert.ToInt32(reader["id"]);
                            rua.NumeroRua = Convert.ToInt32(reader["numeroRua"]);
                            rua.QuantidadePosicao = Convert.ToInt32(reader["numeroRua"]);
                            list.Add(rua);
                        }
                    }
                    BancodeDados.DbConnection().Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível Consultar dados da tabela Rua. Error: {ex}", "Messagem Erro", MessageBoxButton.OK);
            }
            finally
            {
                BancodeDados.Close();
            }

            return list;
        }

        public void Update(Rua t)
        {
            try
            {
                using (var cmd = BancodeDados.DbConnection().CreateCommand())
                {
                    cmd.CommandText = $"UPDATE Rua SET numeroRua = {t.NumeroRua}, quantidadePosicao = {t.QuantidadePosicao} WHERE id = {t.Id};";
                    cmd.ExecuteNonQuery();
                    BancodeDados.DbConnection().Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível atualizar dados na tabela Rua. Error: {ex}", "Messagem Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                BancodeDados.Close();
            }
        }
    }
}
