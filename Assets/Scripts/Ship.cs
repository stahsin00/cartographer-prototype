public class Ship
{
    public int Size { get; private set; }

    private Tile [,] tiles;

    public Ship (int size) {
        Size = size;
        tiles = new Tile [Size,Size];

        for (int x = 0; x < Size; x++) {
            for (int y = 0; y < Size; y++) {
                tiles [x, y] = new Tile(x, y);
            }
        }
    }

    public Tile GetTile(int x, int y) {
        return tiles [x, y];
    }

    public Tile this[int x, int y] {
        get 
        { 
            return tiles [x, y];
        }
    }
}
