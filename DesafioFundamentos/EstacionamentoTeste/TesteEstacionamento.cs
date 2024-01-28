using DesafioFundamentos.Models;

namespace EstacionamentoTeste;

public class EstacionamentoTeste
{
     Estacionamento es;

        public EstacionamentoTeste()
        {
            es = new Estacionamento();
        }

    [Theory]
    [InlineData("BRAGS19")]
    [InlineData("AWS9C89")]
    [InlineData("BWB5F69")]
    [InlineData("BRAOS17")]

    public void DeveAdicionarUmaPlaca(string placaAdicionar)
    {
        //Act (executa a ação de adicionar)
        es.AdicionarVeiculo(placaAdicionar);

        //Assert (válida se tem o resultado esperado)
        var veiculos = es.GetVeiculos();
        int quantidadeDeVeiculos = veiculos.Count;
        Assert.Equal(1, quantidadeDeVeiculos);
    }

    [Theory]
    [InlineData("BRAGS19")]
    [InlineData("AWS9C89")]
    [InlineData("BWB5F69")]
    [InlineData("BRAOS17")]

    public void DeveRemoverUmaPlaca(string placaRemover) 
    {
        //Act (executa a ação de remover)
        es.AdicionarVeiculo(placaRemover);
        es.RemoverVeiculo(placaRemover);

        //Assert (válida se tem o resultado esperado)
        var veiculos = es.GetVeiculos();
        int quantidadeDeVeiculos = veiculos.Count;
        Assert.Equal(0, quantidadeDeVeiculos);
    }
}