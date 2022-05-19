using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Speed = 8f;
    Animator m_PlayerAnimator;
    

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_PlayerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.R)) {
            m_Speed = 2f;
            m_PlayerAnimator.SetBool("Run", false);
            m_PlayerAnimator.SetBool("Walk", false);
            m_PlayerAnimator.SetBool("Push", true);
        } else if (Input.GetKey(KeyCode.T)) {
            m_Speed = 2f;
            m_PlayerAnimator.SetBool("Run", false);
            m_PlayerAnimator.SetBool("Push", false);
            m_PlayerAnimator.SetBool("Walk", true);
        } else {
            m_Speed = 8f;
            m_PlayerAnimator.SetBool("Walk", false);
            m_PlayerAnimator.SetBool("Push", false);
            m_PlayerAnimator.SetBool("Run", true);
        }

        m_Input = m_Input.normalized * Time.deltaTime * m_Speed;
        m_Rigidbody.MovePosition(transform.position + m_Input);
        if (m_Input != Vector3.zero) {
            m_Rigidbody.MoveRotation(Quaternion.LookRotation(m_Input, Vector3.up));
        }
        else {
            m_PlayerAnimator.SetBool("Run", false);   
            m_PlayerAnimator.SetBool("Walk", false);  
            m_PlayerAnimator.SetBool("Push", false);       
        }
    }
}

    // void FixedUpdate()
    // {
    //     Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    //     Vector3 m_Rotation = new Vector3(0, Input.GetAxis("Horizontal"), 0);

    //     m_Input = m_Input.normalized * Time.deltaTime * m_Speed;
    //     m_Rigidbody.MovePosition(transform.position + m_Input);
        
    //     if (m_Input != Vector3.zero) {
    //         Quaternion deltaRotation = Quaternion.LookRotation(m_Input, Vector3.up);            
    //         m_Rigidbody.MoveRotation(Quaternion.RotateTowards(m_Rigidbody.rotation, deltaRotation, m_RotationSpeed * Time.deltaTime));
    //     } 
    // }