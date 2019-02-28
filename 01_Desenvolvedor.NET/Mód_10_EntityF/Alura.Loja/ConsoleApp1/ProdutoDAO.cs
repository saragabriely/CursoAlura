﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    // Classe excluida
    internal class ProdutoDAO  //: IDisposable, IProdutoDAO
    {
         // Classe que não utiliza o Entity (ANTES DO ENTITY FRAMEWORK).
         
         // A classe funciona dessa forma, porém para aplicações que não mudam.
         // O que é muito dificl hoje em dia.

        // Entity - Realiza mapeamento.
        /*
        private SqlConnection conexao;

        public ProdutoDAO()
        {
            // SQLCONNECTION - Representa a conexão com o SQL Server.

            this.conexao = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=LojaDB;Trusted_Connection=true;");

            this.conexao.Open();
        }

        public void Dispose()
        {
            this.conexao.Close();
        }

        // O script é montado a mão para fazer a comunicação com o banco de dados.
        // O comando é montado em uma string.

        //  Os comandos/parametros são representados através de interfaces, que 
        // estão no namespace System.Data.SqlClient;
        // internal
        public void Adicionar(Produto p)
        {
            try
            {
                var insertCmd         = conexao.CreateCommand();
                insertCmd.CommandText = "INSERT INTO Produtos (Nome, Categoria, Preco) VALUES (@nome, @categoria, @preco)";
                
                // Nome
                var paramNome         = new SqlParameter("nome", p.Nome);
                insertCmd.Parameters.Add(paramNome);

                // Categoria
                var paramCategoria    = new SqlParameter("categoria", p.Categoria);
                insertCmd.Parameters.Add(paramCategoria);

                // Preço
                var paramPreco        = new SqlParameter("preco", p.PrecoUnitario);
                insertCmd.Parameters.Add(paramPreco);

                insertCmd.ExecuteNonQuery();
            } catch (SqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }
        //internal
        public void Atualizar(Produto p)
        {
            try
            {
                var updateCmd = conexao.CreateCommand();
                updateCmd.CommandText = "UPDATE Produtos SET Nome = @nome, Categoria = @categoria, Preco = @preco WHERE Id = @id";

                var paramNome       = new SqlParameter("nome", p.Nome);
                var paramCategoria  = new SqlParameter("categoria", p.Categoria);
                var paramPreco      = new SqlParameter("preco", p.PrecoUnitario);
                var paramId         = new SqlParameter("id", p.Id);

                updateCmd.Parameters.Add(paramNome);
                updateCmd.Parameters.Add(paramCategoria);
                updateCmd.Parameters.Add(paramPreco);
                updateCmd.Parameters.Add(paramId);

                updateCmd.ExecuteNonQuery();

            } catch (SqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        // internal
        public void Remover(Produto p)
        {
            try
            {
                var deleteCmd         = conexao.CreateCommand();
                deleteCmd.CommandText = "DELETE FROM Produtos WHERE Id = @id";

                var paramId = new SqlParameter("id", p.Id);
                deleteCmd.Parameters.Add(paramId);

                deleteCmd.ExecuteNonQuery();

            } catch(SqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        // internal
        public IList<Produto> Produtos()
        {
            var lista = new List<Produto>();

            var selectCmd = conexao.CreateCommand();
            selectCmd.CommandText = "SELECT * FROM Produtos";

            var resultado = selectCmd.ExecuteReader();
            while (resultado.Read())
            {
                Produto p = new Produto();
                p.Id        = Convert.ToInt32(resultado["Id"]);
                p.Nome      = Convert.ToString(resultado["Nome"]);
                p.Categoria = Convert.ToString(resultado["Categoria"]);
                p.PrecoUnitario = Convert.ToDouble(resultado["Preco"]);
                lista.Add(p);
            }
            resultado.Close();

            return lista;
        } */
    }
}