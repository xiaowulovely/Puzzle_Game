using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public PlayerItemData_SO playerItemData;

    public Button LeftButton;
    public Button RightButton;

    public Image slot;

    public int currentIndex =0;

    private void OnEnable()
    {
        EventHandle.UpdateUIEvent += OnUpdateUIEvent;
    }

    private void Start()
    {
        UpdateButtonInteractable();
        ItemDetails item = playerItemData.GetItemDetailByIndex(currentIndex);
        if(item!=null)
            OnUpdateUIEvent(item, currentIndex);
    }


    private void OnDisable()
    {
        EventHandle.UpdateUIEvent -= OnUpdateUIEvent;
    }

    private void OnUpdateUIEvent(ItemDetails itemDetails,int index)
    {
        currentIndex = index;
        slot.sprite = itemDetails.itemSprite;
        slot.SetNativeSize();
        UpdateButtonInteractable();
    }

    private void UpdateButtonInteractable()
    {
        int count = playerItemData.GetItemCount();
        if (currentIndex< count - 1)
        {
            RightButton.interactable = true;
        }
        else
        {
            RightButton.interactable = false;
        }

        if(currentIndex>=1)
        {
            LeftButton.interactable = true;
        }
        else
        {
            LeftButton.interactable = false;
        }
    }

    public void NextItem()
    {
        ItemDetails item = playerItemData.GetItemDetailByIndex(currentIndex + 1);
        if(item!=null)
        {
            currentIndex += 1;
            OnUpdateUIEvent(item, currentIndex );
        }
    }

    public void PreItem()
    {
        ItemDetails item = playerItemData.GetItemDetailByIndex(currentIndex - 1);
        if (item != null)
        {
            currentIndex -= 1;
            OnUpdateUIEvent(item, currentIndex );
        }
    }
}
