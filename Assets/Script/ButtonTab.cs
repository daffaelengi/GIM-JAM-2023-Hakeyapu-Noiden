using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTab : MonoBehaviour, IPointerClickHandler

{
    public ButtonContainer tabGroup;

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
    }

    private void Start()
    {
        tabGroup.Subscribe(this);
    }

}
