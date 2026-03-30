using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1
{
    internal class Comprador : Usuario
    {
        public double saldo { get; set; }
        public Comprador( string l, string s, string e, double c, double sal) : base(l, s, e, c)
        {
            this.login = l;
            this.senha = s;
            this.email = e;
            this.saldo = sal;
            this.cnpj = c;
        }
    }
}