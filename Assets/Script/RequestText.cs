using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class RequestText : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    public MainMechanics mm;
    string cream = "";
    string topping = "";

    // Start is called before the first frame update
    void Start()
    {
    }

    public void UpdateText()
    {
        cream = "";
        topping = "";

        foreach (int item in mm.reqIceCream)
        {
            cream += " + " + Convert.ToString(mm.variant[item]);
        }

        foreach (int item in mm.reqTopping)
        {
            topping += " + " + Convert.ToString(mm.topping[item]);
        }
        textUI.text = Convert.ToString(mm.cup[mm.reqCup[0]]) + cream + topping + " + " + Convert.ToString(mm.syrup[mm.reqSyrup[0]]);
    }

    // Update is called once per frame
    void Update()
    {
        // print(mm.variant[0]);
    }
}
