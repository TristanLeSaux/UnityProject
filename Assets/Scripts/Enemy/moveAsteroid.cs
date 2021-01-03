using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAsteroid : MonoBehaviour
{
    private Vector2 movement;
    private Vector3 rightTopCameraBorder;
    private Vector3 leftBottomCameraBorder;
    private Vector3 asteroidOldCenterPosition;
    private Vector2 size;
	public float speed;
	//private int rotation;
	
    void Start()
    {
        leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0));
        rightTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,1,0));
        size.x = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        size.y = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
        this.movement = new Vector2(
            Random.Range(-1.0f*speed, -2f),
            Random.Range(-1.0f, 1.0f)
		);
		//rotation = 0;
        GetComponent<Rigidbody2D>().velocity = movement;
    }

    // Update is called once per frame
    void Update(){
		
		/*if(rotation == 0){
			rotation = Random.Range(-1, 1);
		}
		transform.Rotate (Vector3.forward * rotation);*/
		
        asteroidOldCenterPosition = gameObject.GetComponent<Transform>().position;
		//transform.Rotate (Vector3.forward * rotation);
        //if (asteroidOldCenterPosition.x - (size.x/2) > rightTopCameraBorder.x){
		//	Debug.Log("destroy");Destroy(gameObject);GameObject gY = Instantiate (Resources.Load ("asteroid"), tmpPos, Quaternion.identity) as GameObject; }// L'objet veut sortir à droite 
        if ((asteroidOldCenterPosition.x + (size.x/2) < leftBottomCameraBorder.x) || (asteroidOldCenterPosition.y - (size.y/2) > rightTopCameraBorder.y) ||(asteroidOldCenterPosition.y + (size.y/2) < leftBottomCameraBorder.y)) {
			Debug.Log("destroy"); Destroy(gameObject);
			//GameObject gY = Instantiate (Resources.Load ("asteroid1"), new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(1,1,0)).x,Random.Range(Camera.main.ViewportToWorldPoint(new Vector3(1,1,0)).y, Camera.main.ViewportToWorldPoint(new Vector3(1,0,0)).y),0.0f),Quaternion.identity) as GameObject; 
		}
     }

}
