using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public float smoothness;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(player.transform.position + offset, transform.position, smoothness);
        //Esta linea de codigo lo que hace es darle un efecto a la camara más suave
    }
}
