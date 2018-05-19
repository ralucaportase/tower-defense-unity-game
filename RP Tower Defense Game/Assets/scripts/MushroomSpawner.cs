using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MushroomSpawner : MonoBehaviour {

	public Transform enemyPrefab;
	public float timeBetweenWaves = 5.5f;
	public Transform spawnPoint;

	public int totalNumberOfEnemys = 20;
	public int totalNumberOfLifes = 3;

	[Header("Game UI Fields")]

	public Text waveCountdownText;
	public Text enemyText;
	public Text lifeNumberText;
	public GameObject gameOverUI;
	public GameObject gamePausedUI;

	private float countdown = 2f;
	private int waveIndex = 0;
	private int numberOfEnemysForLevel;
	private int numberOfLifes;

	private bool gameEnded;
	private bool gamePaused;

	public void DecrementNumberOfEnemies()
	{
		numberOfEnemysForLevel--;
		enemyText.text = numberOfEnemysForLevel + "/" + totalNumberOfEnemys;
	}

	public void DecrementNumberOfLifes()
	{
		numberOfLifes--;
		lifeNumberText.text = numberOfLifes + "/" + totalNumberOfLifes;
		if (numberOfLifes == 0) 
		{
			EndGame ();
		}
	}

	public bool IsGameEnded()
	{
		return gameEnded;
	}

	public bool IsGamePaused()
	{
		return gamePaused;
	}

	public void PauseGame() {
		Debug.Log ("paused button pressed");
		gamePaused = !gamePaused;
		gamePausedUI.SetActive (gamePaused);
	}

	void Start () 
	{
		numberOfEnemysForLevel = totalNumberOfEnemys;
		numberOfLifes = totalNumberOfLifes;
		gameEnded = false;
		gamePaused = false;
		gameOverUI.SetActive (false);
		gamePausedUI.SetActive (false);
	}
		
	void Update () {
		if (IsGameEnded() || IsGamePaused()) 
		{
			return;
		}

		//create wave
		if(countdown <= 0f && 
			waveIndex * waveIndex - waveIndex <= totalNumberOfEnemys * 2)
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
		GameObject enemyGO = Instantiate (enemyPrefab, spawnPoint.position, spawnPoint.rotation).gameObject;
		Enemy enemy = enemyGO.GetComponent<Enemy> ();
		enemy.UpdateGameMaster (this.transform);
	}

	void EndGame()
	{
		gameEnded = true;
		gameOverUI.SetActive (true);
	}
		
}

