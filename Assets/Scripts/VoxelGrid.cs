using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelGrid : MonoBehaviour
{
    public GameObject voxelPrefab;
    public int resolution;

    private bool[] voxels;
    private float voxelSize;

    private void Awake()
    {
        voxelSize = 1f / resolution;
        voxels = new bool[resolution * resolution];

        InitVoxelGrid();
    }

    private void InitVoxelGrid()
    {
        for (int i = 0, y = 0; y < resolution; y++)
        {
            for (int x = 0; x < resolution; x++, i++)
            {
                CreateVoxel(i, x, y);
            }
        }
    }

    private void CreateVoxel(int i, int x, int y)
    {
        GameObject voxelObject = Instantiate(voxelPrefab, transform) as GameObject;
        voxelObject.transform.localPosition = new Vector3((x + 0.5f) * voxelSize, (y + 0.5f) * voxelSize);
        voxelObject.transform.localScale = Vector3.one * voxelSize;
    }
}
