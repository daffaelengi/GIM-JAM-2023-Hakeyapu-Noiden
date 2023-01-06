using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMechanics : MonoBehaviour
{
    public string[] topping; // menyimpan macam-macam topping
    public string[] variant; // menyimpan macam-macam variant ice cream
    public int maxTopping; // banyak topping maksimal pada 1x order
    public int maxIceCream; // banyak jenis eskrim maksimal pada 1x order
    public int money; // jumlah uang
    public float cdCustomer; // cooldown sebelum ganti customer karena kelamaan

    public List<int> request = new List<int>(); // menyimpan orderan customer
    public List<int> orderMake = new List<int>(); // menyimpan orderan yang sedang dibuat

    int toppingAmt; // menyimpan banyak topping yang diinginkan customer
    int icecreamAmt; // menyimpan banyak jenis eskrim pada 1x order customer

    int icecream = 0; // menyimpan banyak jenis eskrim pada orderan yang sedang dibuat

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
        orderMake.Clear();
        request.Clear();
        icecream = 0;

        // REQUEST - T O P P I N G
        toppingAmt = UnityEngine.Random.Range(0, maxTopping);
        for (int i = 0; i <= toppingAmt; i++)
        {
            request.Add(UnityEngine.Random.Range(0, topping.Length));
        }
        request.Sort();

        // REQUEST - I C E C R E A M
        icecreamAmt = UnityEngine.Random.Range(1, maxIceCream);
        for (int i = 1; i <= icecreamAmt; i++)
        {
            request.Add(UnityEngine.Random.Range(0, variant.Length));
        }
        print("END");
    }

    // Dipanggil setiap menambah topping
    public void AddTopping(int num)
    {
        orderMake.Add(num);
    }

    // Dipanggil setiap menambah eskrim
    public void AddIceCream(int num)
    {
        orderMake.Sort();
        orderMake.Add(num);
        icecream += 1;
    }

    // Dipanggil setiap menyelesaikan pesanan untuk mengecek kesesuaian pesanan
    public void Done()
    {
        for (int i = 0; i < request.Count; i++)
        {
            if (request[i] != orderMake[i] || request.Count != orderMake.Count || icecream != icecreamAmt)
            {
                print("wrong");
                print(Convert.ToDouble(i) / request.Count);
                icecream = 0;
                orderMake.Clear();
                break;
            }
            if (i == request.Count - 1)
            {
                print("correct");
                money += 5 + request.Count;
                
                // B O N U S  M O N E Y
                if (cdCustomer >= 25f)
                {
                    money += 1;
                }

                Customer();
                break;
            }
        }
    }
}