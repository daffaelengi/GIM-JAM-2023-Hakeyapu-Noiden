using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject orderBox;
    public GameObject kitBox;
    public GameObject counter;
    
    public bool dialogueBoxEnter;
    public bool orderBoxEnter;
    public bool kitBoxEnter;
    public bool counterEnter;
    
    Vector3 dialogueBoxDelta;
    Vector3 orderBoxDelta;
    Vector3 kitBoxDelta;
    Vector3 counterDelta;
    
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
        if (orderBoxDelta.x < -860 && orderBoxEnter == true)
        {
            orderBox.GetComponent<RectTransform>().anchoredPosition = orderBoxDelta;
            orderBoxDelta.x += speed * Time.deltaTime;
        }

        // orderBoxExit
        if (orderBoxDelta.x > -1800 && orderBoxEnter == false)
        {
            orderBox.GetComponent<RectTransform>().anchoredPosition = orderBoxDelta;
            orderBoxDelta.x -= speed * Time.deltaTime;
        }

        // kitBoxEnter
        if (kitBoxDelta.x > 845f && kitBoxEnter == true)
        {
            kitBox.GetComponent<RectTransform>().anchoredPosition = kitBoxDelta;
            kitBoxDelta.x -= speed * Time.deltaTime;
        }

        // kitBoxExit
        if (kitBoxDelta.x < 1800f && kitBoxEnter == false)
        {
            kitBox.GetComponent<RectTransform>().anchoredPosition = kitBoxDelta;
            kitBoxDelta.x += speed * Time.deltaTime;
        }

        // counterEnter
        if (counterDelta.y < 0f && counterEnter == true)
        {
            counter.GetComponent<RectTransform>().anchoredPosition = counterDelta;
            counterDelta.y += speed * Time.deltaTime;
        }

        // counterExit
        if (counterDelta.y > -1440f && counterEnter == false)
        {
            counter.GetComponent<RectTransform>().anchoredPosition = counterDelta;
            counterDelta.y -= speed * Time.deltaTime;
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
        orderBoxDelta.x = orderBox.GetComponent<RectTransform>().anchoredPosition.x;
        // orderBox.GetComponent<RectTransform>().anchoredPosition = orderBoxDelta;
        orderBoxEnter = true;
    }

    public void OrderBoxExit()
    {
        orderBoxDelta.x = orderBox.GetComponent<RectTransform>().anchoredPosition.x;
        // orderBox.GetComponent<RectTransform>().anchoredPosition = orderBoxDelta;
        orderBoxEnter = false;
    }

    public void KitBoxEnter()
    {
        kitBoxDelta.x = kitBox.GetComponent<RectTransform>().anchoredPosition.x;
        // kitBox.GetComponent<RectTransform>().anchoredPosition = kitBoxDelta;
        kitBoxEnter = true;
    }

    public void KitBoxExit()
    {
        kitBoxDelta.x = kitBox.GetComponent<RectTransform>().anchoredPosition.x;
        // kitBox.GetComponent<RectTransform>().anchoredPosition = kitBoxDelta;
        kitBoxEnter = false;
    }

    public void CounterEnter()
    {
        counterDelta.y = counter.GetComponent<RectTransform>().anchoredPosition.y;
        // counterDelta.y = -989.2499f;
        // counter.GetComponent<RectTransform>().anchoredPosition = counterDelta;
        counterEnter = true;
    }

    public void CounterExit()
    {
        counterDelta.y = counter.GetComponent<RectTransform>().anchoredPosition.y;
        // counterDelta.y = -450f;
        // counter.GetComponent<RectTransform>().anchoredPosition = counterDelta;
        counterEnter = false;
    }
}
