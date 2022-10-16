using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class VoxelGrid : MonoBehaviour
{
    public GameObject voxelPrefab;
    public int resolution;

    private bool[] voxels;
    private float voxelSize;

    private Material[] voxelMaterials;

    public void InitVoxelGrid(int resolution, float size)
    {
        this.resolution = resolution;
        voxelSize = size / resolution;
        voxels = new bool[resolution * resolution];
        voxelMaterials = new Material[voxels.Length];

        for (int i = 0, y = 0; y < resolution; y++)
        {
            for (int x = 0; x < resolution; x++, i++)
            {
                CreateVoxel(i, x, y);
            }
        }
        SetVoxelColors();
    }

    public void SetVoxel(int x, int y, bool state)
    {
        voxels[y * resolution + x] = state;
        SetVoxelColors();
    }

    private void SetVoxelColors()
    {
        for (int i = 0; i < voxels.Length; i++)
        {
            voxelMaterials[i].color = voxels[i] ? Color.black : Color.white;
        }
    }

    private void CreateVoxel(int i, int x, int y)
    {
        GameObject voxelObject = Instantiate(voxelPrefab, transform) as GameObject;
        voxelObject.transform.localPosition = new Vector3((x + 0.5f) * voxelSize, (y + 0.5f) * voxelSize);
        voxelObject.transform.localScale = Vector3.one * voxelSize * 0.9f;
        voxelMaterials[i] = voxelObject.GetComponent<MeshRenderer>().material;
    }
}
