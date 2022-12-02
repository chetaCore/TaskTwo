using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] private TypesSet.Type type;
    [Range(0,100)]
    [SerializeField] private float repulsiveForce;
    private Rigidbody _rigidbody;

    public bool isDraggable = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (isDraggable)
        {
            if (other.gameObject.CompareTag("ActiveWall"))
                if (other.gameObject.GetComponent<ActiveWall>().type.Equals(type))
                {
                    EventSet.objectDestroed.Invoke(type);
                    Destroy(gameObject);
                }
                else
                    isDraggable = false;
        }
        else
            if (other.gameObject.CompareTag("ActiveWall"))
                _rigidbody.AddForce(other.transform.right * repulsiveForce);
           
                
        

    }

}
