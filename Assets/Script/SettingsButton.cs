using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private static string previousScene;  // static biar gak berubah saat pindah scene
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
        FindObjectOfType<AudioManager>().Play("but2");
        // Check the current scene
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            previousScene = SceneManager.GetActiveScene().name;  // mengambil scene saat ini sebelum pindah
            SceneManager.LoadScene(sceneName);
        }

        else
            // jika udah di menu pengaturan terus mencet lagi, balik ke scene sebelumnya
            SceneManager.LoadScene(previousScene);
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
