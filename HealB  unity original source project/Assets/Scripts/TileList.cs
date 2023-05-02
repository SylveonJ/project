using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileList : MonoBehaviour
{
    public List<Tile> tiles = new List<Tile>();

    public TileList(List<Tile> tiles = null)
    {
        if (tiles!=null)
        {
            foreach(var tile in tiles)
            {
                this.tiles.Add(tile);
            }
        }
    }

}
