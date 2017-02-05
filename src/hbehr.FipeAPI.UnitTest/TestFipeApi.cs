/** The MIT License (MIT)
 * 
 * Copyright (c) 2017 Henrique Borba Behr
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
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
            Assert.IsTrue(marcas.Any());

            marcas = api.GetMarcas();
            Assert.IsNotNull(marcas);
            Assert.IsTrue(marcas.Any());
        }

        [Test]
        public async Task TestGetVeiculos()
        {
            var marcas = await api.GetMarcasAsync();
            var marca = marcas.First();

            var veiculos = await api.GetVeiculosAsync(marca.id);
            Assert.IsNotNull(veiculos);
            Assert.IsTrue(veiculos.Any());

            veiculos = api.GetVeiculos(marca.id);
            Assert.IsNotNull(veiculos);
            Assert.IsTrue(veiculos.Any());

            Assert.Throws<ArgumentException>(() => api.GetVeiculos(null));
            Assert.ThrowsAsync<ArgumentException>(() => api.GetVeiculosAsync(null));
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
            Assert.IsTrue(anoModelos.Any());

            anoModelos = api.GetAnoModelos(marca.id, veiculo.id);
            Assert.IsNotNull(anoModelos);
            Assert.IsTrue(anoModelos.Any());

            Assert.Throws<ArgumentException>(() => api.GetAnoModelos(null, null));
            Assert.ThrowsAsync<ArgumentException>(() => api.GetAnoModelosAsync(null, null));
        }
    }
}
