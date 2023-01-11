using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !SettingsButton.isHovered)
        {
            FindObjectOfType<AudioManager>().Play("but1");
            StartCoroutine(TransitionToScene("MainMenu"));
        }
    }

    IEnumerator TransitionToScene (string str)
    {
        transition.Play("animation_start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(str);
    }

}

