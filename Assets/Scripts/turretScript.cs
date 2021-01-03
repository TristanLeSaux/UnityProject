using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turretScript : MonoBehaviour
{
	public int pv;
	public Slider BossLife;
	
    void Start()
    {
        
    }
    void Update()
    {
        
    }
	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.tag == "playerShoot")
		{
			pv--;
			if(pv==0)
			{
				gameObject.AddComponent<fadeOut>();
				BossLife.value -= 0.2f;
			}
			Destroy(collider.gameObject);
		}
		
	}
}
