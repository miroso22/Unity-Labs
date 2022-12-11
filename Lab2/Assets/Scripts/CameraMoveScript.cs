using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{
    private Transform player;
    private Vector3 relativeCameraPosition = new Vector3(0, 5, -6);
    
    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    void Update () 
    {
        transform.position = player.position + relativeCameraPosition;
    }
}
