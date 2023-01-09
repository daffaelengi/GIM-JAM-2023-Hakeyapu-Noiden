using UnityEngine;
using TMPro;
using System.Collections;

public class BlinkText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private float transparencyInterval = 0.001f;
    private float transparencyDelta = 0.003f;
    private bool fadeIn = true;

    IEnumerator Start()
    {
        while (true)
        {
            // Get the current color of the text element
            Color currentColor = text.color;

            // Modify the alpha channel of the color
            if (fadeIn)
            {
                currentColor.a += transparencyDelta;
            }
            else
            {
                currentColor.a -= transparencyDelta;
            }

           // Debug.Log("Transparency has changed to " + currentColor.a);

            // Clamp the alpha value to the range 0-1
            currentColor.a = Mathf.Clamp01(currentColor.a);

            // Set the modified color on the text element
            text.color = currentColor;

            // Check the transparency of text
            if ((currentColor.a <= 0.2f) || (currentColor.a >= 1f))
                fadeIn = !fadeIn;

            // Wait for the specified interval before modifying the transparency again
            yield return new WaitForSeconds(transparencyInterval);
        }
    }
}

