using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int angleRotation=90;
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
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && !isJump)
        {
            float zDifference=0;
            if(transform.position.z%1 != 0)//Si no esta alineado le ra
            {
                zDifference = Mathf.Round(transform.position.z)-transform.position.z;
                //Debug.Log(Mathf.Round(transform.position.z));
                //Debug.Log(transform.position.z);
                //Debug.Log(zDifference);
            }
            MovePlayer(new Vector3(1,0,zDifference), 0);//Le suma la diferencia para que quede en un número entero
        }
        else if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && !isJump)
        {
            if(transform.position.z < zRange)
            {
                MovePlayer(new Vector3(0,0,1), -angleRotation);
            }
            else 
            {
                MovePlayer(new Vector3(0,0,0), -angleRotation);//Se queda en la misma position
            }            
        }
        else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && !isJump)
        {
            if(transform.position.z > -zRange)
            {
                MovePlayer(new Vector3(0,0,-1), angleRotation);
            }
            else 
            {
                MovePlayer(new Vector3(0,0,0),angleRotation);//Se queda en la misma position
            }
        }
        if (Input.GetKeyUp(KeyCode.W)||Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D)|| Input.GetKeyUp(KeyCode.UpArrow)|| Input.GetKeyUp(KeyCode.RightArrow)|| Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("jump", false);
            isJump=false;
        }
    }

    private void MovePlayer(Vector3 difference, int rotation)
    {
        animator.SetBool("jump", true);
        isJump = true;
        transform.position = (transform.position + difference);
        terrainGenerator.SpawnTerrainRandom(transform.position, false);
        transform.rotation = Quaternion.Euler(0,rotation,0);//Esto sirve para la rotación del objeto en 3d
    }
}
