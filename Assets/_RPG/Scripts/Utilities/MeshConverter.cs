using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshConverter : MonoBehaviour
{
    [ContextMenu("Convert Mesh")]
    public void Convert()
    {
        MeshFilter newMeshFilter =  gameObject.AddComponent<MeshFilter>();
        MeshRenderer newMeshRenderer = gameObject.AddComponent<MeshRenderer>();

        SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();

        newMeshFilter.sharedMesh = skinnedMeshRenderer.sharedMesh;
        newMeshRenderer.sharedMaterial = skinnedMeshRenderer.sharedMaterial;

        DestroyImmediate(skinnedMeshRenderer);
        DestroyImmediate(this);
    }
}
