using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    // void Update()
    // {
    //     if (Input.GetMouseButtonDown(0) && !SettingsButton.isHovered)
    //     {
    //         StartCoroutine(sc.TransitionToScene("Main"));
    //     }
    // }

    public IEnumerator TransitionToScene (string str)
    {
        transition.Play("animation_start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(str);
    }
}
