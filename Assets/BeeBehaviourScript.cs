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

    private Vector3 _origin;
    
    // Start is called before the first frame update
    void Start()
    {
        // _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        _origin = _transform.position;
    }

    private bool isPlayerCollider(Collider collider)
    {
        // TODO: Change this to a check for the PC
        return collider.name.Equals("Friend Cube");
    }
    
    private void FixedUpdate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(_transform.position, DETECTION_RADIUS);
        bool playerDetected = false;
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (isPlayerCollider(hitColliders[i]))
            {
                playerDetected = true;
                GameObject entity = hitColliders[i].gameObject;
                Vector3 direction = Vector3.Normalize(entity.transform.position - _transform.position);

                _transform.rotation = Quaternion.LookRotation(direction);
                _transform.position += direction * MOVEMENT_SPEED;
            }
        }
        
        // Go back to the bee's origin
        if (!playerDetected)
        {
            // Can be refactored into method
            Vector3 direction = Vector3.Normalize(_origin - _transform.position);
            
            _transform.rotation = Quaternion.LookRotation(direction);
            _transform.position += direction * MOVEMENT_SPEED;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        if (isPlayerCollider(collision.collider))
        {
            // TODO: Score deduction
            Destroy(this.gameObject);
        }
    }
}
