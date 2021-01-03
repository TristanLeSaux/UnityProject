using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class moveBackground : MonoBehaviour
{
  private Vector3 leftBottomCameraBorder;
 // private Vector3 rightBottomCameraBorder;

  public GameObject bg3;

  private float positionRestartX;
  private Vector2 movement;
  private Vector2 siz;

  public SpriteRenderer spriteRenderer;
  public Rigidbody2D rb;
  public float vitesse;
  
  void Start()
  {
      positionRestartX = bg3.GetComponent<SpriteRenderer>().bounds.size.x;
      leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0));
	  //rightBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,0,0));

      siz.x = spriteRenderer.bounds.size.x;
      siz.y = spriteRenderer.bounds.size.y;
	  //spriteRenderer = GetComponent<SpriteRenderer>();
	  //rb = GetComponent<Rigidbody2D>();
      movement = new Vector2(-1*vitesse,0);
  }

  void Update()
  {
      rb.velocity = movement;
      siz.x = spriteRenderer.bounds.size.x;
      siz.y = spriteRenderer.bounds.size.y;

      if(transform.position.x < leftBottomCameraBorder.x - (siz.x/2) ){
          transform.position = new Vector3(positionRestartX,transform.position.y,transform.position.z);
      }

  }
}