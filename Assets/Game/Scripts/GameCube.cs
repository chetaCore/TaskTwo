using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TypesSet;

public class GameCube : MonoBehaviour
{
    [SerializeField] private ElementColor _elementColor;
    [Range(0, 100)]
    [SerializeField] private float _repulsiveForce;
    private Rigidbody _rigidbody;

    [HideInInspector] public bool isDraggable = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDraggable)
        {
            if (other.TryGetComponent(out ActiveWall wall))
            {
                if (wall.type.Equals(_elementColor))
                {
                    EventSet.objectDestroed.Invoke(_elementColor);
                    Destroy(gameObject);
                }
                else
                    isDraggable = false;
            }
        }
        else
        {
            if (other.TryGetComponent(out ActiveWall wall))
                _rigidbody.AddForce(other.transform.right * _repulsiveForce);

        }
    }
}
