using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject orderBox;
    public GameObject kitBox;
    
    public bool dialogueBoxEnter;
    public bool orderBoxEnter;
    public bool kitBoxEnter;
    
    Vector3 dialogueBoxDelta;
    Vector3 orderBoxDelta;
    Vector3 kitBoxDelta;
    
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBoxDelta = dialogueBox.GetComponent<RectTransform>().anchoredPosition;
        orderBoxDelta = orderBox.GetComponent<RectTransform>().anchoredPosition;
        kitBoxDelta = kitBox.GetComponent<RectTransform>().anchoredPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // DialogueBoxEnter
        if (dialogueBoxDelta.y < -450f && dialogueBoxEnter == true)
        {
            dialogueBox.GetComponent<RectTransform>().anchoredPosition = dialogueBoxDelta;
            dialogueBoxDelta.y += speed * Time.deltaTime;
        }

        // DialogueBoxExit
        if (dialogueBoxDelta.y > -989.2499f && dialogueBoxEnter == false)
        {
            dialogueBox.GetComponent<RectTransform>().anchoredPosition = dialogueBoxDelta;
            dialogueBoxDelta.y -= speed * Time.deltaTime;
        }

        // orderBoxEnter
        if (orderBoxDelta.x < -1050.2f && orderBoxEnter == true)
        {
            orderBox.GetComponent<RectTransform>().anchoredPosition = orderBoxDelta;
            orderBoxDelta.x += speed * Time.deltaTime;
        }

        // orderBoxExit
        if (orderBoxDelta.x > -1609.8f && orderBoxEnter == false)
        {
            orderBox.GetComponent<RectTransform>().anchoredPosition = orderBoxDelta;
            orderBoxDelta.x -= speed * Time.deltaTime;
        }

        // kitBoxEnter
        if (kitBoxDelta.x > 1050.2f && kitBoxEnter == true)
        {
            kitBox.GetComponent<RectTransform>().anchoredPosition = kitBoxDelta;
            kitBoxDelta.x -= speed * Time.deltaTime;
        }

        // kitBoxExit
        if (kitBoxDelta.x < 1609.8f && kitBoxEnter == false)
        {
            kitBox.GetComponent<RectTransform>().anchoredPosition = kitBoxDelta;
            kitBoxDelta.x += speed * Time.deltaTime;
        }
    }

    // public void DialogueBox()
    // {
    //     if (dialogueBox.GetComponent<RectTransform>().anchoredPosition.y == -989.2499f)
    //     {
    //         dialogueBox.GetComponent<RectTransform>().anchoredPosition = dialogueBoxDelta;
    //         dialogueBoxEnter = true;
    //     }
    //     if (dialogueBox.GetComponent<RectTransform>().anchoredPosition.y == -450f)
    //     {
    //         dialogueBox.GetComponent<RectTransform>().anchoredPosition = dialogueBoxDelta;
    //         dialogueBoxEnter = false;
    //     }
    // }
    public void DialogueBoxEnter()
    {
        dialogueBoxDelta.y = dialogueBox.GetComponent<RectTransform>().anchoredPosition.y;
        // dialogueBoxDelta.y = -989.2499f;
        // dialogueBox.GetComponent<RectTransform>().anchoredPosition = dialogueBoxDelta;
        dialogueBoxEnter = true;
    }

    public void DialogueBoxExit()
    {
        dialogueBoxDelta.y = dialogueBox.GetComponent<RectTransform>().anchoredPosition.y;
        // dialogueBoxDelta.y = -450f;
        // dialogueBox.GetComponent<RectTransform>().anchoredPosition = dialogueBoxDelta;
        dialogueBoxEnter = false;
    }

    public void OrderBoxEnter()
    {
        orderBoxDelta.x = -1609.8f;
        orderBox.GetComponent<RectTransform>().anchoredPosition = orderBoxDelta;
        orderBoxEnter = true;
    }

    public void OrderBoxExit()
    {
        orderBoxDelta.x = -1050.2f;
        orderBox.GetComponent<RectTransform>().anchoredPosition = orderBoxDelta;
        orderBoxEnter = false;
    }

    public void KitBoxEnter()
    {
        kitBoxDelta.x = 1609.8f;
        kitBox.GetComponent<RectTransform>().anchoredPosition = kitBoxDelta;
        kitBoxEnter = true;
    }

    public void KitBoxExit()
    {
        kitBoxDelta.x = 1050.2f;
        kitBox.GetComponent<RectTransform>().anchoredPosition = kitBoxDelta;
        kitBoxEnter = false;
    }
}
