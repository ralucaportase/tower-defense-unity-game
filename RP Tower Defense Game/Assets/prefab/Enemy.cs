using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed = 10f;

	private Transform target;
	private int waveportIndex = 0;

	void Start () {
		target = Wavepoints.points[0];
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = target.position - transform.position;
		transform.Translate (dir.normalized * speed * Time.deltaTime, Space.World);
	
		if (Vector3.Distance (transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint ();
		}
	}

	void GetNextWaypoint()
	{
		if (waveportIndex >= Wavepoints.points.Length - 1)
		{
			Destroy (gameObject);
			return;
		}
		waveportIndex++;
		target = Wavepoints.points [waveportIndex];
	}
}
