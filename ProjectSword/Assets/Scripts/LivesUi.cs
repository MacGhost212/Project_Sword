using UnityEngine.UI;
using UnityEngine;

public class LivesUi : MonoBehaviour
{
    public Text livesText;

    // Update is called once per frame
    void Update()
    {
        livesText.text = PlayerStats.Lives.ToString() + " :Lives";
    }
}
