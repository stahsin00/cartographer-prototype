public class Block
{
    public enum BlockType { Empty, Block, Grass, GrassyBlockLight, GrassyBlockDark, Tree}; // TODO

    private BlockType type = BlockType.Empty;

    private World world;

    public int X { get; private set; }
    public int Y { get; private set; }
    public int Z { get; private set; }

    public Block(World world, int x, int y, int z)
    {
        this.world = world;

        X = x;
        Y = y;
        Z = z;
    }

    public BlockType GetBlockType()
    {
        return type;
    }

    public void SetBlockType(BlockType type)
    {
        this.type = type;
    }
}
