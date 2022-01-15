using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBehaviourScript : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Transform _transform;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
}
