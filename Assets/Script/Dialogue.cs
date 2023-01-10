using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    // public GameObject confirm;
    public TextMeshProUGUI textDialogue;
    public string[] lines;
    public float textSpeed;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        textDialogue.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textDialogue.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textDialogue.text = lines[index]; 
            }
            // confirm.SetActive(false);
        }

    }
    
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textDialogue.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        // confirm.SetActive(true);
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textDialogue.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
