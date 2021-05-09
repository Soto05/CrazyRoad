using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTerrain : MonoBehaviour
{
    public int maxRangeTerrain;//El maximo de terrenos que vamos a tener
    private Vector3 nowPosition = new Vector3 (0, 0, 0);//Este almacenara la posición actual pero al principio de juego siempre empieza en 0, 0, 0
    [SerializeField] private List<GameObject> terrains = new List<GameObject>();// La lista de los diferentes terrenos que tenemos
    // Start is called before the first frame update
    private List<GameObject> terrainsGenerates = new List<GameObject>();//Lista de los terrenos generados
    void Start()
    {
        for (int i = 0; i < maxRangeTerrain; i++)
        {
            SpawnTerrainRandom();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            SpawnTerrainRandom();
        }
    }

    private void SpawnTerrainRandom()//Crea terrenos al hazar con la diferencia de la posicion x+1 
    {
        GameObject terrain = Instantiate(terrains[Random.Range(0, terrains.Count)], nowPosition, Quaternion.identity);
        terrainsGenerates.Add(terrain);
        if(terrainsGenerates.Count> maxRangeTerrain)
        {
            Destroy(terrainsGenerates[0]);//Destruye el terreno
            terrainsGenerates.RemoveAt(0);//Elimin de la lista el terreno
        }
        nowPosition.x++;

    }
}
