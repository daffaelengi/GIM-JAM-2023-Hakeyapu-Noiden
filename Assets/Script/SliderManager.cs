using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public Slider rejectTimer;
    public Slider moneyTarget;
    public Slider patienceTimer;
    public MainMechanics mm;
    public float moneyTargetSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rejectTimer.value = 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rejectTimer.value > (float)mm.cdCustomerReject)
        {
            rejectTimer.value -= Time.deltaTime;
        }
        else
        {
            rejectTimer.value = (float)mm.cdCustomerReject;
        }

        if (moneyTarget.value < (float)mm.money)
        {
            moneyTarget.value += moneyTargetSpeed * Time.deltaTime;
        }
        else
        {
            // print(mm.moneyTarget);
            moneyTarget.value = (float)mm.money;
            moneyTarget.maxValue = mm.moneyTarget;
        }
        
        if (mm.cdCustomer.Count > 0)
        {
            if (patienceTimer.value > (float)mm.cdCustomer[0])
            {
                patienceTimer.value -= Time.deltaTime;
            }
            else
            {
                patienceTimer.value = (float)mm.cdCustomer[0];
            }
        }
        
        // if (rejectTimer.value < mm.cdCustomerReject)
        // {
        //     rejectTimer.value = mm.cdCustomerReject;
        // }
        // else
        // {
        //     rejectTimer.value = (float)mm.cdCustomerReject;
        // }
    }
}
