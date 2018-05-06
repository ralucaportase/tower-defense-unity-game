using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MushroomSpawner : MonoBehaviour {

	public Transform enemyPrefab;
	public float timeBetweenWaves = 5.5f;
	public Transform spawnPoint;

	public int totalNumberOfEnemys = 20;
	public int numberOfEnemysForLevel;

	[Header("Game UI Fields")]

	public Text waveCountdownText;
	public Text enemyText;

	private float countdown = 2f;
	private int waveIndex = 0;

	public void DecrementNumberOfEnemies()
	{
		numberOfEnemysForLevel--;
		enemyText.text = numberOfEnemysForLevel + "/" + totalNumberOfEnemys;
	}

	void Start () 
	{
		numberOfEnemysForLevel = totalNumberOfEnemys;
	}
		
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
		if (waveIndex * waveIndex - waveIndex >= totalNumberOfEnemys * 2) {
			//TODO We should stop the instantiation of enemies
			StopCoroutine (SpawnWave ());
		}

		waveIndex++;
		for (int i = 0; i < waveIndex; i++) 
		{
			SpawnEnemy ();
			yield return new WaitForSeconds (0.5f);
		}
	}

	void SpawnEnemy()
	{
		GameObject enemyGO = Instantiate (enemyPrefab, spawnPoint.position, spawnPoint.rotation).gameObject;
		Enemy enemy = enemyGO.GetComponent<Enemy> ();
		enemy.UpdateGameMaster (this.transform);
	}
}

