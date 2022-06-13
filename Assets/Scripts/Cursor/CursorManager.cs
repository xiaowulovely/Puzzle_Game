using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : Singleton<CursorManager>
{
    private Vector3 mouseWorldPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    private bool canClick;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        if (TransitionManager.Instance.isFade) return;

        canClick = OnjectAtMousePosition();
        if(canClick&&Input.GetMouseButtonDown(0))
        {
            ClickAction(OnjectAtMousePosition().gameObject);
        }
    }
    //Êó±êµã»÷
    private void ClickAction(GameObject _clickObject)
    {
        switch (_clickObject.tag)
        {
            case "Teleport":
                var teleport = _clickObject.GetComponent<Teleport>();
                teleport?.TeleportToScene();
                break;
            case "Item":
                var item = _clickObject.GetComponent<Item>();
                item?.ItemClick();
                break;
        }
    }

    private Collider2D OnjectAtMousePosition()
    {
        return Physics2D.OverlapPoint(mouseWorldPos);
    }
}
