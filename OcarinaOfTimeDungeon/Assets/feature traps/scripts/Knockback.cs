using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Knockback : MonoBehaviour
{
    [SerializeField] private float force = 20.0f;
    private Vector3 impact = Vector3.zero;
    private bool waited = true;

    public UnityEvent takeDMG;
    public CharacterController character;

    // call this function to add an impact force: with unityevent
    public void AddImpact(Vector3 dir, float force)
    {
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
        impact += dir.normalized * force;
        takeDMG.Invoke();
    }

    public void Update()
    {
        if (impact.magnitude > 0.2) character.Move(impact * Time.deltaTime);
        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("addimpact");
            AddImpact(transform.position, force);
        }
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Trap"))
        {
            if (waited == true)
            {
                AddImpact(transform.position, force);
                waited = false;
                StartCoroutine(Wait());
            }

        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        waited = true;
    }
}

