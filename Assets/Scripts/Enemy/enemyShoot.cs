using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
    private Vector2 siz;
	public float delayBetweenShots;
	public float startDelay = 0f;
	private float lastShotDate;
	public string resources;
	
	void Start()
	{
		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;
		lastShotDate = Time.time+startDelay;
	}

    void Update () {
		if (Time.time - lastShotDate > delayBetweenShots) {
			Vector3 tmpPos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
			GameObject gY = Instantiate(Resources.Load (resources), tmpPos, Quaternion.identity) as GameObject;
			lastShotDate = Time.time;
		}
	}
}
