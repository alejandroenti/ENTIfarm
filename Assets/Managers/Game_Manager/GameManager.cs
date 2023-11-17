using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager _GAMEMANAGER;

    private GameObject plantSelected;
    private Sprite plantSprite;

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
            plantClickableScript = null;
        }
    }

    public Sprite GetPlantSprite() => plantSprite;

    public void SelectPlant(GameObject plant)
    {
        if (plantSelected != null)
        {
            plantClickableScript = plantSelected.GetComponent<UserPlantClickable>();
            plantClickableScript.ResetPlant();
            ResetPlantSelected();
        }

        plantSelected = plant;
        plantSprite = plantSelected.transform.GetChild(1).GetComponent<Image>().sprite;
        Texture2D cursorTexture = plantSprite.texture;
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    public void ResetPlantSelected()
    {
        plantSelected = null;
        plantSprite = null;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
