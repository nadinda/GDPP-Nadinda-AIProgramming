using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody _rigidBody;
 
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontal,0,vertical);
        _rigidBody.velocity = movementDirection * _speed * Time.fixedDeltaTime;
    }
}
