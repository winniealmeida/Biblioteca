using System;
using System.Collections.Generic;

class Sistema{
  private static Genero[] generos = new Genero[10];
  private static int nGenero;
  private static List<Livro> livros = new List<Livro>();
  private static List<Cliente> clientes = new List<Cliente>();
  private static List<Servico> servicos = new List<Servico>();
  private static List<Aluguel> agenda = new List<Aluguel>();
  public static void GeneroInserir(Genero obj) {
    if (nGenero == generos.Length);
      Array.Resize(ref generos, 2 * generos.Length);
    generos[nGenero] = obj;
    nGenero++;
  }
  public static Genero[] GeneroListar() {
    Genero[] aux = new Genero[nGenero];
    Array.Copy(generos, aux, nGenero);
    return aux;
  }
  public static Genero GeneroLocalizar(int id) {
    foreach(Genero obj in generos)
      if (obj != null && obj.GetId() == id) return obj;
    return null;
  }
  public static void GeneroAtt(Genero obj) {
    Genero aux = GeneroLocalizar(obj.GetId());
    if (aux != null)
      aux.SetNome(obj.GetNome());
  }
  public static void GeneroExcluir(Genero obj) {
    int aux = GeneroIndice(obj.GetId());
    if (aux != -1) {
      for (int i = aux; i < nGenero - 1; i++)
        generos[i] = generos[i + 1];
      nGenero--;
    }
  }
  private static int GeneroIndice(int id) {
    for(int i = 0; i < nGenero; i ++) {
      Genero obj = generos[i];
      if (obj.GetId() == id) return i;
    } 
    return -1;
  }
  
  public static void LivroInserir(Livro obj) {
    livros.Add(obj);
  }
  public static List<Livro> LivroListar() {
    return livros;
  }
  public static Livro LivroLocalizar(int id) {
    foreach(Livro obj in livros)
      if (obj.GetId() == id) return obj;
    return null;
  }
  public static void LivroAtt(Livro obj) {
    Livro aux = LivroLocalizar(obj.GetId());
    if (aux != null){
      aux.SetNome(obj.GetNome());
      aux.SetId(obj.GetId());
      aux.SetIdGenero(obj.GetIdGenero());
    }
  }
  public static void LivroExcluir(Livro obj) {
    Livro aux = LivroLocalizar(obj.GetId());
    if (aux != null) livros.Remove(aux);
  }

  public static void ClienteInserir(Cliente obj) {
    int id = 0;
    foreach(Cliente aux in clientes)
      if (aux.Id > id) id = aux.Id;
    obj.Id = id + 1;
    clientes.Add(obj);
  }
  public static List<Cliente> ClienteListar() {
    return clientes;
  }
  public static Cliente ClienteLocalizar(int id) {
    foreach(Cliente obj in clientes)
      if (obj.Id == id) return obj;
    return null;
  }
  public static void ClienteAtt(Cliente obj) {
    Cliente aux = ClienteLocalizar(obj.Id);
    if (aux != null){
      aux.Nome = obj.Nome;
      aux.Telefone = obj.Telefone;
    }
  }
  public static void ClienteExcluir(Cliente obj) {
    Cliente aux = ClienteLocalizar(obj.Id);
    if (aux != null) clientes.Remove(aux);
  }
  
  public static void ServicoInserir(Servico obj) {
    int id = 0;
    foreach(Servico aux in servicos)
      if (aux.Id > id) id = aux.Id;
    obj.Id = id + 1;
    servicos.Add(obj);
  }
  public static List<Servico> ServicoListar() {
    return servicos;
  }
  public static Servico ServicoLocalizar(int id) {
    foreach(Servico obj in servicos)
      if (obj.Id == id) return obj;
    return null;
  }
  public static void ServicoAtt(Servico obj) {
    Servico aux = ServicoLocalizar(obj.Id);
    if (aux != null){
      aux.Desc = obj.Desc;
      aux.Preco = obj.Preco;
    }
  }
  public static void ServicoExcluir(Servico obj) {
    Servico aux = ServicoLocalizar(obj.Id);
    if (aux != null) servicos.Remove(aux);
  }

  public static void AluguelInserir(Aluguel obj) {
    int id = 0;
    foreach(Aluguel aux in agenda)
      if (aux.Id > id) id = aux.Id;
    obj.Id = id + 1;
    agenda.Add(obj);
  }
  public static List<Aluguel> AluguelListar() {
    return agenda;
  }
  public static Aluguel AluguelLocalizar(int id) {
    foreach(Aluguel obj in agenda)
      if (obj.Id == id) return obj;
    return null;
  }
  public static Aluguel AluguelClienteListar(int idCliente) {
    foreach(Aluguel obj in agenda)
      if (obj.IdCliente == idCliente) return obj;
    return null;
  }
  
  public static void AluguelAtt(Aluguel obj) {
    Aluguel aux = AluguelLocalizar(obj.Id);
    if (aux != null){
      aux.Data = obj.Data;
      aux.IdLivro = obj.IdLivro;
      aux.NomeLivro = obj.NomeLivro;
      aux.IdServico = obj.IdServico;
    }
  }
  public static List<Aluguel> AluguelLivroListar(Livro livro) {
    List<Aluguel> aluguelporlivro = new List<Aluguel>();
    foreach(Aluguel obj in agenda)
      if (obj.IdLivro == livro.id)
        aluguelporlivro.Add(obj);
    return aluguelporlivro;
  }
  
  /*public static List<Aluguel> AluguelDisponivelListar(idlivro, datadigitada) {
    List<Aluguel> aluguellivrodisponivel = new List<Aluguel>();
    foreach(Aluguel obj in agenda)
      /*livro já está alugado //
      if (obj.idLivro == idlivro && obj.Data == datadigitada)
        return null;
      if (obj.idLivro == idlivro && obj.Data != datadigitada)
        aluguellivrodisponivel.Add(obj);
        return aluguellivrodisponivel;
  }*/

    /*Lista de livros alugados no livro */
  public static List<Aluguel> AluguelDisponivelListar(Livro livro) {
      List<Aluguel> alugueldatadisponivel = new List<Aluguel>();
    foreach(Aluguel obj in agenda)
      if (obj.idLivro == livro.id) /* tirei a comparação do id obj.IdLivro == 0 && pq somente pela data já sabemos se o livro está alugado ou não*/
        alugueldatadisponivel.Add(obj);
    return alugueldatadisponivel;
  }

  
  /*Lista de livros alugados na data digitada */
  public static List<Aluguel> AluguelDisponivelListar(DateTime datadigitada) {
    List<Aluguel> alugueldatadisponivel = new List<Aluguel>();
    foreach(Aluguel obj in agenda)
      if (obj.Data == datadigitada) /* retirei a comparação do ID obj.IdLivro == 0 && pois somente pela data já saberemos se o livro está alugado ou não*/
        alugueldatadisponivel.Add(obj);
    return alugueldatadisponivel;
  }
  
  //public static void AluguelAbrirAgenda(DateTime datadigitada) {
      //int[] alugueispordia = { 8, 9, 10, 11, 13, 14, 15, 16, 17, 18 };
      //DateTime hoje = datadigitada;
      //foreach(int a in alugueispordia){
        //TimeSpan alugueis = new TimeSpan(0, a, 0, 0);
        //Aluguel obj = new Aluguel { Data = hoje + alugueis };
        //AluguelInserir(obj);
      //}
    //}
  public static void AluguelExcluir(Aluguel obj) {
    Aluguel aux = AluguelLocalizar(obj.Id);
    if (aux != null) agenda.Remove(aux);
  }
}