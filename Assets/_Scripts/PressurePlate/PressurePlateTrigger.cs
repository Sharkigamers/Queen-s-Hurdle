using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateTrigger : MonoBehaviour
{
    MeshCollider _plateCollider;
    public GameObject _tile;
    public float speed = 2f;
    public bool pressed = false;

    void Start()
    {
        _plateCollider = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed) {
            MoveTileDown();
        }
        else {
            MoveTileUp();
        }
    }

    void OnTriggerEnter(Collider col) {
        Debug.Log("Tamer");
        pressed = true;
    }

    void OnTriggerExit(Collider col) {
        Debug.Log("Down");
        pressed = false;
    }

    private void MoveTileDown() {
        if (_tile.transform.position.y > 1.125752) {
            _tile.transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
    }

    private void MoveTileUp() {
        if (_tile.transform.position.y < 3.23) {
            _tile.transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
    }
}
