using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveMissile : MonoBehaviour
{
	private GameObject[] respawns;
	private Vector3 targetPosition;
	private Vector3 position;
	private Vector2 size;
	private Vector3 rightTopCameraBorder;
	private Vector3 leftBottomCameraBorder;
	private float vitesse;
	public AudioClip bruitage;
	
    void Start()
    {
		respawns = GameObject.FindGameObjectsWithTag("asteroid");
		targetPosition = respawns[0].GetComponent<Transform>().position;
		size.x = GetComponent<SpriteRenderer>().bounds.size.x;
		size.y = GetComponent<SpriteRenderer>().bounds.size.y;
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0));
        rightTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,1,0));
		vitesse = 4;
    }

    void Update()
    {
		float directionY = 0, directionX = 0;
		respawns = GameObject.FindGameObjectsWithTag("asteroid");
		targetPosition = respawns[0].GetComponent<Transform>().position; 
		position = GetComponent<Transform>().position;
		vitesse = 4;
		if(transform.position.x > rightTopCameraBorder.x + (size.x/2)
		|| transform.position.y > rightTopCameraBorder.y + (size.x/2)
		|| transform.position.x < leftBottomCameraBorder.x + (size.x/2)
		|| transform.position.y < leftBottomCameraBorder.y + (size.x/2)){
			Destroy(gameObject);}

		if(targetPosition.y > position.y){directionY = vitesse;}
		if(targetPosition.y < position.y){directionY = vitesse*(-1);}
		if(targetPosition.x > position.x){directionX = vitesse;}
		if(targetPosition.x < position.x){directionX = vitesse*(-1);}
		GetComponent<Rigidbody2D>().velocity = new Vector2(directionX,directionY);
    }
	void OnTriggerEnter2D(Collider2D collider) {
		// Add the fade script to the gameObject containing this script
		collider.gameObject.AddComponent<fadeOut>();
		if(SceneManager.GetActiveScene().name != "Menu"){
			SoundManager.Instance.Play(bruitage);
		}
		// Shoot destroy
		Destroy (gameObject);
	}
}
