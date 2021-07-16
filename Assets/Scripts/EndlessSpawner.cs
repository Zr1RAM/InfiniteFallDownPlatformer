using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessSpawner : MonoBehaviour
{
    [SerializeField]
    Vector3 StartingTilePosition;
    [SerializeField]
    GameObject CylinderTile;
    [SerializeField]
    int NumberOfEndlessTiles; // For this project the value will always be 2
    [HideInInspector]
    public Vector3 nextSpawnLocation;
    public static EndlessSpawner endlessSpawnerManager;
    Transform[] Tiles;
    RingsSpawner RingsManager;
    void Start()
    {
        if(endlessSpawnerManager == null)
        {
            endlessSpawnerManager = this;
            RingsManager = FindObjectOfType<RingsSpawner>();
        }
        SpawnTile();
    }
    float SpawnHeightDistance;
    public void SpawnTile()
    {
        Tiles = new Transform[NumberOfEndlessTiles];
        Tiles[0] = Instantiate(CylinderTile, StartingTilePosition, Quaternion.identity).transform;
        Tiles[0].SetParent(transform, true);
        RingsManager.SpawnRings(Tiles[0]);
#if UNITY_EDITOR
        Tiles[0].name = "Tiles1";
#endif
        SpawnHeightDistance = Vector3.Distance(Tiles[0].transform.position, Tiles[0].GetChild(1).transform.position);
        print(Vector3.Distance(Tiles[0].transform.position, Tiles[0].GetChild(1).transform.position));
        for (int i = 1; i < NumberOfEndlessTiles; i++)
        {
            Vector3 newSpawnPosition = Tiles[i-1].position;
            newSpawnPosition = new Vector3(newSpawnPosition.x,newSpawnPosition.y + SpawnHeightDistance * 2, newSpawnPosition.z);
            Tiles[i] = Instantiate(CylinderTile, newSpawnPosition, Quaternion.identity).transform;
            Tiles[i].SetParent(transform, true);
            RingsManager.SpawnRings(Tiles[i]);
#if UNITY_EDITOR
            Tiles[i].name = "Tiles" + (i+1).ToString();
#endif
        }
    }
    // Tried to make an array with size more than 2 for future-proofing SpawnTile but due to time constraints
    // This function will work with swapping between only 2 tiles
    bool TileSwapSwitch = false;
    public void SwapLastTilePosition()
    {
        TileSwapSwitch = !TileSwapSwitch;
        if(TileSwapSwitch)
        {
            Tiles[1].position = new Vector3(Tiles[0].position.x,Tiles[0].position.y - (SpawnHeightDistance * 2), Tiles[0].position.z);
            Tiles[1].GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            Tiles[0].position = new Vector3(Tiles[1].position.x, Tiles[1].position.y - (SpawnHeightDistance * 2), Tiles[1].position.z);
            Tiles[0].GetChild(0).gameObject.SetActive(true);
        }
    }

// Just to test if swapLastTileposition works as intended
#if UNITY_EDITOR
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SwapLastTilePosition();
        }
    }
#endif
    public void TurnEndlessPipe(float val)
    {
        transform.Rotate(0, val, 0);
    }
}