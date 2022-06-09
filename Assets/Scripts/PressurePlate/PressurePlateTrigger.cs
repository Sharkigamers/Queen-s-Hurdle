using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateTrigger : MonoBehaviour
{
    MeshCollider _plateCollider;
    Transform _plateTransform;
    public GameObject _tile;
    public GameObject _wall;
    public float speed = 1f;
    public float tileSpeed = 1f;
    public float plateformSpeed = 1f;
    public float finishSpeed = 2.5f;

    void Start()
    {
        _plateCollider = GetComponent<MeshCollider>();
        _plateTransform = GetComponent<Transform>();
    }

    void OnTriggerStay(Collider col) {
        float distance = Vector3.Distance(_plateTransform.position, col.transform.position);

        if (distance < 0.7f && !col.CompareTag("Player")) {
            Rigidbody rig = col.GetComponent<Rigidbody>();
            rig.isKinematic = true;

            if (_tile.CompareTag("UpAndDown")) {
                    MoveTileUpAndDown();
                }
                else if (_tile.CompareTag("Spikes")) {
                    MoveTileDown();
                }
                else if (_tile.CompareTag("Platform")) {
                    MovePlateform();
                }
                else if (_tile.CompareTag("Finish")) {
                    _wall.SetActive(false);
                    MoveFinish();
                }
        }
    }

    private void MoveTileDown() {
        if (_tile.transform.position.y > 1.125752) {
            _tile.transform.Translate(Vector3.down * Time.deltaTime * speed);
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

    private void MoveFinish() {
        if (_tile.transform.position.z > -6.7) {
            _tile.transform.Translate(Vector3.back * Time.deltaTime * finishSpeed);
            Debug.Log(_tile.transform.position.z);
        }
        
    }
}
