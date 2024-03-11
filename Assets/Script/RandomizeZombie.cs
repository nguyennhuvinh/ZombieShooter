using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeZombie : MonoBehaviour
{
    public Material[] zombieMaterials;

    void Start()
    {
        SkinnedMeshRenderer myRenderer = GetComponent<SkinnedMeshRenderer>();
        myRenderer.material = zombieMaterials[Random.Range(0,zombieMaterials.Length)];
    }
}
