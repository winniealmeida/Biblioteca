using System;

class Program {
  public static void Main() {
    Console.WriteLine("Bem vindo a Biblioteca");
    int op = 0;
    do {
      try {
        op = Menu();
          switch(op) {
            case 1 : GeneroInserir(); break;
            case 2 : GeneroListar(); break;
            case 3 : GeneroAtt(); break;
            case 4 : GeneroExcluir(); break;
          }
      }
      catch (Exception erro){
        op = -1;
        Console.WriteLine("Erro: " + erro.Message);
      }   
    } while (op != 0);
  }
  public static int Menu() {
    Console.WriteLine("Escolha uma opção:");
    Console.WriteLine("01 - Inserir um novo gênero");
    Console.WriteLine("02 - Listar os gêneros cadastrados");
    Console.WriteLine("03 - Atualizar um gênero");
    Console.WriteLine("04 - Excluir um gênero");
    Console.WriteLine("00 - Finalizar o sistema");
    Console.Write("Opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }
  public static void GeneroInserir() {
    Console.WriteLine("---- Inserir um novo gênero ----");
    Console.Write("Informe o id: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome: ");
    string nome = Console.ReadLine();
    Genero obj = new Genero(id, nome);
    Sistema.GeneroInserir(obj);
    Console.WriteLine("---- Operação realizada com sucesso ----");
    Console.WriteLine("----------------------------------------");
  }
  public static void GeneroListar() {
    Console.WriteLine("---- Listar os gêneros cadastrados ----");
    foreach(Genero obj in Sistema.GeneroListar())
      Console.WriteLine(obj);
    Console.WriteLine("----------------------------------------");
  }
  public static void GeneroAtt() {
    Console.WriteLine("---- Atualizar um gênero ----");
    Console.Write("Informe o id do gênero: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o novo nome: ");
    string nome = Console.ReadLine();
    Genero obj = new Genero(id, nome);
    Sistema.GeneroAtt(obj);
    Console.WriteLine("---- Operação realizada com sucesso ----");
    Console.WriteLine("----------------------------------------");
  }
  public static void GeneroExcluir() {
    Console.WriteLine("---- Excluir um gênero ----");
    Console.Write("Informe o id do gênero: ");
    int id = int.Parse(Console.ReadLine());
    string nome = "";
    Genero obj = new Genero(id, nome);
    Sistema.GeneroExcluir(obj);
    Console.WriteLine("---- Operação realizada com sucesso ----");
    Console.WriteLine("----------------------------------------");
  }
}