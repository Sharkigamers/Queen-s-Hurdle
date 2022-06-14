using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collctible : MonoBehaviour
{
    public float delay;
    private Animator _animator;
    private AudioSource _audioSource;

    private void Start() {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            StartCoroutine(_Animate());
        }
    }

    private IEnumerator _Animate() {
        _animator.SetTrigger("Collect");
        _audioSource.Play();
        yield return new WaitForSeconds(delay);
        Object.Destroy(this.gameObject);
    }
}
