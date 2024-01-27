using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandControl : MonoBehaviour
{
    public static HandControl Instance;

    public FingerInput inputActions;

    [SerializeField]
    private Transform point , referent , arm , ref_holder , move_ref_point;

    [SerializeField]
    private float speed = 10.0f;

    [SerializeField]
    private Transform F1_target, F2_target, F3_target, F4_target, F5_target;

    float f1, f2, f3, f4, f5;

    public bool b1, b2, b3, b4, b5;

    [SerializeField]
    private float finger_speed = 5.0f;

    private InputAction Z, X, C, V, B;

    public GameObject holder;

    public bool isHolder;

    private void Awake()
    {
        Instance = this;
        inputActions = new FingerInput();
    }

    public void setItemHolder(GameObject g)
    {
        holder = g;
    }

    private void FixedUpdate()
    {

        point.position = Vector3.Lerp(point.position , referent.position , 20.0f * Time.deltaTime);
        point.rotation = referent.rotation;
        referent.Rotate(Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0 , -Input.GetAxisRaw("Yaw") * speed * Time.deltaTime);
        arm.Rotate(0, Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0);

    }

    private void OnEnable()
    {
        Z = inputActions.Finger.Z;
        Z.Enable();
        Z.performed += Z_KEY;

        X = inputActions.Finger.X;
        X.Enable();
        X.performed += X_KEY;

        C = inputActions.Finger.C;
        C.Enable();
        C.performed += C_KEY;

        V = inputActions.Finger.V;
        V.Enable();
        V.performed += V_KEY;

        B = inputActions.Finger.B;
        B.Enable();
        B.performed += B_KEY;
    }

    private void OnDisable()
    {
        Z.Disable();
        X.Disable();
        C.Disable();
        V.Disable();
        B.Disable();
    }

    private void Z_KEY(InputAction.CallbackContext context)
    {
        b1 = context.action.IsPressed();

    }

    private void X_KEY(InputAction.CallbackContext context)
    {
        b2 = context.action.IsPressed();
    }

    private void C_KEY(InputAction.CallbackContext context)
    {
        b3 = context.action.IsPressed();
    }

    private void V_KEY(InputAction.CallbackContext context)
    {
        b4 = context.action.IsPressed();
    }

    private void B_KEY(InputAction.CallbackContext context)
    {
        b5 = context.action.IsPressed();
    }


    private void Update()
    {
        fingerControl();
        checkHolder();
        handDistance();

    }

    void handDistance()
    {
        move_ref_point.Translate(0,0, Input.GetAxisRaw("Mouse ScrollWheel") * speed * Time.deltaTime , Space.Self);
    }

    void checkHolder()
    {
        bool[] finger = { b1,b2,b3,b4,b5};

        int len_of_true = finger.Where(f => f).ToArray().Length;

        if (len_of_true >= 3)
        {
            if (holder)
            {
                holder.transform.SetParent(ref_holder.transform);
                holder.GetComponent<Rigidbody>().isKinematic = true;
                isHolder = true;
            }
        }
        else
        {
            if (holder) {
                holder.transform.SetParent(null);
                holder.GetComponent<Rigidbody>().isKinematic = false;
                Invoke("setBackIsHolder" , 1.0f);
            }
        }
    }

    void setBackIsHolder()
    {
        isHolder = false;
        holder = null;
    }

    void fingerControl()
    {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            b1 = true;
            
        }

        if(Input.GetKeyUp(KeyCode.Z))
        {
            b1 = false;
            
        }

        if (Input.GetKeyDown(KeyCode.X))
        {

            b2 = true;
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            b2 = false;

        }


        if (Input.GetKeyDown(KeyCode.C))
        {
            b3 = true;
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            b3 = false;
        }


        if (Input.GetKeyDown(KeyCode.V))
        {
            b4 = true;

        }

        if (Input.GetKeyUp(KeyCode.V))
        {
            b4 = false;

        }


        if (Input.GetKeyDown(KeyCode.B))
        {
           b5 = true;

        }

        if (Input.GetKeyUp(KeyCode.B))
        {
            b5 = false;

        }


        f1 = Mathf.Lerp(f1, b1 ? -90.0f : 0.0f, Time.deltaTime * finger_speed);
        f2 = Mathf.Lerp(f2, b2 ? 90.0f : 0.0f, Time.deltaTime * finger_speed);
        f3 = Mathf.Lerp(f3, b3 ? 90.0f : 0.0f, Time.deltaTime * finger_speed);
        f4 = Mathf.Lerp(f4, b4 ? 90.0f : 0.0f, Time.deltaTime * finger_speed);
        f5 = Mathf.Lerp(f5, b5 ? 90.0f : 0.0f, Time.deltaTime * finger_speed);

        F1_target.localRotation = Quaternion.Euler(new Vector3(0, 0, f1));
        F2_target.localRotation = Quaternion.Euler(new Vector3(f2, 0, 0));
        F3_target.localRotation = Quaternion.Euler(new Vector3(f3, 0, 0));
        F4_target.localRotation = Quaternion.Euler(new Vector3(f4, 0, 0));
        F5_target.localRotation = Quaternion.Euler(new Vector3(f5, 0, 0));

    }
}
