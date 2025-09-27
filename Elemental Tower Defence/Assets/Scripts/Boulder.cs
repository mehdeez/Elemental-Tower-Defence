using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour {

	public float duration;

	// Use this for initialization
	void Start () {
		StartCoroutine (Fadeout());
	}
		
	IEnumerator Fadeout(){
		yield return new WaitForSeconds (duration);
		Destroy (gameObject);
	}
}
