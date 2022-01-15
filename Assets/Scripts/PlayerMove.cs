using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    private float _usrHorInput;
    private float _usrRotInput;
    private const float movementScale = 0.25f;

    private Vector3 _usrRot;
    private Transform _transform;
    private Rigidbody _rigidbody; 

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>(); 
        _transform = GetComponent<Transform>(); 
    }

    // Update is called once per frame
    void Update()
    {
        _usrHorInput = Input.GetAxis("Vertical");
        _usrRotInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        _usrRot = _transform.rotation.eulerAngles;
        _usrRot += new Vector3(0, _usrRotInput, 0);
        _transform.rotation = Quaternion.Euler(_usrRot);
        _rigidbody.velocity += _transform.forward * _usrHorInput;
    }
}
