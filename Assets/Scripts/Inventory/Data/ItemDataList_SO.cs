using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName ="ItemDataList_SO",menuName ="Inventory/ItemDataList_SO")]
public class ItemDataList_SO : ScriptableObject
{
    public List<ItemDetails> itemDetails = new List<ItemDetails>();

    /// <summary>
    /// ���ݵ������ƻ�ȡ����
    /// </summary>
    /// <param name="_itemName"></param>
    /// <returns></returns>
    public ItemDetails GetItemDetail(string _itemName)
    {
        return itemDetails.Find(i=>i.itemName== _itemName);
    }
    /// <summary>
    /// ���ݵ���ID�Ż�ȡ����
    /// </summary>
    /// <param name="_itemID"></param>
    /// <returns></returns>
    public ItemDetails GetItemDetail(int _itemID)
    {
        return itemDetails.Find(i => i.ID == _itemID);
    }

}

[Serializable]
public class ItemDetails
{
    public int ID;
    public string itemName;
    public Sprite itemSprite;
    //public int count;
}