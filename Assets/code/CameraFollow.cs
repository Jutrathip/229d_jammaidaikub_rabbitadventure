using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ใส่ Transform ของ GameObject ที่คุณต้องการให้กล้องตาม
    public float smoothTime = 0.5f; // เวลาที่ใช้ในการสมูธของกล้อง
    public float distanceFromTarget = 10f; // ระยะห่างของกล้องจาก GameObject ที่กำหนด

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + new Vector3(0, 0, -distanceFromTarget); // ตำแหน่งที่กล้องจะเลื่อนไป (พร้อมกับระยะทาง Z เพื่อให้กล้องมองไปที่สิ่งที่ตาม)
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime); // การเคลื่อนไหวของกล้องที่นุ่มนวล

            transform.position = smoothedPosition; // ปรับตำแหน่งของกล้อง

            
        }

    }
}
