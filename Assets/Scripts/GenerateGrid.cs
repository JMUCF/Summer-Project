using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    public GameObject blockObject;
    public Transform blockParent;
    public GameObject spawnPointObject;
    public GameObject[] spawnPointParents;
    private int worldSizeX = 31; //make sure world sizes are odd numbers so that spawn points get placed exactly in the center of things
    private int worldSizeZ = 31;
    private int noiseHeight = 4;
    private int gridOffset = 1;

    // Start is called before the first frame update
    void Start()
    {
        int counter = 0;
        int perlinLocation;
        perlinLocation = (int)Random.Range(-1000, 1000);
        for(int i = 0; i < worldSizeX; i++)
        {
            for(int j = 0; j < worldSizeZ; j++)
            {
                Vector3 pos = new Vector3(i * gridOffset, GenerateNoise(i + perlinLocation, j + perlinLocation, 8f) * noiseHeight, j * gridOffset);
                GameObject block = Instantiate(blockObject, pos, Quaternion.identity) as GameObject;
                block.transform.SetParent(blockParent);

                //disgusting if statement that spawns a spawnpoint object at the midpoint of each side of the map
                if((i == worldSizeX / 2 && j == 0) || (j == worldSizeZ / 2 && i == 0) || (i == worldSizeX / 2 && j == worldSizeZ - 1) || (i == worldSizeX - 1 && j == worldSizeZ / 2))
                {
                    Vector3 spawnPos = new Vector3(pos.x, pos.y + 2f, pos.z);
                    GameObject spawn = Instantiate(spawnPointObject, spawnPos, Quaternion.identity) as GameObject;
                    spawn.transform.SetParent(spawnPointParents[counter].transform);
                    counter++;
                }
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
