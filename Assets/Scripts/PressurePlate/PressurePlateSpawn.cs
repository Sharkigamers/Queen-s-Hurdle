using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateSpawn : MonoBehaviour
{
    BoxCollider _plateCollider;
    public GameObject _box;

    void Start()
    {
        _plateCollider = GetComponent<BoxCollider>();
    }

    void OnTriggerEnter(Collider col) {
            GameObject boxCp = _box;
            boxCp.GetComponent<Rigidbody>().isKinematic = false;
            Instantiate(boxCp, new Vector3(10, 4, 4), Quaternion.identity);
            _plateCollider.enabled = false;
    }
}
