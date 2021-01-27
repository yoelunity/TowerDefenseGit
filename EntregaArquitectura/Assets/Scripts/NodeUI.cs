using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

	public GameObject ui;

	public Text upgradeCost;
	public Button upgradeButton;

	public Text sellAmount;

	private Node target;

	public void SetTarget (Node _target)
	{
		target = _target;

		transform.position = target.GetBuildPosition();

		ui.SetActive(true);
	}

	public void Hide ()
	{
		ui.SetActive(false);
	}


}
