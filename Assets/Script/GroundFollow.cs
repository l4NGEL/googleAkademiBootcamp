using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundFollow : MonoBehaviour
{
    public Transform groundMask; // Karakterin altýna eklediðimiz bir boþ obje
    public float groundDistance = 0.4f; // Yerden belirli bir mesafe

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        RaycastHit hit;
        // Karakterin altýna doðru raycast atýyoruz
        if (Physics.Raycast(groundMask.position, Vector3.down, out hit, groundDistance))
        {
            Vector3 newPosition = hit.point;
            newPosition.y += groundDistance; // Karakteri hafifçe yerden yukarý kaldýrýyoruz
            transform.position = newPosition;
        }
    }
}

