using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    void OnDrop(PointerEventData eventData)
    {
        Debug.Log("on drop");
    }
}
