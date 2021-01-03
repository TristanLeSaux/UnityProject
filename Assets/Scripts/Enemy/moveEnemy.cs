using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemy : MonoBehaviour
{
	private Vector2 movement;
    private Vector3 leftBottomCameraBorder;
	private Vector3 rightTopCameraBorder;
    private Vector3 enemyOldCenterPosition;
    private Vector2 size;

	
    void Start()
    {
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0));
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,1,0));
        size.x = (gameObject.GetComponent<SpriteRenderer>().bounds.size.x)/gameObject.transform.localScale.x;
        size.y = (gameObject.GetComponent<SpriteRenderer>().bounds.size.y)/gameObject.transform.localScale.y;
		movement = new Vector2(-1.5f, -1f);
		GetComponent<Rigidbody2D>().velocity = movement;
    }

    void Update()
    {
		if(transform.position.x < rightTopCameraBorder.x - (size.x)){
			movement.x = 0;
			GetComponent<Rigidbody2D>().velocity = movement;
		}
		if(transform.position.y > rightTopCameraBorder.y - (size.y)){
			movement.y = -1f;
			GetComponent<Rigidbody2D>().velocity = movement;
		}
		if(transform.position.y < leftBottomCameraBorder.y + (size.y)){
			movement.y = 1f;
			GetComponent<Rigidbody2D>().velocity = movement;
		}
        if(transform.position.x < leftBottomCameraBorder.x - (size.x/2)){
			Destroy(gameObject);
		}
    }
}
