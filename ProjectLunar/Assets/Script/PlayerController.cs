using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float m_Vertical = 0.0f;
    private float m_Horizontal = 0.0f;
    private float m_MouseRot = 0.0f;
    public float m_MoveSpeed = 1.0f;
    private float m_RotSpeed = 80.0f;
    private Transform m_Transform;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        m_Transform = GetComponent<Transform>();
        animator = m_Transform.Find("GFX").gameObject.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Vertical = Input.GetAxisRaw("Vertical");
        m_Horizontal = Input.GetAxisRaw("Horizontal");
        m_MouseRot = Input.GetAxis("Mouse X");

        animator.SetFloat("MoveSpeed", m_Vertical);

        //Debug.Log("V = " + m_Vertical.ToString());
        //Debug.Log("H = " + m_Horizontal.ToString());
        //Debug.Log("Mouse X = " + m_MouseRot.ToString());

        Vector3 MoveDir = (Vector3.forward * m_Vertical) + (Vector3.right * m_Horizontal);

        //m_Transform.Rotate(Vector3.up * m_MouseRot * m_RotSpeed * Time.deltaTime);
        m_Transform.Translate(Vector3.Normalize(MoveDir) * m_MoveSpeed * Time.deltaTime, Space.Self);

        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }

        
    }
}
