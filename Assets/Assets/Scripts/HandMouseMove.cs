using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMouseMove : MonoBehaviour
{
    [SerializeField] private GameObject arm;
    [SerializeField] private GameObject finger1;
    [SerializeField] private GameObject finger2;
    [SerializeField] private GameObject finger3;
    [SerializeField] private GameObject finger4;
    [SerializeField] private GameObject finger5;
    [SerializeField] private float armTurnSpeed;
    [SerializeField] private float fingerTurnSpeed;
    private Vector2 turn;

    //Input
    private bool qPrees;
    private bool wPrees;
    private bool ePrees;
    private bool rPrees;
    private bool tPrees;

    void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        ProcessInput();
    }

    void FixedUpdate() 
    {
        RotateFinger();
        RotateArm();
    }

    void RotateArm()
    {
        //HardCode
        
        // Debug.Log(arm.transform.localEulerAngles);
        if (arm.transform.localEulerAngles.x - turn.y < 80 || arm.transform.localEulerAngles.x - turn.y > 280)
        {
            arm.transform.eulerAngles = new Vector3(arm.transform.eulerAngles.x - turn.y, arm.transform.eulerAngles.y, 0);
        }
        if (arm.transform.localEulerAngles.y + turn.x < 80 || arm.transform.localEulerAngles.y + turn.x > 280)
        {
            arm.transform.eulerAngles = new Vector3(arm.transform.eulerAngles.x, arm.transform.eulerAngles.y + turn.x, 0);
        }
    }

    void RotateFinger()
    {
        //HardCode

        //Thumb
        if (qPrees)
        {
            if (Mathf.Abs(finger1.transform.localEulerAngles.z) < 90)
            {
                finger1.transform.Rotate(Vector3.forward * fingerTurnSpeed);
            }
        }
        else
        {
            if (Mathf.Abs(finger1.transform.localEulerAngles.z) > 5)
            {
                finger1.transform.Rotate(Vector3.forward * fingerTurnSpeed * -1);
            }
        }

        //Index
        if (wPrees)
        {
            if (Mathf.Abs(finger2.transform.localEulerAngles.y) > 230)
            {
                finger2.transform.Rotate(Vector3.forward * fingerTurnSpeed);
            }
        }
        else
        {
            if (Mathf.Abs(finger2.transform.localEulerAngles.y) <= 340)
            {
                finger2.transform.Rotate(Vector3.forward * fingerTurnSpeed * -1);
            }
        }

        //Middle
        if (ePrees)
        {
            if (Mathf.Abs(finger3.transform.localEulerAngles.y) > 230)
            {
                finger3.transform.Rotate(Vector3.forward * fingerTurnSpeed);
            }
        }
        else
        {
            if (Mathf.Abs(finger3.transform.localEulerAngles.y) <= 340)
            {
                finger3.transform.Rotate(Vector3.forward * fingerTurnSpeed * -1);
            }
        }

        //Ring
        if (rPrees)
        {
            if (Mathf.Abs(finger4.transform.localEulerAngles.y) > 230)
            {
                finger4.transform.Rotate(Vector3.forward * fingerTurnSpeed);
            }
        }
        else
        {
            if (Mathf.Abs(finger4.transform.localEulerAngles.y) <= 340)
            {
                finger4.transform.Rotate(Vector3.forward * fingerTurnSpeed * -1);
            }
        }


        //Little
        if (tPrees)
        {
            if (Mathf.Abs(finger5.transform.localEulerAngles.y) > 230)
            {
                finger5.transform.Rotate(Vector3.forward * fingerTurnSpeed);
            }
        }
        else
        {
            if (Mathf.Abs(finger5.transform.localEulerAngles.y) <= 340)
            {
                finger5.transform.Rotate(Vector3.forward * fingerTurnSpeed * -1);
            }
        }
    }

    void ProcessInput()
    {
        //HardCode GetInput
        turn.x = Input.GetAxis("Mouse X") * armTurnSpeed;
        turn.y = Input.GetAxis("Mouse Y") * armTurnSpeed;

        if (Input.GetKeyDown(KeyCode.Q))
            qPrees = true;
        if (Input.GetKeyUp(KeyCode.Q))
            qPrees = false;

        if (Input.GetKeyDown(KeyCode.W))
            wPrees = true;
        if (Input.GetKeyUp(KeyCode.W))
            wPrees = false;
        
        if (Input.GetKeyDown(KeyCode.E))
            ePrees = true;
        if (Input.GetKeyUp(KeyCode.E))
            ePrees = false;

        if (Input.GetKeyDown(KeyCode.R))
            rPrees = true;
        if (Input.GetKeyUp(KeyCode.R))
            rPrees = false;

        if (Input.GetKeyDown(KeyCode.T))
            tPrees = true;
        if (Input.GetKeyUp(KeyCode.T))
            tPrees = false;
    }
}
