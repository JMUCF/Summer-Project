using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    public GameObject blockObject;
    private int worldSizeX = 40;
    private int worldSizeZ = 40;
    private int noiseHeight = 4;
    private int gridOffset = 1;
    private int perlinLocation;

    // Start is called before the first frame update
    void Start()
    {
        perlinLocation = (int)Random.Range(-1000, 1000);
        for(int i = 0; i < worldSizeX; i++)
        {
            for(int j = 0; j < worldSizeZ; j++)
            {
                Vector3 pos = new Vector3(i * gridOffset, GenerateNoise(i + perlinLocation, j + perlinLocation, 8f) * noiseHeight, j * gridOffset);
                GameObject block = Instantiate(blockObject, pos, Quaternion.identity) as GameObject;
                block.transform.SetParent(this.transform);
            }
        }
    }

    private float GenerateNoise(int i, int j, float detailScale)
    {
        float iNoise = (i + this.transform.position.x) / detailScale;
        float jNoise = (j + this.transform.position.y) / detailScale;

        return Mathf.PerlinNoise(iNoise, jNoise);
    }
}
