using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager _GAMEMANAGER;

    private GameObject plantSelected;

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
            plantClickableScript = null;
        }
    }

    public void SelectPlant(GameObject plant)
    {
        if (plantSelected != null)
        {
            plantClickableScript = plantSelected.GetComponent<UserPlantClickable>();
            plantClickableScript.ResetPlant();
            ResetPlantSelected();
        }

        plantSelected = plant;
        Texture2D cursorTexture = plantSelected.transform.GetChild(1).GetComponent<Image>().sprite.texture;
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    public void ResetPlantSelected()
    {
        plantSelected = null;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
