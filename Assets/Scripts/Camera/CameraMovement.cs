using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float smoothSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate() {
        if (target.activeSelf) {
            Vector3 desiredPostion = target.transform.position - offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPostion, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
