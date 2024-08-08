using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;

    [SerializeField]
    private float moveSpeed = 10;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        rigidbody2d.velocity  = rigidbody2d.velocity.normalized * moveSpeed;
    }
}
