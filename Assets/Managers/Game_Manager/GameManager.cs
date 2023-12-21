using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager _GAMEMANAGER;

    [Header("Generate User Plants Reference")]
    [SerializeField] private GenerateUserPlants generateUserPlantsScript;

    private GameObject plantSelected;
    private Sprite plantSprite;
    private float plantGrowTime;

    private float currency;

    private GameObject plant;

    private UserPlantClickable plantClickableScript;
    private UpdateCurrency updateCurrencyScript;

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

            currency = 100f;
        }
    }

    private void Start()
    {
        updateCurrencyScript = GameObject.Find("CurrencyText").GetComponent<UpdateCurrency>();
        updateCurrencyScript.UpdateCurrencyText(currency);
    }

    public GameObject GetPlantSelected() => plantSelected;
    public Sprite GetPlantSprite() => plantSprite;
    public float GetPlantGrowTime() => plantGrowTime;

    public float GetCurrency() => currency;
    public void AddCurrency(float amount)
    {
        currency += amount;
        updateCurrencyScript.UpdateCurrencyText(currency);
    }
    public void SubstractCurrency(float amount)
    {
        currency -= amount;
        updateCurrencyScript.UpdateCurrencyText(currency);
    }

    public void SubstractPlantQuantity(GameObject plant)
    {
        UpdateQuantity updateQuantityScript = plant.transform.GetChild(3).GetComponent<UpdateQuantity>();
        updateQuantityScript.SubstractQuantity();
    }
    public void AddPlantQuantity(GameObject plant) 
    {
        UpdateQuantity updateQuantityScript = plant.transform.GetChild(3).GetComponent<UpdateQuantity>();
        updateQuantityScript.AddQuantity();
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
        plantGrowTime = plant.GetComponent<UserPlantClickable>().GetPlantSelected().GetGrowTime();
        plantSprite = plantSelected.transform.GetChild(1).GetComponent<Image>().sprite;
        Texture2D cursorTexture = plantSprite.texture;
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    public void ResetPlantSelected()
    {
        plantSelected = null;
        plantSprite = null;
        plantGrowTime = -1f;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void UpdateUserPlantsList()
    {
        generateUserPlantsScript.UpdateList();
    }
}
