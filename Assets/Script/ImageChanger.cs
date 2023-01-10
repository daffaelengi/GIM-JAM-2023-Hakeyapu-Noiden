using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public Image background;
    public Image cupOrder;
    public Image icecreamOrder;
    public Image toppingOrder;
    public Image syrupOrder;
    public Sprite[] backgroundSprite;
    public Sprite[] cupOrderSprite;
    public Sprite[] icecreamOrderSprite;
    public Sprite[] toppingOrderSprite;
    public Sprite[] syrupOrderSprite;
    public float backgroundDelay;
    public float timer;
    public bool timerEnabled = false;
    int bgIndex;
    // Start is called before the first frame update
    void Start()
    {
        bgIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerEnabled == true && timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timerEnabled == true && bgIndex == 0)
        {
            bgIndex = 1;
            timerEnabled = false;
            timer = 0;
            background.sprite = backgroundSprite[bgIndex];
        }
        else if (timerEnabled == true && bgIndex == 1)
        {
            bgIndex = 0;
            timerEnabled = false;
            timer = 0;
            background.sprite = backgroundSprite[bgIndex];
        }
    }

    public void ChangeBackground()
    {
        timer = backgroundDelay;
        timerEnabled =  true;
    }

    public void ChangeCupOrder(int index)
    {
        print(index);
        cupOrder.sprite = cupOrderSprite[index];
    }

    public void ChangeIceCreamOrder(int index)
    {
        print(index);
        icecreamOrder.sprite = icecreamOrderSprite[index];
    }

    public void ChangeToppingOrder(int index)
    {
        print(index);
        toppingOrder.sprite = toppingOrderSprite[index];
    }

    public void ChangeSyrupOrder(int index)
    {
        print(index);
        syrupOrder.sprite = syrupOrderSprite[index];
    }
}
