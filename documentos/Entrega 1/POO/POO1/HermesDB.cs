using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace POO1
{
    internal class HermesDB
    {

        private readonly string connStr;

        public HermesDB(string caminhoBanco)
        {
            this.connStr = $"Data Source={caminhoBanco}";
            MkTables();
        }

        public void MkTables()
        {
            using var cur = new SqliteConnection(connStr);
            cur.Open();

            using var comando = cur.CreateCommand();
            comando.CommandText = @"
                
            CREATE TABLE IF NOT EXISTS Compradores(id INTEGER PRIMARY KEY AUTOINCREMENT, login TEXT NOT NULL, senha TEXT NOT NULL,
             email TEXT NOT NULL UNIQUE, CNPJ INTEGER NOT NULL UNIQUE, saldo REAL NOT NULL);

            CREATE TABLE IF NOT EXISTS Fornecedores(id INTEGER PRIMARY KEY AUTOINCREMENT, login TEXT NOT NULL, senha TEXT NOT NULL,
             email TEXT NOT NULL UNIQUE, CNPJ INTEGER NOT NULL UNIQUE);


            CREATE TABLE IF NOT EXISTS Anuncios(id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT NOT NULL,
             descricao TEXT NOT NULL, marca TEXT NOT NULL, MOQ INTEGER NOT NULL, regiao TEXT NOT NULL,
             prazo TEXT NOT NULL, contato TEXT NOT NULL, status TEXT NOT NULL, 
             fornecedor INTEGER NOT NULL, FOREIGN KEY(""fornecedor"") REFERENCES ""Fornecedores""(""CNPJ""))";

            comando.ExecuteNonQuery();
        }

        public void InsertForn(Fornecedor forn) 
        {
            using var cur = new SqliteConnection(connStr);
            cur.Open();

            using var comando = cur.CreateCommand();
            try
            {
                comando.CommandText = $"INSERT INTO Fornecedores VALUES(NULL,'{forn.login}','{forn.senha}','{forn.email}','{forn.cnpj}');";
                comando.ExecuteNonQuery();
                Console.WriteLine("Fornecedor cadastrado");
            }catch (Exception ex) 
            { Console.WriteLine("Ocorreu um erro: \n" + ex); }

        }

        public void InsertComp(Comprador comp)
        {
            using var cur = new SqliteConnection(connStr);
            cur.Open();

            using var comando = cur.CreateCommand();
            try
            {
                comando.CommandText = $"INSERT INTO Compradores VALUES(NULL,'{comp.login}','{comp.senha}','{comp.email}','{comp.cnpj}','{comp.saldo}');";
                comando.ExecuteNonQuery();
                Console.WriteLine("Comprador cadastrado");
            }
            catch (Exception ex)
            { Console.WriteLine("Ocorreu um erro: \n" +ex ); }
        }

        public void InsertAd(Anuncio ad) 
        {
            using var cur = new SqliteConnection(connStr);
            cur.Open();

            using var comando = cur.CreateCommand();
            try
            {
                comando.CommandText = @$"INSERT INTO Anuncios VALUES(NULL,'{ad.nome}','{ad.desc}','{ad.marca}',{ad.MOQ},'{ad.regiao}','{ad.prazoEntrega}','{ad.contato}','{ad.status}',{ad.fornecedor});";
                comando.ExecuteNonQuery();
                Console.WriteLine("Anuncio inserido");
            }
            catch (Exception ex)
            { Console.WriteLine("Ocorreu um erro: \n" + ex); }
        }
    }
}
