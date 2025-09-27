using UnityEngine;
using UnityEngine.UI;

public class NodeUIUpgrade : MonoBehaviour {

	public GameObject ui;
	public Button upgradeButton;

	public Text sellAmount;

	private Node target;

	public void SetTarget (Node _target)
	{
		target = _target;

		transform.position = target.GetBuildPosition();
		sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();
		ui.SetActive(true);
	}

	public void Hide ()
	{
		ui.SetActive(false);
	}

	public void Build(){
		
	}

	public void Sell ()
	{
		target.SellTurret();
		BuildManager.instance.DeselectNode();
		BuildManager.instance.DeselectNodeForUpgrade();
	}

}
