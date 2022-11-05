using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backendProjeto
{
    public class Pessoa
    {
        public string nome { get; set; }

        public Endereco endereco { get; set; }

        public float salario { get; set; }

        public float rendimento { get; set; }

        public abstract double PagarImposto();
    }
}