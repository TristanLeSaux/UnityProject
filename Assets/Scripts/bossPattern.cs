using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossPattern : MonoBehaviour
{
	private int nombreTourelle;
	public Slider BossLife;
	public GameObject EndGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }
	void Update()
    {
        nombreTourelle = FindObjectsOfType<turretScript>().Length;
    }
    void OnTriggerEnter2D(Collider2D collider){
		if(collider.tag == "playerShoot"){
			if(nombreTourelle<1){
				BossLife.value-= 0.1f;
			}
			if(BossLife.value == 0f){
				BossLife.gameObject.SetActive(false);
				Destroy(gameObject);
				Destroy(FindObjectOfType<movePlayer>().gameObject);
				EndGame.SetActive(true);
			}
		Destroy(collider.gameObject);
		}
	}
}
