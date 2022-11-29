using System;

namespace backendProjeto
{
    public class PessoaFisica : Pessoa
    {
        public string? cpf { get; set; }

        public DateTime dataNascimento { get; set; }

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