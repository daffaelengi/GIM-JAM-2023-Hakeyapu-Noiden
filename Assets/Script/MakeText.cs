using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MakeText : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    public MainMechanics mm;
    string cream = "";
    string topping = "";

    // Start is called before the first frame update
    void Start()
    {
        UpdateText(0);
    }

    public void UpdateText(int i)
    {
        if (i == 1)
        {
            cream = "";
            topping = "";
            textUI.text = Convert.ToString(mm.cup[mm.makeCup[0]]);
        }
        if (i == 2)
        {
            cream = "";
            foreach (int item in mm.makeIceCream)
            {
                cream += " + " + Convert.ToString(mm.variant[item]);
            }
            textUI.text = Convert.ToString(mm.cup[mm.makeCup[0]]) + cream;
        }
        if (i == 3)
        {
            topping = "";
            foreach (int item in mm.makeTopping)
            {
                topping += " + " + Convert.ToString(mm.topping[item]);
            }
            textUI.text = Convert.ToString(mm.cup[mm.makeCup[0]]) + cream + topping;
        }
        if (i == 4)
        {
            textUI.text = Convert.ToString(mm.cup[mm.makeCup[0]]) + cream + topping + " + " + Convert.ToString(mm.syrup[mm.makeSyrup[0]]);
        }
        if (i == 5)
        {
            cream = "";
            topping = "";
            foreach (int item in mm.makeIceCream)
            {
                cream += " + " + Convert.ToString(mm.variant[item]);
            }
            foreach (int item in mm.makeTopping)
            {
                topping += " + " + Convert.ToString(mm.topping[item]);
            }
            textUI.text = Convert.ToString(mm.cup[mm.makeCup[0]]) + cream + topping + " + " + Convert.ToString(mm.syrup[mm.makeSyrup[0]]);
        }
        if (i == 0)
        {
            textUI.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        // print(mm.variant[0]);
    }
}
