using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemyLaser : MonoBehaviour
{
    private Vector2 movement;
	private Vector3 leftBottomCameraBorder;
	private Vector2 size;
	public AudioClip bruitage;
    void Start()
    {
        movement = new Vector2(-6,0);
		GetComponent<Rigidbody2D>().velocity = movement;
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (0,0,0));
		size.x = GetComponent<SpriteRenderer>().bounds.size.x;
		size.y = GetComponent<SpriteRenderer>().bounds.size.y;
		SoundManager.Instance.Play(bruitage);
    }

    void Update()
    {
		if(transform.position.x < leftBottomCameraBorder.x - (size.x/2)){
			Destroy(gameObject);
		}
    }
}
