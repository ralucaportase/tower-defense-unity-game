using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	[Header("Attributes")]

	public float range = 10f;
	public float fireRate = 1f;

	private float fireCountdown = 0f;

	[Header("Unity Setup Fields")]
	public string enemyTag = "Enemy";

	public Transform target;

	public GameObject bulletPrefab;
	public Transform firePoint;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
	}

	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

		foreach (GameObject enemy in enemies) 
		{
			float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance) {
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (shortestDistance <= range && nearestEnemy != null) 
		{
			target = nearestEnemy.transform;
		} else 
		{
			target = null;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null) {
			return;
		}

		if (fireCountdown <= 0f)
		{
			Shoot ();
			fireCountdown = 1f / fireRate;
		}

		fireCountdown -= Time.deltaTime;

	}

	void Shoot()
	{
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet>();

		if (bullet != null) {
			bullet.Seek (target);
		}
	}

	//On click the range is showned
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere (transform.position, range);
	}
}
