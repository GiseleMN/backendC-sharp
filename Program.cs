// See https://aka.ms/new-console-template for more information


using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace backendProjeto.Class
{

    class Program
    {

        static void Main(string[] args)
        {


            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Cyan;

            Console.WriteLine(@$"
            =============================================
            |       Bem-vindo ao sistema de cadastro     |
            |     de Pessoa Física e Pessoa Jurídica     |
            =============================================
            ");

            BarraCarregamento("Iniciando");

            List<PessoaFisica> listPf = new List<PessoaFisica>();
            Console.Clear();

            List<PessoaJuridica> listPj = new List<PessoaJuridica>();
            Console.Clear();

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

                        Console.WriteLine($"Digite o seu número de endereço");
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

                        PessoaFisica PF = new PessoaFisica();

                        PF.endereco = end;

                        Console.WriteLine($"Digite o seu nome");
                        PF.nome = Console.ReadLine();

                        Console.WriteLine($"digite o seu CPF");
                        PF.cpf = Console.ReadLine();


                        Console.WriteLine($"Escreva sua Data de Nascimento");
                        PF.dataNascimento = DateTime.Parse(Console.ReadLine()!);

                        bool idadeValida = PF.ValidarDataNascimento(PF.dataNascimento);

                        if (idadeValida == true)
                        {
                            System.Console.WriteLine("Cadastro Aprovado");
                        }
                        else
                        {
                            System.Console.WriteLine("Cadastro não aprovado");
                        }

                        Console.WriteLine($"Digite o valor de seu rendimento mensal");
                        PF.rendimento = float.Parse(Console.ReadLine()!);


                        listPf.Add(PF);

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Cadastro realizado com sucesso");
                        Thread.Sleep(3000);
                        Console.ResetColor();


                        break;

                    case "2":

                        Console.Clear();

                        if (listPf.Count > 0)
                        {

                            foreach (PessoaFisica cadaPessoa in listPf)
                            {
                                Console.Clear();
                                Console.WriteLine(@$"
                                Nome: {cadaPessoa.nome}
                                Endereço: {cadaPessoa.endereco.logradouro}, {cadaPessoa.endereco.numero}
                                Data de nascimento: {cadaPessoa.dataNascimento}
                                Taxa de imposto a ser paga é: {cadaPessoa.PagarImposto(cadaPessoa.rendimento).ToString("C")}
");

                                Console.WriteLine($"Aperte 'Enter' para continuar");
                                Console.ReadLine();
                            }

                        }
                        else
                        {
                            Console.WriteLine($"Lista vazia!!");
                            Thread.Sleep(3000);
                        }

                        foreach (var cadaPessoa in listPf)
                        {
                            Console.WriteLine($"{cadaPessoa.nome},{cadaPessoa.cpf},{cadaPessoa.dataNascimento}{cadaPessoa.logradouro}");

                            Console.WriteLine($"Aperte ENTER para continuar");
                            Console.ReadLine();
                        }
                        break;

                    case "3":

                        Console.WriteLine($"Digite o CPF que você deseja remover");
                        string? cpfProcurado = Console.ReadLine();

                        PessoaFisica? pessoaEncontrada = listPf.Find(cadaItem => cadaItem.cpf == cpfProcurado);
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

                        PessoaJuridica PJ = new PessoaJuridica();

                        PJ.endereco = endpj;

                        Console.WriteLine($"Digite o CNPJ da sua empresa");
                        PJ.cnpj = Console.ReadLine();

                        Console.WriteLine($"Digite o nome da sua empresa");
                        PJ.nome = Console.ReadLine();

                        Console.WriteLine($"Digite sua Razão Social");
                        PJ.razaoSocial = Console.ReadLine();

                        PJ.ValidarCNPJ(PJ.cnpj);

                        if (PJ.ValidarCNPJ(PJ.cnpj))
                        {
                            Console.WriteLine($"CNPJ {PJ.cnpj} é inválido");
                        }
                        else
                        {
                            Console.WriteLine("O CPNJ" + PJ.cnpj + "está válido");
                        }

                        Console.WriteLine($"Digite o valor de seu rendimento mensal");
                        PJ.rendimento = float.Parse(Console.ReadLine()!);

                        listPj.Add(PJ);

                        break;

                    case "5":

                        Console.Clear();

                        if (listPj.Count > 0)
                        {

                            foreach (PessoaJuridica cadaPessoa in listPj)
                            {
                                Console.Clear();
                                Console.WriteLine(@$"
                                Nome: {cadaPessoa.nome}
                                Endereço: {cadaPessoa.endereco.logradouro}, {cadaPessoa.endereco.numero}
                                Razão Social: {cadaPessoa.razaoSocial}
                                Taxa de imposto a ser paga é: {cadaPessoa.PagarImposto(cadaPessoa.rendimento).ToString("C")}
                                ");
                                Console.WriteLine($"Aperte 'Enter' para continuar");
                                Console.ReadLine();
                            }

                        }
                        else
                        {
                            Console.WriteLine($"Lista vazia!!");
                            Thread.Sleep(3000);
                        }
                        if (listPj.Count > 0)
                        {
                            foreach (var cadaPessoa in listPf)
                            {
                                Console.WriteLine($"{cadaPessoa.nome},{cadaPessoa.cpf},{cadaPessoa.dataNascimento}{cadaPessoa.logradouro}");

                                Console.WriteLine($"Aperte ENTER para continuar");
                                Console.ReadLine();
                            }
                        }


                        break;

                    case "6":

                        Console.WriteLine($"Digite o CNPJ da empresa que deseja remover cadastro");
                        string? cnpjProcurado = Console.ReadLine();

                        PessoaJuridica? pjEncontrada = listPj.Find(cadaItem => cadaItem.cnpj == cnpjProcurado);

                        if (cnpjProcurado != null)
                        {
                            listPj.Remove(pjEncontrada);
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

                Console.ForegroundColor = ConsoleColor.Magenta;
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

