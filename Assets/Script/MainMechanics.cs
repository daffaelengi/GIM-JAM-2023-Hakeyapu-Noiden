using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMechanics : MonoBehaviour
{
    public MakeText mt;
    public string[] cup;
    public string[] variant; // menyimpan macam-macam variant ice cream
    public string[] topping; // menyimpan macam-macam topping
    public string[] syrup;
    public string[] slot = new string[3];

    public int maxTopping; // banyak topping maksimal pada 1x order
    public int maxIceCream; // banyak jenis eskrim maksimal pada 1x order
    public int money; // jumlah uang
    public float cdCustomer; // cooldown sebelum ganti customer karena kelamaan

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

    // 41v1v3vvv1v

    int toppingAmt; // menyimpan banyak topping yang diinginkan customer
    int icecreamAmt; // menyimpan banyak jenis eskrim pada 1x order customer

    // int icecream = 0; // menyimpan banyak jenis eskrim pada orderan yang sedang dibuat

    // Start is called before the first frame update
    void Start()
    {
        Customer();
    }

    // Update is called once per frame
    void Update()
    {
        cdCustomer -= Time.deltaTime;
        if (cdCustomer <= 0f)
        {
            Customer();
        }
    }

    // Dipanggil setiap berganti customer
    void Customer()
    {
        cdCustomer = 30f;

        // Clear Previous Order
        orderMake.Clear();
        orderReq.Clear();
        reqCup.Clear();
        reqIceCream.Clear();
        reqTopping.Clear();
        reqSyrup.Clear();
        Trash();

        // orderReq - C U P
        reqCup.Add(UnityEngine.Random.Range(0, cup.Length));

        // orderReq - I C E C R E A M
        icecreamAmt = UnityEngine.Random.Range(1, maxIceCream);
        for (int i = 1; i <= icecreamAmt; i++)
        {
            reqIceCream.Add(UnityEngine.Random.Range(0, variant.Length));
        }
        reqIceCream.Sort();

        // orderReq - T O P P I N G
        toppingAmt = UnityEngine.Random.Range(0, maxTopping);
        for (int i = 0; i <= toppingAmt; i++)
        {
            reqTopping.Add(UnityEngine.Random.Range(0, topping.Length));
        }
        reqTopping.Sort();

        // orderReq - S Y R U P
        reqSyrup.Add(UnityEngine.Random.Range(0, syrup.Length));

        print("END");

        RequestOrder();
    }

    void RequestOrder()
    {
        orderReq.Add(reqCup);
        orderReq.Add(reqIceCream);
        orderReq.Add(reqTopping);
        orderReq.Add(reqSyrup);

        orderMake.Add(makeCup);
        orderMake.Add(makeIceCream);
        orderMake.Add(makeTopping);
        orderMake.Add(makeSyrup);
    }

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
        money += 5 + reqTopping.Count;
        
        // B O N U S  M O N E Y
        if (cdCustomer >= 25f)
        {
            money += 1;
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

    // Dipanggil setiap menambah sesuatu pada orderan yang sedang dibuat
    public void AddCup(int num)
    {
        makeCup.Add(num);
        mt.UpdateText(1);
    }

    public void AddIceCream(int num)
    {
        makeIceCream.Add(num);
        mt.UpdateText(2);
    }

    public void AddTopping(int num)
    {
        makeTopping.Add(num);
        mt.UpdateText(3);
    }

    public void AddSyrup(int num)
    {
        makeSyrup.Add(num);
        mt.UpdateText(4);
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
                Trash();
            }
            else
            {
                slotCheck[0] = 0;
                StringReader(slot[0], orderMake);
                mt.UpdateText(5);
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
        mt.UpdateText(0);
        makeCup.Clear();
        makeIceCream.Clear();
        makeTopping.Clear();
        makeSyrup.Clear();
    }

    // Dipanggil setiap menyelesaikan pesanan untuk mengecek kesesuaian pesanan
    public void Done()
    {
        if (reqCup.Count != makeCup.Count || reqIceCream.Count != makeIceCream.Count || reqTopping.Count != makeTopping.Count || reqSyrup.Count != makeSyrup.Count)
        {
            orderMake.Clear();
        }
        else if (CheckOrder(reqCup, makeCup) == true && CheckOrder(reqIceCream, makeIceCream) == true && CheckOrder(reqTopping, makeTopping) == true && CheckOrder(reqSyrup, makeSyrup) == true)
        {
            GetMoney();
            Customer();
        }
        else
        {
            orderMake.Clear();
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