using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVehicle : MonoBehaviour
{
    public int speedEnemyValue;
    public float spanwTimeMin;
    public float spanwTimeMax;
    private float spanwTime;

    public GameObject vehicle;
    public Transform roadPos;
    private MoveEnemy speedEnemy;
    // Start is called before the first frame update
    private void Start()
    {
        spanwTime=Random.Range(spanwTimeMin,spanwTimeMax);
        InvokeRepeating("SpawnVehicleGround", 1,spanwTime);
    }

    void SpawnVehicleGround()
    {
        Instantiate(vehicle, roadPos.position, Quaternion.Euler(0,90,0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
