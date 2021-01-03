using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileAgain : MonoBehaviour
{
	private Vector2 siz;
	private GameObject[] missiles;
	
    void Update () {
		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;
		missiles = GameObject.FindGameObjectsWithTag("missile");
		
		if (missiles.Length < 1 ) {
			Vector3 tmpPos = new Vector3(transform.position.x + siz.x/2,transform.position.y,transform.position.z);
			GameObject gY = Instantiate(Resources.Load ("missile"), tmpPos, Quaternion.identity) as GameObject;
			//SoundState.touchButtonSound();
			gY.tag = "missile";
		}
	}
}
