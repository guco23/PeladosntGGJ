using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    #region references


    [SerializeField] private Transform[] placeSpawnPoints;

    [SerializeField] private Transform[] objectSpawnPoints;

    [SerializeField] private Transform[] obstaclesSpawnPoints;

    [SerializeField] private GameObject[] placePrefabs;

    [SerializeField] private GameObject[] objectPrefabs;

    [SerializeField] private GameObject[] obstaclesPrefabs;

    #endregion




    #region methods



    private int[] RandomArrayNoReps(int size)
    {
        int[] prefabsOrder = new int[size];

        List<int> list = new List<int>();   //  Declare list

        for (int n = 0; n < size; n++)    //  Populate list
        {
            list.Add(n);
        }

        for(int n = 0; n < prefabsOrder.Length; n++)
        {
            int index = Random.Range(0, list.Count - 1);    //  Pick random element from the list
            prefabsOrder[n] = list[index];    //  i = the number that was randomly picked
            list.RemoveAt(index);   //  Remove chosen element
        }
        
        return prefabsOrder;

    }


    #endregion

    // Start is called before the first frame update
    void Start()
    {
        int[] placesOrder = RandomArrayNoReps(placePrefabs.Length);

        int[] objectOrder = RandomArrayNoReps(objectPrefabs.Length);

        int[] obstaclesOrder = RandomArrayNoReps(obstaclesPrefabs.Length);

        for(int i = 0; i < placesOrder.Length; i++)
        {

            Instantiate(placePrefabs[placesOrder[i]], placeSpawnPoints[i].position, Quaternion.identity);

        }

        for (int i = 0; i < objectOrder.Length; i++)
        {

            Instantiate(objectPrefabs[objectOrder[i]], objectSpawnPoints[i].position, Quaternion.identity);

        }

        for (int i = 0; i < obstaclesOrder.Length; i++)
        {

            Instantiate(obstaclesPrefabs[obstaclesOrder[i]], obstaclesSpawnPoints[i].position, Quaternion.identity);

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
