using UnityEngine;

public class Crop_Controller : MonoBehaviour
{
    private CropGrow.GrowStates cropState;
    private bool hasPlant;
    private bool isPlantGrown;
    private Color outlineColor;

    private Plant currentPlant;

    private CropClickable cropClickableScript;
    private CropGrow cropGrowScript;
    private PlantImageGrown plantImageGrownScript;

    private void Awake()
    {
        cropClickableScript = GetComponent<CropClickable>();
        cropGrowScript = GetComponentInChildren<CropGrow>();
        plantImageGrownScript = GetComponentInChildren<PlantImageGrown>();
    }

    public void SetPlant(Plant newPlant) => currentPlant = newPlant;

    public CropGrow.GrowStates GetCropState() => cropState;
    public void SetCropState(CropGrow.GrowStates state) => cropState = state;
    public bool GetHasPlant() => hasPlant;
    public void SetHasPlant(bool planted) => hasPlant = planted;
    public bool GetIsPlantGrown() => isPlantGrown;
    public void SetIsPlantGrown(bool grown)
    {
        isPlantGrown = grown;
        plantImageGrownScript.SetIsAnimated(isPlantGrown);
    }
    public Color GetOutlineColor() => outlineColor;
    public void SetOutlineColor(Color newColor)
    {
        outlineColor = newColor;
        cropClickableScript.SetColorTargetOutline(outlineColor);
    }

    public void Plant()
    {
        currentPlant = GameManager._GAMEMANAGER.GetPlantSelected().GetComponent<UserPlantClickable>().GetPlantSelected();
        transform.GetChild(0).gameObject.SetActive(true);
        //GameManager._GAMEMANAGER.AddPlantInDictionary(currentPlant.GetPlantID());
        cropGrowScript.Plant();
    }

    public void Collect()
    {
        //GameManager._GAMEMANAGER.SubstractPlantInDictionary(currentPlant.GetPlantID());
        currentPlant = null;
        cropGrowScript.Collect();
    }
}
