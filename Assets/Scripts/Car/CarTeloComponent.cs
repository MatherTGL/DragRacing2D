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
        Debug.Log($"color {color}");
        if (spriteRenderer != null)
        {
            spriteRenderer.color = color;
        }
        else
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = color;
        }
    }
}
