using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject UI;

    public Text upgradeCost;
    public Button upgradeButton;

    private Node target;

    public Text sellAmount;

    public void SetTarget(Node _target_)
    {
        this.target = _target_;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Done";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();

        UI.SetActive(true);
    }

    public void hide()
    {
        UI.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
