using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovment : MonoBehaviour
{      
    Rigidbody rb;
    public GameObject Char;
    public Animator anim;
    [SerializeField]private float speedMove;
    [SerializeField]private float smoothRotatChr;
    float Roty;
    public float nextTime;
    public float fireRate;
    bool isAnotherOurControl;
    public Transform gameOverPanel;
    public Transform winPanel;
    public bool isGameOver =false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredVelocity = Input.GetAxis("Horizontal")* transform.right *speedMove + Input.GetAxis("Vertical") * transform.forward *speedMove;
        rotates(desiredVelocity);
       if(!isAnotherOurControl && isGrounded())
       {
            move(desiredVelocity);
       }
       else if (!isGrounded())
       {
            // we fly
            AnimJump();
       }

      
    }
    void Update()
    {
        // cam
       // y_upDown_lock = calculate_y_upDown_lock(y_upDown_lock);
       // CamObjRotate.transform.localRotation = Quaternion.Euler(y_upDown_lock , transform.rotation.y , 0);
      //  transform.Rotate(0, Input.GetAxis("Mouse X") * speedRotateCam * Time.deltaTime * slowRotate,0);
            
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fall"))
        {
            Cursor.visible = true; 
            gameOverPanel.gameObject.SetActive(true);
            Time.timeScale = 0;
            isGameOver =true;
        }
        
        if (other.CompareTag("endline"))
        {
            Cursor.visible = true; 
            winPanel.gameObject.SetActive(true);
            Invoke("freeze" , 2);
            
        }
    }

    private void freeze()
    {
        Time.timeScale = 0;
    }
//-------------------------------------------------------------------------------------
    void rotates(Vector3 moveValue)
    {
        float V = Input.GetAxis("Vertical");
        float H = Input.GetAxis("Horizontal");

        if(V > 0)
        {   
            if(H > 0)
            {
                Roty =  45;   
            }
            else if (H < 0)
            {
                Roty =  -45;
            }
            else
            {
                Roty =  0;
            }
           
            nextTime_();    
        }
        else  
        if(V < 0)
        {   
            if(H > 0)
            {
                Roty =  135;   
            }
            else if (H < 0)
            {
                Roty =  225;
            }
            else
            {
                Roty =  180;
            }
           
            nextTime_();    
        }
        else
        if(H > 0 && V == 0)
        {
            Roty = 90;
            nextTime_(); 
        }
        else
        if(H < 0 && V == 0)
        {
            Roty = -90;
            nextTime_(); 
        }

        else if(Time.time >= nextTime)
        {
            nextTime_();
            Roty = 0;  
        }

       
       Quaternion a = Char.transform.localRotation ;
       Quaternion b = Quaternion.Euler (0 , Roty , 0);
       Char.transform.localRotation  =  Quaternion.Slerp(a , b , smoothRotatChr * Time.deltaTime);
    }

   
    float calculate_YRot(int a)
    {
      return  a * 90 * Input.GetAxis("Horizontal") *100 /100 ;
    }

    void nextTime_()
    {
        nextTime = Time.time + 1/fireRate;
    }

 
//------------------------------------------------------------------------------------
    void move(Vector3 moveValue)
    {
        rb.velocity = Vector3.Lerp(rb.velocity, moveValue, Time.deltaTime * speedMove);
        if(moveValue.magnitude > 0)
        {
            // run
            AnimMove();
            return;
        }

        AnimIdle();
    }

    void AnimIdle()
    {
        anim.SetBool("isRun" , false); 
        anim.SetBool("isJump" , false);
    }
    void AnimMove()
    {
        anim.SetBool("isRun" , true); 
        anim.SetBool("isJump" , false);
    }

    void AnimJump()
    {
        anim.SetBool("isJump" , true);
    }


      // jump
    [Header("Jump value ...")]
    [SerializeField] float jumpPower;
    [SerializeField] float distToGround;
    [SerializeField] float minDistance;

     // jump
    // pressed from script (read jump) >>  on UI jump btn

    void  LateUpdate()
    {
        // jump
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }   
    }
    public void Jump()
    {
        if(isGrounded())
        {
            // jump
            rb.AddForce(Vector3.up * jumpPower);
            Debug.Log("jumping..");
        }
    }

    public bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + minDistance);
    }

    //-------------------------------------CAM---------------------------------------------------
   /* [Header("Cam value ...")]
    public GameObject CamObjRotate;
    public float speedRotateCam;
    public float slowRotate;
    float y_upDown_lock;
    float calculate_y_upDown_lock(float y_upDown_lock_)
    {
        y_upDown_lock_ += Input.GetAxis("Mouse Y") * -speedRotateCam * Time.deltaTime *slowRotate;
        y_upDown_lock_ = Mathf.Clamp(y_upDown_lock_, -18 , 39);
        return y_upDown_lock_;
    }*/
}