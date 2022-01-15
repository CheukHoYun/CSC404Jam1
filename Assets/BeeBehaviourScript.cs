using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBehaviourScript : MonoBehaviour
{
    // TODO: Fiddle with detection radius
    private const float DETECTION_RADIUS = 4.0f;

    // TODO: Fiddle with speed
    private const float MOVEMENT_SPEED = 0.05f;

    private const int PENALTY = 2;

    private const int COOLDOWN = 3;
    
    // private Rigidbody _rigidbody;
    
    private Transform _transform;

    private Vector3 _origin;

    private bool _cooldown = false;

    private Collision _colliding = null;
    
    // Start is called before the first frame update
    void Start()
    {
        // _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        _origin = _transform.position;
    }

    private bool isPlayerCollider(Collider collider)
    {
        return collider.tag.Equals("Player");
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

        if (_colliding != null && !_cooldown)
        {
            ScoreManager.instance.RemovePoints(PENALTY);
            _cooldown = true;
            StartCoroutine(Cooldown(COOLDOWN));
        }
    }

    private IEnumerator Cooldown(int secs)
    {
        yield return new WaitForSeconds(secs);
        _cooldown = false;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (isPlayerCollider(collision.collider) && !_cooldown)
        {
            _colliding = collision;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision == _colliding)
        {
            _colliding = null;
        }
    }
}
