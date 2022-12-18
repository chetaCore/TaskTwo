using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private List<GameObject> _createdObjects;
    [SerializeField] private int _objectsCount;
    [Range(0,2)]
    [SerializeField] private float _creationRadius;

    private void Start()
    {
        CreatingObjects();
    }

    private void CreatingObjects()
    {
        for (int i = 0; i < _objectsCount; i++)
        {
            var index = Random.Range(0, _createdObjects.Count);
            var radius = Random.Range(-_creationRadius, _creationRadius + 1);
            var creationPosition = new Vector3(radius, radius, 0);

            Instantiate(_createdObjects[index], transform.position + creationPosition, Quaternion.identity, transform);
        }


    }


}
