using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Speed = 5f;
    Animator m_PlayerAnimator;
    

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_PlayerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        m_Input = m_Input.normalized * Time.deltaTime * m_Speed;
        m_Rigidbody.MovePosition(transform.position + m_Input);
        if (m_Input != Vector3.zero) {
            m_PlayerAnimator.SetBool("Run", true);
            m_Rigidbody.MoveRotation(Quaternion.LookRotation(m_Input, Vector3.up));
        }
        else {
            m_PlayerAnimator.SetBool("Run", false);            
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