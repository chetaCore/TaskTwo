using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggingObjects : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Rigidbody _rigidbody;
    private Collider _collider;
    private GameCube _gameCube;

    private float _pointSeporationValue = 2.8f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        _gameCube = GetComponent<GameCube>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _gameCube.isDraggable = false;
        _rigidbody.isKinematic = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!_gameCube.isDraggable)
        {
            _rigidbody.isKinematic = false;
            return;
        }

        transform.rotation = Quaternion.Euler(Vector3.zero);

        var pos = eventData.pointerCurrentRaycast.worldPosition;
        var delta = pos - transform.position;
        delta.z = 0;
        delta.y += _collider.bounds.size.y / _pointSeporationValue;
        transform.position += delta;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _gameCube.isDraggable = true;
        _rigidbody.isKinematic = true;
    }

  

 


}
