using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBuildPrint standardTurret;
    public TurretBuildPrint tankTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard turret selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectTankTurret()
    {
        Debug.Log("Tank turret selected");
        buildManager.SelectTurretToBuild(tankTurret);
    }
}
