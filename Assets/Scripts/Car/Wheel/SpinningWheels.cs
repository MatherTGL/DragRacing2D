using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class SpinningWheels : MonoBehaviour
{
    [SerializeField, Required]
    private Rigidbody2D _carPlayerRigidbody;


    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, _carPlayerRigidbody.velocity.x));
    }
}
