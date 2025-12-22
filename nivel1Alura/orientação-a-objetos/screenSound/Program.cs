Console.Clear();

Album album1 = new Album();
album1.Nome = "Xtranho";

Musica musica1 = new Musica();
musica1.Nome = "Meu Cemitério";
musica1.Duracao = 172;

Musica musica2 = new Musica();
musica2.Nome = "Rei Tuê";
musica2.Duracao = 180;

album1.AdicionarMusica(musica1);
album1.AdicionarMusica(musica2);

Banda banda1 = new Banda();
banda1.Nome = "30 pra 1";
banda1.AdicionarAlbum(album1);

banda1.ExibirDiscografia();