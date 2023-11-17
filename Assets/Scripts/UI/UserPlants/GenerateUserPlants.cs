using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GenerateUserPlants : MonoBehaviour
{
    [SerializeField] private GameObject userPlantPrefab;
    [SerializeField] private Sprite sprite;

    private List<Plant> userPlants = new List<Plant>();

    private void Start()
    {
        UpdateList();
    }

    public void UpdateList()
    {
        userPlants = Database._DATABASE.GetUserPlants();

        for (int i = 0; i < userPlants.Count; i++)
        {
            GameObject temp = Instantiate(userPlantPrefab, transform);
            temp.transform.SetParent(transform, false);

            sprite = Resources.Load<Sprite>("Fruits/icons/32x32/" + userPlants[i].GetPlantID().ToString());
            Debug.Log(sprite);

            temp.transform.GetChild(1).GetComponent<Image>().sprite = sprite;
            temp.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = userPlants[i].GetPlantName();
            temp.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = userPlants[i].GetStackQuantity().ToString();

            temp.transform.name = "Plant_" + userPlants[i].GetPlantID().ToString("0000");
            temp.name = "Plant_" + userPlants[i].GetPlantID().ToString("0000");
        }
    }
}
