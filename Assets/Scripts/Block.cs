using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private int hitsRemaining = 10;

    private SpriteRenderer spriteRenderer;
    private TextMeshPro text;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        text = GetComponentInChildren<TextMeshPro>();
        UpdateVisualState();
    }

    private void UpdateVisualState()
    {
        text.SetText(hitsRemaining.ToString()); 
        spriteRenderer.color = Color.Lerp(Color.white, Color.red, hitsRemaining / 10f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitsRemaining--;

        if(hitsRemaining > 0)
            UpdateVisualState();
        else
            Destroy(gameObject);
    }
}
