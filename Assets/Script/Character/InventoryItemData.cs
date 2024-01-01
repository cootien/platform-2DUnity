using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item", fileName = "ItemData")]
public class InventoryItemData : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private bool stackable;
    [SerializeField] private string itemName;
    [SerializeField] private string itemDescription;
    [SerializeField] private Sprite itemSprite;

    public int Id
    {
        get => id;
    }

    public bool Stackable
    {
        get => stackable;
    }

    public string ItemName
    {
        get => itemName;
    }

    public string ItemDescription
    {
        get => itemDescription;
    }

    public Sprite ItemSprite
    {
        get => itemSprite;
    }
}
