using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    public void RespawnPoint()
    {
        transform.position = spawnPoint.position;
    }
}
