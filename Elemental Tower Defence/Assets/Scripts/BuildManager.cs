using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}

	public GameObject buildEffect;
	public GameObject sellEffect;

	private TurretBlueprint turretToBuild;
	private Node selectedNode;

	public NodeUIBuild nodeUIBuild;
	public NodeUIBuild nodeUISpecial;
	public NodeUIUpgrade nodeUIUpgrade;

	[Header("For Inspector")]
	public Button fireTurretButton;
	public Button waterTurretButton;
	public Button earthTurretButton;	
	public Button windTurretButton;
	public Button metalTurretButton;
	public Button lightningTurretButton;
	public Button woodTurretButton;
	public Button iceTurretButton;

	public void SelectNode (Node node)
	{
		if (selectedNode != null)
		{
			DeselectAllNodes();
			return;
		}
		selectedNode = node;
		nodeUIBuild.SetTarget(node);
	}
	// Todo: DRY - Combine it with SelectNode() for cleaner code!
	public void SelectNodeForUpgrade(Node node)
	{
		if (selectedNode != null)
		{
			DeselectAllNodes();
			Debug.Log("Node deselected");
			return;
		}
		selectedNode = node;
		Debug.Log("Node selected");
		nodeUIUpgrade.SetTarget(node);
	}

	public void DeselectNode()
	{
		selectedNode = null;
		nodeUIBuild.Hide();
	}

	public void DeselectNodeForUpgrade()
	{
		selectedNode = null;
		nodeUIUpgrade.Hide();
	}

	public void DeselectNodeSpecialElements()
	{
		selectedNode = null;
		nodeUISpecial.Hide();
	}

	public void DeselectAllNodes() {
		DeselectNode();
		DeselectNodeForUpgrade();
		DeselectNodeSpecialElements();
	}

	public void SelectTurretToBuild (TurretBlueprint turret){
		turretToBuild = turret;
		// If the turret is an upgrade, call UpgradeTurret() to ensure that the current turret is destroyed, and mark the node as upgraded
		if (CheckForUpgradedTurret(turret)) selectedNode.UpgradeTurret(turretToBuild);
		else selectedNode.BuildTurret(turretToBuild);
		DeselectAllNodes();
	}

	public bool CheckForUpgradedTurret(TurretBlueprint turret) {
		if (turret.prefab.name == "MetalTurret" ||
			turret.prefab.name == "LightningTurret" ||
			turret.prefab.name == "WoodTurret" ||
			turret.prefab.name == "IceTurret") {
			return true;
		}
		else return false;
	}

	public TurretBlueprint GetTurretToBuild(){
		return turretToBuild;
	}

	public void UpgradeTurretSelection() {
		nodeUIUpgrade.Hide();
		nodeUISpecial.SetTarget(selectedNode);
	}

	public void UnlockFireButton() {
		fireTurretButton.interactable = true;
	}
	public void UnlockWaterButton()
	{
		waterTurretButton.interactable = true;
	}
	public void UnlockEarthButton()
	{
		earthTurretButton.interactable = true;
	}
	public void UnlockWindButton()
	{
		windTurretButton.interactable = true;
	}

	public void UnlockMetalButton()
	{
		metalTurretButton.interactable = true;
	}
	public void UnlockLightningButton()
	{
		lightningTurretButton.interactable = true;
	}
	public void UnlockWoodButton()
	{
		woodTurretButton.interactable = true;
	}
	public void UnlockIceButton()
	{
		iceTurretButton.interactable = true;
	}

}
