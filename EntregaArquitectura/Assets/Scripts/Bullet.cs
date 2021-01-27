using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform target;

	public float speed = 70f;

	public int damage = 50;

	public float explosionRadius = 0f;
	
	//Marca al target
	public void Seek (Transform _target)
	{
		target = _target;
	}

	// Update is called once per frame
	void Update () {
//Si no hay target se destruye la bala
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
//Daña al objetivo, le resta vida y se destruye
	void HitTarget ()
	{
		Damage(target);

			Destroy(gameObject);
	}

	//Hacer daño al enemigo
	void Damage (Transform enemy)
	{
		Enemy e = enemy.GetComponent<Enemy>();

		if (e != null)
		{
			e.TakeDamage(damage);
		}
	}

}
