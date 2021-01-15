using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class knockBackScript : MonoBehaviour
{
    public UnityEvent takeDMG;
    [SerializeField] private float mass = 3.0f; // defines the character mass
    private Vector3 impact = Vector3.zero;
    public CharacterController character;

    // call this function to add an impact force: with unityevent
    public void AddImpact(Vector3 dir, float force)
    {
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
        impact += dir.normalized * force / mass;
        takeDMG.Invoke();
    }

    void Update()
    {
        // apply the impact force:
        if (impact.magnitude > 0.2) character.Move(impact * Time.deltaTime);
        // consumes the impact energy each cycle:
        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
    }
}
