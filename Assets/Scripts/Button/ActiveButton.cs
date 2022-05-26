using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveButton : MonoBehaviour
{
    [SerializeField]
    private GameObject island;

    [SerializeField]
    private bool isTriggered = false;
    [SerializeField]
    private float verticalMovement;
    [SerializeField]
    private float smoothSpeed;

    private Vector3 maxPosition;
    private Vector3 minPosition;


    // Start is called before the first frame update
    void Start()
    {
        maxPosition = island.transform.position;
        minPosition = new Vector3(island.transform.position.x,
        island.transform.position.y - verticalMovement, island.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered && island.transform.position.y >= minPosition.y) {
            Vector3 newPosition = new Vector3(island.transform.position.x,
            island.transform.position.y - verticalMovement, island.transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(island.transform.position, newPosition, smoothSpeed);
            island.transform.position = smoothedPosition;
        } else if (!isTriggered && island.transform.position.y <= maxPosition.y) {
            Vector3 newPosition = new Vector3(island.transform.position.x,
            island.transform.position.y + verticalMovement, island.transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(island.transform.position, newPosition, smoothSpeed);
            island.transform.position = smoothedPosition;
        }
    }

    private void OnTriggerStay(Collider other) {
        isTriggered = true;
    }

    private void OnTriggerExit(Collider other) {
        isTriggered = false;
    }
}
