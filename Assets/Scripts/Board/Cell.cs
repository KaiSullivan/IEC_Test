﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int BoardX { get; private set; }

    public int BoardY { get; private set; }

    public Item Item { get; private set; }

    public Cell NeighbourUp { get; set; }

    public Cell NeighbourRight { get; set; }

    public Cell NeighbourBottom { get; set; }

    public Cell NeighbourLeft { get; set; }


    public bool IsEmpty => Item == null;

    public void Setup(int cellX, int cellY)
    {
        this.BoardX = cellX;
        this.BoardY = cellY;

        NeighbourUp = NeighbourRight = NeighbourBottom = NeighbourLeft = null;
    }

    public bool IsNeighbour(Cell other)
    {
        return BoardX == other.BoardX && Mathf.Abs(BoardY - other.BoardY) == 1 ||
            BoardY == other.BoardY && Mathf.Abs(BoardX - other.BoardX) == 1;
    }


    public void Free()
    {
        Item = null;
    }

    public void Assign(Item item)
    {
        Item = item;
        Item.SetCell(this);
    }

    public void ApplyItemPosition(bool withAppearAnimation)
    {
        Item.SetViewPosition(this.transform.position);

        if (withAppearAnimation)
        {
            Item.ShowAppearAnimation();
        }
    }

    internal void Clear()
    {
        if (Item != null)
        {
            Item.Clear();
            Item = null;
        }
    }

    internal bool IsSameType(Cell other)
    {
        return Item != null && other.Item != null && Item.IsSameType(other.Item);
    }

    internal void ExplodeItem()
    {
        if (Item == null) return;

        Item.ExplodeView();
        Item = null;
    }

    internal void AnimateItemForHint()
    {
        Item.AnimateForHint();
    }

    internal void StopHintAnimation()
    {
        Item.StopAnimateForHint();
    }

    internal void ApplyItemMoveToPosition()
    {
        Item.AnimationMoveToPosition();
    }

    public List<NormalItem.eNormalType> GetSurroundingNormalItemType()
    {
        List<NormalItem.eNormalType> result = new List<NormalItem.eNormalType>();

        if (NeighbourUp != null && NeighbourUp.Item != null && NeighbourUp.Item is NormalItem)
        {
            result.Add((NeighbourUp.Item as NormalItem).ItemType);
        }
        if (NeighbourBottom != null && NeighbourBottom.Item != null && NeighbourBottom.Item is NormalItem)
        {
            result.Add((NeighbourBottom.Item as NormalItem).ItemType);
        }
        if (NeighbourLeft != null && NeighbourLeft.Item != null && NeighbourLeft.Item is NormalItem)
        {
            result.Add((NeighbourLeft.Item as NormalItem).ItemType);
        }
        if (NeighbourRight != null && NeighbourRight.Item != null && NeighbourRight.Item is NormalItem)
        {
            result.Add((NeighbourRight.Item as NormalItem).ItemType);
        }

        return result;
    }


}
