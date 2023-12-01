using UnityEngine;
using UnityEngine.UI;

public class BuyPlant : MonoBehaviour
{
    private int plantID;

    private Button buyButton;

    private void Awake()
    {

    }

    public void Buy()
    {
        Database._DATABASE.BuyPlant(1);
    }
}
