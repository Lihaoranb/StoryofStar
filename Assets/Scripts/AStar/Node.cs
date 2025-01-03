using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace LFarm.AStar
{
    public class Node : IComparable<Node>
    {
        // Start is called before the first frame update
        public Vector2Int gridPoition;
        public int gCost=0;
        public int hCost=0;
        public int FCost => gCost + hCost;

        public bool isObstacle = false;
        public Node parentNode;

        public Node(Vector2Int pos)
        {
            gridPoition = pos;
            parentNode = null;
        }

        public int CompareTo(Node other)
        {
            int result = FCost.CompareTo(other.FCost);
            if (result == 0)
            {
                result = hCost.CompareTo(other.hCost);
            }
            return result;
        }
    }
}
