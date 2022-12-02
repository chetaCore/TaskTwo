using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private List<GameObject> createdObjects;
    [SerializeField] private int objectsCount;
    [Range(0,2)]
    [SerializeField] private float creationRadius;



    private void Start()
    {
        CreatingObjects();
    }

    private void CreatingObjects()
    {
        for (int i = 0; i < objectsCount; i++)
        {
            var index = Random.Range(0, createdObjects.Count);
            var radius = Random.Range(-creationRadius, creationRadius + 1);
            var creationPosition = new Vector3(radius, radius, 0);

            Instantiate(createdObjects[index], transform.position + creationPosition, Quaternion.identity, transform);
            
        }


    }


}
