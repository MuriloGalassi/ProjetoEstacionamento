using System;
using DesafioFundamentos.Models;

namespace DesafioFundamentos.Models
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao Sistema de Estacionamento!");

            Console.Write("Digite o número de vagas disponíveis: ");
            int quantidadeVagas = int.Parse(Console.ReadLine());

            Estacionamento estacionamento = new Estacionamento(quantidadeVagas);

            bool executando = true;
            while (executando)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Estacionar veículo");
                Console.WriteLine("2. Retirar veículo");
                Console.WriteLine("3. Ver status do estacionamento");
                Console.WriteLine("4. Sair");
                Console.Write("Escolha uma opção: ");
                
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("Digite a placa do veículo: ");
                        string placa = Console.ReadLine();
                        estacionamento.EntrarVeiculo(placa);
                        break;

                    case "2":
                        Console.Write("Digite a placa do veículo: ");
                        placa = Console.ReadLine();
                        estacionamento.SairVeiculo(placa);
                        break;

                    case "3":
                        estacionamento.ExibirStatus();
                        break;

                    case "4":
                        executando = false;
                        Console.WriteLine("Saindo do sistema...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }
            }
        }
    }
}