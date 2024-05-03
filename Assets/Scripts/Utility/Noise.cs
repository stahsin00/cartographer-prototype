using UnityEngine;

public class Noise
{
    private int dimension;
    private float[,] cells;
    private float[,] noise;

    private float scale;
    private int octaves;
    private float persistence;
    private float lacunarity;

    public Noise(int dimension, float scale = 27.6f, int octaves = 4, float persistence = 0.5f, float lacunarity = 2.0f) {
        this.dimension = dimension;

        cells = new float[dimension, dimension];
        noise = new float[dimension, dimension];

        this.scale = scale;
        this.octaves = octaves;
        this.persistence = persistence;
        this.lacunarity = lacunarity;

        Initialize();
    }

    private void Initialize() {
        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        for (int x = 0; x < dimension; x++)
        {
            for (int y = 0; y < dimension; y++)
            {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;

                for (int i = 0; i < octaves; i++)
                {
                    float sampleX = (float)x / scale * frequency;
                    float sampleY = (float)y / scale * frequency;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;

                    noiseHeight += perlinValue * amplitude;
                    amplitude *= persistence;
                    frequency *= lacunarity;
                }

                if (noiseHeight > maxNoiseHeight)
                {
                    maxNoiseHeight = noiseHeight;
                }
                else if (noiseHeight < minNoiseHeight)
                {
                    minNoiseHeight = noiseHeight;
                }

                noise[x, y] = noiseHeight;
            }
        }

        for (int x = 0; x < dimension; x++)
        {
            for (int y = 0; y < dimension; y++)
            {
                cells[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noise[x, y]);
            }
        }
    }

    public float GetValue(int x, int y)
    {
        return cells[x, y];
    }
}
