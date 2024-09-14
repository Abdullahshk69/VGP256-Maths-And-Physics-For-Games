using UnityEngine;

public class SinCosLandscape : MonoBehaviour
{
    public Terrain terrain;
    public int width = 100;
    public int height = 100;
    public float scale = 10f;

    public float strength = 1f;

    void Start()
    {
        float[,] heightMap = new float[width, height];
        GenerateTerrain(heightMap, scale);
        ApplyHeightMap(heightMap);
        ApplyRandomColorTexture();
    }

    void GenerateTerrain(float[,] terrain, float scale)
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float xCoord = (float)x / width * scale;
                float yCoord = (float)y / height * scale;
                float sample = Mathf.PerlinNoise(xCoord, yCoord);
                terrain[x, y] = sample * strength;
            }
        }
    }

    void ApplyHeightMap(float[,] heightMap)
    {
        TerrainData terrainData = terrain.terrainData;
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, scale, height);

        float[,] heights = new float[height, width];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                heights[y, x] = heightMap[x, y] / scale;
            }
        }
        terrainData.SetHeights(0, 0, heights);
    }

    void ApplyRandomColorTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Color randomColor = new Color(Random.value, Random.value, Random.value);
                texture.SetPixel(x, y, randomColor);
            }
        }

        texture.Apply();

        Material terrainMaterial = new Material(Shader.Find("Standard"));
        terrainMaterial.mainTexture = texture;

        terrain.materialTemplate = terrainMaterial;
    }
}
