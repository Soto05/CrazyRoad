using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SpawnTerrain : MonoBehaviour
{
    public Text textMeter;
    public int minDistanceFromPlayer;
    public int maxRangeTerrain;//El maximo de terrenos que vamos a tener
    public Vector3 nowPosition = new Vector3 (0, 0, 0);//Este almacenara la posición actual pero al principio de juego siempre empieza en 0, 0, 0
    [SerializeField] private List<GameObject> terrains = new List<GameObject>();// La lista de los diferentes terrenos que tenemos
    [SerializeField] private List<GameObject> objects = new List<GameObject>();// La lista de los diferentes terrenos que tenemos
    private int nRandomGround;
    private int nRandomObjects;
    private int nRandomPosSpawnObjectZ;

    private int numberObjects=10;

    private List<GameObject> terrainsGenerates = new List<GameObject>();//Lista de los terrenos generados
    public Transform objectTerrains;//Carpeta para almacenar los terrenos
    void Start()
    {
        for (int i = 0; i < maxRangeTerrain; i++)//agrega los suelos del inicio
        {
            SpawnTerrainRandom(new Vector3(0,0,0), true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.W))
        // {
        //     SpawnTerrainRandom();
        // }
    }

    public void SpawnTerrainRandom(Vector3 playerPos, bool isStart)//Crea terrenos al hazar con la diferencia de la posicion x+1 
    {
        if((nowPosition.x-playerPos.x < minDistanceFromPlayer)||(isStart))//si superan la distancia del jugador al final empiece a generar más niveles
        {
            if(isStart)
            {
                nRandomGround=0;
            }
            else
            {
                nRandomGround=Random.Range(0, terrains.Count);   
            }
            GameObject terrain = Instantiate(terrains[nRandomGround], nowPosition, Quaternion.identity);
            terrain.transform.SetParent(objectTerrains);//Enviara los terrenos al padre (Terrains)
            terrainsGenerates.Add(terrain);
            textMeter.text=(nowPosition.x-29) +"m";
            if(nRandomGround==0)//Para crear onjetos aleatorios
            {   
                if (isStart)
                {
                    for (int i = 0; i < numberObjects/4; i++)
                    {
                        nRandomObjects=Random.Range(0,objects.Count);//Número de objeto
                        nRandomPosSpawnObjectZ=Random.Range(-12,-2);//Posición del objeto
                        Vector3 posSpawnObject= new Vector3 (nowPosition.x,nowPosition.y,nRandomPosSpawnObjectZ);
                        GameObject objectGrass = Instantiate(objects[nRandomObjects], posSpawnObject, Quaternion.identity);   
                        objectGrass.transform.SetParent(objectTerrains);
                        nRandomObjects=Random.Range(0,objects.Count);//Número de objeto
                        nRandomPosSpawnObjectZ=Random.Range(2,12);//Posición del objeto
                        posSpawnObject= new Vector3 (nowPosition.x,nowPosition.y,nRandomPosSpawnObjectZ);
                        objectGrass = Instantiate(objects[nRandomObjects], posSpawnObject, Quaternion.identity);   
                        objectGrass.transform.SetParent(objectTerrains);
                    }                    
                }
                else
                {
                    for (int i = 0; i < numberObjects; i++)
                    {
                        nRandomObjects=Random.Range(0,objects.Count);//Número de objeto
                        nRandomPosSpawnObjectZ=Random.Range(-20,20);//Posición del objeto
                        Vector3 posSpawnObject= new Vector3 (nowPosition.x,nowPosition.y,nRandomPosSpawnObjectZ);
                        GameObject objectGrass = Instantiate(objects[nRandomObjects], posSpawnObject, Quaternion.identity);   
                        objectGrass.transform.SetParent(objectTerrains);
                    }                    
                }
            }
            if(terrainsGenerates.Count> maxRangeTerrain)
            {
                Destroy(terrainsGenerates[0]);//Destruye el terreno
                terrainsGenerates.RemoveAt(0);//Elimina de la lista el terreno
            }
            nowPosition.x++;
            //Debug.Log(nowPosition.x);
            //Debug.Log(playerPos.x);
        }    
    }


}
