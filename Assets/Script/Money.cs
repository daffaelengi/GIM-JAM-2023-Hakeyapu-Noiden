using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Money : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    public MainMechanics mm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textUI.text = "Jumlah Uang: Hn " + Convert.ToString(mm.money);
    }
}
