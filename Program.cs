
using System.Text.Json;
using Treino.API.Paises;
Console.Clear();

using (HttpClient client = new HttpClient())
{
    try
    {
        
    string resposta = await client.GetStringAsync("https://raw.githubusercontent.com/ArthurOcFernandes/Exerc-cios-C-/curso-4-aula-2/Jsons/Paises.json");
    var paises = JsonSerializer.Deserialize<List<Pais>>(resposta)!;

    paises.ForEach(p => p.ExibirInfos());
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}