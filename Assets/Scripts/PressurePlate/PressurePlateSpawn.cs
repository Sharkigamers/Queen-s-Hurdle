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
        GameObject boxCp = _box;
        boxCp.GetComponent<Rigidbody>().isKinematic = false;
        Instantiate(boxCp, new Vector3(10, 4, 4), Quaternion.identity);
    }
}
