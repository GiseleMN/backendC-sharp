// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
using System.Threading;
using System.Collections.Generic;

namespace backendProjeto
{

    class Program
    {

        static void Main(string[] args)
        {
            List<PessoaFisica> listPf = new List<PessoaFisica>();
            Console.Clear();

            List<PessoaJuridica> listPj = new List<PessoaJuridica>();
            Console.Clear();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine(@$"
            =============================================
            |       Bem-vindo ao sistema de cadastro     |
            |     de Pessoa Física e Pessoa Jurídica     |
            =============================================
            ");

            BarraCarregamento("Iniciando");

            string? opcao;

            do
            {

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

                        Console.WriteLine($"Digite o seu logradouro");
                        end.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digit o seu número de endereço");
                        end.numero = Console.ReadLine();

                        Console.WriteLine($"Digite o complemento(Aperte ENTER para vazio)");
                        end.complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial? S/N");
                        string endComercial = Console.ReadLine().ToUpper();

                        if (endComercial == "S")
                        {
                            end.enderecoComercial = true;
                        }
                        else
                        {
                            end.enderecoComercial = false;
                        }

                        PessoaFisica novaPf = new PessoaFisica();

                        novaPf.endereco = end;

                        Console.WriteLine($"Digite o seu nome");
                        novaPf.nome = Console.ReadLine();

                        Console.WriteLine($"digite o seu CPF");
                        novaPf.cpf = Console.ReadLine();

                        Console.WriteLine($"Escreva sua Data de Nascimento");
                        novaPf.dataNascimento = DateTime.Parse(Console.ReadLine());

                        bool idadeValida = novaPf.ValidarDataNascimento(novaPf.dataNascimento);

                        if (idadeValida == true)
                        {
                            System.Console.WriteLine("Cadastro Aprovado");
                        }
                        else
                        {
                            System.Console.WriteLine("Cadastro não aprovado");
                        }

                        Console.WriteLine($"Digite o valor de seu rendimento mensal");
                        novaPf.rendimento = float.Parse(Console.ReadLine());


                        break;

                    case "2":

                        foreach (var cadaItem in listPf)
                        {
                            Console.WriteLine($"{cadaItem.nome},{cadaItem.cpf},{cadaItem.dataNascimento}{cadaItem.endereco.logradouro}");
                        }
                        break;

                    case "3":

                        Console.WriteLine($"Digite o CPF que você deseja remover");
                        string cpfProcurado = Console.ReadLine();

                        PessoaFisica pessoaEncontrada = listPf.Find(cadaItem => cadaItem.cpf == cpfProcurado);
                        if (pessoaEncontrada != null)
                        {
                            listPf.Remove(pessoaEncontrada);
                            Console.WriteLine($"Cadastro removido com sucesso");
                        }
                        else
                        {
                            Console.WriteLine($"CPF não encontrado");
                        }
                        break;

                    case "4":


                        Endereco endpj = new Endereco();

                        Console.WriteLine($"Digite o seu logradouro");
                        endpj.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número de seu logradouro");
                        endpj.numero = Console.ReadLine();

                        Console.WriteLine($"Digite o complemento(Aperte ENTER para vazio)");
                        endpj.complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial? S/N");
                        string endComercialPj = Console.ReadLine().ToUpper();

                        if (endComercialPj == "S")
                        {
                            endpj.enderecoComercial = true;
                        }
                        else
                        {
                            endpj.enderecoComercial = false;
                        }

                        PessoaJuridica novaPj = new PessoaJuridica();

                        novaPj.endereco = endpj;

                        Console.WriteLine($"Digite o CNPJ da sua empresa");
                        novaPj.cnpj = Console.ReadLine();

                        Console.WriteLine($"Digite o nome da sua empresa");
                        novaPj.nome = Console.ReadLine();

                        Console.WriteLine($"Digite sua Razão Social");
                        novaPj.razaoSocial = Console.ReadLine();

                        novaPj.ValidarCNPJ(novaPj.cnpj);

                        if (novaPj.ValidarCNPJ(novaPj.cnpj))
                        {
                            Console.WriteLine($"CNPJ {novaPj.cnpj} é válido");
                        }
                        else
                        {
                            Console.WriteLine("O CPNJ" + novaPj.cnpj + "está inválido");
                        }

                        break;

                    case "5":

                        foreach (var cadaItem in listPj)
                        {
                            Console.WriteLine($"{cadaItem.nome},{cadaItem.cnpj},{cadaItem.razaoSocial}");
                        }

                        break;

                    case "6":

                        Console.WriteLine($"Digite o CNPJ da empresa que deseja remover cadastro");
                        string cnpjProcurado = Console.ReadLine();

                        PessoaJuridica pessoaJuridicacontrada = listPj.Find(cadaItem => cadaItem.cnpj == cnpjProcurado);

                        if (cnpjProcurado != null)
                        {
                            listPj.Remove(pessoaJuridicacontrada);
                            Console.WriteLine($"CNPJ removido com sucesso");
                        }
                        else
                        {
                            Console.WriteLine($"CNPJ não encontrado");
                        }

                        break;
                    case "0":

                        BarraCarregamento("Finalizando...");
                        break;
                    default:
                        Console.WriteLine($"Opção Inválida, digite uma opção válida");
                        break;
                }

            } while (opcao != "0");

            static void BarraCarregamento(string textoCarregamento)
            {
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(textoCarregamento);
                Thread.Sleep(500);

                for (var contador = 0; contador < 10; contador++)
                {
                    Console.Write(".");
                    Thread.Sleep(500);
                }
                Console.ResetColor();
            }


        }

    }
}

