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
    public float jumpForce;
    public float gravity = -20;
    private bool sliding = false;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;
        direction.z = forwardSpeed;
        

        if (controller.isGrounded)
        {
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
            if (SwipeManager.swipeUp)
            {
                Jump();
            }
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
        }

        if (SwipeManager.swipeDown)
        {
            StartCoroutine(Slide());
        }
        // get LaneChange Status
        if (SwipeManager.swipeRight)
        {
            currentLane++;
            if(currentLane==3)
            {
                currentLane = 2;
            }
        }

        if (SwipeManager.swipeLeft)
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


        if (transform.position != targetPos)
        {
            Vector3 diff = targetPos - transform.position;
            Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.magnitude)
                controller.Move(moveDir);
            else
                controller.Move(diff);
        }
    }

    private void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted)
            return;
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        if(hit.transform.tag == "Obstacle")
        {
            PlayerManager.gameover = true;
        }
        else if(hit.transform.tag == "Enemy")
        {
            Events.LoadFpsScene();
        }
    }

    private IEnumerator Slide()
    {
        if (sliding)
            yield break;
        sliding = true;
        var newScale = new Vector3(transform.localScale.x, transform.localScale.y * 0.5f, transform.localScale.z);
        var newPos = new Vector3(transform.position.x, 0.5f, transform.position.z);
        transform.position = newPos;
        transform.localScale = newScale;
        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1f;
        yield return new WaitForSeconds(1.3f);
        controller.center = new Vector3(0, 0, 0);
        controller.height = 2f; 
        newScale = new Vector3(transform.localScale.x, transform.localScale.y * 2f, transform.localScale.z);

        transform.localScale = newScale;
        newPos = new Vector3(transform.position.x, 1f, transform.position.z);
        transform.position = newPos;
        sliding = false;
    }
}
