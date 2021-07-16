using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLocationSpawner : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            EndlessSpawner.endlessSpawnerManager.SwapLastTilePosition();
            gameObject.SetActive(false);
        }
    }
}
