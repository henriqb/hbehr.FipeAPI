using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace hbehr.FipeAPI.UnitTest
{
    public abstract class TestFipeApi
    {
        protected abstract FipeApi api { get; }

        [Test]
        public async Task TestGetMarcas()
        {
            var marcas = await api.GetMarcasAsync();
            Assert.IsNotNull(marcas);
            Assert.GreaterOrEqual(1, marcas.Count());

            marcas = api.GetMarcas();
            Assert.IsNotNull(marcas);
            Assert.GreaterOrEqual(1, marcas.Count());
        }

        [Test]
        public async Task TestGetVeiculos()
        {
            var marcas = await api.GetMarcasAsync();
            var marca = marcas.First();

            var veiculos = await api.GetVeiculosAsync(marca.id);
            Assert.IsNotNull(veiculos);
            Assert.GreaterOrEqual(1, veiculos.Count());

            veiculos = api.GetVeiculos(marca.id);
            Assert.IsNotNull(veiculos);
            Assert.GreaterOrEqual(1, veiculos.Count());

            Assert.Throws<ArgumentException>(() => api.GetVeiculos(null));
            Assert.Throws<ArgumentException>(async () => await api.GetVeiculosAsync(null));
        }

        [Test]
        public async Task TestGetAnoModelos()
        {
            var marcas = await api.GetMarcasAsync();
            var marca = marcas.First();
            var veiculos = await api.GetVeiculosAsync(marca.id);
            var veiculo = veiculos.First();

            var anoModelos = await api.GetAnoModelosAsync(marca.id, veiculo.id);
            Assert.IsNotNull(anoModelos);
            Assert.GreaterOrEqual(1, anoModelos.Count());

            anoModelos = api.GetAnoModelos(marca.id, veiculo.id);
            Assert.IsNotNull(anoModelos);
            Assert.GreaterOrEqual(1, anoModelos.Count());

            Assert.Throws<ArgumentException>(() => api.GetAnoModelos(null, null));
            Assert.Throws<ArgumentException>(async () => await api.GetAnoModelosAsync(null, null));
        }
    }
}
