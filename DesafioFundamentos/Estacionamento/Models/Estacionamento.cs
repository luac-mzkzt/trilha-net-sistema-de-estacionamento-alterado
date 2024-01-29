namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal PrecoInicial;
        private decimal PrecoPorHora;
        private Dictionary<string, DateTime> veiculos = new Dictionary<string, DateTime>();

        public Estacionamento() 
        {

        }
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            PrecoInicial = precoInicial;
            PrecoPorHora = precoPorHora;
        }

        public Dictionary<string, DateTime> GetVeiculos()
        {
            return veiculos;
        }
        
        public void AdicionarVeiculo(string placaAdicionar)
        {
             if (veiculos.ContainsKey(placaAdicionar))
             {
                 Console.WriteLine("Esta placa já está cadastrada. " +
                 "Por favor, confira se digitou a placa correta.");
             }
             else 
             {
                veiculos.Add(placaAdicionar, DateTime.Now);
                Console.WriteLine($"O veículo {placaAdicionar} " +
                $"foi cadastrado em {veiculos[placaAdicionar]:dd/MM/yy HH:mm}.");
             }
        }
        
        public void RemoverVeiculo(string placa)
        {
            if (veiculos.TryGetValue(placa, out DateTime horaCadastro))
            {
                TimeSpan tempoEstacionado = DateTime.Now - horaCadastro;
                decimal valorTotal;

                // Verifica se o veículo estacionou menos de meia hora
                if (tempoEstacionado.TotalMinutes <= 30)
                {
                    valorTotal = PrecoInicial;
                }
                else
                {
                    // Calcula o número de horas arredondando para cima
                    int horasEstacionado = (int)Math.Ceiling(tempoEstacionado.TotalHours);

                    // Calcula o valor total considerando o preço por hora
                    valorTotal = PrecoPorHora * horasEstacionado;
                }

                veiculos.Remove(placa);
                Console.WriteLine($"Veículo {placa} removido em {DateTime.Now:dd/MM/yy HH:mm}.");
                Console.WriteLine($"Valor total a pagar: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. " +
                                "Confira se digitou a placa corretamente");
            }
        }
        public void ListarVeiculos()
        {
            // Verifica se há veículos estacionados e lista os resultados encontrados no dicionário
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                 foreach (var (placa, horaCadastro) in veiculos) {
                    Console.WriteLine($"Placa: {placa}");
                    Console.WriteLine($"Data e Hora de Entrada: {horaCadastro:dd/MM/yy HH:mm}");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
