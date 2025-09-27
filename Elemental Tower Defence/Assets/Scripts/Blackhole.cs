using UnityEngine;
using System.Collections;

public class Blackhole : MonoBehaviour
{
	public float suctionForce = 10.0f;
	public float duration;

	private float timer;

	private void OnTriggerStay(Collider other){
		StartCoroutine (Fadeout());
		// Todo: "tornado" bullet has no rigidbody, this will give a minor error
		Rigidbody rb = other.attachedRigidbody;
		Enemy en = other.GetComponent<Enemy> ();
		en.speed = 0f;

		// Only apply force to objects with a Rigidbody component
		if (rb != null) {
			Vector2 forceDir = transform.position - other.transform.position;
			rb.AddForce (forceDir.normalized * suctionForce * Time.deltaTime);
		}
	}

	IEnumerator Fadeout(){
		yield return new WaitForSeconds (duration);
		Destroy (gameObject);
	}
}