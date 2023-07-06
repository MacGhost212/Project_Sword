using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject currTurret;

    [HideInInspector]
    public TurretBuildPrint turretBlueprint;

    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance; 
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();


        Destroy(currTurret);
        turretBlueprint = null;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (currTurret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBuildPrint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build!");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject _Turret_ = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        currTurret = _Turret_;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 3f);

        Debug.Log("Turret built! Money Left: " + PlayerStats.Money);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade that!");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        Destroy(currTurret);//get rid of the old turret

        //Building a new one
        GameObject _Turret_ = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        currTurret = _Turret_;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 3f);

        isUpgraded = true;

        Debug.Log("Turret upgraded!");
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
