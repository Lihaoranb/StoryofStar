using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LFarm.AStar
{
    public class GridNode : MonoBehaviour
    {
        private int width;
        private int height;
        private Node[,] gridNode;

        public GridNode(int width,int height)
        {
            this.width = width;
            this.height = height;
            gridNode = new Node[width,height];
            for(int x = 0; x< width; x++)
            {
                for(int y = 0; y< height; y++)
                {
                    gridNode[x, y] = new Node(new Vector2Int(x, y));
                }
            }
        }
    }

}
