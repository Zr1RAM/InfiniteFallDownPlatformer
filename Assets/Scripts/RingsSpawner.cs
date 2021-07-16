using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingsSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject RingPrefab;
    [SerializeField]
    int MaxNumberOfRingsPerTile;
    [SerializeField]
    float RingsVerticalOffsetDistance;
    List<Transform> Rings;
    public void SpawnRings(Transform cylinderTile)
    {
        if(Rings == null || Rings.Count == 0)
        {
            Rings = new List<Transform>();
            for (int i = 0; i < MaxNumberOfRingsPerTile; i++)
            {
                Vector3 RingPosition = cylinderTile.GetChild(2).position - new Vector3(0, RingsVerticalOffsetDistance * i, 0);
                GameObject TempRing = Instantiate(RingPrefab, RingPosition, Quaternion.identity);
                TempRing.transform.SetParent(cylinderTile.GetChild(2), true);
            }
        }
    }
}
