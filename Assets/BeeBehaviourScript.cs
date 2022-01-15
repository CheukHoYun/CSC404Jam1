using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBehaviourScript : MonoBehaviour
{
    // TODO: Fiddle with detection radius
    private const float DETECTION_RADIUS = 4.0f;

    // TODO: Fiddle with speed
    private const float MOVEMENT_SPEED = 0.05f;
    
    // private Rigidbody _rigidbody;
    
    private Transform _transform;
    
    // Start is called before the first frame update
    void Start()
    {
        // _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(_transform.position, DETECTION_RADIUS);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            // TODO: Change this to a check for the PC
            if (hitColliders[i].name.Equals("Friend Cube"))
            {
                GameObject entity = hitColliders[i].gameObject;
                Vector3 direction = Vector3.Normalize(entity.transform.position - _transform.position);

                _transform.rotation = Quaternion.LookRotation(direction);
                _transform.position += direction * MOVEMENT_SPEED;
            }
        }
    }
    
}
