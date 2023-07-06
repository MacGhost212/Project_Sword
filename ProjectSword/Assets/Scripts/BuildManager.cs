using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject tankTurretPrefab;

    public GameObject buildEffect;

    private TurretBuildPrint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;
         
    public bool CanBuild
    {
        get
        {
            return turretToBuild != null;
        }
    }

    public bool HasMoney
    {
        get
        {
            return PlayerStats.Money >= turretToBuild.cost;
        }
    }

    public void SelectNode (Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.hide();
    }

    public void SelectTurretToBuild(TurretBuildPrint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBuildPrint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
