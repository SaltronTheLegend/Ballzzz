using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    private Vector3 startDragPosition;
    private Vector3 endDragPosition;
    private BlockSpawner blockSpawner;
    private LauncherPreview launcherPreview;
    private List<Ball> balls = new();
    private int ballsReady;
      

    [SerializeField]
    private Ball ballPrefab;

    private void Awake()
    {
        blockSpawner = FindObjectOfType<BlockSpawner>();
        launcherPreview = GetComponent<LauncherPreview>();
        CreateBall();
        
    }

    public void ReturnBall()
    {
        ballsReady++;
        if ( ballsReady == balls.Count)
        {
            blockSpawner.SpawnRowOfBlocks();
            CreateBall();
        }
    }

    private void CreateBall()
    {
        var ball = Instantiate(ballPrefab);
        balls.Add(ball);
        ballsReady++;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Vector3.back * -10;

        if (Input.GetMouseButtonDown(0))
        {
            StartDrag(worldPosition);
        }
        else if (Input.GetMouseButton(0))
        {
            ContinueDrag(worldPosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }
    }

    private void EndDrag()
    {
        StartCoroutine(LauncchBalls());
    }

    private IEnumerator LauncchBalls()
    {
        Vector3 direction = endDragPosition - startDragPosition;
        direction.Normalize();

        foreach (var ball in balls)
        {
            ball.transform.position = transform.position;
            ball.gameObject.SetActive(true);
            ball.GetComponent<Rigidbody2D>().AddForce(-direction);

            yield return new WaitForSeconds(0.1f);
        } 
        ballsReady = 0;  
    }

    private void ContinueDrag(Vector3 worldPosition)
    {
        endDragPosition = worldPosition;
        Vector3 direction = endDragPosition - startDragPosition;
        launcherPreview.SetEndPoint(transform.position - direction);
    }

    private void StartDrag(Vector3 worldPosition)
    {
        startDragPosition = worldPosition;
        launcherPreview.SetStartPoint(transform.position);
    }

}
