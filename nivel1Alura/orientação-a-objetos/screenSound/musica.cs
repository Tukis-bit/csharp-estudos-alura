class Musica
{
    public string nome = "";
    public string artista = "";
    public int duracao;
    private bool disponivel;

 
 public void ExibirNome()
    {
        Console.WriteLine($"Nome: {nome}");
        Console.WriteLine($"Artista: {artista}");
    }
    public void ExibirMusica()
    {
        Console.WriteLine($"Nome da musica: {nome}");
        Console.WriteLine($"Artista da musica: {artista}");
        Console.WriteLine($"Duracao da musica: {duracao}");
        
        if(disponivel)
        {
        Console.WriteLine("Esta musica está disponível");
            
        }
        else{
        Console.WriteLine("Esta música está indisponível");
            
        }


    } 
}
