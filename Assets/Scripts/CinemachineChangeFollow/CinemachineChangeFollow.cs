using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Player.Movement;
using UnityEngine;

public class CinemachineChangeFollow : MonoBehaviour
{
    private void Start()
    {
        var cinemachine = FindObjectOfType<CinemachineVirtualCamera>();
        var player = FindObjectOfType<PlayerMovementControl>().transform;
        cinemachine.Follow = player;
        cinemachine.LookAt = player;
    }
}
