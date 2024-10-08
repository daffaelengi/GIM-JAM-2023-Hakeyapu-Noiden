using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMechanics : MonoBehaviour
{
    // public MakeText mt;
    public RequestText rt;
    public BoxMovement bm;
    public ImageChanger ic;
    public SceneChanger sc;

    public Animator transition;

    // public GameObject acceptButton;
    // public GameObject rejectButton;
    // public GameObject customerImg;

    public string[] cup;
    public string[] variant; // menyimpan macam-macam variant ice cream
    public string[] topping; // menyimpan macam-macam topping
    public string[] syrup;
    public string[] slot = new string[3];

    public int maxTopping; // banyak topping maksimal pada 1x order
    public int maxIceCream; // banyak jenis eskrim maksimal pada 1x order
    public int money; // jumlah uang
    public int moneyTarget;
    public int day;
    public int place; // 0 for cashier, 1 for ice cream making

    public float cdCustomerDelay; // delay in between customer
    public float cdCustomerReject; // countdown sebelum customer auto reject
    public List<float> cdCustomer = new List<float>(); // countdown sebelum ganti customer karena kelamaan
    public float cdDay;

    public bool cdCustomerDelayCheck;
    public bool cdCustomerRejectCheck;
    public List<bool> cdCustomerCheck = new List<bool>();
    public bool allowBackgroundOrder;
    public bool dialogueEnabled = false;
    public bool specialEnabled = false;

    public List<GameObject> dialogueList;

    public List<List<int>> orderReq = new List<List<int>>(); // menyimpan orderan customer
    public List<int> reqCup = new List<int>(); // menyimpan orderan jenis cup
    public List<int> reqIceCream = new List<int>(); // menyimpan orderan jenis es krim
    public List<int> reqTopping = new List<int>(); // menyimpan orderan jenis topping
    public List<int> reqSyrup = new List<int>(); // menyimpan orderan jenis syrup

    public List<List<int>> orderMake = new List<List<int>>(); // menyimpan orderan yang sedang dibuat
    public List<int> makeCup = new List<int>(); // menyimpan buatan orderan jenis cup
    public List<int> makeIceCream = new List<int>(); // menyimpan buatan orderan jenis es krim
    public List<int> makeTopping = new List<int>(); // menyimpan buatan orderan jenis topping
    public List<int> makeSyrup = new List<int>(); // menyimpan buatan orderan jenis syrup

    public List<string> orderList = new List<string>();


    int toppingAmt; // menyimpan banyak topping yang diinginkan customer
    int icecreamAmt; // menyimpan banyak jenis eskrim pada 1x order customer

    // int icecream = 0; // menyimpan banyak jenis eskrim pada orderan yang sedang dibuat

    // Start is called before the first frame update
    void Start()
    {
        // acceptButton.SetActive(false);
        // rejectButton.SetActive(false);
        // customerImg.SetActive(false);

        ic.Blank(ic.cup);
        ic.Blank(ic.icecream);
        ic.Blank(ic.syrup);
        ic.Blank(ic.topping);
        
        place = 0;
        
        StartCustomerDelay();
        cdCustomerRejectCheck = false;
        // cdCustomerCheck = false;
        // cdCustomerReject = 5;
        cdDay = 600f;

        orderReq.Add(reqCup);
        orderReq.Add(reqIceCream);
        orderReq.Add(reqTopping);
        orderReq.Add(reqSyrup);

        orderMake.Add(makeCup);
        orderMake.Add(makeIceCream);
        orderMake.Add(makeTopping);
        orderMake.Add(makeSyrup);
        FindObjectOfType<AudioManager>().Play("crowd");
    }

    // Update is called once per frame
    void Update()
    {
        if (orderList.Count != 0)
        {
            UpdateOrderBox(orderList[0].Remove(0, 1));
        }
        else
        {
            ic.ChangeCupOrder(ic.cupOrderSprite.Length-1);
            ic.ChangeIceCreamOrder(ic.icecreamOrderSprite.Length-1);
            ic.ChangeToppingOrder(ic.toppingOrderSprite.Length-1);
            ic.ChangeSyrupOrder(ic.syrupOrderSprite.Length-1);
        }

        if (cdDay > 0f && money < moneyTarget) // && cdDay <= 600 && money < moneyTarget)
        {
            cdDay -= Time.deltaTime;
        }
        else //if (specialEnabled == false)
        {
            // ChangeDay();
            // orderList.Clear();
            SpecialEvent();
            // if (cdDay <= 0 || money >= moneyTarget)
            // {
            //     // ChangeDay();
            // }
        }

        // Countdown Customer Delay
        if (cdCustomerDelayCheck == true && cdCustomerDelay > 0)
        {
            cdCustomerDelay -= Time.deltaTime;
        }
        else if (cdCustomerDelayCheck == true)
        {
            Customer();
        }

        // Countdown Customer Reject
        if (cdCustomerRejectCheck == true && cdCustomerReject > 0)
        {
            cdCustomerReject -= Time.deltaTime;
        }
        else if (cdCustomerRejectCheck == true)
        {
            RejectOrder();
            // cdCustomerRejectCheck = false;
            // cdCustomerReject = 0;
        }

        // Countdown Customer
        for (int i = 0; i < orderList.Count; i++)
        {
            // print(orderList.Count);
            if (cdCustomerCheck[i] == true && cdCustomer[i] > 0)
            {
                cdCustomer[i] -= Time.deltaTime;
            }
            else if (cdCustomerCheck[i] == true)
            {
                orderList.RemoveAt(0);
                cdCustomerCheck[i] = false;
                cdCustomerCheck.RemoveAt(0);
                cdCustomer[i] = 0;
                cdCustomer.RemoveAt(0);
                break;
                // if (allowBackgroundOrder == false)
                // {
                //     StartCustomerDelay();
                // }
            }
        }
        // cdCustomer -= Time.deltaTime;

        // if (cdCustomerDelay == 0)
        // {
        //     Customer();
        // }
        // else
        // {
        //     cdCustomerDelay -= Time.deltaTime;
        // }

        // cdCustomerReject -= Time.deltaTime;
        // else if (cdCustomerReject <= 0)
        // {
        //     cdCustomerDelay = (float)(UnityEngine.Random.Range(0, 5));
        //     RejectOrder();
        // }

        // if (cdCustomerDelay <= 0)
        // {
        //     cdCustomerDelay = 0;
        //     if (cdCustomerReject <= 0)
        //     {
        //         cdCustomerReject = 0;
        //     }
        //     else
        //     {
        //         cdCustomerReject -= Time.deltaTime;
        //     }
        // }
        // else
        // {
        //     cdCustomerDelay -= Time.deltaTime;
        // }
    }

    void StartCustomerDelay()
    {
        cdCustomerDelay = (float)(UnityEngine.Random.Range(1, 5));
        cdCustomerDelayCheck = true;
    }

    void ChangeDay() // pengerjaan di skip
    {
        // cdDay = 600f;
        // moneyTarget = moneyTarget * 110 / 100;
        // day += 1;
        cdDay = 0;

        if (money < moneyTarget)
        {
            GameOver();
            money = 0;
        }
        else
        {
            dialogueList[0].SetActive(true);
            dialogueList.RemoveAt(0);
            money = 0;
            // play dialogue
        }
    }

    bool clearOrderSpecial = false;
    bool specialMakingEnabled = false;
    public GameObject customerGroup;
    public GameObject whiteBox;
    void SpecialEvent()
    {
        customerGroup.SetActive(false);
        whiteBox.SetActive(false);
        specialEnabled = true;
        cdDay = 0;

        if (clearOrderSpecial == false)
        {
            clearOrderSpecial = true;
            orderList.Clear();
        }

        if (dialogueEnabled == false && specialMakingEnabled == false)
        {
            if (money < moneyTarget)
            {
                GameOver();
                // money = 0;
            }
            else if (orderList.Count != 0)
            {
                specialMakingEnabled = true;
                money = 0;
                SwitchPlace();
                for (int i = 0; i < 3; i++)
                {
                    cdCustomerCheck[i] = true;
                }
            }
            else
            {
                DialogueStart();
                Customer();
                AcceptOrder();
                Customer();
                AcceptOrder();
                Customer();
                AcceptOrder();
                for (int i = 0; i < 3; i++)
                {
                    cdCustomerCheck[i] = false;
                }
                // money = 0;
                // play dialogue
            }
        }
        else if (orderList.Count == 0)// && money < moneyTarget)
        {
            // specialMakingEnabled = false;
            if (money < moneyTarget)
            {
                FindObjectOfType<AudioManager>().Play("boom");
                GameOver();
                // money = 0;
            }
            else
            {
                DialogueStart();
            }

            if (dialogueEnabled == false)
            {
                DayPassed();
            }
        }
    }

    void DialogueStart()
    {
        if (dialogueList.Count != 0)
        {
            dialogueEnabled = true;
            dialogueList[0].SetActive(true);
            dialogueList.RemoveAt(0);
        }
    }

    void GameOver()
    {
        FindObjectOfType<AudioManager>().Stop("bg");
        StartCoroutine(sc.TransitionToScene("GameOver"));
        FindObjectOfType<AudioManager>().Play("game_over");        
    }

    void DayPassed()
    {
        FindObjectOfType<AudioManager>().Stop("bg");
        int randInt = UnityEngine.Random.Range(0, 2);

        if (randInt == 0)
        {
            FindObjectOfType<AudioManager>().Play("noice");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("yeah"); ;
        }
        StartCoroutine(sc.TransitionToScene("DayPassed"));
    }

    // Dipanggil setiap berganti customer
    string orderTemp;
    void Customer()
    {
        orderTemp = "";

        if (specialEnabled == true)
        {
            cdCustomerDelayCheck = false;
            cdCustomerDelay = 0;
            cdCustomerRejectCheck = false;
            cdCustomerReject = 0;
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("customer");
            // Start Customer Reject Timer
            cdCustomerReject = 5f;
            cdCustomerRejectCheck = true;

            // Stop Customer Delay Timer
            cdCustomerDelayCheck = false;
            cdCustomerDelay = 0;
        }


        // Clear Previous Order
        // orderMake.Clear();
        // orderReq.Clear();
        reqCup.Clear();
        reqIceCream.Clear();
        reqTopping.Clear();
        reqSyrup.Clear();
        // Trash();

        // randomize customer type
        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            orderTemp += "F";
        }
        else
        {
            orderTemp += "M";
        }

        // orderReq - C U P
        reqCup.Add(UnityEngine.Random.Range(0, cup.Length));

        // orderReq - I C E C R E A M
        icecreamAmt = UnityEngine.Random.Range(1, maxIceCream + 1);
        for (int i = 1; i <= icecreamAmt; i++)
        {
            reqIceCream.Add(UnityEngine.Random.Range(0, variant.Length));
        }
        reqIceCream.Sort();

        // orderReq - T O P P I N G
        toppingAmt = UnityEngine.Random.Range(0, maxTopping + 1);
        for (int i = 0; i < toppingAmt; i++)
        {
            reqTopping.Add(UnityEngine.Random.Range(0, topping.Length));
        }
        reqTopping.Sort();

        // orderReq - S Y R U P
        for (int i = 0; i < UnityEngine.Random.Range(0, 2); i++)
        {
            reqSyrup.Add(UnityEngine.Random.Range(0, syrup.Length));
        }


        orderTemp += StringWriter(orderReq);

        bm.DialogueBoxEnter();
        rt.UpdateText();
        // customerImg.SetActive(true);
        // acceptButton.SetActive(true);
        // rejectButton.SetActive(true);
        ic.CustomerGroupEnter();

        if (orderTemp != "")
        {
            ic.ChangeCustomer(Convert.ToString(orderTemp[0]), 0);
        }
    }

    // void RequestOrder()
    // {
    // }

    bool CheckOrder(List<int> reqList, List<int> makeList)
    {
        for (int i = 0; i < reqList.Count; i++)
        {
            if (reqList[i] != makeList[i] || reqList.Count != makeList.Count)
            {
                return false;
            }
            // if (i == reqList.Count - 1)
            // {
            //     return true;
            // }
        }
        return true;
    }

    void GetMoney()
    {
        FindObjectOfType<AudioManager>().Play("cash");
        if (specialEnabled)
        {
            money += 34;
        }
        else
        {
            money += 5 + reqTopping.Count;
            
            // B O N U S  M O N E Y
            if (cdCustomer[0] >= 25f)
            {
                money += 1;
            }
        }
        
    }

    // // Dipanggil setiap menambah eskrim
    // public void AddIceCream(int num)
    // {
    //     orderMake.Sort();
    //     orderMake.Add(num);
    //     icecream += 1;
    // }

    // // Dipanggil setiap menambah topping
    // public void AddTopping(int num)
    // {
    //     orderMake.Add(num);
    // }

    public void AcceptOrder()
    {
        FindObjectOfType<AudioManager>().Play("pop");
        orderList.Add(orderTemp);
        
        cdCustomer.Add(30f);
        cdCustomerCheck.Add(true);
        cdCustomerReject = 0;
        cdCustomerRejectCheck = false;
        StartCustomerDelay();

        bm.DialogueBoxExit();
        // acceptButton.SetActive(false);
        // rejectButton.SetActive(false);
        // customerImg.SetActive(false);
        ic.CustomerGroupExit();

        // RequestOrder();
    }

    public void RejectOrder()
    {
        FindObjectOfType<AudioManager>().Play("pop");
        rt.ClearText();
        StartCustomerDelay();
        cdCustomerReject = 0;
        cdCustomerRejectCheck = false;
        bm.DialogueBoxExit();
        // acceptButton.SetActive(false);
        // rejectButton.SetActive(false);
        // customerImg.SetActive(false);
        ic.CustomerGroupExit();
    }

    // Dipanggil untuk berpindah-pindah lokasi
    public TextMeshProUGUI switchText;
    public void SwitchPlace()
    {
        FindObjectOfType<AudioManager>().Play("but1");
        if (orderList.Count != 0)
        {
            UpdateOrderBox(orderList[0].Remove(0, 1));
        }
        ic.ChangeBackground();
        transition.Play("animation_start");
        if (place == 0)
        {
            if (allowBackgroundOrder == false)
            {
                cdCustomerDelay = 0;
                cdCustomerDelayCheck = false;
                cdCustomerReject = 0;
                cdCustomerRejectCheck = false;
            }

            // customerImg.SetActive(false);
            // acceptButton.SetActive(false);
            // rejectButton.SetActive(false);
            ic.CustomerGroupExit();
            
            place = 1;
            FindObjectOfType<AudioManager>().Stop("crowd");
            bm.OrderBoxEnter();
            bm.KitBoxEnter();
            bm.CounterEnter();
            bm.DialogueBoxExit();
            rt.ClearText();
            UpdateIceCream(orderMake);

            switchText.text = "Kitchen";
        }
        else if (place == 1)
        {
            // ic.Blank(ic.cup);
            // ic.Blank(ic.icecream);
            // ic.Blank(ic.syrup);
            // ic.Blank(ic.topping);
            if (allowBackgroundOrder == false)
            {
                StartCustomerDelay();
            }

            place = 0;
            FindObjectOfType<AudioManager>().Play("crowd");
            bm.OrderBoxExit();
            bm.KitBoxExit();
            bm.CounterExit();

            switchText.text = "Cashier";
        }
    }

    // Dipanggil setiap menambah sesuatu pada orderan yang sedang dibuat
    bool cupPlaced = false;
    public void AddCup(int num)
    {
        if (cupPlaced == false)
        {
            if (num == 1)
                FindObjectOfType<AudioManager>().Play("cup");
            else
                FindObjectOfType<AudioManager>().Play("cone");
            
            ic.PlaceCup(num);
            cupPlaced = true;
            makeCup.Add(num);
            // mt.UpdateText(1);
        }
    }

    bool flavorPlaced = false;
    public void AddIceCream(int num)
    {
        if (cupPlaced == true && flavorPlaced == false)
        {
            FindObjectOfType<AudioManager>().Play("pop");
            ic.PlaceIceCream(num);
            flavorPlaced = true;
            makeIceCream.Add(num);
            // mt.UpdateText(2);
        }
    }

    bool toppingPlaced = false;
    public void AddTopping(int num)
    {
        if (flavorPlaced == true && toppingPlaced == false)
        {
            FindObjectOfType<AudioManager>().Play("pop");
            ic.PlaceTopping(num);
            toppingPlaced = true;
            makeTopping.Add(num);
            // mt.UpdateText(3);
        }
    }

    bool syrupPlaced = false;
    public void AddSyrup(int num)
    {
        if (flavorPlaced == true && syrupPlaced == false)
        {
            FindObjectOfType<AudioManager>().Play("pop");
            ic.PlaceSyrup(num);
            syrupPlaced = true;
            makeSyrup.Add(num);
            // mt.UpdateText(4);
        }
    }

    string StringWriter(List<List<int>> list)
    {
        // string save = "";
        string save = Convert.ToString(list.Count);
        for (int j = 0; j < list.Count; j++)
        {
            save += Convert.ToString(list[j].Count);
            for (int i = 0; i < list[j].Count; i++)
            {
                save += Convert.ToString(list[j][i]);
            }
        }
        return save;
    }

    void StringReader(string text, List<List<int>> list)
    {
        Trash();
        int x = 0;
        int y = 0;
        for (int i = x; i < Convert.ToInt32(Convert.ToString(text[0])); i++)
        {
            x += 1;
            y = x;
            // print(i);
            for (int j = y; j < y + Convert.ToInt32(Convert.ToString(text[y])); j++)
            {
                x += 1;
                // print(Convert.ToInt32(Convert.ToString(text[x]))); //4131220210
                list[i].Add(Convert.ToInt32(Convert.ToString(text[x])));
                // break;
            }
            // break;
        }
    }

    void UpdateIceCream(List<List<int>> list)
    {
        ic.icecreamMask.Play("entry");
        // string save = "";
        // string save = Convert.ToString(list.Count);
        for (int j = 0; j < list.Count; j++)
        {
            // save += Convert.ToString(list[j].Count);
            for (int i = 0; i < list[j].Count; i++)
            {
                // save += Convert.ToString(list[j][i]);
                ic.PlaceFullIceCream(j, list[j][i]);
                // if (j == 0)
                // {
                //     ic.PlaceCup(i);
                // }
                // if (j == 1)
                // {
                //     ic.PlaceIceCream(i);
                // }
                // if (j == 2)
                // {
                //     ic.PlaceTopping(i);
                // }
                // if (j == 3)
                // {
                //     ic.PlaceSyrup(i);
                // }
            }
        }
        // return save;
    }

    // menerjemahkan list orderList sehingga bisa merubah gambar pesanan di order box
    void UpdateOrderBox(string text)
    {
        ic.ChangeCupOrder(ic.cupOrderSprite.Length-1);
        ic.ChangeIceCreamOrder(ic.icecreamOrderSprite.Length-1);
        ic.ChangeToppingOrder(ic.toppingOrderSprite.Length-1);
        ic.ChangeSyrupOrder(ic.syrupOrderSprite.Length-1);
        int x = 0;
        int y = 0;
        for (int i = x; i < Convert.ToInt32(Convert.ToString(text[0])); i++)
        {
            x += 1;
            y = x;
            // print(i);
            for (int j = y; j < y + Convert.ToInt32(Convert.ToString(text[y])); j++)
            {
                x += 1;
                // print(Convert.ToInt32(Convert.ToString(text[x]))); //4131220210
                // list[i].Add(Convert.ToInt32(Convert.ToString(text[x])));
                if (i == 0)
                {
                    ic.ChangeCupOrder(Convert.ToInt32(Convert.ToString(text[x])));
                }
                if (i == 1)
                {
                    ic.ChangeIceCreamOrder(Convert.ToInt32(Convert.ToString(text[x])));
                }
                if (i == 2)
                {
                    ic.ChangeToppingOrder(Convert.ToInt32(Convert.ToString(text[x])));
                }
                if (i == 3)
                {
                    ic.ChangeSyrupOrder(Convert.ToInt32(Convert.ToString(text[x])));
                }
                // break;
            }
            // break;
        }
    }

    public int[] slotCheck = {0, 0, 0};
    public void SaveSlot(int num)
    {
        if (num == 1)
        {
            if (slotCheck[0] == 0)
            {
                slotCheck[0] = 1;
                // print("A");
                slot[0] = StringWriter(orderMake);
                print(StringWriter(orderMake));
                if (slot[0] == "40000")
                {
                    slotCheck[0] = 0;
                }
                Trash();
            }
            else
            {
                slotCheck[0] = 0;
                StringReader(slot[0], orderMake);
                UpdateIceCream(orderMake);
                // mt.UpdateText(5);
            }  
        }
        if (num == 2)
        {
            if (slotCheck[1] == 0)
            {
                slotCheck[1] = 1;
                // print("A");
                slot[1] = StringWriter(orderMake);
                if (slot[1] == "40000")
                {
                    slotCheck[1] = 0;
                }
                Trash();
            }
            else
            {
                slotCheck[1] = 0;
                StringReader(slot[1], orderMake);
                UpdateIceCream(orderMake);
                // mt.UpdateText(5);
            }  
        }
        if (num == 3)
        {
            if (slotCheck[2] == 0)
            {
                slotCheck[2] = 1;
                // print("A");
                slot[2] = StringWriter(orderMake);
                if (slot[2] == "40000")
                {
                    slotCheck[2] = 0;
                }
                Trash();
            }
            else
            {
                slotCheck[2] = 0;
                StringReader(slot[2], orderMake);
                UpdateIceCream(orderMake);
                // mt.UpdateText(5);
            }  
        }
        // if (num == 2)
        // {
        //     if (slotCheck[1] == 0)
        //     {  
        //         slot[1] = orderMake;
        //         slotCheck[1] = 1;
        //         Trash();
        //     }
        //     else
        //     {
        //         orderMake = slot[1];
        //         slotCheck[1] = 0;
        //     }
        // }
        // if (num == 3)
        // {
        //     if (slotCheck[2] == 0)
        //     {  
        //         slot[2] = orderMake;
        //         slotCheck[2] = 1;
        //         Trash();
        //     }
        //     else
        //     {
        //         orderMake = slot[2];
        //         slotCheck[2] = 0;
        //     }
        // }
    }

    public void Trash()
    {
        cupPlaced = false;
        flavorPlaced = false;
        syrupPlaced = false;
        toppingPlaced = false;
        ic.icecreamMask.Play("exit");
        ic.Blank(ic.cup);
        ic.Blank(ic.icecream);
        ic.Blank(ic.syrup);
        ic.Blank(ic.topping);
        // mt.UpdateText(0);
        makeCup.Clear();
        makeIceCream.Clear();
        makeTopping.Clear();
        makeSyrup.Clear();
    }

    // Dipanggil setiap menyelesaikan pesanan untuk mengecek kesesuaian pesanan
    public void Done(int num)
    {
        if (orderList.Count != 0)
        {
            UpdateOrderBox(orderList[0].Remove(0, 1));
        }
        // if (reqCup.Count != makeCup.Count || reqIceCream.Count != makeIceCream.Count || reqTopping.Count != makeTopping.Count || reqSyrup.Count != makeSyrup.Count)
        // {
        //     orderMake.Clear();
        // }
        // else if (CheckOrder(reqCup, makeCup) == true && CheckOrder(reqIceCream, makeIceCream) == true && CheckOrder(reqTopping, makeTopping) == true && CheckOrder(reqSyrup, makeSyrup) == true)
        // {
        //     GetMoney();
        //     Customer();
        // }
        // else
        // {
        //     orderMake.Clear();
        //     // orderReq.Clear();
        //     // reqCup.Clear();
        //     // reqIceCream.Clear();
        //     // reqTopping.Clear();
        //     // reqSyrup.Clear();
        // }

        if (orderList[num].Remove(0, 1) == StringWriter(orderMake))
        {
            print("correct");
            Trash();
            GetMoney();
            orderList.RemoveAt(0);
            cdCustomer.RemoveAt(0);
            cdCustomerCheck.RemoveAt(0);

            if (orderList.Count == 0)
            {
                SwitchPlace();
                StartCustomerDelay();
            }
            rt.ClearText();
            cdCustomerReject = 0;
            cdCustomerRejectCheck = false;
            bm.DialogueBoxExit();
            // acceptButton.SetActive(false);
            // rejectButton.SetActive(false);
            // customerImg.SetActive(false);
            ic.CustomerGroupExit();
            // Customer();
        }
        else
        {
            print("wrong");
            // orderMake.Clear();
            // orderReq.Clear();
            // reqCup.Clear();
            // reqIceCream.Clear();
            // reqTopping.Clear();
            // reqSyrup.Clear();
        }


        // for (int i = 0; i < orderReq.Count; i++)
        // {
        //     if (orderReq[i] != orderMake[i] || orderReq.Count != orderMake.Count)
        //     {
        //         print("wrong");
        //         print(Convert.ToDouble(i) / orderReq.Count);
        //         orderMake.Clear();
        //         break;
        //     }
        //     if (i == orderReq.Count - 1)
        //     {
        //         print("correct");
        //         money += 5 + reqTopping.Count;
                
        //         // B O N U S  M O N E Y
        //         if (cdCustomer >= 25f)
        //         {
        //             money += 1;
        //         }

        //         Customer();
        //         break;
        //     }
        // }
    }
}