using UnityEngine;

public class Shop : MonoBehaviour {

	public TurretBlueprint standardTurret;
	public TurretBlueprint missileLauncher;
	public TurretBlueprint laserBeamer;

	public static int elementUnlockCost = 1000;

	public TurretBlueprint fireTurret;
	public TurretBlueprint waterTurret;
	public TurretBlueprint earthTurret;
	public TurretBlueprint windTurret;

	public TurretBlueprint metalTurret;
	public TurretBlueprint lightningTurret;
	public TurretBlueprint woodTurret;
	public TurretBlueprint iceTurret;

	BuildManager buildManager;

	void Start(){
		buildManager = BuildManager.instance;
	}

	public void SelectStandardTurret (){
		buildManager.SelectTurretToBuild(standardTurret);
	}

	public void SelectMissileLauncher(){
		buildManager.SelectTurretToBuild(missileLauncher);
	}

	public void SelectLaserBeamer(){
		buildManager.SelectTurretToBuild(laserBeamer);
	}

	public void SelectFireTurret (){
		buildManager.SelectTurretToBuild(fireTurret);
	}

	public void SelectWaterTurret(){
		buildManager.SelectTurretToBuild(waterTurret);
	}

	public void SelectEarthTurret(){
		buildManager.SelectTurretToBuild(earthTurret);
	}

	public void SelectWindTurret (){
		buildManager.SelectTurretToBuild(windTurret);
	}

	public void SelectMetalTurret()
	{
		buildManager.SelectTurretToBuild(metalTurret);
	}

	public void SelectLightningTurret()
	{
		buildManager.SelectTurretToBuild(lightningTurret);
	}

	public void SelectWoodTurret()
	{
		buildManager.SelectTurretToBuild(woodTurret);
	}

	public void SelectIceTurret()
	{
		buildManager.SelectTurretToBuild(iceTurret);
	}

	public void UnlockFireElement(){
		PlayerStats.fireUnlocked = true;
		PlayerStats.Money -= elementUnlockCost;
		buildManager.UnlockFireButton();
		GameManager.instance.elementsUnlockedUI.transform.GetChild (0).gameObject.SetActive (true);
		CheckForUnlockedSpecialElement();
	}

	public void UnlockWaterElement(){
		PlayerStats.waterUnlocked = true;
		PlayerStats.Money -= elementUnlockCost;
		buildManager.UnlockWaterButton();
		GameManager.instance.elementsUnlockedUI.transform.GetChild (1).gameObject.SetActive (true);
		CheckForUnlockedSpecialElement();
	}

	public void UnlockEarthElement(){
		PlayerStats.earthUnlocked = true;
		PlayerStats.Money -= elementUnlockCost;
		buildManager.UnlockEarthButton();
		GameManager.instance.elementsUnlockedUI.transform.GetChild (2).gameObject.SetActive (true);
		CheckForUnlockedSpecialElement();
	}

	public void UnlockWindElement(){
		PlayerStats.windUnlocked = true;
		PlayerStats.Money -= elementUnlockCost;
		buildManager.UnlockWindButton();
		GameManager.instance.elementsUnlockedUI.transform.GetChild (3).gameObject.SetActive (true);
		CheckForUnlockedSpecialElement();
	}

	public void CheckForUnlockedSpecialElement() {
		if (PlayerStats.fireUnlocked && PlayerStats.earthUnlocked) { 
			PlayerStats.metalUnlocked = true;
			buildManager.UnlockMetalButton();
			buildManager.nodeUIUpgrade.upgradeButton.interactable = true;
		}

		if (PlayerStats.fireUnlocked && PlayerStats.windUnlocked) {
			PlayerStats.lightningUnlocked = true;
			buildManager.UnlockLightningButton();
			buildManager.nodeUIUpgrade.upgradeButton.interactable = true;
		}
		
		if (PlayerStats.waterUnlocked && PlayerStats.earthUnlocked) {
			PlayerStats.woodUnlocked = true;
			buildManager.UnlockWoodButton();
			buildManager.nodeUIUpgrade.upgradeButton.interactable = true;
		}
		
		if (PlayerStats.waterUnlocked && PlayerStats.windUnlocked) {
			PlayerStats.iceUnlocked = true;
			buildManager.UnlockIceButton();
			buildManager.nodeUIUpgrade.upgradeButton.interactable = true;
		}	
	}

}
