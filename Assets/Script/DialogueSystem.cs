using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    [SerializeField] private static int part = 0;
    [SerializeField] private static int index = 0;

    public string[] prologueLines;
    public string[] part1Lines;
    public string[] part2Lines;
    public string[] part3Lines;
    public string[] part4Lines;
    
    
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        getPart();
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        // nulis karakter satu demi satu
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            part++;
            index = 0;
            textComponent.text = string.Empty;
            StartDialogue();
        }
    }
    

    void getPart()
    {
        if (part == 0)
            lines = prologueLines;
        else if (part == 1)
            lines = part1Lines;
        else if (part == 2)
            lines = part2Lines;
        else if (part == 3)
            lines = part3Lines;
        else if (part == 4)
            lines = part4Lines;
    }
}
