using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTeloComponent : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeColor(Color color)
    {
        spriteRenderer.color = color;
    }
}
