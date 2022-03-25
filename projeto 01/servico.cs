using System;

class Servico {
  public int Id { get; set; }
  public string Desc { get; set; }
  public double Preco { get; set; }
  public override string ToString() {
    return $"{Id} {Desc} R${Preco:0.00}";
  }
}