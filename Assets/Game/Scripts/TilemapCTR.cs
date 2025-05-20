using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapCTR : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase replaceTile;
    public TileBase placeTile;
    public Sprite sprite1;
    public Sprite sprite2;

    private GameObject target;

    void Start()
    {

    }
    
    void Pushed()
    {
        foreach (var pos in tilemap.cellBounds.allPositionsWithin)
        {
            Vector3Int cellPosition = new Vector3Int(pos.x, pos.y, pos.z);
            if (tilemap.HasTile(cellPosition))
            {
                if (tilemap.GetSprite(cellPosition) == sprite1)
                {
                    tilemap.SetTile(cellPosition, replaceTile);
                }
                else if (tilemap.GetSprite(cellPosition) == sprite2)
                {
                    tilemap.SetTile(cellPosition, placeTile);
                }
            }
        }
    }
}
