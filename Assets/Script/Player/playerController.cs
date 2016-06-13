using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {


    //Objects to check direction, isGrounded, etc
    GameObject feet;
    GameObject head;
    //Positive = facing right
    bool facing;
    bool isGrounded;

    public Transform top_left;
    public Transform bottom_right;

    playerSystem pSystem;
    bool doubleJumpEnabled;    
    float gravity = 1;
    float shootTimer;
    

	// Use this for initialization
	void Start () {

        //TODO init pSystem vars (eg shootTimer)
        pSystem = this.GetComponent<playerSystem>();

        //Set top_left and bottom_right to respective places
        top_left.position = GetComponent<Collider2D>().bounds.center - GetComponent<Collider2D>().bounds.extents;
        bottom_right.position = GetComponent<Collider2D>().bounds.center + GetComponent<Collider2D>().bounds.extents;
    }

    void move(float h)
    {
        transform.Translate(h, 0, 0);
    }

    void jump()
    {
        Vector3 force = new Vector3(0,pSystem.getJumpStrength(),0);
        GetComponent<Rigidbody>().AddForce(force);
    }
	
    void boostJump(float h, float v)
    {
        Vector3 force = new Vector3(h, pSystem.getJumpStrength(), v);
        GetComponent<Rigidbody>().AddForce(force);
    }

    void shootWeapon()
    {
        pSystem.getWeap().shoot(facing);
    }

	// Update is called once per frame
	void Update () {

        if (!pSystem.getVitals())
        {
            return;
        }

        //TODO add grounded code

        float h = Input.GetAxis("Horiz");
        float v = Input.GetAxis("Vert");

        h = h / h;
        v = v / v;

        //Positive Horiz value means player is facing right
        if(h > 0)
        {
            facing = true;
        }

        if(h < 0)
        {
            facing = false;
        }

        move(h * pSystem.getSpeed() * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            jump();
        }

        if(Input.GetButtonDown("Jump") && !isGrounded && doubleJumpEnabled)
        {
            boostJump(h, v);
        }

        if(Input.GetButton("Shoot") && shootTimer <= 0)
        {
            shootWeapon();
        }

        if(Input.GetButtonDown("Item"))
        {
            //TODO item use code
            pSystem.getItem().use();
        }
        if(Input.GetKey(KeyCode.Space))
        {
            //TODO space power
            pSystem.getPlayerClass().useAbility();
        }

        transform.Translate(0, -gravity * Time.deltaTime, 0);

        if(shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }
        if(shootTimer < 0)
        {
            shootTimer = 0;
        }

	}

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(top_left.position, bottom_right.position, LayerMask.NameToLayer("Ground"));
    }
}
