using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    CharacterController player;
    PlayerStats playerStats;
    Transform groundChecker;
    float groundDistance = 0.55f;
    Vector3 _velocity;
    bool isGrounded;
    bool locked = false;

    GameObject[] enemyLocations;
    GameObject closest;

    [SerializeField, Range(0f, 20f)]
    float gravityFactor = 10f;

    public LayerMask Ground;
    public Vector3 Drag;
    Vector3 inputs;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        playerStats = GetComponent<PlayerStats>();
        groundChecker = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, groundDistance, Ground, QueryTriggerInteraction.Ignore);
        if(isGrounded && _velocity.y < 0)
        {
            _velocity.y = 0f;
        }

        float inputX = Input.GetAxisRaw("Horizontal");
        float inputZ = Input.GetAxisRaw("Vertical");

        inputs = new Vector3(inputX, 0f, inputZ);
        if(inputs != Vector3.zero)
        {
             inputs = Quaternion.Euler(0f, Camera.main.transform.localEulerAngles.y, 0f) * inputs;
             transform.rotation = Quaternion.LookRotation(inputs);
        }
        player.Move(inputs * Time.deltaTime * playerStats.playerSpeed);
       


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Lock();
        }

        if(closest && locked)
        {
            transform.LookAt(new Vector3(closest.transform.position.x, transform.position.y, closest.transform.position.z));
            
        }

        _velocity.y += -gravityFactor * Time.deltaTime;

        _velocity.x /= 1 + Drag.x * Time.deltaTime;
        _velocity.y /= 1 + Drag.y * Time.deltaTime;
        _velocity.z /= 1 + Drag.z * Time.deltaTime;

        player.Move(_velocity * Time.deltaTime);
    }

    void Jump()
    {
        _velocity.y += Mathf.Sqrt(playerStats.playerJumpHeight * -2f * Physics.gravity.y);
    }

    void Dash()
    {
        _velocity += Vector3.Scale(transform.forward, playerStats.playerDashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * Drag.x + 1)) / -Time.deltaTime),0,(Mathf.Log(1f / (Time.deltaTime * Drag.z + 1)) / -Time.deltaTime)));
    }

    void Lock()
    {
        FindClosestEnemy();
        locked = !locked;

        if (locked)
        {
            if (!closest)
            {
                locked = false;
                closest = null;
                return;
            }    
        }
    }
    
    GameObject FindClosestEnemy()
    {
        enemyLocations = GameObject.FindGameObjectsWithTag("Enemy");
        var distance = Mathf.Infinity;
        var position = transform.position;
        foreach(var go in enemyLocations)
        {
            var diff = (go.transform.position - position);
            var curDistance = diff.sqrMagnitude;

            if(curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
