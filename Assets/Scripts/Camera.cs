using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    GameObject player;
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        position.x = player.transform.position.x;
        position.y = player.transform.position.y;
        transform.position = position;

    }
}
