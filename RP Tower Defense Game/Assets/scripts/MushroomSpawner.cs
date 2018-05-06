using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MushroomSpawner : MonoBehaviour {

	public Transform enemyPrefab;
	public float timeBetweenWaves = 5.5f;
	public Transform spawnPoint;

	public Text waveCountdownText;

	private float countdown = 2f;
	private int waveIndex = 0;

	// Update is called once per frame
	void Update () {
		if(countdown <= 0f)
		{
			StartCoroutine (SpawnWave ());
			countdown = timeBetweenWaves;
		}

		countdown -= Time.deltaTime;
		waveCountdownText.text = Mathf.Floor(countdown).ToString();
	}

	IEnumerator SpawnWave()
	{
		waveIndex++;
		for (int i = 0; i < waveIndex; i++) 
		{
			SpawnEnemy ();
			yield return new WaitForSeconds (0.5f);
		}
	}

	void SpawnEnemy()
	{
		Instantiate (enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}
}

