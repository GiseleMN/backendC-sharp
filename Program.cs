// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
using System.Threading;
using System.Collections.Generic;



namespace backendProjeto{

    class Program{

        static void Main( string [] args)
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(@$"
            =================================
            |Bem-vindo ao sistema de cadastro|
            |de pessoa Física e Jurídica     |
            =================================
            ");

            
            for (int contador = 0; contador < length; contador++)
            { Console.ResetColor();
                Console.Write("iniciando....");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;         
                Console.Write(".");
                Thread.Sleep(500);
            };

            string? opcao;
            do{

            Console.WriteLine(@$"
            ========================================
            |     Escolha uma das opções abaixo:    |
            ----------------------------------------
            |     PESSOA_FISICA                     |
            |   1- Cadastrar Pessoa Fisica          |
            |   2 - Listar Pessoa Fisica            |
            |   3 - Remover Pessoa Fisica           |
            |---------------------------------------|
            |                                       |
            |      PESSOA_JURIDICA                  |
            |   4 - Cadastrar Pessoa Fisica         |
            |   5 - Listar Pessoa Fisica            |
            |   6 - Remover Pessoa Fisica           |   
            |                                       |
            |                                       |
            |      0 -Sair                          |
            ========================================

            ");

            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    
                    Endereco end = new Endereco();
                    end.logradouro = "Rua: ";
                    end.numero = 100;
                    end.complemento = "Proximo";
                    end.enderecoComercial = false;

                    PessoaFisica pf = new PessoaFisica();
                    pf.nome = "maria";
                    pf.endereco = end;
                    pf.cpf = "87489743";
                    pf.dataNascimento = 20/02/2000;
                    pf.salario = 458759;

                    bool idadeValida = novaPf.ValidarDataNascimento(novaPf.dataNascimento);
            
            if(idadeValida == true){
                System.Console.WriteLine("Cadastro Aprovado");
            }else{
                System.Console.WriteLine("Cadastro não aprovado");
            } 
                
                    BarraCarregamento("Iniciando...");
                    break;

                case "2":
                
                    Endereco endpj = new Endereco();
                    endpj.logradouro = "Rua: ";
                    endpj.numero = 100;
                    endpj.complemento = "Proximo";
                    endpj.enderecoComercial = false;

                    PessoaJuridica novaPj = new PessoaJuridica();
                    novaPj.endereco = endpj;
                    novaPj.cnpj = "12345678910001";
                    novaPj.nome = "Empresa LTDA";
                    novaPj.razaoSocial = "Empresa fanstasia";

                    novaPj.ValidarCNPJ(novaPj.cnpj);

            if(novaPj.ValidarCNPJ(novaPj.cnpj)){
                    Console.WriteLine($"CNPJ {novaPj.cnpj} é válido");                    
            }else{
                    Console.WriteLine("O CPNJ" + novaPj.cnpj+"está inválido"); 
            }
            
                   BarraCarregamento("Iniciando...");
                    break;

                case "0":

                  BarraCarregamento("Finalizando...");
                    break;
                default:
                   Console.WriteLine($"Opção Inválida, digite uma opção válida");
                    break;
            }

            }while (opcao != "0");  

            PessoaFisica novapf = new PessoaFisica();
            novapf.nome = "Pessoa Fisica";
            novapf.endereco = end;
            novapf.cpf = "787489";            
            novapf.dataNascimento = new DateTime(2000,02,20);
            novapf.salario = 2542563;

            

            

              
            
            static void BarraCarregamento(string textoCarregamento)
            { 
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Iniciando");
                Thread.Sleep(500);

              for (int contador = 0; contador < length; contador++)
              {         
                Console.Write(".");
                Thread.Sleep(500);
             }
             Console.ResetColor();
            }    

            
        }

    }
}

