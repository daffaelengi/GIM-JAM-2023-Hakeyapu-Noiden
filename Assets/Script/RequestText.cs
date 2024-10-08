using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class RequestText : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI timerText;
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

        if (mm.reqTopping.Count != 0 && mm.reqSyrup.Count != 0)
        {
            textUI.text = Convert.ToString(mm.cup[mm.reqCup[0]]) + cream + topping + " + " + Convert.ToString(mm.syrup[mm.reqSyrup[0]]);
        }
        else if (mm.reqTopping.Count != 0)
        {
            textUI.text = Convert.ToString(mm.cup[mm.reqCup[0]]) + cream + topping;
        }
        else if (mm.reqSyrup.Count != 0)
        {
            textUI.text = Convert.ToString(mm.cup[mm.reqCup[0]]) + cream + " + " + Convert.ToString(mm.syrup[mm.reqSyrup[0]]);
        }
        else
        {
            textUI.text = Convert.ToString(mm.cup[mm.reqCup[0]]) + cream;
        }

    }

    public void ClearText()
    {
        textUI.text = "";
    }

    // Update is called once per frame
    float hourFiction;
    void Update()
    {
        hourFiction = ((600 - mm.cdDay) * 900 / 600) + 420;
        dayText.text = "Day " + Convert.ToString(mm.day + 1);
        if (Convert.ToString(Convert.ToInt32(hourFiction)/60).Length != 1 && Convert.ToString(Convert.ToInt32(hourFiction%60)).Length != 1)
        {
            timerText.text = Convert.ToString(Convert.ToInt32(hourFiction)/60) + ":" + Convert.ToString(Convert.ToInt32(hourFiction%60));
        }
        else if (Convert.ToString(Convert.ToInt32(hourFiction)/60).Length == 1 && Convert.ToString(Convert.ToInt32(hourFiction%60)).Length == 1)
        {
            timerText.text = "0" + Convert.ToString(Convert.ToInt32(hourFiction)/60) + ":0" + Convert.ToString(Convert.ToInt32(hourFiction%60));
        }
        else if (Convert.ToString(Convert.ToInt32(hourFiction%60)).Length == 1)
        {
            timerText.text = Convert.ToString(Convert.ToInt32(hourFiction)/60) + ":0" + Convert.ToString(Convert.ToInt32(hourFiction%60));
        }
        else
        {
            timerText.text = "0" + Convert.ToString(Convert.ToInt32(hourFiction)/60) + ":" + Convert.ToString(Convert.ToInt32(hourFiction%60));
        }
        // print(mm.variant[0]);
    }
}
