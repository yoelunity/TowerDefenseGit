using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float startSpeed = 10f;

	public float speed;
	public int valor = 50;

	public float vidaInicial = 100;
	private float vida;




	public Image barraDeVida;

	private bool muerto = false;

	void Start ()
	{
		speed = startSpeed;
		vida = vidaInicial;
	}
//Recibe daño de las balas
	public void TakeDamage (float damage)
	{
		vida -= damage;

		barraDeVida.fillAmount = vida / vidaInicial;

		if (vida <= 0 && !muerto)
		{
			Muere();
		}
	}

	public void Slow (float pct)
	{
		speed = startSpeed * (1f - pct);
	}
//su valor de vida baja a 0
	void Muere ()
	{
		muerto = true;

		PlayerStats.Money += valor;


		WaveSpawner.EnemiesAlive--;

		Destroy(gameObject);
	}

}
