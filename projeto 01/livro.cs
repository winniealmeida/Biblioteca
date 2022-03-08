using System;

class Livro {
  private string nome;
  private int idGenero;
  public Livro(string nome, int idGenero) {
    this.nome = nome;
    this.idGenero = idGenero;
  }
  public void SetNome(string nome) {
    this.nome = nome;
  }
  public void SetIdGenero(int idGenero) {
    this.idGenero = idGenero;
  }
  public string GetNome() {
    return nome;
  }
  public int GetIdGenero() {
    return idGenero;
  }
  public override string ToString() {
    return $"{nome}";
  }
}