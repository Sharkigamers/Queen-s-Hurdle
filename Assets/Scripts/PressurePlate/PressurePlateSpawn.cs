using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateSpawn : MonoBehaviour
{
    MeshCollider _plateCollider;
    public GameObject _box;

    void Start()
    {
        _plateCollider = GetComponent<MeshCollider>();
    }

    void OnTriggerEnter(Collider col) {
        Instantiate(_box, new Vector3(10, 4, 4), Quaternion.identity);
    }
}
