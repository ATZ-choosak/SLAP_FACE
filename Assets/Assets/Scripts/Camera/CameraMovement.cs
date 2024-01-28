using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement instance;

    [SerializeField]
    private float minX , maxX , minY , maxY ;

    float mouseX , mouseY ;

    [SerializeField]
    private float smooth = 5.0f;

    Animator animator ;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        mouseX += Input.GetAxisRaw("Mouse X") * smooth * Time.deltaTime;
        mouseY -= Input.GetAxisRaw("Mouse Y") * smooth * Time.deltaTime;

        mouseX = Mathf.Clamp(mouseX, minX , maxX);
        mouseY = Mathf.Clamp(mouseY, minY , maxY);

        transform.rotation = Quaternion.Euler(mouseY , mouseX, 0);
    }

    public void playDamage()
    {
        animator.SetTrigger("Damage");
    }
}
