using UnityEngine;
using UnityEngine.UI;

public class OpenShop : MonoBehaviour
{
    private Button shopButton;

    private void Awake()
    {
        shopButton = GetComponent<Button>();

        shopButton.onClick.AddListener(SpawnShopMenu);
    }

    private void SpawnShopMenu()
    {
        Debug.Log("Button pressed!");
    }
}
