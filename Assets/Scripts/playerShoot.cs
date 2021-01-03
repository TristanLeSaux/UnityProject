using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
    
	private Vector2 siz;
	private float delayBetweenShots = 0.3f;
	private float lastShotDate;
	
	void Start()
	{
		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;
		lastShotDate = Time.time;
	}
	public void setDelay(float delay)
	{
		delayBetweenShots = delay;
	}
    void Update () {
		// If space key pressed
		bool sp = Input.GetKey (KeyCode.Space);
		bool sp2 = Input.GetButton ("Fire1");
		if ((sp || sp2) && Time.time - lastShotDate > delayBetweenShots) {
			Vector3 tmpPos = new Vector3(transform.position.x + siz.x/2,transform.position.y,transform.position.z);
			GameObject gY = Instantiate(Resources.Load ("BlueLaser"), tmpPos, Quaternion.identity) as GameObject;
			lastShotDate = Time.time;
		}
	}
}