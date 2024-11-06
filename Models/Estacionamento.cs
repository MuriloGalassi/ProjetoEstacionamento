using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    public class Veiculo
    {
        public string Placa { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime? HoraSaida { get; set; }

        public Veiculo(string placa)
        {
            Placa = placa;
            HoraEntrada = DateTime.Now;
        }
    }

    public class Vaga
    {
        public int Numero { get; set; }
        public Veiculo VeiculoOcupante { get; set; }

        public Vaga(int numero)
        {
            Numero = numero;
            VeiculoOcupante = null;
        }

        public bool EstaDisponivel()
        {
            return VeiculoOcupante == null;
        }
    }

    public class Estacionamento
    {
        private List<Vaga> Vagas;
        private decimal tarifaPorHora = 5.0m;

        public Estacionamento(int quantidadeVagas)
        {
            Vagas = new List<Vaga>();
            for (int i = 1; i <= quantidadeVagas; i++)
            {
                Vagas.Add(new Vaga(i));
            }
        }

        public bool EntrarVeiculo(string placa)
        {
            var vagaDisponivel = Vagas.Find(v => v.EstaDisponivel());

            if (vagaDisponivel != null)
            {
                vagaDisponivel.VeiculoOcupante = new Veiculo(placa);
                Console.WriteLine($"Veículo {placa} estacionado na vaga {vagaDisponivel.Numero}.");
                return true;
            }

            Console.WriteLine("Estacionamento cheio!");
            return false;
        }

        public decimal SairVeiculo(string placa)
        {
            var vaga = Vagas.Find(v => v.VeiculoOcupante != null && v.VeiculoOcupante.Placa == placa);

            if (vaga != null)
            {
                var veiculo = vaga.VeiculoOcupante;
                veiculo.HoraSaida = DateTime.Now;

                decimal valorCobrado = CalcularTarifa(veiculo);
                vaga.VeiculoOcupante = null;

                Console.WriteLine($"Veículo {placa} saiu. Total a pagar: R$ {valorCobrado}");
                return valorCobrado;
            }

            Console.WriteLine("Veículo não encontrado.");
            return 0;
        }

        private decimal CalcularTarifa(Veiculo veiculo)
        {
            if (veiculo.HoraSaida == null) return 0;

            var tempoEstacionado = veiculo.HoraSaida.Value - veiculo.HoraEntrada;
            return (decimal)tempoEstacionado.TotalHours * tarifaPorHora;
        }

        public void ExibirStatus()
        {
            Console.WriteLine("Status do estacionamento:");
            foreach (var vaga in Vagas)
            {
                string status = vaga.EstaDisponivel() ? "Disponível" : $"Ocupada por {vaga.VeiculoOcupante.Placa}";
                Console.WriteLine($"Vaga {vaga.Numero}: {status}");
            }
        }
    }
}