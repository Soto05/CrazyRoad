using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVehicle : MonoBehaviour
{
    public float spanwTime;
    public GameObject vehicle;
    public Transform roadPos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnVehicleGround());
    }

    private IEnumerator SpawnVehicleGround()
    {

        yield return new WaitForSeconds(spanwTime);
        Vector3 vehiclePos = new Vector3(roadPos.transform.position.x,roadPos.transform.position.y+1,roadPos.transform.position.z+10);
        Instantiate(vehicle, vehiclePos, Quaternion.Euler(0,90,0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
