using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 10;
    public float maxSpeed = 50;

    public AudioSource Hit;

    public float moveForce = 365f;
    public float hitForce = 1000f;

    public BoxCollider2D MyBox;
    Animator myamin;

    public float timeTillStart = 3;
    bool hurt;

    Rigidbody2D myRb;
    bool goingUp;

    bool disabled;

    public GameObject myArm;


    JointMotor2D motor;
    HingeJoint2D hinge;

    LevelManager levelManger;

    // bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        myamin = GetComponent<Animator>();
        hinge = myArm.GetComponent<HingeJoint2D>();
        levelManger = FindObjectOfType<LevelManager>();
        motor = hinge.motor;
        motor.motorSpeed = 0f;
        hinge.motor = motor;
        OnDisable();

    }
    private void OnCollisionEnter2D(Collision2D collision)   /// <summary>
                                                             ///  will need to be changed for player 2
                                                             /// </summary>
    {
        if (collision.gameObject.tag == "PlayerTwoPillow"&& this.gameObject.tag == "PlayerOne"|| collision.gameObject.tag == "PlayerOnePillow" && this.gameObject.tag == "PlayerTwo")
        {
            Vector3 pos = collision.transform.position;
            Vector3 dir = (transform.position - collision.transform.position).normalized;
            myRb.velocity = Vector2.zero;
            myamin.SetTrigger("Hit");
            Hit.Play();
            if (hurt)
            {
                myRb.AddForce(dir * hitForce * 3);
            }
            else
            {
                myRb.AddForce(dir * hitForce);
            }
            //OnDisable();
            levelManger.Shake();
            int whoTakesDamage = this.gameObject.tag == "PlayerOne" ? 1 : 2;
            levelManger.PlayerTakesDamage(whoTakesDamage);
        }
    }
    public void OnDisable()
    {
        myamin.SetTrigger("Hurt");
        hurt = true;
        MyBox.isTrigger = true;
        disabled = true;
        Invoke("OnEnable", 2.5f);


    }
    void OnEnable()
    {
        MyBox.isTrigger = false;
        hurt = false;
//        myamin.SetTrigger("Fine");
        disabled = false;
        //        myRb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    void FixedUpdate()
    {
        if (!disabled)
        {
              if (gameObject.tag == "PlayerOne")
                {


       
                float h = Input.GetAxisRaw("Horizontal");


            if (h * myRb.velocity.x < maxSpeed)
                    myRb.AddForce(Vector2.right * h * moveForce);

                if (Mathf.Abs(myRb.velocity.x) > maxSpeed)
                    myRb.velocity = new Vector2(Mathf.Sign(myRb.velocity.x) * maxSpeed, myRb.velocity.y);
            }
            if (gameObject.tag == "PlayerTwo")
            {


                float h = Input.GetAxisRaw("Horizontal_P2");


                if (h * myRb.velocity.x < maxSpeed)
                    myRb.AddForce(Vector2.right * h * moveForce);

                if (Mathf.Abs(myRb.velocity.x) > maxSpeed)
                    myRb.velocity = new Vector2(Mathf.Sign(myRb.velocity.x) * maxSpeed, myRb.velocity.y);
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (!disabled)
        {
            goingUp = myRb.velocity.y > 0;


            if (Input.GetKeyDown(KeyCode.U) && gameObject.tag == "PlayerTwo"|| Input.GetKeyDown(KeyCode.R) && gameObject.tag == "PlayerOne")
            {

                bool up;

                up = motor.motorSpeed > 0;
                if (!up)
                {
                    // theMotor.motorSpeed = 500;
                    motor = hinge.motor;
                    motor.motorSpeed = 800f;
                    hinge.motor = motor;
                }
                else
                {

                    motor = hinge.motor;
                    motor.motorSpeed = -800f;
                    hinge.motor = motor;
                }

            }
        }
    }
}




