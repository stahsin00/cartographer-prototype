public class Ship
{
    public int Size { get; private set; }

    private Tile [,] tiles;

    public Ship (int size) {
        Size = size;

        for (int x = 0; x < Size; x++) {
            for (int y = 0; y < Size; y++) {
                tiles [x, y] = new Tile(x, y);
            }
        }
    }
}
