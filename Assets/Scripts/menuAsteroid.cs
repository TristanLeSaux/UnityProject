using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuAsteroid : MonoBehaviour
{
    private GameObject[] respawns;
	private Vector2 siz;
	private Vector3 leftBottomCameraBorder;
	private Vector3 rightTopCameraBorder;
	
	
	void Start()
	{
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0));
        rightTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,1,0));
	}
    void Update () {
		respawns = GameObject.FindGameObjectsWithTag("asteroid");// Create a tab containing all the asteroid in a scene
		if (respawns.Length > 0) {
			siz.x = respawns[0].GetComponent<SpriteRenderer> ().bounds.size.x;
			siz.y = respawns[0].GetComponent<SpriteRenderer> ().bounds.size.y;
		}
		if (respawns.Length < 5){
			if (Random.Range(1,100) == 50 || respawns.Length < 2)// Choose randomly if an asteroid will be created or not
			{
				GameObject gY = Instantiate (Resources.Load ("asteroid1"),
				new Vector3(rightTopCameraBorder.x+siz.x,Random.Range(rightTopCameraBorder.y,leftBottomCameraBorder.y),0.0f),Quaternion.identity) as GameObject;
				gY.tag = "asteroid";
			}
		}
	}
}