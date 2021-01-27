using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;
//Para este codigo me apoye en un tutorial

//Aqui comprueba si ya existe un objeto de este tipo para el control de excepciones
	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}
	

	private TurretBlueprint turretToBuild;
	private Node selectedNode;

	public NodeUI nodeUI;
//Comprueba si se puede buildear una torre y si se tiene el dinero necesario
	public bool CanBuild { get { return turretToBuild != null; } }
	public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

	//Selecciona la baldosa en la que se ha hecho click
	public void SelectNode (Node node)
	{
		if (selectedNode == node)
		{
			DeselectNode();
			return;
		}

		selectedNode = node;
		turretToBuild = null;


	}
//La deselecciona la sacar el raton de la baldosa
	public void DeselectNode()
	{
		selectedNode = null;
	}
//Se modifica el valor cuando seleccionas la torre a construir, con este scripts puedes tener mas torres ya que es un scriptable object

	public void SelectTurretToBuild (TurretBlueprint turret)
	{
		turretToBuild = turret;
		DeselectNode();
	}

	public TurretBlueprint GetTurretToBuild ()
	{
		return turretToBuild;
	}

}
