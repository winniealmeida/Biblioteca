using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

class Program {

  private static Cliente clienteLogin = null;
  
  public static void Main() {
    Thread.CurrentThread.CurrentCulture =
    new CultureInfo("pt-BR");
    
    Console.WriteLine("Bem-vindo à Livraria :)");
    int op = 0;
    int perfil = 0;
    do {
      try {
        if (perfil == 0) {
          op = 0;
          perfil = MenuUsuario();
        }
        if (perfil == 1) {
        op = MenuAdmin();
          switch(op) {
            case 1 : LivroInserir(); break;
            case 2 : LivroListar(); break;
            case 3 : LivroAtt(); break;
            case 4 : LivroExcluir(); break;
            case 5 : GeneroInserir(); break;
            case 6 : GeneroListar(); break;
            case 7 : GeneroAtt(); break;
            case 8 : GeneroExcluir(); break;
            case 9 : ClienteInserir(); break;
            case 10: ClienteListar(); break;
            case 11: ClienteAtt(); break;
            case 12: ClienteExcluir(); break;
            case 13: ServicoInserir(); break;
            case 14: ServicoListar(); break;
            case 15: ServicoAtt(); break;
            case 16: ServicoExcluir(); break;
            case 17: AluguelVerAgenda(); break;
            case 99: perfil = 0; break;
          }
        }
        if (perfil == 2 && clienteLogin == null) {
          op = MenuClienteLogin();
          switch(op) {
            case 1 : ClienteLogin(); break;
            case 99 : perfil = 0; break;
          }
        }
        if (perfil == 2 && clienteLogin != null) {
          op = MenuClienteLogout();
          switch(op) {
            case 1 : ClienteAlugar(); break;
            case 2 : ClienteVerAlugueis(); break;
            case 99: ClienteLogout(); break;
          }
        }
      }
      catch (Exception erro){
        op = -1;
        Console.WriteLine("Erro: " + erro.Message);
      }   
    } while (op != 0);
  }

  public static void ClienteLogin() {
    Console.WriteLine("-------- Login --------");
    ClienteListar();
    Console.Write("Diga o seu código de cliente para logar: ");
    int id_digitado = int.Parse(Console.ReadLine());
    List<Cliente> listaclientes = Sistema.ClienteListar();
    //andar na lista e achar o código ID
    // quando eu achar o ID setar o objeto para a variavel global
    //clienteLogin = null;

    foreach (Cliente acliente in listaclientes )
      if (acliente.Id == id_digitado)
        clienteLogin = acliente;
    
  }
  public static void ClienteLogout() { 
    Console.WriteLine("-------- Logout --------");
    clienteLogin = null;
  }
  public static void ClienteAlugar() {
    Console.WriteLine("-------- Alugar um livro --------");
    Sistema.LivroListar();
    Console.Write("Informe o Id do livro: ");
    int idLivro = int.Parse(Console.ReadLine());
    Sistema.AluguelDisponivelListar(idLivro);
    Console.Write("Informe a data desejada <enter para hoje>: ");
    DateTime data = Console.ReadLine();
    /* procurar se o livro está disponível na data desejada para aluguel */
    //string l = new obj.IdLivro;
    if (Sistema.AluguelDisponivelListar(IdLivro, Data) != null)
      DateTime.Data = obj.Data;
      idLivro = obj.IdLivro;
      Aluguel obj = new Aluguel();
      /*alugar o livro*/
      agenda.Add(obj);
      //Sistema.AluguelInserir(obj);
    if (Sistema.AluguelDisponivelListar(idLivro, d) == null) 
      Console.Write("Esse livro já está alugado nesse dia. Para tentar um novo aluguel, digite");
    }
    
