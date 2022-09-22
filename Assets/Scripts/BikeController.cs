using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BikeController : MonoBehaviour
{

    public float speed;
    public float turnSpeed;
    public GameObject frontWheelCol;
    public GameObject backWheelCol;
    public GameObject frontWheelVis;
    public GameObject backWheelVis;

    private Rigidbody rb;
    private float Movement;
    private float TurnMovement;


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
    }

    private void FixedUpdate()
    {
        Vector3 Move = new Vector3(Movement * speed, 0, 0);

        frontWheelCol.GetComponent<Rigidbody>().AddForce(Move);
        backWheelCol.GetComponent<Rigidbody>().AddForce(Move);

        backWheelVis.transform.SetPositionAndRotation(backWheelCol.transform.position, backWheelCol.transform.rotation);
        frontWheelVis.transform.SetPositionAndRotation(frontWheelCol.transform.position, frontWheelCol.transform.rotation);

        //rb.AddForce(Move);
        frontWheelCol.transform.Rotate(-TurnMovement * turnSpeed, 0, 0);

    }
}
