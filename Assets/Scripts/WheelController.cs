using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WheelController : MonoBehaviour
{

    public float speed;
    public float turnSpeed;

    private Rigidbody rb;
    private float Movement;
    private float TurnMovement;
    //private float startRotateX;
    //private float startRotateY;
    //private float startRotateZ;


    void OnMove(InputValue MovementValue)
    {
        Vector2 MovementVector = MovementValue.Get<Vector2>();
        Movement = MovementVector.y;
        TurnMovement = MovementVector.x;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //startRotateX = GetComponent<Transform>().rotation.x;
        //startRotateY = GetComponent<Transform>().rotation.y;
        //startRotateZ = GetComponent<Transform>().rotation.z;
    }

    private void FixedUpdate()
    {
        Vector3 Move = new Vector3(Movement * speed, 0, 0);

        rb.AddForce(Move);
        transform.Rotate(0, 0, -TurnMovement * turnSpeed);
    }
}
