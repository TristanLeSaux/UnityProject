using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
	public AudioClip musiqueMenu;
	public AudioClip musiqueLevel;
	public EventSystem eventSystem;
	public TMP_Text score;
	
	void Start()
	{
		SoundManager.Instance.PlayMusic(musiqueMenu);
	}
	
    public void PlayGame()
	{
		SoundManager.Instance.PlayMusic(musiqueLevel);
		SceneManager.LoadScene("Level01");
	}
	
	public void QuitGame()
	{
		Debug.Log("Quit");
		Application.Quit();
	}
	
	public void SelectNewButton(GameObject selected)
	{
		eventSystem.SetSelectedGameObject(selected);
	}
	
	public void OnClickScore(){
        score.text = GameState.Instance.getScorePlayer();
      }
}
