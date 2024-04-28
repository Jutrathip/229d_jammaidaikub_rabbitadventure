using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 10;
    public Transform Ball;
    public Transform PosDribble;
    public Transform PosOverHead;

    // variables
    private bool IsBallInHands = true;
    private bool IsBallFlying = false;
    private float T = 0;

    // Update is called once per frame
    void Update()
    {

        // walking
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        transform.position += direction * MoveSpeed * Time.deltaTime;
        transform.LookAt(transform.position + direction);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "coin")
        {
            Score.scoreCount +=1 ;
            Destroy(other.gameObject);
        }
    }
}
