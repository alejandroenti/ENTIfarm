using UnityEngine;

public class Crop_Controller : MonoBehaviour
{
    private CropGrow.GrowStates cropState;
    private bool hasPlant;
    private bool isPlantGrown;
    private Color outlineColor;

    private CropClickable cropClickableScript;
    private CropGrow cropGrowScript;

    private void Awake()
    {
        cropClickableScript = GetComponent<CropClickable>();
        cropGrowScript = GetComponentInChildren<CropGrow>();
    }

    public CropGrow.GrowStates GetCropState() => cropState;
    public void SetCropState(CropGrow.GrowStates state) => cropState = state;
    public bool GetHasPlant() => hasPlant;
    public void SetHasPlant(bool planted) => hasPlant = planted;
    public bool GetIsPlantGrown() => isPlantGrown;
    public void SetIsPlantGrown(bool grown) => hasPlant = grown;
    public Color GetOutlineColor() => outlineColor;
    public void SetOutlineColor(Color newColor)
    {
        outlineColor = newColor;
        cropClickableScript.SetColorTargetOutline(outlineColor);
    }

    public void Plant()
    {
        cropGrowScript.Plant();
    }
}
