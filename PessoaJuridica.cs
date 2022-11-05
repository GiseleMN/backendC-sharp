using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backendProjeto
{
    public class PessoaJuridica:Pessoa
    {
        public string? cnpj{get;set;}

        public string? razaoSocial{get;set;}
        

        public override double PagarImposto(float rendimento){

            if(rendimento <= 5000){
                return rendimento * .06;
            }else if(rendimento > 5000 && rendimento <= 10000){
                return rendimento * .08;
            }else{
                return (rendimento/100) * 10;
            }

            // string salario = salario.valor
            // salario.valor += "";
            // salario.valor = totalValor
            // if(totalValor >= 10.000,01){
            //     desconto = salario - 10%
                
            // }else if(totalValor >= 5.000,01 < 10.000,00){
            //     desconto = salario - 8%                              

            // }else{
            //     desconto = salario - 6%               

            // }
            // return desconto;
            
        }

        public bool ValidarCNPJ(string cnpj){

            if(cnpj.Length >= 14 && cnpj.Substring(cnpj.Length - 4 ) == '0001'){
                return true;               
            }else{
                return false;
            }
            
        }
    }
}