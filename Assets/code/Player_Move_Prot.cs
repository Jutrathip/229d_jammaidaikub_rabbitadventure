using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class Player_Move_Prot : MonoBehaviour
{
    public int playerSpeed = 10;
    private bool facingRight = false;
    public int playerJumpPower = 1250;
    public bool isGrounded;
    private bool canDoubleJump = true; // เพิ่มตัวแปรเพื่อตรวจสอบการ double jump

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerRaycast();

        
    }

    void PlayerMove()
    {
        float moveX = Input.GetAxis("Horizontal");

        if (moveX > 0.0f && facingRight)
        {
            FlipPlayer();
        }
        else if (moveX < 0.0f && !facingRight)
        {
            FlipPlayer();
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                Jump();
                canDoubleJump = true; // ตรวจสอบเพื่อเปิดให้ทำ double jump ได้
            }
            else if (canDoubleJump)
            {
                Jump();
                canDoubleJump = false;
            }
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0); // รีเซ็ตความเร็วในแกน y เพื่อหยุดการกระโดดปัจจุบัน
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player has collided with " + collision.collider.name);
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }

        
    }

   



    void PlayerRaycast()
    {
        RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
        if (rayUp != null && rayUp.collider != null && rayUp.distance < 0.9f && rayUp.collider.name == "Box_2")
        {
            Destroy(rayUp.collider.gameObject);


        }



        RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);
        if (rayDown != null && rayDown.collider != null && rayDown.distance < 0.9f && rayDown.collider.tag == "enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rayDown.collider.gameObject.GetComponent<EnemyMove>().enabled = false;

        }
        if (rayDown != null && rayDown.collider != null && rayDown.distance < 0.9f && rayDown.collider.tag == "enemy")
        {
            isGrounded = true;
        }
    }

    


    private Vector2 CalculateProjectile(Vector2 origin, Vector2 targetPoint, float time)
    {
        Vector2 distance = targetPoint - origin;
        float velocityX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        Vector2 projectileVelocity = new Vector2(velocityX, velocityY);
        return projectileVelocity;
    }

}
