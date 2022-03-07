using System;

class Program{
  public static void Main() {
    Console.WriteLine("Bem vindo a Biblioteca");
    Genero g1 = new Genero(1, "Não-Ficção");
    Genero g2 = new Genero(2, "Drama");
    Livro l1 = new Livro("livro 1", 1);
    Livro l2 = new Livro("livro 2", 2);
    Console.WriteLine(g2);
    Console.WriteLine(l1);
    Console.WriteLine(l2);
  }
}