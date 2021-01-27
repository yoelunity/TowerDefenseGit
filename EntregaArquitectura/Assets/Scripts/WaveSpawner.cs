using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public static int EnemiesAlive = 0;

	public Wave[] waves;

	public Transform spawnPoint;

	public float entreRondas = 5f;
	private float cuentaAtrasWave = 2f;

	public Text waveCountdownText;
	
	private int waveIndex = 0;

	
	//Se comprueba si quedan enemigos vivos , tras esto se comprueba si se han completado todas las waves establecidas. Y se comienza la corrutina
	//que inicia la wave.
	void Update ()
	{
		if (EnemiesAlive > 0)
		{
			return;
		}

		if (waveIndex == waves.Length)
		{
			this.enabled = false;
		}

		if (cuentaAtrasWave <= 0f)
		{
			StartCoroutine(SpawnWave());
			cuentaAtrasWave = entreRondas;
			return;
		}

		cuentaAtrasWave -= Time.deltaTime;

		cuentaAtrasWave = Mathf.Clamp(cuentaAtrasWave, 0f, Mathf.Infinity);

		waveCountdownText.text = string.Format("{0:00.00}", cuentaAtrasWave);
	}
	
	//Instancia tantos enemigos como la wave en la que se está con un delay de 1 segundo entre el rate de la wave
	IEnumerator SpawnWave ()
	{
		PlayerStats.Rounds++;

		Wave wave = waves[waveIndex];

		EnemiesAlive = wave.count;

		for (int i = 0; i < wave.count; i++)
		{
			SpawnEnemy(wave.enemy);
			yield return new WaitForSeconds(1f / wave.rate);
		}

		waveIndex++;
	}
//instancia al enemigo en el spawn point
	void SpawnEnemy (GameObject enemy)
	{
		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
	}

}
