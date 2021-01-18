using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Knockback : MonoBehaviour
{
    [SerializeField] private float force = 20.0f;
    [SerializeField] private float mass = 3.0f; // defines the character mass
    private Vector3 impact = Vector3.zero;

    public UnityEvent takeDMG;
    public CharacterController character;

    // call this function to add an impact force: with unityevent
    public void AddImpact(Vector3 dir, float force)
    {
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
        impact += dir.normalized * force / mass;
        takeDMG.Invoke();
    }

    public void Update()
    {
        if (impact.magnitude > 0.2) character.Move(impact * Time.deltaTime);
        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("addimpact");
            AddImpact(transform.position, force);
        }  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Debug.Log("werk?");
            AddImpact(transform.position, force);
        }
    }
}
