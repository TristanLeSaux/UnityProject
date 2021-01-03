using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveLaser : MonoBehaviour
{
	
	private Vector2 movement;
	private Vector3 rightBottomCameraBorder;
	private Vector2 size;
	public AudioClip bruitage;
	private Text score;
	
    void Start()
    {
        movement = new Vector2(10,0);
		GetComponent<Rigidbody2D>().velocity = movement;
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (1,0,0));
		size.x = GetComponent<SpriteRenderer>().bounds.size.x;
		size.y = GetComponent<SpriteRenderer>().bounds.size.y;
		score = FindObjectOfType<SceneState>().scoreText;
		SoundManager.Instance.Play(bruitage);
    }

    void Update()
    {
		if(transform.position.x > rightBottomCameraBorder.x + (size.x/2)){
			Destroy(gameObject);
		}
    }
	
	void OnTriggerEnter2D(Collider2D collider) {
		string stringTag = collider.gameObject.tag;
		if(stringTag == "asteroid" || stringTag == "enemy"){
			collider.gameObject.AddComponent<fadeOut>();
			GameState.Instance.addScorePlayer(1);
			Debug.Log("Score = " +score.text);
			score.text=GameState.Instance.scorePlayer.ToString();
			Destroy (gameObject);
		}
	}
}
