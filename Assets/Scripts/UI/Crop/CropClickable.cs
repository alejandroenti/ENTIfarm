using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CropClickable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Image img;

    private void Awake()
    {
        img = gameObject.GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        img.color = Color.red;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        img.color = Color.white;
    }
}
