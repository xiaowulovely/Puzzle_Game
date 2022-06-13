using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayItemData",menuName = "Inventory/PlayerItemData_SO")]
public class PlayerItemData_SO : ScriptableObject
{
    public ItemDataList_SO ItemData;

    public List<ItemDetails> m_ItemList = new List<ItemDetails>();

    public bool UseItem(int _itemID)
    {
        ItemDetails item;
        item = ItemData.GetItemDetail(_itemID);
        if (m_ItemList.Contains(item))
        {
            m_ItemList.Remove(item);
            return true;
        }
        return false;
    }

    public bool UserGetItem(int _itemID,out ItemDetails itemDetail)
    {
        ItemDetails item;
        item = ItemData.GetItemDetail(_itemID);
        itemDetail = item;
        if (m_ItemList.Contains(item))
        { 
            return false;
        }
        m_ItemList.Add(item);
        return true;
    }

    public int GetItemCount()
    {
        return m_ItemList.Count;
    }

    public ItemDetails GetItemDetailByIndex(int _index)
    {
        if(CollectionHelper.IsInList(m_ItemList, _index))
        {
            return m_ItemList[_index];
        }

        return null;
    }
}
