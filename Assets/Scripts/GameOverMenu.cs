using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
	
    public void Retry()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

    public void Menu()
	{
		SceneManager.LoadScene("Menu");
	}
	
	public void Quit()
	{
		Debug.Log("Quit");
		Application.Quit();
	}
}
