using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CropClickable : MonoBehaviour, IPointerDownHandler
{
    private const int START_NUMBERS_NAME = 6;

    private GenerateCrops generateCropsScript;
    private CropGrow cropGrowScript;

    private void Awake()
    {
        generateCropsScript = GetComponentInParent<GenerateCrops>();
        cropGrowScript = this.transform.GetChild(0).GetComponent<CropGrow>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)) return;

        if (GameManager._GAMEMANAGER.GetPlantSprite() != null)
        {
            if (!this.gameObject.transform.GetChild(0).GetComponentInChildren<Image>().IsActive())
            {
                cropGrowScript.Plant();
            }
        }

        int id = int.Parse(transform.name.Substring(START_NUMBERS_NAME));
        int cropsRows = generateCropsScript.GetCropsRows();
        int row = (int)id / cropsRows;
        int col = id % cropsRows;

        Debug.Log("Clicked on position: X-> " +  row + ", Y-> " + col);
    }
}
