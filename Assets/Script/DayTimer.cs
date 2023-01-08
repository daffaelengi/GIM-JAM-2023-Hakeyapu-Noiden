using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTimer : MonoBehaviour
{
    public Slider dayTimer;
    public MainMechanics mm;

    // Start is called before the first frame update
    void Start()
    {
        dayTimer.value = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (dayTimer.value < (float)mm.cdDay)
        {
            dayTimer.value += Time.deltaTime;
        }
        if (dayTimer.value > mm.cdDay)
        {
            dayTimer.value = 0;
        }
    }
}
