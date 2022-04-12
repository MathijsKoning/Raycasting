using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Ray : MonoBehaviour
{
    [SerializeField] public float height = 2;

    private Rigidbody _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ShootColouredRay();
    }

    private void ShootRay()
    {
        Vector3 down = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, down, 10))
        {
            print("There is something in front of the object!");
            
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 10, Color.red);
        }
    }

    private void ShootColouredRay()
    {
        RaycastHit hit;
        
        if (_rigidbody.velocity.magnitude > 0.1f) // This checks if the RigidBody is actually moving / falling
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 10, Color.yellow);

            if (Physics.Raycast(transform.position, Vector3.down, out hit, height))
            {
                // This means the ray hits an object within 2 of its position.
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);

                if (hit.collider.tag == "Environment")
                {
                    Debug.Log("It is a hit!");
                }
            }
        }
    }
}
