using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public bool enableSelectCharacter;
    public enum Player{Car1,Car2,Car3,Car4,Car5,Car6};//Esto es como un contructor y lo que esta dentro de llaves son
    public Player playerSelected;//En esta variable podemos escoger nuestras opciones
    public Animator animator;
    public int getChild;
    public RuntimeAnimatorController[] playerController;//Esto hace referencia al controlador del personaje



    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(4).gameObject.SetActive(false);
        transform.GetChild(5).gameObject.SetActive(false);
         if(!enableSelectCharacter)
        {
            ChangePlayerInMenu();//Para cambiar el personaje desde el juego
        }
        else
        {
            switch(playerSelected)
            {
                case Player.Car1:
                    transform.GetChild(0).gameObject.SetActive(true);
                    animator.runtimeAnimatorController = playerController[0];//Cambia el controlador
                break;
                case Player.Car2:
                    transform.GetChild(1).gameObject.SetActive(true);
                    animator.runtimeAnimatorController = playerController[1];//Cambia el controlador
                break;
                case Player.Car3:
                    transform.GetChild(2).gameObject.SetActive(true);
                    animator.runtimeAnimatorController = playerController[2];//Cambia el controlador
                break;
                case Player.Car4:
                    transform.GetChild(3).gameObject.SetActive(true);
                    animator.runtimeAnimatorController = playerController[3];//Cambia el controlador
                break;
                case Player.Car5:
                    transform.GetChild(4).gameObject.SetActive(true);
                    animator.runtimeAnimatorController = playerController[4];//Cambia el controlador
                break;
                case Player.Car6:
                    transform.GetChild(5).gameObject.SetActive(true);
                    animator.runtimeAnimatorController = playerController[5];//Cambia el controlador
                break;
                default:
                   break;
            }
        }


        
    }

    public void ChangePlayerInMenu()
    {
        switch(PlayerPrefs.GetString("PlayerSelected"))//Este verificara que valor tiene nuestra 
        //variable PlayerPrefs la variable es PlayerSelected 
        {
            case "Car1":
                transform.GetChild(0).gameObject.SetActive(true);
                animator.runtimeAnimatorController = playerController[0];//Cambia el controlador
            break;
            case "Car2":
                transform.GetChild(1).gameObject.SetActive(true);
                animator.runtimeAnimatorController = playerController[1];//Cambia el controlador
            break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
