using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Button : MonoBehaviour, IPointerClickHandler {

    public Action ClickFunc = null;
    public Action<PointerEventData> OnPointerClickFunc;

    public virtual void OnPointerClick(PointerEventData eventData) {
        if (eventData.button == PointerEventData.InputButton.Left) {
            if (ClickFunc != null) ClickFunc();
        }
    }
}