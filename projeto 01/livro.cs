using System;

class Livro {
  private string nome;
  public int id;
  private int idGenero;
  public Livro(int id) {
    this.id = id;
  }
  public Livro(string nome, int id, int idGenero) {
    this.nome = nome;
    this.id = id;
    this.idGenero = idGenero;
  }
  public void SetNome(string nome) {
    this.nome = nome;
  }
  public void SetId(int id) {
    this.id = id;
  }
  public void SetIdGenero(int idGenero) {
    this.idGenero = idGenero;
  }
  public string GetNome() {
    return nome;
  }
  public int GetId() {
    return id;
  }
  public int GetIdGenero() {
    return idGenero;
  }
  public override string ToString() {
    return $"{nome} - {id}";
  }
}