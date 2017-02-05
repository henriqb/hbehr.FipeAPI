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
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hbehr.FipeAPI
{
    /// <summary>
    /// Abstract API de download de informação de carros/motos/caminhoes
    /// </summary>
    public abstract class FipeApi
    {
        protected abstract IRestClient client { get; }

        /// <summary>
        /// Busca todas as marcas de veículos
        /// </summary>
        /// <returns>IEnumerable de Marcas</returns>
        public IEnumerable<Marcas> GetMarcas()
        {
            IRestRequest request = new RestRequest("/marcas.json", Method.GET);
            IRestResponse response = client.Execute(request);
            return response.ErrorTreatment().Deserialize<IEnumerable<Marcas>>();
        }

        /// <summary>
        /// Busca todas as marcas de veículos
        /// </summary>
        /// <returns>IEnumerable de Marcas</returns>
        public async Task<IEnumerable<Marcas>> GetMarcasAsync()
        {
            IRestRequest request = new RestRequest("/marcas.json", Method.GET);
            IRestResponse response = await client.ExecuteTaskAsync(request);
            return response.ErrorTreatment().Deserialize<IEnumerable<Marcas>>();
        }

        /// <summary>
        /// Busca todos os modelos de uma marca
        /// </summary>
        /// <param name="marcaId">id da marca</param>
        /// <returns>IEnumerable de Veículos</returns>
        public IEnumerable<Veiculos> GetVeiculos(string marcaId)
        {
            if (string.IsNullOrWhiteSpace(marcaId)) { throw new ArgumentException(nameof(marcaId)); }
            IRestRequest request = new RestRequest(string.Format("/veiculos/{0}.json", marcaId), Method.GET);
            IRestResponse response = client.Execute(request);
            return response.ErrorTreatment().Deserialize<IEnumerable<Veiculos>>();

        }

        /// <summary>
        /// Busca todos os modelos de uma marca
        /// </summary>
        /// <param name="marcaId">id da marca</param>
        /// <returns>Set de Veículos</returns>
        public async Task<IEnumerable<Veiculos>> GetVeiculosAsync(string marcaId)
        {
            if (string.IsNullOrWhiteSpace(marcaId)) { throw new ArgumentException(nameof(marcaId)); }
            IRestRequest request = new RestRequest(string.Format("/veiculos/{0}.json", marcaId), Method.GET);
            IRestResponse response = await client.ExecuteTaskAsync(request);
            return response.ErrorTreatment().Deserialize<IEnumerable<Veiculos>>();
        }

        /// <summary>
        /// Busca todos os modelos de uma marca
        /// </summary>
        /// <param name="marcaId">id da marca</param>
        /// <param name="veiculoId">id do modelo</param>
        /// <returns>IEnumerable de Ano Modelos</returns>
        public IEnumerable<AnoModelo> GetAnoModelos(string marcaId, string veiculoId)
        {
            if (string.IsNullOrWhiteSpace(marcaId)) { throw new ArgumentException(nameof(marcaId)); }
            if (string.IsNullOrWhiteSpace(veiculoId)) { throw new ArgumentException(nameof(veiculoId)); }
            IRestRequest request = new RestRequest(string.Format("/veiculo/{0}/{1}.json", marcaId, veiculoId), Method.GET);
            IRestResponse response = client.Execute(request);
            return response.ErrorTreatment().Deserialize<IEnumerable<AnoModelo>>();
        }

        /// <summary>
        /// Busca todos os modelos de uma marca
        /// </summary>
        /// <param name="marcaId">id da marca</param>
        /// <param name="veiculoId">id do modelo</param>
        /// <returns>IEnumerable de Ano Modelos</returns>
        public async Task<IEnumerable<AnoModelo>> GetAnoModelosAsync(string marcaId, string veiculoId)
        {
            if (string.IsNullOrWhiteSpace(marcaId)) { throw new ArgumentException(nameof(marcaId)); }
            if (string.IsNullOrWhiteSpace(veiculoId)) { throw new ArgumentException(nameof(veiculoId)); }
            IRestRequest request = new RestRequest(string.Format("/veiculo/{0}/{1}.json", marcaId, veiculoId), Method.GET);
            IRestResponse response = await client.ExecuteTaskAsync(request);
            return response.ErrorTreatment().Deserialize<IEnumerable<AnoModelo>>();
        }
    }
}