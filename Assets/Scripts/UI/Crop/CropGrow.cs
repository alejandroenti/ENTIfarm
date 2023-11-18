using UnityEngine;
using UnityEngine.UI;

public class CropGrow : MonoBehaviour
{
    private enum GrowStates { SEED, GROW, PLANT }

    private bool hasPlant = false;

    private float cropGrowTime;
    private float cropGrowTimeState;

    private GrowStates currentState;

    private Image plantImage;

    private void Awake()
    {
        plantImage = GetComponent<Image>();
        
        currentState = GrowStates.SEED;
    }


    public void Plant()
    {
        hasPlant = true;

        plantImage.enabled = true;
        plantImage.sprite = GameManager._GAMEMANAGER.GetPlantSprite();

        cropGrowTime = GameManager._GAMEMANAGER.GetPlantGrowTime();
        cropGrowTimeState = cropGrowTime / 3f;

        Debug.Log(cropGrowTime + " - " + cropGrowTimeState + ": " + currentState);
    }
}
