using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int zRange;//Limite en Z
    public SpawnTerrain terrainGenerator;
    private Animator animator;
    private bool isJump;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isJump)
        {
            float zDifference=0;
            if(transform.position.z%1 != 0)//Si no esta alineado le ra
            {
                zDifference = Mathf.Round(transform.position.z)-transform.position.z;
                //Debug.Log(Mathf.Round(transform.position.z));
                //Debug.Log(transform.position.z);
                //Debug.Log(zDifference);
            }
        MovePlayer(new Vector3(1,0,zDifference));//Le suma la diferencia para que quede en un número entero
        }
        else if (Input.GetKeyDown(KeyCode.A) && !isJump)
        {
            if(transform.position.z < zRange)
            {
                MovePlayer(new Vector3(0,0,1));
            }
            else 
            {
                MovePlayer(new Vector3(0,0,0));//Se queda en la misma position
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.D) && !isJump)
        {
            if(transform.position.z > -zRange)
            {
                MovePlayer(new Vector3(0,0,-1));
            }
            else 
            {
                MovePlayer(new Vector3(0,0,0));//Se queda en la misma position
            }
        }

        if (Input.GetKeyUp(KeyCode.W)||Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("jump", false);
            isJump=false;
        }
    }

    private void MovePlayer(Vector3 difference)
    {
        animator.SetBool("jump", true);
        isJump = true;
        transform.position = (transform.position + difference);
        terrainGenerator.SpawnTerrainRandom(transform.position, false);
    }
}
