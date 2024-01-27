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

    [SerializeField] private float minThumbRotate;
    [SerializeField] private float maxThumbRotate;
    [SerializeField] private float minOthrFingerRotate;
    [SerializeField] private float maxOthrFingerRotate;
    [SerializeField] private float minArmRotate;
    [SerializeField] private float maxArmRotate;

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
        if (arm.transform.localEulerAngles.x - turn.y < minArmRotate || arm.transform.localEulerAngles.x - turn.y > maxArmRotate)
        {
            arm.transform.eulerAngles = new Vector3(arm.transform.eulerAngles.x - turn.y, arm.transform.eulerAngles.y, 0);
        }
        if (arm.transform.localEulerAngles.y + turn.x < minArmRotate || arm.transform.localEulerAngles.y + turn.x > maxArmRotate)
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
            if (Mathf.Abs(finger1.transform.localEulerAngles.z) < maxThumbRotate)
            {
                finger1.transform.Rotate(Vector3.forward * fingerTurnSpeed);
            }
        }
        else
        {
            if (Mathf.Abs(finger1.transform.localEulerAngles.z) > minThumbRotate)
            {
                finger1.transform.Rotate(Vector3.forward * fingerTurnSpeed * -1);
            }
        }

        //Index
        if (wPrees)
        {
            if (Mathf.Abs(finger2.transform.localEulerAngles.y) > minOthrFingerRotate)
            {
                finger2.transform.Rotate(Vector3.forward * fingerTurnSpeed);
            }
        }
        else
        {
            if (Mathf.Abs(finger2.transform.localEulerAngles.y) <= maxOthrFingerRotate)
            {
                finger2.transform.Rotate(Vector3.forward * fingerTurnSpeed * -1);
            }
        }

        //Middle
        if (ePrees)
        {
            if (Mathf.Abs(finger3.transform.localEulerAngles.y) > minOthrFingerRotate)
            {
                finger3.transform.Rotate(Vector3.forward * fingerTurnSpeed);
            }
        }
        else
        {
            if (Mathf.Abs(finger3.transform.localEulerAngles.y) <= maxOthrFingerRotate)
            {
                finger3.transform.Rotate(Vector3.forward * fingerTurnSpeed * -1);
            }
        }

        //Ring
        if (rPrees)
        {
            if (Mathf.Abs(finger4.transform.localEulerAngles.y) > minOthrFingerRotate)
            {
                finger4.transform.Rotate(Vector3.forward * fingerTurnSpeed);
            }
        }
        else
        {
            if (Mathf.Abs(finger4.transform.localEulerAngles.y) <= maxOthrFingerRotate)
            {
                finger4.transform.Rotate(Vector3.forward * fingerTurnSpeed * -1);
            }
        }


        //Little
        if (tPrees)
        {
            if (Mathf.Abs(finger5.transform.localEulerAngles.y) > minOthrFingerRotate)
            {
                finger5.transform.Rotate(Vector3.forward * fingerTurnSpeed);
            }
        }
        else
        {
            if (Mathf.Abs(finger5.transform.localEulerAngles.y) <= maxOthrFingerRotate)
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
