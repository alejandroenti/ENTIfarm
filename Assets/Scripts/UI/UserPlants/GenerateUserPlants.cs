using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GenerateUserPlants : MonoBehaviour
{
    [SerializeField] private GameObject userPlantPrefab;
    
    private List<Plant> userPlants = new List<Plant>();
    private Sprite sprite;

    //private void Start()
    //{
    //    UpdateList();
    //}

    public void UpdateList()
    {
        CleanCurrentList();

        userPlants = Database._DATABASE.GetUserPlants(GameManager._GAMEMANAGER.GetUsderID());

        for (int i = 0; i < userPlants.Count; i++)
        {
            GameObject temp = Instantiate(userPlantPrefab, transform);
            temp.transform.SetParent(transform, false);

            sprite = Resources.Load<Sprite>("Fruits/icons/32x32/" + userPlants[i].GetPlantID().ToString());

            temp.transform.GetChild(1).GetComponent<Image>().sprite = sprite;
            temp.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = userPlants[i].GetPlantName();

            //int plantQuantity = userPlants[i].GetStackQuantity() - GameManager._GAMEMANAGER.GetPlantInDictionary(userPlants[i]);
            //temp.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = plantQuantity.ToString();
            temp.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = userPlants[i].GetStackQuantity().ToString();

            temp.transform.name = "Plant_" + userPlants[i].GetPlantID().ToString("0000");
            temp.name = "Plant_" + userPlants[i].GetPlantID().ToString("0000");

            UserPlantClickable userPlantClickableScript = temp.GetComponent<UserPlantClickable>();
            userPlantClickableScript.SetPlantSelected(new Plant(userPlants[i].GetPlantID(), userPlants[i].GetPlantName(), userPlants[i].GetGrowTime(), userPlants[i].GetStackQuantity(), userPlants[i].GetSellPrice(), userPlants[i].GetBuyPrice()));
        }
    }

    private void CleanCurrentList()
    {
        if (transform.childCount == 0)
        {
            return;
        }

        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
