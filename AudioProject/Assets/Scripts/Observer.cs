using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;
    bool _IsPlayerInRange = false;

    void OnTriggerEnter (Collider other)
    {
        if (other.transform == player)
        {
            _IsPlayerInRange = true;
        }
    }

    
    void OnTriggerExit (Collider other)
    {
        if (other.transform == player)
        {
            _IsPlayerInRange = false;
        }
    }

    void Update()
    {
        if(_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;

            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}
