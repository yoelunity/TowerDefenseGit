using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

	private Transform target;
	private int wavepointIndex = 0;

	private Enemy enemy;

	void Start()
	{
		enemy = GetComponent<Enemy>();

		target = CheckPoints.points[0];
	}
//mueve al enemy entre los checkpoints de la ruta establecida y cuando llega o esta muy cerca cambia el target al siguiente checkpoint
	void Update()
	{
		Vector3 direccion = target.position - transform.position;
		transform.Translate(direccion.normalized * enemy.speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			NextCheckPoint();
		}

		enemy.speed = enemy.startSpeed;
	}
//cambia el checkpoint
	void NextCheckPoint()
	{
		if (wavepointIndex >= CheckPoints.points.Length - 1)
		{
			EndPath();
			return;
		}

		wavepointIndex++;
		target = CheckPoints.points[wavepointIndex];
	}
//si el enemigo llega al final resta una vida al jugador y desaparece y resta uno en el contador de enemigos vivos para poder pasar la wave
	void EndPath()
	{
		PlayerStats.Lives--;
		WaveSpawner.EnemiesAlive--;
		Destroy(gameObject);
	}

}
