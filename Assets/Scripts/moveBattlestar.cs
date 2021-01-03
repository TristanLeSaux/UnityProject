using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBattlestar : MonoBehaviour
{
    private Vector2 movement;
    private Vector3 rightTopCameraBorder;
	private Vector3 leftTopCameraBorder;
    private Vector3 leftBottomCameraBorder;
    private Vector3 battlestarOldCenterPosition;
    private Vector3 size;
	
    void Start()
    {
        leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0));
		leftTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,1,0));
        rightTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,1,0));
        size.x = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        size.y = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
        size.z = gameObject.GetComponent<SpriteRenderer>().bounds.size.z;
        this.movement = new Vector2(1,0);
        GetComponent<Rigidbody2D>().velocity = movement;
    }
	
	void Update(){
        battlestarOldCenterPosition = gameObject.GetComponent<Transform>().position;
        if (battlestarOldCenterPosition.x - (size.x/2) > rightTopCameraBorder.x){
		Debug.Log("destroy");Destroy(gameObject);
		GameObject gY = Instantiate (Resources.Load ("Battlestar"),
		new Vector3(leftBottomCameraBorder.x - size.x/2,Random.Range(leftBottomCameraBorder.y+size.y/2, leftTopCameraBorder.y-size.y/2),0.0f),
		Quaternion.identity) as GameObject; }// L'objet veut sortir à droite 
     }
}
