using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !SettingsButton.isHovered)
            SceneManager.LoadScene("SampleScene");
    }

}

