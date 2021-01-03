using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneState : MonoBehaviour
{
    public Text scoreText;
	public AudioClip musiqueBoss;
	
	void Start()
	{
		if(SceneManager.GetActiveScene().name == "BossLevel"){
			SoundManager.Instance.PlayMusic(musiqueBoss);
		}
	}
}