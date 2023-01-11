using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public MainMechanics mm;
    // public GameObject confirm;
    public Animator dialogueKitAnim;

    // Dialogue
    public TextMeshProUGUI textDialogue;
    public string[] lines;
    public int[] eventTriggerOnIndex;
    public float textSpeed;
    public int index;


    // Array for saving index on specific event
    public List<int> audioEventOnIndex;
    public List<int> spriteEventOnIndex;


    // Switch Kit
    public Image character;
    public float switchSpeed;
    float bgColor;
    public int switchEnabled; 
    public List<int> switchEventOnIndex;
    public List<int> switchList;

    // Name kit
    public TextMeshProUGUI characterName;
    public List<int> nameEventOnIndex;
    public List<string> nameList;


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

        // if (eventTriggerOnIndex.Contains(index))
        // {
            // print("A");
            TriggerEvent(index);
        // }


        // Dim Character
        if (switchEnabled == 0)
        {
            character.color = new Color32((byte)bgColor, (byte)bgColor, (byte)bgColor, 255);
            if (bgColor > 80)
            {
                bgColor -= switchSpeed * Time.deltaTime;
            }
            else
            {
                bgColor = 80;
            }
        }
        
        // Light Character
        if (switchEnabled == 1)
        {
            character.color = new Color32((byte)bgColor, (byte)bgColor, (byte)bgColor, 255);
            if (bgColor < 255)
            {
                bgColor += switchSpeed * Time.deltaTime;
            }
            else
            {
                bgColor = 255;
            }
        }

    }
    
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        if (index == 0)
            FindObjectOfType<AudioManager>().Play("bing");
        else if (index == 3)
            FindObjectOfType<AudioManager>().Play("dil_nanyae");
        else if (index == 5)
            FindObjectOfType<AudioManager>().Play("dil_cepmek");
        else if (index == 8)
            FindObjectOfType<AudioManager>().Play("dil_nt");
        else if (index == 13)
            FindObjectOfType<AudioManager>().Play("dil_nanyae");
        else if (index == 17)
            FindObjectOfType<AudioManager>().Play("dil_penjelasan");

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
            dialogueKitAnim.Play("dialogue_end");
            StartCoroutine(DisableDialogue(1));
        }
    }

    IEnumerator DisableDialogue(float time)
    {
        yield return new WaitForSeconds(time);

        mm.dialogueEnabled = false;
        gameObject.SetActive(false);
    }

    void TriggerEvent(int i)
    {
        if (audioEventOnIndex.Contains(i))
        {
            audioEventOnIndex.RemoveAt(0);
            // Play audio
        }
        if (nameEventOnIndex.Contains(i))
        {
            nameEventOnIndex.RemoveAt(0);
            NameEvent(nameList[0]);
            nameList.RemoveAt(0);
            // Change Name
        }
        if (switchEventOnIndex.Contains(i))
        {
            switchEventOnIndex.RemoveAt(0);
            SwitchEvent(switchList[0]);
            switchList.RemoveAt(0);
        }
        if (spriteEventOnIndex.Contains(i))
        {
            spriteEventOnIndex.RemoveAt(0);
            // Change character sprite
        }
    }
    
    void SwitchEvent(int i)
    {
        // print("A");
        if (i == 0)
        {
            switchEnabled = 0;
        }
        else
        {
            switchEnabled = 1;
        }
    }

    void NameEvent(string str)
    {
        characterName.text = str;
    }
}
