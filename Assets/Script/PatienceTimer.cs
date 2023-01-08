using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatienceTimer : MonoBehaviour
{
    public Slider patienceTimer;
    public MainMechanics mm;

    // Start is called before the first frame update
    void Start()
    {
        patienceTimer.value = 30;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (patienceTimer.value > (float)mm.cdCustomer)
        {
            patienceTimer.value -= Time.deltaTime;
        }
        if (patienceTimer.value < mm.cdCustomer)
        {
            patienceTimer.value = mm.cdCustomer;
        }
    }
}
