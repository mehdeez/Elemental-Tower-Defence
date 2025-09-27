using UnityEngine;

public class Bullet : MonoBehaviour {

	public Transform target;

	public float speed = 70f;

	public int damage = 50;

	public float explosionRadius = 0f;
	public GameObject impactEffect;
	
	public void Seek (Transform _target)
	{
		target = _target;
	}

	// Update is called once per frame
	void Update () {

		if (target == null)
		{
			Destroy(gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame)
		{
			HitTarget();
			return;
		}
			
		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
		transform.LookAt(target);
	}

	public void HitTarget ()
	{
		if (this.tag == "SupportBullet") {
			Rigidbody rb = gameObject.GetComponent<Rigidbody>();
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
			Destroy (this);
			return;
		}

		if (this.gameObject.tag == "WoodBullet")
		{
			// true: isLifeAbsorption
			Damage(target, true);
		}

		GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(effectIns, 5f);

		if (explosionRadius > 0f)
		{
			Explode();
		} else
		{
			Damage(target);
		}

		Destroy(gameObject);
	}

	void Explode ()
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
		foreach (Collider collider in colliders)
		{
			if (collider.tag == "Enemy")
			{
				Damage(collider.transform);
			}
		}
	}

	void Damage (Transform enemy)
	{
		Enemy e = enemy.GetComponent<Enemy>();

		if (e != null)
		{
			e.TakeDamage(damage);
		}
	}

	void Damage(Transform enemy, bool isLifeAbsorption)
	{
		Enemy e = enemy.GetComponent<Enemy>();

		if (e != null)
		{
			e.TakeDamage(damage, isLifeAbsorption);
		}
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, explosionRadius);
	}
}
