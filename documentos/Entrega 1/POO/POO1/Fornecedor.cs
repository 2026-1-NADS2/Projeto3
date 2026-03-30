using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1
{
    internal class Fornecedor : Usuario
    {
        public List<Anuncio> anuncios { get; set; } = new List<Anuncio>();

        public Fornecedor(string l, string s, string e, double c) : base(l, s, e, c)
        {
            this.login = l;
            this.senha = s;
            this.email = e;
            this.cnpj = c;
        }

        public void MkAnuncio(string n, string d, string cat, string m, int mo, string r, string pE, string cont, HermesDB b) 
        {
            Anuncio a = new Anuncio( n, d, cat, m, mo, r, pE,cont,"Pendente");
            a.fornecedor = this.cnpj;
            anuncios.Add(a);
            b.InsertAd(a);
            Console.WriteLine("Anuncio " + n + " adicionado e esperando avaliação");
        }

        public void DadosFor()
        {
            Console.WriteLine($"Usuario: {this.login} \nSenha: {this.senha} \nEmail: {this.email}" +
                $" \nCNPJ: {this.cnpj.ToString(@"00\.000\.000\/0000\-00")}");
            Console.WriteLine("///ANUNCIOS///");
            foreach (Anuncio anuncio in anuncios)
            {
                Console.WriteLine($"{anuncio.nome} da marca: {anuncio.marca} " +
                    $"\nDescrição: {anuncio.desc} \nContato em: {anuncio.contato}");
                Console.WriteLine();
            }
        }
    }
}