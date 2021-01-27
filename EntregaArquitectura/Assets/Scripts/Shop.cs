using UnityEngine;

public class Shop : MonoBehaviour {

	public TurretBlueprint standardTurret;


	BuildManager buildManager;

	void Start ()
	{
		buildManager = BuildManager.instance;
	}

	public void SelectStandardTurret ()
	{
		Debug.Log("Standard Turret Selected");
		buildManager.SelectTurretToBuild(standardTurret);
	}


}
