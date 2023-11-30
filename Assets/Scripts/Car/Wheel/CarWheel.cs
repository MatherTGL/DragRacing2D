using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class CarWheel : MonoBehaviour
{
    [SerializeField, Required]
    private SpriteRenderer _wheelSprite;


    private void Start()
    {
        _wheelSprite = GetComponent<SpriteRenderer>();
    }
}
