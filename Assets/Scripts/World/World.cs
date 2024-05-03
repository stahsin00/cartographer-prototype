using UnityEngine;

// TODO : cleanup
public class World
{
    public int Width { get; private set; }
    public int Length { get; private set; }
    public int Height { get; private set; }

    private Block[,,] blocks;

    private Noise noise;

    public World(int width = 64, int length = 64,  int height = 64)
    {
        Width = width;
        Length = length;
        Height = height;

        blocks = new Block[width,length,height];
        noise = new Noise(width);

        Initialize();
    }

    private void Initialize() {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Length; y++)
            {
                for (int z = 0; z < Height; z++)
                {
                    blocks[x, y, z] = new Block(this, x, y, z);
                    Block cur = blocks[x, y, z];

                    if (noise.GetValue(x,y) * Height >= z)
                    {
                        if (isLit(x, y, z))
                        {
                            if (Random.value > 0.5)
                            {
                                cur.SetBlockType(Block.BlockType.GrassyBlockLight);
                            }
                            else
                            {
                                cur.SetBlockType(Block.BlockType.GrassyBlockDark);
                            }
                        }
                        else
                        {
                            cur.SetBlockType(Block.BlockType.Block);
                        }
                    } else 
                    {
                        if (noise.GetValue(x, y) * Height >= z - 1)
                        {
                            float chance = Random.value;
                            if (chance < 0.2)
                            {
                                cur.SetBlockType(Block.BlockType.Tree);
                            } else if (chance < 0.7)
                            {
                                cur.SetBlockType(Block.BlockType.Grass);
                            } else
                            {
                                cur.SetBlockType(Block.BlockType.Empty);
                            }
                        } else {
                            cur.SetBlockType(Block.BlockType.Empty);
                        }
                    }
                }
            }
        }
    }

    public Block GetBlockAt(int x, int y, int z)
    {
        return blocks[x, y, z];
    }

    public bool isLit(int x, int y, int z)
    {
        if (noise.GetValue(x, y) * Height < z + 1)
        {
            return true;
        }

        if (x != 0 && noise.GetValue(x - 1, y) * Height < z)
        {
            return true;
        }

        if (x < Width - 1 && noise.GetValue(x + 1, y) * Height < z)
        {
            return true;
        }

        if (y != 0 && noise.GetValue(x, y - 1) * Height < z)
        {
            return true;
        }

        if (y < Length - 1 && noise.GetValue(x, y + 1) * Height < z)
        {
            return true;
        }

        return false;
    }

    public bool isEdge(int x, int y, int z)
    {
        return x == 0 || x == Width - 1 || y == 0 || y == Length - 1 || z == 0 || z == Height - 1;
    }
}
