using System;

class Aluguel {
  public int Id { get; set; }
  public DateTime Data { get; set; }
  public int IdLivro { get; set; }
  public string NomeLivro { get; set; }
  public int IdCliente { get; set; }
  public string NomeCliente { get; set; }
  public int IdServico { get; set; }
  public double PrecoServico { get; set; }
  public override string ToString() {
    string s = $"{Id}: {IdLivro}-{NomeLivro} para {IdCliente}-{NomeCliente} em {Data:dd/MM/yyyy} - R${PrecoServico:0.00} {IdServico}";
    return s;
  }
}