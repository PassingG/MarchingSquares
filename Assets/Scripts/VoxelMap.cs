using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMap : MonoBehaviour
{
    public float size = 2f;

    public int voxelResolution = 8;
    public int chunkResolution = 2;

    [SerializeField] private VoxelGrid voxelGridPrefab;

    private VoxelGrid[] chunks;
    private float chunkSize, voxelSize, halfSize;

    private void Awake()
    {
        halfSize = size * 0.5f;
        chunkSize = size / chunkResolution;
        voxelSize = chunkSize / voxelResolution;

        chunks = new VoxelGrid[voxelResolution * voxelResolution];
        for (int i = 0, y = 0; y < chunkResolution; y++)
        {
            for (int x = 0; x < chunkResolution; x++, i++)
            {
                CreateChunk(i, x, y);
            }
        }
    }

    private void CreateChunk(int i, int x, int y)
    {
        VoxelGrid chunk = Instantiate(voxelGridPrefab, transform) as VoxelGrid;
        chunk.InitVoxelGrid(voxelResolution, chunkSize);
        chunk.transform.localPosition = new Vector3(x * chunkSize - halfSize, y * chunkSize - halfSize);
        chunks[i] = chunk;
    }
}
