 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    private int currentLane = 1; //0-left; 1-middle; 2-right;
    public float laneDistance = 2.5f; //distance between lanes
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;

        // get LaneChange Status

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentLane++;
            if(currentLane==3)
            {
                currentLane = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentLane--;
            if (currentLane == -1)
            {
                currentLane = 0;
            }
        }

        Vector3 targetPos = transform.position.z * transform.forward + 
                                    transform.position.y * transform.up;

        if(currentLane == 0)
        {
            targetPos += Vector3.left * laneDistance;
        }
        else if (currentLane == 2)
        {
            targetPos += Vector3.right * laneDistance;
        }

        transform.position = targetPos;
    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }
}
