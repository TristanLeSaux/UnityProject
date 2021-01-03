using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "score", menuName = "so/score")]
public class SOScore : ScriptableObject
{
  public List<int> scoreInt;
  public List<string> scoreNom;

  public void AjouterNouveauScore(string nom, int score)
  {
    int indice = -1;
    bool trouve = false;
    int taille = scoreInt.Count;

    if (taille <= 10)
    { // le tableau des score est inférieur à 10
      for (int i = 0; i < taille; i++)
      { // On regarde si le score est supérieur à un score déjà présent dans le tableau
        if (scoreInt[i] < score && !trouve) { indice = i; trouve = true; } // On a trouvé et on récupère un indice
      }
      if (indice < 0) { scoreNom.Add(nom); scoreInt.Add(score); } // on a pas trouvé mais on est inférieur à 10 donc on ajoute.
    }
    else
    {
      for (int i = 0; i < 10; i++)
      {
        if (scoreInt[i] < score && !trouve) { indice = i; trouve = true; }
      }
    }
    if (indice >= 0)
    {
      DecalerScores(indice);
      scoreInt[indice] = score;
      scoreNom[indice] = nom;
    }
  }
  public void DecalerScores(int indiceDepart)
  {
    if (indiceDepart >= scoreInt.Count || indiceDepart < 0) return;

    int nextScore = scoreInt[indiceDepart];
    string nextName = scoreNom[indiceDepart];

    int maxIndex = Mathf.Min(scoreInt.Count+1, 10);

    for(int i = indiceDepart+1; i < maxIndex; i++)
    {
      if (i < scoreInt.Count)
      {
        int tmp_score = scoreInt[i];
        string tmp_name = scoreNom[i];

        scoreInt[i] = nextScore;
        scoreNom[i] = nextName;

        nextScore = tmp_score;
        nextName = tmp_name;
      }
      else
      {
        scoreInt.Add(nextScore);
        scoreNom.Add(nextName);
      }
    }

  }


  public int GetScore(string nom) => scoreInt[nom.IndexOf(nom)];
}
