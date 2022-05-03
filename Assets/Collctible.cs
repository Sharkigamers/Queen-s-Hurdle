using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collctible : MonoBehaviour
{
    public float delay;
    private Animator _animator;

    private void Start() {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            StartCoroutine(_Animate());
        }
    }

    private IEnumerator _Animate() {
        _animator.SetTrigger("Collect");
        yield return new WaitForSeconds(delay);
        transform.gameObject.SetActive(false);
    }
}
