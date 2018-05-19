using UnityEngine;

public class ShopScript : MonoBehaviour {

	BuildManager buildManager;
	public GameObject firstTurretType;
	public GameObject secondTurretType;

	public void PurchaseType1Turret()
	{
		buildManager.SetTurretToBuild (firstTurretType);
	}

	public void PurchaseType2Turret()
	{
		buildManager.SetTurretToBuild (secondTurretType);
	}

	void Start()
	{
		buildManager = BuildManager.instance;
	}
}
