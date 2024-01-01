using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private InventoryItemData data;


    public static event Action<InventoryItemData> PickUpItem;

    private bool isInvoked = false;

    private void Awake() // ham abstract cua 
    {
        Init(); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player"))
        {
            return;
        }

        OnPickUp();
    }
    private void Init()
    {
        LoadData(data);
    }
    private void OnPickUp()
    {
        if (isInvoked)
        {
            return;
        }

        PickUpItem?.Invoke(data);
        isInvoked = true;
        Destroy(this.gameObject);
    }
    private void LoadData(InventoryItemData data)
    {
        if (data == null)
        {
            return;
        }

        SetSprite(data.ItemSprite); 
    }

    private void SetSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite; // load hinh trong prefab
    }
}
