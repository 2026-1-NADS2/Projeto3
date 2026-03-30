using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1
{
    internal class Usuario
    {
        public int id { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
        public double cnpj { get; set; }


        public Usuario( string l, string s, string e, double c)
        {
            this.login = l;
            this.senha = s;
            this.email = e;
            this.cnpj = c;
        }

        public void Pesquisar()
        {
            Console.WriteLine("Digite oq deseja pesquisar: ");
            string P = Convert.ToString(Console.Read());
            Console.WriteLine($"Resultados da pesquisa sobre {P}:");
        }
        public void Logar()
        {
            Console.WriteLine($"{this.login} seja bem vindo!!!");
        }
        public void Logout()
        {
            Console.WriteLine($"Adeus {this.login}!!!");
        }
    }
}