using System;

class Sistema{
  private static Genero[] generos = new Genero[10];
  private static int nGenero;
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
}