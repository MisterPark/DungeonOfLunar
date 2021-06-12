using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float m_Vertical = 0.0f;
    private float m_Horizontal = 0.0f;
    private float m_MouseRot = 0.0f;
    public float m_MoveSpeed = 5.0f;
    private float m_RotSpeed = 80.0f;
    private Transform m_Transform;
    private Animator animator;
    private JoystickController joystick;
    // Start is called before the first frame update
    void Start()
    {
        joystick = GameObject.Find("Joystick").GetComponent<JoystickController>();
        m_Transform = GetComponent<Transform>();
        animator = m_Transform.Find("GFX").GetChild(0).gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Vertical = Input.GetAxisRaw("Vertical");
        m_Horizontal = Input.GetAxisRaw("Horizontal");
        m_MouseRot = Input.GetAxis("Mouse X");

        m_Vertical = joystick.Speed;

        animator.SetFloat("MoveSpeed", m_Vertical);

        Vector3 MoveDir = joystick.Direction.normalized;


        float angleY = Vector3.Cross(m_Transform.forward, MoveDir).y;
        //float angleY = Vector3.Angle(Vector3.forward, MoveDir);
        Debug.Log("AngleY :" + MoveDir.ToString());
        m_Transform.Rotate(Vector3.up, angleY *m_RotSpeed);
        m_Transform.Translate(MoveDir *joystick.Speed * m_MoveSpeed * Time.deltaTime, Space.World);

        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }
    }
}
