using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour
{
    public int EnemySpeed;
    public int XMoveDirection = -1; // เริ่มต้นให้ศัตรูเคลื่อนที่ไปทางซ้าย
    public float wallCheckDistance = 0.1f; // ระยะห่างในการตรวจสอบการชนกับสิ่งกีดขวาง
    public string mainmenu;

    bool hasFlipped = false; // เพิ่มตัวแปรเพื่อตรวจสอบว่าเคยพลิกทิศทางหรือไม่

    void Update()
    {
        // ตรวจสอบการชนกับสิ่งกีดขวาง
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0), wallCheckDistance);

        // ตั้งค่าความเร็วให้ศัตรู
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;

        // หากมีการชน
        if (hit.collider != null)
        {
            if (!hasFlipped) // ตรวจสอบว่ายังไม่เคยพลิกทิศทาง
            {
                Flip(); // พลิกทิศทาง
                        // หันหน้าศัตรูให้สอดคล้องกับทิศทางใหม่
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                hasFlipped = true; // ตั้งค่าให้เคยพลิกทิศทางแล้ว

                if (hit.collider.tag == "Player")
                {
                    Destroy(hit.collider.gameObject);
                    SceneManager.LoadScene(mainmenu);

                }
            }
        }
        else
        {
            hasFlipped = false; // ตั้งค่าให้ยังไม่เคยพลิกทิศทาง
        }

        if (gameObject.transform.position.y < -50)
        {
            Destroy(gameObject);
        }





    }


    void Flip()
    {
        // กำหนดทิศทางใหม่ของการเคลื่อนที่
        XMoveDirection *= -1; // เปลี่ยนเครื่องหมายของ XMoveDirection ให้เป็นตรงข้าม
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
        }
    }
}



