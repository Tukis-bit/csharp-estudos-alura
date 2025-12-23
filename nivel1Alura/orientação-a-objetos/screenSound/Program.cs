Episodio ep1 = new(45,1,"Explicação da aula");

ep1.AdicionarConvidados("Arthur");
ep1.AdicionarConvidados("Evelyn");

Console.Clear();
Console.WriteLine(ep1.Resumo);