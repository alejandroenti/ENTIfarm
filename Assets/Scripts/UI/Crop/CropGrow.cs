using UnityEngine;
using UnityEngine.UI;

public class CropGrow : MonoBehaviour
{
    private Image plantImage;

    private void Awake()
    {
        plantImage = GetComponent<Image>();
    }


    public void Plant()
    {
        plantImage.enabled = true;
        plantImage.sprite = GameManager._GAMEMANAGER.GetPlantSprite();
    }
}
