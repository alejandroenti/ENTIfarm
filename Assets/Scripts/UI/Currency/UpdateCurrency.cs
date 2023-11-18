using TMPro;
using UnityEngine;

public class UpdateCurrency : MonoBehaviour
{
    private TextMeshProUGUI textCurrencyComponent;

    private void Awake()
    {
        textCurrencyComponent = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCurrencyText(float amount)
    {
        textCurrencyComponent.text = amount.ToString() + " $";
    }
}
