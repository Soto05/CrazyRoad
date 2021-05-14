using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckobjectDown : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool checkObjectTouch=false;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Tree")||other.CompareTag("Rock1"))
        {
            checkObjectTouch=true;
        }
    }

    private void OnTriggerExit(Collider other) {
         if (other.CompareTag("Tree")||other.CompareTag("Rock1"))
        {
            checkObjectTouch=false;
        }
    }
    
}
