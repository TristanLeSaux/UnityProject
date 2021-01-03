using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class spawnAsteroid : MonoBehaviour
{
	private GameObject[] respawns;
	private Vector2 siz;

	private Vector3 leftBottomCameraBorder;
	private Vector3 rightTopCameraBorder;

	private GameObject asteroid;

	[Header("Increase difficulty")]
	public float minScale;
	public float maxScale;
	public float minSpeed;
	public float maxSpeed;
	public int minAsteroid;
	public int maxAsteroid;

	private float maxCurrentScale;
	private float maxCurrentSpeed;
	private int maxCurrentAsteroid;

	private void Awake()
	{
		asteroid = Resources.Load<GameObject>("asteroid1");

		siz.x = asteroid.GetComponent<SpriteRenderer>().bounds.size.x;
		siz.y = asteroid.GetComponent<SpriteRenderer>().bounds.size.y;
	}

	void Start(){
		StartCoroutine(IncreaseDifficulty());
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0));
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,1,0));
	}

	void Update()
	{
		respawns = FindObjectsOfType<moveAsteroid>().ToList().Select(o => o.gameObject).ToArray();
		Respawn();
		if(GameState.Instance.scorePlayer > 30){
			SceneManager.LoadScene("BossLevel");
		}
	}
	private IEnumerator IncreaseDifficulty()
	{
		yield return new WaitForEndOfFrame(); //attends la fin de la frame

		int numberOfPass = 1;

		while(numberOfPass < 100f)
		{
			//maxCurrentScale = minScale * Random.Range(1f, 1f + numberOfPass / 100f);
			maxCurrentScale = Mathf.Lerp(minScale, maxScale, numberOfPass / 100f);
			maxCurrentSpeed = Mathf.Lerp(minSpeed, maxSpeed, numberOfPass / 100f);
			maxCurrentAsteroid = (int)(Mathf.Lerp(minAsteroid, maxAsteroid, numberOfPass / 100f));
			//maxCurrentSpeed = minSpeed * Random.Range(1f, 1f + numberOfPass / 100f);
			//maxCurrentAsteroid = (int)(minAsteroid * Random.Range(1f, 1f + numberOfPass / 100f));
			numberOfPass++;
			yield return new WaitForSeconds(1f);

		}
	}

	private void Respawn()
	{
		if (respawns.Length < maxCurrentAsteroid)
		{
			if (Random.Range(1, 50) == 25 || respawns.Length < 3)// Choose randomly if an asteroid will be created or not
			{
			GameObject gY = Instantiate<GameObject>(asteroid,
			new Vector3(rightTopCameraBorder.x + siz.x,
			Random.Range(rightTopCameraBorder.y - (siz.y / 2),
			leftBottomCameraBorder.y + (siz.y / 2)), 0.0f),
			Quaternion.identity);
			gY.transform.localScale = maxCurrentScale * Vector3.one;
			gY.GetComponent<moveAsteroid>().speed = maxCurrentSpeed;
			gY.tag = "asteroid";
			}
		}
	}
}
