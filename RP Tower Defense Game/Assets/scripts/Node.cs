using UnityEngine;

public class Node : MonoBehaviour {

	public Color hoverColor;
	public Vector3 positionOffset;
	private GameObject turret;

	private Renderer nodeRenderer;
	private Color startColor;

	void Start () 
	{
		nodeRenderer = GetComponent<Renderer> ();
		startColor = nodeRenderer.material.color;
	}

	void OnMouseDown()
	{
		if (turret != null)
		{
			//TODO Space is occupied. Check for other things inside there 
			Debug.Log ("Can't build here!");
		}

		//Build the turret aka mushrooms
		GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
		turret = (GameObject)Instantiate (turretToBuild, transform.position + positionOffset, transform.rotation);
	}

	void OnMouseEnter()
	{
		nodeRenderer.material.color = hoverColor;
	}

	void OnMouseExit()
	{
		nodeRenderer.material.color = startColor;
	}
}
