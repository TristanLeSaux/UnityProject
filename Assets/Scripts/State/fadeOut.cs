using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeOut : MonoBehaviour
{

    void Update () {
		Color cl = GetComponent<SpriteRenderer> ().color;
		cl.a -= 0.02f;
		GetComponent<SpriteRenderer> ().color = cl;
		tag = "Untagged";
		if (cl.a < 0) {
		Destroy (gameObject);
		}
	}
}