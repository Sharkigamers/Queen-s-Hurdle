using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearTower : MonoBehaviour
{
    public string levelName;
    private Animator animator;

    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            _appear();
    }

    private void _appear() {
        animator.SetTrigger("Appear");
    }
}
