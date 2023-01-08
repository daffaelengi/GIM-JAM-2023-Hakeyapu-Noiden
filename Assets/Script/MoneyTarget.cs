using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyTarget : MonoBehaviour
{
    public Slider moneyTarget;
    public MainMechanics mm;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (mm.money == 0)
        {
            moneyTarget.value = 0;
            moneyTarget.maxValue = mm.moneyTarget;
        }
        if (moneyTarget.value < (float)mm.money)
        {
            moneyTarget.value += Time.deltaTime;
        }
    }
}
