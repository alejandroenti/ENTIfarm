using UnityEngine;

public class BuyPlant : MonoBehaviour
{
    private int plantID;

    public void Buy()
    {
        Database._DATABASE.BuyPlant(GetComponentInParent<Plant_Controller>().GetPlant().GetPlantID());
    }
}
