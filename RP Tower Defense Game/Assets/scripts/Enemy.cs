using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed = 10f;
	public int life = 5;

	private Transform target;
	private Transform gameMaster;
	private int waveportIndex = 0;

	public void UpdateGameMaster(Transform _gameMaster)
	{
		gameMaster = _gameMaster;	
	}

	void Start () 
	{
		target = Wavepoints.points[0];
	}

	// Update is called once per frame
	void Update () 
	{
		if (gameMaster.gameObject.GetComponent<MushroomSpawner> ().IsGameEnded () || 
			gameMaster.gameObject.GetComponent<MushroomSpawner> ().IsGamePaused ()) 
		{
			return;
		}
		Vector3 dir = target.position - transform.position;
		transform.Translate (dir.normalized * speed * Time.deltaTime, Space.World);
	
		if (Vector3.Distance (transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint ();
		}
			
		if (life <= 0) {
			gameMaster.gameObject.GetComponent<MushroomSpawner> ().DecrementNumberOfEnemies ();
			Destroy (gameObject);
		}
	}

	void GetNextWaypoint()
	{
		if (waveportIndex >= Wavepoints.points.Length - 1)
		{
			gameMaster.gameObject.GetComponent<MushroomSpawner> ().DecrementNumberOfEnemies ();
			gameMaster.gameObject.GetComponent<MushroomSpawner> ().DecrementNumberOfLifes ();
			Destroy (gameObject);
			return;
		}
		waveportIndex++;
		target = Wavepoints.points [waveportIndex];
	}
}
