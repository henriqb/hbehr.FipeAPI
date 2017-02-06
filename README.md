# hbehr.FipeAPI
C# .NET Blibioteca para acessar a API pública da tabela FIPE para veículos.

To understand how FIPE Public API works, read on http://fipeapi.appspot.com/

## Instalation
Get it on nuget: https://www.nuget.org/packages/hbehr.FipeAPI/1.0.0

  PM> Install-Package hbehr.FipeAPI

## How to use

### Initialize
```C#
FipeApi api = new FipeCarrosApi(); // For Cars
FipeApi api = new FipeCaminhoesApi(); // For Trucks
FipeApi api = new FipeMotosApi(); // For Motorcycles
```

### Load Marcas
```C#
IEnumerable<Marcas> marcas = await api.GetMarcasAsync(); // Assync
IEnumerable<Marcas> marcas = api.GetMarcas(); // Sync

public struct Marcas
{
  public string key { get; set; }
  public string id { get; set; }
  public string fipe_name { get; set; }
  public string name { get; set; }
}
```

### Load Veículos (Modelos/Versões)
```C#
string marcaId = marcas.First().id;
IEnumerable<Veiculos> marcas = await api.GetVeiculosAsync(marcaId); // Assync
IEnumerable<Veiculos> marcas = api.GetVeiculos(marcaId); // Sync

public struct Veiculos
{
  public string fipe_marca { get; set; }
  public string name { get; set; }
  public string marca { get; set; }
  public string key { get; set; }
  public string id { get; set; }
  public string fipe_name { get; set; }
}
```

### Load Ano Modelo (Ano/Modelo)
```C#
string veiculoId = veiculos.First().id;
IEnumerable<AnoModelo> anoModelos = await api.GetAnoModelosAsync(marcaId, veiculoId); // Assync
IEnumerable<AnoModelo> anoModelos = api.GetAnoModelos(marcaId, veiculoId); // Sync

public struct AnoModelo
{
  public string fipe_marca { get; set; }
  public string fipe_codigo { get; set; }
  public string name { get; set; }
  public string marca { get; set; }
  public string key { get; set; }
  public string veiculo { get; set; }
  public string id { get; set; }
}
```

### Load Preço Corrente
```C#
string anoModeloId = anoModelos.First().id;
PrecoCorrente precoCorrente = await api.GetPrecoCorrenteAsync(marcaId, veiculoId, anoModeloId);
PrecoCorrente precoCorrente = api.GetPrecoCorrente(marcaId, veiculoId, anoModeloId);

public struct PrecoCorrente
{
  public string id { get; set; }
  public string ano_modelo { get; set; }
  public string marca { get; set; }
  public string name { get; set; }
  public string veiculo { get; set; }
  public string preco { get; set; }
  public string combustivel { get; set; }
  public string referencia { get; set; }
  public string fipe_codigo { get; set; }
  public string key { get; set; }
}
```