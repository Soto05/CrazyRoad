using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed=Random.Range(1,5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right*speed*Time.deltaTime);
    }
}
