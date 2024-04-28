using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    public float rotationSpeed = 50f; // ความเร็วในการหมุน
    void Update()
    {
        // หมุนโดยใช้แกน Y (สามารถเปลี่ยนแกนตามต้องการ)
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
