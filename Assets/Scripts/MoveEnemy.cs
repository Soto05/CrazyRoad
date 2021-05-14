using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;//Libreria para usar audio

public class MoveEnemy : MonoBehaviour
{
    private AudioSource sound;
    public bool isWood;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {  
        sound = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right*speed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
       if(!isWood)
       {
            if(other.CompareTag("Player"))
            {
                Debug.Log("Game Over");
                sound.Play();
            }

       }
       
    }

}
