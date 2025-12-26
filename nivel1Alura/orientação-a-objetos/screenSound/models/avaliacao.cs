namespace ScreenSound.models;

internal class Avaliacao
{
    public Avaliacao(int nota)
    {
        Nota = nota;
    }

    public int Nota { get;}

    public static Avaliacao Parse(string texto)
    {
        int nota = int.Parse(texto);
        if(nota > 10) nota = 10;
        else if(nota < 0) nota = 0;

        return new Avaliacao(nota); 
    }
}