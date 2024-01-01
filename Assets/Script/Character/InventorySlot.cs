using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    private Transform itemParent;
    public Transform ItemParent => itemParent;
    public InventoryItem CurrentItem; 



    //drag & drop 
    public void OnDrop(PointerEventData eventData)
    {
        InventoryItem item = eventData.pointerDrag.GetComponent<InventoryItem>();

        if (item != null)
        {
            item.transform.SetParent(transform);
            item.transform.position = transform.position;
        }
    }
}
