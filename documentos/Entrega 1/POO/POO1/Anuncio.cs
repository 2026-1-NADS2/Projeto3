using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1
{
    internal class Anuncio
    {
        public int id { get; set; }
        public string nome { get; set; } //Nome
        public string desc { get; set; }
        public string categoria { get; set; }
        public string marca { get; set; }
        public double fornecedor { get; set; } //CNPJ
        public int MOQ { get; set; } //Quantidade minima
        public string regiao { get; set; }
        public string prazoEntrega { get; set; }
        public string contato { get; set; }
        public string status { get; set; } //(rascunho/ativo/pausado)

        public Anuncio(string n, string d, string cat, string m, int mo, string r, string pE, string cont, string s)
        {
            this.nome = n;
            this.desc = d;
            this.categoria = cat;
            this.marca = m;
            this.MOQ = mo;
            this.regiao = r;
            this.prazoEntrega = pE;
            this.contato = cont;
            this.status = s;
        }
    }
}
