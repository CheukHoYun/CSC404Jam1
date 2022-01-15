using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float _userVerticalInput;
    private const float ScaleMovement = 0.25f;
    private Transform playerTransform;

    private float _userRotationInput;
    private Vector3 _userRotation;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _userVerticalInput = Input.GetAxis("Vertical");
        Debug.Log(_userVerticalInput);

        _userRotationInput = Input.GetAxis("Horizontal");
        _userRotation = playerTransform.rotation.eulerAngles;
        _userRotation += new Vector3(0, _userRotationInput, 0);

        playerTransform.position += transform.forward * _userVerticalInput;
        playerTransform.rotation = Quaternion.Euler(_userRotation);
    }
}
