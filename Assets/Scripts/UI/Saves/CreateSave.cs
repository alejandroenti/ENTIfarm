using TMPro;
using UnityEngine;

public class CreateSave : MonoBehaviour
{
    [Header("Username Text Component")]
    [SerializeField] private TMP_InputField textComponent;

    public void CreateSaveButton()
    {
        if (textComponent.text != "")
        {
            GameManager._GAMEMANAGER.CreateSave(textComponent.text);
        }
    }
}
