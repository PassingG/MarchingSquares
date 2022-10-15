using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelGrid : MonoBehaviour
{
    public int resolution;
    private bool[] voxels;

    private void Awake()
    {
        voxels = new bool[resolution * resolution];
    }
}
