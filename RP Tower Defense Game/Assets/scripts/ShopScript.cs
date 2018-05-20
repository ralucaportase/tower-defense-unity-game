using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour {

	BuildManager buildManager;
	public GameObject firstTurretType;
	public GameObject secondTurretType;
	public int avaliableAmount = 1000;
	public int type1TurretPrice = 200;
	public int type2TurretPrice = 150;
	public Text availableAmountText;

	public void PurchaseType1Turret()
	{
		if (avaliableAmount < type1TurretPrice) 
		{
			buildManager.SetTurretToBuild (null);
			return;
		}
		avaliableAmount -= type1TurretPrice;
		buildManager.SetTurretToBuild (firstTurretType);
		availableAmountText.text = avaliableAmount + "$";
	}

	public void PurchaseType2Turret()
	{
		if (avaliableAmount < type2TurretPrice) 
		{
			buildManager.SetTurretToBuild (null);
			return;
		}
		avaliableAmount -= type2TurretPrice;
		buildManager.SetTurretToBuild (secondTurretType);
		availableAmountText.text = avaliableAmount + "$";
	}

	void Start()
	{
		buildManager = BuildManager.instance;
	}
}
