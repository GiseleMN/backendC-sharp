using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace backendProjeto.Class
{

    public class PessoaFisica : Pessoa
    {
        public string? cpf { get; set; }

        public DateTime dataNascimento { get; set; }



        public void Inserir(PessoaFisica Pf)
        {
            using (StreamWriter sw = new StreamWriter($"{Pf.nome}.txt"))
            {
                sw.WriteLine($"{Pf.nome},{Pf.rendimento},{Pf.cpf},{Pf.dataNascimento},{Pf.endereco.logradouro},{Pf.endereco.numero}");
            }
        }

        public PessoaFisica Ler(string nameArquivo)
        {
            PessoaFisica Pf = new PessoaFisica();

            using (StreamReader sr = new StreamReader($"{nameArquivo}.txt"))
            {
                string[] atributos = sr.ReadLine()!.Split(",");

                Pf.nome = atributos[0];
                Pf.rendimento = float.Parse(atributos[1]);
                Pf.cpf = atributos[2];
                Pf.dataNascimento = DateTime.Parse(atributos[3]);
                Pf.endereco.logradouro = atributos[4];
                Pf.endereco.numero = atributos[5];

            }
            return Pf;
        }

        public override double PagarImposto(float rendimento)
        {
            if (rendimento <= 1500)
            {
                return 0;
            }
            else if (rendimento > 1500 && rendimento <= 5000)
            {

                return rendimento * .03;
            }
            else
            {
                return (rendimento / 100) * .05;
            }

        }

        public bool ValidarDataNascimento(DateTime dataNasc)
        {

            DateTime dataAtual = DateTime.Today;
            double age = (dataAtual - dataNasc).TotalDays / 365;

            if (age >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
