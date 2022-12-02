using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggingObjects : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Rigidbody _rigidbody;
    private Object _object;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _object = GetComponent<Object>();
    }




    public void OnPointerUp(PointerEventData eventData)
    {
        _object.isDraggable = false;
        _rigidbody.isKinematic = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!_object.isDraggable)
        {
            _rigidbody.isKinematic = false;
            return;
        }
        var pos = eventData.pointerCurrentRaycast.worldPosition;
        var delta = pos - transform.position;
        delta.z = 0;

        transform.position += delta;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _object.isDraggable = true;
        _rigidbody.isKinematic = true;
    }

  

 


}
