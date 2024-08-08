using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField]
    private Block blockPrefab;

    private void OnEnable()
    {
        for(int i = 0; i < 3; i++)
        {
            SpawnRowOfBlocks();
        }
    }

    private void SpawnRowOfBlocks()
    {
        
    }
}
