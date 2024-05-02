using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public const int SHIP_SIZE = 16;

    public Sprite floorSprite;

    public Ship ship;

    Dictionary<Tile, GameObject> tileMap = new Dictionary<Tile, GameObject>();

    private static WorldController instance;
    public static WorldController Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            ship = new Ship(SHIP_SIZE);
            RenderShip();
        }
    }

    private void RenderShip() {
        for (int x = 0; x < ship.Size; x++) {
            for (int y = 0; y < ship.Size; y++) {
                Tile tile = ship[x,y];

				GameObject tileGO = new GameObject();

				tileMap.Add(tile, tileGO);

				tileGO.name = "Tile_" + x + "_" + y;
				tileGO.transform.position = new Vector3(tile.X, tile.Y, 0);
				tileGO.transform.SetParent(this.transform, true);

				SpriteRenderer sr = tileGO.AddComponent<SpriteRenderer>();
				sr.sprite = floorSprite;
            }
        }
    }
}
