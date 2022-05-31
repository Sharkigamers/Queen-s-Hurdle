using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateTrigger : MonoBehaviour
{
    MeshCollider _plateCollider;
    Transform _plateTransform;
    public GameObject _tile;
    public float speed = 2f;
    public float tileSpeed = 2f;
    public float plateformSpeed = 2f;
    //public bool pressed = false;

    void Start()
    {
        _plateCollider = GetComponent<MeshCollider>();
        _plateTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (pressed) {
            if (_tile.CompareTag("UpAndDown")) {
                MoveTileUpAndDown();
            }
            else if (_tile.CompareTag("Spikes") || _tile.CompareTag("Tile")) {
                MoveTileDown();
            }
            else if (_tile.CompareTag("Platform")) {
                MovePlateform();
            }
        }
        else {
            if (_tile.CompareTag("Tile") || _tile.CompareTag("UpAndDown")) {
                MoveTileUp();
            }
        }
        */
    }

    void OnTriggerStay(Collider col) {
        float distance = Vector3.Distance(_plateTransform.position, col.transform.position);
        Debug.Log("Distance" + distance);

        if (distance < 0.7f && !col.CompareTag("Player")) {
            Rigidbody rig = col.GetComponent<Rigidbody>();
            rig.isKinematic = true;

            if (_tile.CompareTag("UpAndDown")) {
                    MoveTileUpAndDown();
                }
                else if (_tile.CompareTag("Spikes") || _tile.CompareTag("Tile")) {
                    MoveTileDown();
                }
                else if (_tile.CompareTag("Platform")) {
                    MovePlateform();
                }
        }
    }

    /*void OnTriggerEnter(Collider col) {
        if (!_tile.CompareTag("Spikes") && !col.CompareTag("Player")) {
            pressed = true;
        }
        if (_tile.CompareTag("Spikes") && col.CompareTag("Player")) {
            pressed = true;
            _tile.GetComponent<BoxCollider>().enabled = false;
        }
    }

    void OnTriggerExit(Collider col) {
        pressed = false;
    } */

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

    private void MovePlateform() {
        if (_tile.transform.position.x < 8.494 || _tile.transform.position.x > 12.606) {
            plateformSpeed = plateformSpeed * -1;
        }
        _tile.transform.Translate(Vector3.right * Time.deltaTime * plateformSpeed);
    }

    private void MoveTileUpAndDown() {
        if (_tile.transform.position.y < 1.125752 || _tile.transform.position.y > 3.23) {
            tileSpeed = tileSpeed * -1;
        }
        _tile.transform.Translate(Vector3.up * Time.deltaTime * tileSpeed);
    }
}
