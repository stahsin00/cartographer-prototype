using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public const int SHIP_SIZE = 16;

    public Sprite floorSprite;

    public Sprite blockSprite;
    public Sprite grassBlockSprite;

    public Ship ship;
    public World world;

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
				tileGO.transform.SetParent(transform, true);

				SpriteRenderer sr = tileGO.AddComponent<SpriteRenderer>();
				sr.sprite = floorSprite;
            }
        }
    }

    // TODO
    private void RenderWorld() {
        var (a, b, c, d) = RandomColor();

        for (int z = 0; z < world.Height; z++)
        {
            for (int x = 0; x < world.Width; x++)
            {
                for (int y = 0; y < world.Length; y++)
                {
                    Block block = world.GetBlockAt(x, y, z);

                    if ((block.GetBlockType() != Block.BlockType.Empty) && (world.isLit(x,y,z) || world.isEdge(x,y,z)))
                    {
                        GameObject blockGO = new GameObject();
                        blockGO.name = "Block_" + x + "_" + y + "_" + z;

                        float x_iso = (block.X - block.Y) / 2.0f;
                        float y_iso = ((block.X + block.Y) / 4.0f) + (block.Z / 2.0f);

                        blockGO.transform.position = new Vector3(x_iso, y_iso, 0);

                        SpriteRenderer sr = blockGO.AddComponent<SpriteRenderer>();

                        // TODO
                        if (block.GetBlockType() == Block.BlockType.Block)
                        {
                            sr.sprite = blockSprite;
                        } 
                        else if (block.GetBlockType() == Block.BlockType.Grass) {
                            sr.sprite = grassBlockSprite;
                            sr.material.color = Palette(0.32f, a, b, c, d);
                        }
                        else if (block.GetBlockType() == Block.BlockType.GrassyBlockLight)
                        {
                            sr.sprite = blockSprite;
                            sr.material.color = Palette(0.3f, a, b, c, d);
                        }
                        else if (block.GetBlockType() == Block.BlockType.GrassyBlockDark)
                        {
                            sr.sprite = blockSprite;
                            sr.material.color = Palette(0.31f, a, b, c, d);
                        }
                        else if (block.GetBlockType() == Block.BlockType.Tree)
                        {

                        }


                        int sortingOrder = -(int)(blockGO.transform.position.y * 100) + (z * 100);
                        sr.sortingOrder = sortingOrder;
                    }

                }
            }
        }
    }

    // TODO
    (Vector3 a, Vector3 b, Vector3 c, Vector3 d) RandomColor()
    {
        Vector3 a_ = new Vector3(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        Vector3 b_ = new Vector3(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        Vector3 c_ = new Vector3(Random.Range(0.0f, 3.0f), Random.Range(0.0f, 3.0f), Random.Range(0.0f, 3.0f));
        Vector3 d_ = new Vector3(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

        if ((c_.x * 2) % 1 != 0)
        {
            c_.x = Mathf.Round(c_.x);
        }

        if ((c_.y * 2) % 1 != 0)
        {
            c_.y = Mathf.Round(c_.y);
        }

        if ((c_.z * 2) % 1 != 0)
        {
            c_.z = Mathf.Round(c_.z);
        }

        return (a_, b_, c_, d_);
    }

    Color Palette(float t, Vector3 a, Vector3 b, Vector3 c, Vector3 d)
    {
        float x_ = (a.x + (b.x * (Mathf.Cos(2 * Mathf.PI * (c.x * t + d.x)))));
        float y_ = (a.y + (b.y * (Mathf.Cos(2 * Mathf.PI * (c.y * t + d.y)))));
        float z_ = (a.z + (b.z * (Mathf.Cos(2 * Mathf.PI * (c.z * t + d.z)))));

        return new Color(x_, y_, z_, 1);
    }
}
