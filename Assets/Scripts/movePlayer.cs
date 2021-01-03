using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movePlayer : MonoBehaviour
{
	// 1 - La vitesse de déplacement
	public Vector2 speed; // Vector2 -> 2 floats (X, Y)
	// 2 - Stockage
	private Vector2 movement;
	
	//public Animator  animator;
	public Rigidbody2D rb;
	public SpriteRenderer spriteRenderer;
	public Slider BarreDeVie;
	public GameObject MenuGameOver;
	
	void Start(){
		/*animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();*/
		
	}
	
    void Update()
    {
        // 3 - Récupérer les informations du clavier/manette
		float inputY = Input.GetAxis("Vertical");
		float inputX = Input.GetAxis("Horizontal");
		
		//4 - Calcul du mouvement
		movement = new Vector2(
			speed.x * inputX,
			speed.y * inputY);
		GetComponent<Rigidbody2D> ().velocity = movement;
		
		float vitesse = Mathf.Abs(rb.velocity.x);
		//animator.SetFloat("Speed", vitesse);
    }
	
	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log(collider);
		Debug.Log(BarreDeVie.value);
		if(BarreDeVie.value - 0.2f<=0){
			Debug.Log("Mortibus");
			MenuGameOver.SetActive(true);
			Destroy(gameObject);
			Destroy(BarreDeVie);
		}
		if(collider.gameObject.tag != "playerShoot"){
			BarreDeVie.value = BarreDeVie.value - 0.2f;
			if(BarreDeVie.value>0.2f && BarreDeVie.value<1f){
				BarreDeVie.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = new Color(255f/255f, 190f/255f, 25f/255f);
			}
			if(BarreDeVie.value<0.3f){
				BarreDeVie.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = new Color(255f/255f, 28f/255f, 18f/255f);
			}
		}
	}
}