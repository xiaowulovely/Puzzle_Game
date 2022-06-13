using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemID;

    public void ItemClick()
    {
        InventoryManager.Instance.AddItem(itemID);
        gameObject.SetActive(false);
    }
}
