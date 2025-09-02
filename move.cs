using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Transform player;
    Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0.0f, 0.0f, 11);
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, 0) + offset;
    }
}
