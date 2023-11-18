using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CropClickable : MonoBehaviour, IPointerDownHandler
{
    //private const int START_NUMBERS_NAME = 6;

    [Header("Outline Color transition")]
    [SerializeField, Range(0, 0.75f)] private float trasitionColorSpeed;

    private Outline outlineComponent;
    private Color currentOutlineColor;
    private Color targetOutlineColor;

    private float timeToTranisition;
    private float timeToTranisitionTimer;

    //private GenerateCrops generateCropsScript;
    private Crop_Controller crop_controller;

    private void Awake()
    {
        outlineComponent = GetComponent<Outline>();
        //generateCropsScript = GetComponentInParent<GenerateCrops>();
        crop_controller = GetComponent<Crop_Controller>();

        currentOutlineColor = outlineComponent.effectColor;
        targetOutlineColor = currentOutlineColor;
    }

    private void Update()
    {
        ChangeColorOutline();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)) return;

        if (GameManager._GAMEMANAGER.GetPlantSprite() != null)
        {
            if (crop_controller.GetHasPlant())
            {
                outlineComponent.enabled = true;
                crop_controller.Plant();
            }
        }

        //int id = int.Parse(transform.name.Substring(START_NUMBERS_NAME));
        //int cropsRows = generateCropsScript.GetCropsRows();
        //int row = (int)id / cropsRows;
        //int col = id % cropsRows;

        //Debug.Log("Clicked on position: X-> " +  row + ", Y-> " + col);*/
    }

    public void RemoveCropOutline()
    {
        outlineComponent.enabled = false;
    }

    public void SetColorTargetOutline(Color newColor) => targetOutlineColor = newColor;

    private void ChangeColorOutline()
    {
        outlineComponent.effectColor = Color.Lerp(currentOutlineColor, targetOutlineColor, trasitionColorSpeed * Time.deltaTime);
        currentOutlineColor = outlineComponent.effectColor;
    }
}
