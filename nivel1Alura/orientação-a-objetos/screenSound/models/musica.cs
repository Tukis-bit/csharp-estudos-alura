class Musica
{
    public string Nome {get; set;} = "";
    public string Artista {get; set;} = "";
    public int Duracao {get; set;}
    public bool Disponivel{set; get;}
    public Genero genero { get; set; }
    //escrever a palavra prop + tab já faz a extrutura da propriedade com get e set
    //set = escrever/dar valor
    //get = ler/pegar valor

//=> determina que está disponível apenas a leitura da propriedade

        public string Descricao =>
         $"A musica {Nome} pertence ao artista {Artista}";
//Atribuindo o valor que será lido
 
 public void ExibirNome()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Artista: {Artista}");
    }
    public void ExibirMusica()
    {
        Console.WriteLine($"Nome da musica: {Nome}");
        Console.WriteLine($"Artista da musica: {Artista}");
        Console.WriteLine($"Duracao da musica: {Duracao}");
        
        if(Disponivel)
        {
        Console.WriteLine("Esta musica está disponível");
            
        }
        else{
        Console.WriteLine("Esta música está indisponível");
            
        }


    } 

}

