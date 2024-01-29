using System.Globalization;

using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!");

decimal precoInicial = SolicitarPreco("Digite o preço inicial:");
decimal precoPorHora = SolicitarPreco("Digite o preço por hora:");

static decimal SolicitarPreco(string mensagem)
{
    while (true)
    {
        Console.WriteLine(mensagem);
        if (decimal.TryParse(Console.ReadLine().Replace(',', '.'), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal preco) && preco > 0)
        {
            return preco;
        }
        Console.WriteLine("Valor inválido. Deve ser maior que zero.");
    }
}

Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placaAdicionar = Console.ReadLine().ToUpper();
            es.AdicionarVeiculo(placaAdicionar);
            break;

        case "2":
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placaRemover = Console.ReadLine().ToUpper();
            es.RemoverVeiculo(placaRemover);
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
