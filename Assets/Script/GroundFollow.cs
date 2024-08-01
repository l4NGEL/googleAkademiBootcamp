using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundFollow : MonoBehaviour
{
    public Transform groundMask; // Karakterin alt�na ekledi�imiz bir bo� obje
    public float groundDistance = 0.4f; // Yerden belirli bir mesafe

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        RaycastHit hit;
        // Karakterin alt�na do�ru raycast at�yoruz
        if (Physics.Raycast(groundMask.position, Vector3.down, out hit, groundDistance))
        {
            Vector3 newPosition = hit.point;
            newPosition.y += groundDistance; // Karakteri hafif�e yerden yukar� kald�r�yoruz
            transform.position = newPosition;
        }
    }
}

