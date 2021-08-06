using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Class variables
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offsetPos;
    [SerializeField] private Space offsetPositionSpace = Space.Self;
    [SerializeField] private bool lookAt = true;

    // Start is called before the first frame update
    private void Update()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (player == null)
        {
            Debug.LogWarning("Missing target ref !", this);
            return;
        }

        // compute position
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = player.TransformPoint(offsetPos);
        }
        else
        {
            transform.position = player.position + offsetPos;
        }

        // compute rotation
        if (lookAt)
        {
            transform.LookAt(player);
        }
        else
        {
            transform.rotation = player.rotation;
        }
    }
}
