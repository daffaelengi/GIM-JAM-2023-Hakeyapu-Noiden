using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public Animator customerGroup;
    public Animator cupMask;
    public Animator icecreamMask;
    public Animator toppingMask;
    public Animator syrupMask;
    public Button acceptOrder;
    public Button rejectOrder;
    public Image background;
    public Image cupOrder;
    public Image icecreamOrder;
    public Image toppingOrder;
    public Image syrupOrder;
    public Image customer;
    public Image cup;
    public Image icecream;
    public Image topping;
    public Image syrup;
    public Sprite[] backgroundSprite;
    public Sprite[] cupOrderSprite;
    public Sprite[] icecreamOrderSprite;
    public Sprite[] toppingOrderSprite;
    public Sprite[] syrupOrderSprite;
    public Sprite[] customerMaleSprite;
    public Sprite[] customerFemaleSprite;
    public Sprite[] cupSprite;
    public Sprite[] icecreamSprite;
    public Sprite[] toppingSprite;
    public Sprite[] syrupSprite;
    public Sprite blank;
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
        // print(index);
        cupOrder.sprite = cupOrderSprite[index];
    }

    public void ChangeIceCreamOrder(int index)
    {
        // print(index);
        icecreamOrder.sprite = icecreamOrderSprite[index];
    }

    public void ChangeToppingOrder(int index)
    {
        // print(index);
        toppingOrder.sprite = toppingOrderSprite[index];
    }

    public void ChangeSyrupOrder(int index)
    {
        // print(index);
        syrupOrder.sprite = syrupOrderSprite[index];
    }

    public void ChangeCustomer(string type, int expression)
    {
        if (type == "M")
        {
            customer.sprite = customerMaleSprite[expression];
        }
        if (type == "F")
        {
            customer.sprite = customerFemaleSprite[expression];
        }
    }

    public void CustomerGroupEnter()
    {
        customerGroup.Play("customergroup_start");
        acceptOrder.interactable = true;
        rejectOrder.interactable = true;
    }

    public void CustomerGroupExit()
    {
        customerGroup.Play("customergroup_end");
        acceptOrder.interactable = false;
        rejectOrder.interactable = false;
    }

    int cupType;
    public void PlaceCup(int num)
    {
        cupType = num;
        cup.sprite = cupSprite[num];
    }

    public void PlaceIceCream(int num)
    {
        if (cupType == 0)
        {
            icecream.sprite = icecreamSprite[num];
        }
        if (cupType == 1)
        {
            icecream.sprite = icecreamSprite[num + 3];
        }
        icecreamMask.Play("icecream_pour");
        // print("A");
    }

    public void PlaceSyrup(int num)
    {
        syrup.sprite = syrupSprite[num];
    }

    public void PlaceTopping(int num)
    {
        topping.sprite = toppingSprite[num];
    }

    public void Blank(Image img)
    {
        img.sprite = blank;
    }

    public void PlaceFullIceCream(int j, int i)
    {
        if (j == 0)
        {
            cup.sprite = cupSprite[i];
        }
        if (j == 1)
        {
            if (cupType == 0)
            {
            print(i);
            print(cupType);
                icecream.sprite = icecreamSprite[i];
            }
            if (cupType == 1)
            {
                icecream.sprite = icecreamSprite[i + 3];
            }
        }
        if (j == 2)
        {
            topping.sprite = toppingSprite[i];
        }
        if (j == 3)
        {
            syrup.sprite = syrupSprite[i];
        }

    }
}
