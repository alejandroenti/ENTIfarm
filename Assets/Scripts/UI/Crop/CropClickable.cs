using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CropClickable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Image img;

    private void Awake()
    {
        img = gameObject.GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        img.rectTransform.eulerAngles = Vector2.up;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        img.color = Color.white;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        img.color = Color.red;
    }
}
