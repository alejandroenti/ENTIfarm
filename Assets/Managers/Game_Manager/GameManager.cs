using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager _GAMEMANAGER;

    private GameObject plantSelected;
    private Sprite plantSprite;
    private float plantGrowTime;

    private UserPlantClickable plantClickableScript;

    private void Awake()
    {
        if (_GAMEMANAGER != null && _GAMEMANAGER != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _GAMEMANAGER = this;

            plantSelected = null;
            plantSprite = null;
            plantGrowTime = -1f;
            plantClickableScript = null;
        }
    }

    public Sprite GetPlantSprite() => plantSprite;
    public float GetPlantGrowTime() => plantGrowTime;

    public void SelectPlant(GameObject plant)
    {
        if (plantSelected != null)
        {
            plantClickableScript = plantSelected.GetComponent<UserPlantClickable>();
            plantClickableScript.ResetPlant();
            ResetPlantSelected();
        }

        plantSelected = plant;
        plantGrowTime = plant.GetComponent<UserPlantClickable>().GetPlantSelected().GetGrowTime();
        plantSprite = plantSelected.transform.GetChild(1).GetComponent<Image>().sprite;
        Texture2D cursorTexture = plantSprite.texture;
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    public void ResetPlantSelected()
    {
        plantSelected = null;
        plantSprite = null;
        plantGrowTime = -1;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
