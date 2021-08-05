using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rightRigidbody;

    [SerializeField]
    private Rigidbody leftRigidbody;

    private BoxCollider collider;

    private void Start()
    {
        collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        collider.enabled = false;

        rightRigidbody.isKinematic = false;
        leftRigidbody.isKinematic = false;
    }

}
