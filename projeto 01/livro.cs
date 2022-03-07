using System;

class Livro {
  private string nome;
  private int idGenero;
  public Livro(string nome, int idGenero) {
    this.nome = nome;
    this.idGenero = idGenero;
  }
  public void SetNome(string nome, int idGenero) {
    this.nome = nome;
    this.idGenero = idGenero;
  }
  public string GetNome() {
    return nome;
  }
  public override string ToString() {
    return $"{nome}";
  }
}