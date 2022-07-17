using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [Header("MovementVar")]
    public LayerMask whatCanBeClickedOn;
    private NavMeshAgent myAgent;
    private AudioSource stickSound;

    [Header("Sound Pitch")]
    public float groundPitch;
    public float nonInteractablePitch;

    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        stickSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo, 100, whatCanBeClickedOn))
            {
                myAgent.SetDestination(hitInfo.point);
                stickSound.pitch = groundPitch;
                stickSound.Play();
            }
            else
            {
                stickSound.pitch = nonInteractablePitch;
                stickSound.Play();
            }
        }
    }

    public Vector3 PlayerPos()
    {
        Vector3 playerPos = gameObject.transform.position;
        return playerPos;
    }
}
