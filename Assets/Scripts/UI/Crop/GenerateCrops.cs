using UnityEngine;
using UnityEngine.UI;

public class GenerateCrops : MonoBehaviour
{
    [SerializeField] private GameObject cropPrefab;

    private int cropsRows;

    private GridLayoutGroup cropsLayoutGroup;

    private void Awake()
    {
        // Pedir cropsRow a la base de datos, de momento incializamos en 5
        cropsRows = 5;
        
        cropsLayoutGroup = GetComponent<GridLayoutGroup>();
        cropsLayoutGroup.constraintCount = cropsRows;
    }

    private void Start()
    {
        GenerateCropsLands();
    }

    public void SetCropsRows(int number)
    {
        cropsRows = number;
        cropsLayoutGroup.constraintCount = cropsRows;

        GenerateCropsLands();
    }

    private void GenerateCropsLands()
    {
        for (int i = 0; i < cropsRows; i++)
        {
            for (int j = 0; j < cropsRows; j++)
            {
                GameObject temp = Instantiate(cropPrefab, transform);
                temp.transform.parent = transform;
            }
        }
    }
}
