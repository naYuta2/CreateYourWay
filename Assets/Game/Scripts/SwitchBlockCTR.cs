using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SwitchBlockCTR : MonoBehaviour
{
    public Sprite sprite;
    public Tilemap tilemap;
    public TilemapCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var pos in tilemap.cellBounds.allPositionsWithin)
        {
            Vector3Int cellPosition = new Vector3Int(pos.x, pos.y, pos.z);
            if (tilemap.HasTile(cellPosition))
            {
                if (tilemap.GetSprite(cellPosition) == sprite)
                {
                    col.enabled = false;
                }
                else
                {
                    col.enabled = true;
                }
            }
        }
    }
}
