using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemConfigDetail
{
    public NormalItem.eNormalType ItemType;
    public Sprite icon;
}

[CreateAssetMenu(fileName = "ItemConfig", menuName = "ScriptableObjects/ItemConfig", order = 1)]
public class ItemConfig : ScriptableObject
{
    public List<ItemConfigDetail> Items;
}
