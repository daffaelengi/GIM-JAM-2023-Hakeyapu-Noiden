using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool isHovered = false;

    [SerializeField] private Button button;

    private string sceneName = "SettingsMenu";

    void Start()
    {
        // Add an OnClick event listener to the button
        button.onClick.AddListener(OnButtonClick);
       
    }

    void OnButtonClick()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }

    public void OnPointerEnter(PointerEventData _eventData)
    {
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData _eventData)
    {
        isHovered = false;
    }
}
