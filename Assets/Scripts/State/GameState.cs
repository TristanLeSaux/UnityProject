using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
	private static GameState instance = null;
	public SOScore score{get;private set;}
	public int scorePlayer;
	
	public static GameState Instance 
    { 
      get
      {
         if(instance == null)
         {
            instance = FindObjectOfType<GameState>();
            if( instance == null) 
            {
              GameObject go = new GameObject();
              go.name = "GameState";
              instance = go.AddComponent<GameState>(); 
              DontDestroyOnLoad(go); 
            }
          }
           return instance;
        }
      }
     void Awake() 
     {
       if(instance == null ) 
       {
         instance = this; 
         DontDestroyOnLoad(this.gameObject); 
       }
       else
       {
         Destroy(gameObject); 
       }
	  score = Resources.Load<SOScore>("score");
	  SceneManager.sceneLoaded += OnSceneLoad;
    }
	
	void OnSceneLoad(Scene scene, LoadSceneMode lsm){
		if(scorePlayer!=0){score.AjouterNouveauScore("", scorePlayer);}
        scorePlayer = 0;
    }
	
    void Update(){}

	public void addScorePlayer(int toAdd) {
		scorePlayer += toAdd;
	}
	public string getScorePlayer(){
		string lesScoresJusqueDix = "";
		int taille = score.scoreNom.Count;
		if(taille>0){
			for(int i=0; i<10; i++){
				if(i<taille) lesScoresJusqueDix += (i+1) +"\t"+ score.scoreNom[i]+"\t" + score.scoreInt[i].ToString()+"\n";
			}
		}else {lesScoresJusqueDix = "Pas de scores";}
		return lesScoresJusqueDix;
	}
	public int getScore()
	{
		return scorePlayer;
	}
	void GameOver()
	{
		Debug.Log("GameOver");
	}
}