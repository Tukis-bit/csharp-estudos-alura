class Episodio
{
    List<string> convidados = new();

    public Episodio(int duracao, int ordem,string titulo)
    {
        Duracao = duracao;
        Ordem = ordem;
        Titulo = titulo;
    }

    public int Duracao { get;  }
public int Ordem { get; }
public string Resumo => $"{Ordem} {Titulo} ({Duracao} min) - {String.Join(", ",convidados)}";
public string Titulo { get; }      

public void AdicionarConvidados(string convidado)
    {
        convidados.Add(convidado);
    }

}