using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backendProjeto
{
    public class PessoaFisica : Pessoa
    {
        public string cpf { get; set; }

        public DateTime dataNascimento { get; set; }

        public override double PagarImposto(float rendimento)
        {

            if (rendimento <= 1500)
            {
                return 0.0;
            }
            else if (rendimento > 1500 && rendimento <= 5000)
            {

                return rendimento * .03;
            }
            else
            {
                return (rendimento / 100) * .05;
            }




            // float rendimento = salario.valor
            // salario.valor += "";
            // totalValor = salario.valor.lenght/12
            // if(totalValor >= 5000.01 ){
            //     desconto = totalValor - totalValor * 0.05
            // }else if(totalValor < 5000.00 >= 1501.00){
            //     desconto = totalValor - totalValor * 0.03
            // }else{
            //     desconto = 0;
            // }
            // return desconto;
        }

        public bool ValidarDataNascimento(DateTime dataNascimento)
        {

            DateTime dataAtual = DateTime.Today;
            double age = (dataAtual - dataNascimento).TotalDays / 365;

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