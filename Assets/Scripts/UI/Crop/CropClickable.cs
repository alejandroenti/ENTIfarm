using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CropClickable : MonoBehaviour, IPointerDownHandler
{
    private const int START_NUMBERS_NAME = 6;

    private GenerateCrops generateCropsScript;

    private void Awake()
    {
        generateCropsScript = GetComponentInParent<GenerateCrops>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (GameManager._GAMEMANAGER.GetPlantSprite() != null)
        {
            if (!this.gameObject.transform.GetChild(0).GetComponentInChildren<Image>().IsActive())
            {
                Image plantImage = this.gameObject.transform.GetChild(0).GetComponentInChildren<Image>();
                plantImage.enabled = true;
                plantImage.sprite = GameManager._GAMEMANAGER.GetPlantSprite();
            }
        }

        int id = int.Parse(transform.name.Substring(START_NUMBERS_NAME));
        int cropsRows = generateCropsScript.GetCropsRows();
        int row = (int)id / cropsRows;
        int col = id % cropsRows;

        Debug.Log("Clicked on position: X-> " +  row + ", Y-> " + col);
    }
}
