using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallReturn : MonoBehaviour
{
    private BallLauncher BallLauncher;

    private void Awake()
    {
        BallLauncher =  FindAnyObjectByType<BallLauncher>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallLauncher.ReturnBall();
        collision.collider.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