  public static void ClienteVerAlugueis() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------------");
    AluguelClienteListar(idCliente);
    Console.Write("Diga o seu código de cliente para logar: ");
    int id_digitado = int.Parse(Console.ReadLine());
    foreach (Aluguel obj in agenda)
      if (Aluguel.IdCliente == id_digitado) return obj;
  }
  
  
  public static int MenuUsuario() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("01 -  Entrar como administrador");
    Console.WriteLine("02 -  Entrar como cliente");
    Console.WriteLine("00 - Finalizar o sistema");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Escolha uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }
  
  public static int MenuAdmin() {
    Console.WriteLine("Escolha uma opção:");
    Console.WriteLine("------------- Livros -------------");
    Console.WriteLine("01 - Inserir um novo livro");
    Console.WriteLine("02 - Listar os livros cadastrados");
    Console.WriteLine("03 - Atualizar um livro");
    Console.WriteLine("04 - Excluir um livro");
    Console.WriteLine("------------- Gêneros -------------");
    Console.WriteLine("05 - Inserir um novo gênero");
    Console.WriteLine("06 - Listar os gêneros cadastrados");
    Console.WriteLine("07 - Atualizar um gênero");
    Console.WriteLine("08 - Excluir um gênero");
    Console.WriteLine("------------ Clientes ------------");
    Console.WriteLine("09 - Inserir um novo cliente");
    Console.WriteLine("10 - Listar os clientes cadastrados");
    Console.WriteLine("11 - Atualizar um cliente");
    Console.WriteLine("12 - Excluir um cliente");
    Console.WriteLine("------------ Serviços ------------");
    Console.WriteLine("13 - Inserir um novo serviço");
    Console.WriteLine("14 - Listar os serviços cadastrados");
    Console.WriteLine("15 - Atualizar um serviço");
    Console.WriteLine("16 - Excluir um serviço");
    Console.WriteLine("--------- Agenda de aluguéis --------");
    Console.WriteLine("17 - Ver agenda");
    Console.WriteLine("99 - Voltar ao menu anterior");
    Console.WriteLine("00 - Finalizar o sistema");
    Console.Write("Opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

  public static int MenuClienteLogin() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("01 -  Fazer login");
    Console.WriteLine("99 -  Voltar");
    Console.WriteLine("00 - Finalizar o sistema");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Escolha uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

  public static int MenuClienteLogout() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Olá, " + clienteLogin.Nome);
    Console.WriteLine("01 - Alugar um livro");
    Console.WriteLine("02 - Ver meus aluguéis anteriores");
    Console.WriteLine("99 -  Sair");
    Console.WriteLine("00 - Finalizar o sistema");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Escolha uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }
  
  public static void LivroInserir() {
    Console.WriteLine("---- Inserir um novo livro ----");
    Console.Write("Informe o nome: ");
    string nome = Console.ReadLine();
    Console.Write("Informe o id: ");
    int id = int.Parse(Console.ReadLine());

    GeneroListar();
    Console.Write("Informe o id do gênero: ");
    int idGenero = int.Parse(Console.ReadLine());
    
    Livro obj = new Livro(nome, id, idGenero);
    Sistema.LivroInserir(obj);
    Console.WriteLine("---- Operação realizada com sucesso ----");
    Console.WriteLine("----------------------------------------");
  }
  public static void LivroListar() {
    Console.WriteLine("---- Listar os livros cadastrados ----");
    foreach(Livro obj in Sistema.LivroListar()) {
      Genero g = Sistema.GeneroLocalizar(obj.GetIdGenero());
       Console.WriteLine($"{obj} {g.GetNome()}");
       }
    Console.WriteLine("----------------------------------------");
  }
  public static void LivroAtt() {
    Console.WriteLine("---- Atualizar um livro ----");
    Console.Write("Informe o id do livro: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o novo nome: ");
    string nome = Console.ReadLine();
    GeneroListar();
    Console.Write("Informe o id do gênero: ");
    int idGenero = int.Parse(Console.ReadLine());
    Livro obj = new Livro(nome, id, idGenero);
    Sistema.LivroAtt(obj);
    Console.WriteLine("---- Operação realizada com sucesso ----");
    Console.WriteLine("----------------------------------------");
  }
  public static void LivroExcluir() {
    Console.WriteLine("---- Excluir um livro ----");
    Console.Write("Informe o id do livro: ");
    int id = int.Parse(Console.ReadLine());
    Livro obj = new Livro(id);
    Sistema.LivroExcluir(obj);
    Console.WriteLine("---- Operação realizada com sucesso ----");
    Console.WriteLine("----------------------------------------");
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
  
  public static void ClienteInserir() {
    Console.WriteLine("---- Inserir um novo cliente ----");
    Console.Write("Informe o nome: ");
    string nome = Console.ReadLine();
    Console.Write("Informe o telefone: ");
    string tel = Console.ReadLine();
    Cliente obj = new Cliente { Nome = nome, Telefone = tel };
    Sistema.ClienteInserir(obj);
    Console.WriteLine("---- Operação realizada com sucesso ----");
    Console.WriteLine("----------------------------------------");
  }
  public static void ClienteListar() {
    Console.WriteLine("---- Listar os clientes cadastrados ----");
    foreach(Cliente obj in Sistema.ClienteListar())
      Console.WriteLine(obj);
    Console.WriteLine("----------------------------------------");
  }
  public static void ClienteAtt() {
    Console.WriteLine("---- Atualizar um cliente ----");
    Console.Write("Informe o id do cliente: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o novo cliente: ");
    string nome = Console.ReadLine();
    Cliente obj = new Cliente { Id = id, Nome = nome };
    Sistema.ClienteAtt(obj);
    Console.WriteLine("---- Operação realizada com sucesso ----");
    Console.WriteLine("----------------------------------------");
  }
  public static void ClienteExcluir() {
    Console.WriteLine("---- Excluir um cliente ----");
    Console.Write("Informe o id do cliente: ");
    int id = int.Parse(Console.ReadLine());
    Cliente obj = new Cliente { Id = id };
    Sistema.ClienteExcluir(obj);
    Console.WriteLine("---- Operação realizada com sucesso ----");
    Console.WriteLine("----------------------------------------");
  }

  public static void ServicoInserir() {
    Console.WriteLine("---- Inserir um novo serviço ----");
    Console.Write("Informe a descrição: ");
    string desc = Console.ReadLine();
    Console.Write("Informe o preço: ");
    double preco = double.Parse(Console.ReadLine());
    Servico obj = new Servico { Desc = desc, Preco = preco };
    Sistema.ServicoInserir(obj);
    Console.WriteLine("---- Operação realizada com sucesso ----");
    Console.WriteLine("----------------------------------------");
  }
  public static void ServicoListar() {
    Console.WriteLine("---- Listar os serviços cadastrados ----");
    foreach(Servico obj in Sistema.ServicoListar())
      Console.WriteLine(obj);
    Console.WriteLine("----------------------------------------");
  }
  public static void ServicoAtt() {
    Console.WriteLine("---- Atualizar um serviço ----");
    Console.Write("Informe o id do serviço: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a nova descrição: ");
    string desc = Console.ReadLine();
    Console.Write("Informe o preço: ");
    double preco = double.Parse(Console.ReadLine());
    Servico obj = new Servico { Id = id, Desc = desc, Preco = preco };
    Sistema.ServicoAtt(obj);
    Console.WriteLine("---- Operação realizada com sucesso ----");
    Console.WriteLine("----------------------------------------");
  }
  public static void ServicoExcluir() {
    Console.WriteLine("---- Excluir um serviço ----");
    Console.Write("Informe o id do seviço: ");
    int id = int.Parse(Console.ReadLine());
    Servico obj = new Servico { Id = id };
    Sistema.ServicoExcluir(obj);
    Console.WriteLine("---- Operação realizada com sucesso ----");
    Console.WriteLine("----------------------------------------");
  }

  public static void AluguelVerAgenda() {
    Console.WriteLine("---- Ver agenda ----");
    foreach(Aluguel obj in Sistema.AluguelListar()) {
      //List<Cliente> c = Sistema.ClienteListar();
      Cliente c = Sistema.ClienteLocalizar(obj.IdCliente);
      //List<Livro> l = Sistema.LivroListar();
      Livro l = Sistema.LivroLocalizar(obj.IdLivro);
      //List<Servico> s = Sistema.ServicoListar();
      Servico s = Sistema.ServicoLocalizar(obj.IdServico);
      if (c != null)
        Console.WriteLine(obj + " - " + c.Nome + " - " + l.GetNome() + " - " + s.Desc);
      else
        Console.WriteLine(obj);
    }
    Console.WriteLine("----------------------------------------");
  }
}