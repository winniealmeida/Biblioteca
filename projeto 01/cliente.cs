using System;

class Cliente {
  public int Id { get; set; }
  public string Nome { get; set; }
  public string Telefone { get; set; }
  public override string ToString() {
    return $"{Id}: {Nome} {Telefone}";
  }
}