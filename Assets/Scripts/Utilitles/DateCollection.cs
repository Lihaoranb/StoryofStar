using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ItemDetails
{
    public int itemID;
    public string itemName;
    public ItemType itemType;
    public Sprite itemIcon;
    public Sprite itemOnWorldSprite;
    public string itemDescription;
    public int itemUseRadius;
    public bool canCarried;
    public bool canPickedup;
    public bool canDropped;
}



[System.Serializable]
public struct InventoryItem
{
    public int itemID;
    public int itemAmount;
}
[System.Serializable]
public class TileProperty
{
    public Vector2Int tileCoordinate;
    public bool boolTypeValue;
    public GridType gridType;
}
