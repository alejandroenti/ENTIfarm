using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager _GAMEMANAGER;

    [Header("Generate User Plants Reference")]
    [SerializeField] private GenerateUserPlants generateUserPlantsScript;

    [Header("Crops Object")]
    [SerializeField] private GameObject cropsObject;
    
    [Header("User Plants Object")]
    [SerializeField] private GameObject userPlantsObject;

    [Header("Save Selector Menu Object")]
    [SerializeField] private GameObject saveMenuObject;

    private GameObject plantSelected;
    private Sprite plantSprite;
    private float plantGrowTime;

    private float gameTime = 0f;
    private int userID = 1;
    private int saveID = 1;
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

            currency = 0f;
        }
    }

    private void Start()
    {
        updateCurrencyScript = GameObject.Find("CurrencyText").GetComponent<UpdateCurrency>();
        updateCurrencyScript.UpdateCurrencyText(currency);
    }

    private void Update()
    {
        gameTime += Time.deltaTime;
    }

    public void SetGameTime(float time) => gameTime = time;
    public int GetUsderID() => userID;
    public void SetUserID(int newUserID) => userID = newUserID;
    public int GetSaveID() => saveID;
    public void SetSaveID(int newSaveID) => saveID = newSaveID;
    public GameObject GetPlantSelected() => plantSelected;
    public Sprite GetPlantSprite() => plantSprite;
    public float GetPlantGrowTime() => plantGrowTime;

    public float GetCurrency() => currency;
    public void SetCurrency(float money)
    {
        currency = money;
        updateCurrencyScript.UpdateCurrencyText(currency);
    }
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

    public void OpenSaveSelector()
    {
        saveMenuObject.SetActive(true);
        SaveGame();
    }
    public void CloseSaveSelector() => saveMenuObject.SetActive(false);

    public void SaveGame()
    {
        Database._DATABASE.SaveGame(gameTime, currency, cropsObject);
    }

    public void LoadSave()
    {
        List<CellsSave> cells = Database._DATABASE.LoadGame(saveID);

        Debug.Log(cells.Count);

        for (int j = 0; j < userPlantsObject.transform.childCount; j++)
        {
            UpdateQuantity updateQuantityScript = userPlantsObject.transform.GetChild(j).GetChild(3).GetComponent<UpdateQuantity>();
            updateQuantityScript.RestartQuantity();
        }

        for (int i = 0; i < cells.Count; i++)
        {
            Debug.Log("Loading " + (int)i / 5 + ", " + (int)i % 5 + " - Plant ID: " + cells[i].GetPlantID());
            if (cells[i].GetPlantID() != 1)
            {
                for (int j = 0; j < userPlantsObject.transform.childCount; j++)
                {
                    if (userPlantsObject.transform.GetChild(j).GetComponent<UserPlantClickable>().GetPlantSelected().GetPlantID() == cells[i].GetPlantID())
                    {
                        SelectPlant(userPlantsObject.transform.GetChild(j).gameObject);
                        cropsObject.transform.GetChild(i).GetChild(0).GetComponent<CropGrow>().SetCurrentPlantObject(userPlantsObject.transform.GetChild(j).gameObject);
                        cropsObject.transform.GetChild(i).GetChild(0).GetComponent<CropGrow>().LoadPlant(cells[i].GetTime());
                        cropsObject.transform.GetChild(i).GetComponent<Outline>().enabled = true;
                        ResetPlantSelected();
                        break;
                    }
                }
            }
        }

        CloseSaveSelector();
    }
}
