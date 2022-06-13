using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public PlayerItemData_SO playerItemData;

    private void Start()
    {
        
    }

    public void AddItem(int _item)
    {
        ItemDetails detail;
        if(playerItemData.UserGetItem(_item,out detail))
        {
            EventHandle.CallUpdateUIEvent(detail, playerItemData.GetItemCount()-1);
        }
        
    }
}
