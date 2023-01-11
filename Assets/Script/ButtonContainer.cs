using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonContainer : MonoBehaviour
{
    public List<ButtonTab> tabButtons;
    public List<GameObject> pages;

    public void Subscribe(ButtonTab button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<ButtonTab>();
        }
        tabButtons.Add(button);
    }

    public void OnTabSelected(ButtonTab button)
    {
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < pages.Count; i++)
        {
            if (i == index)
            {
                pages[i].SetActive(true);
            }
            else
            {
                pages[i].SetActive(false);
            }
        }
        FindObjectOfType<AudioManager>().Play("but2");
    }

}
