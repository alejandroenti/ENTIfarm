using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GenerateUserPlants : MonoBehaviour
{
    [SerializeField] private GameObject userPlantPrefab;

    private List<Plant> userPlants = new List<Plant>();

    private void Start()
    {
        userPlants = Database._DATABASE.GetUserPlants();

        for (int i = 0; i < userPlants.Count; i++)
        {
            GameObject temp = Instantiate(userPlantPrefab, transform);
            temp.transform.SetParent(transform, false);

            temp.transform.GetChild(1).GetComponent<Image>().color = Color.blue;
            temp.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = userPlants[i].GetPlantName();
            temp.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = userPlants[i].GetStackQuantity().ToString();
        }
    }
}
