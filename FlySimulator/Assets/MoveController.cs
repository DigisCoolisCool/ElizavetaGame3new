using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float FlySpeed = 5;
    public float YawAmount = 120;
    private float Yaw;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * FlySpeed * Time.deltaTime;

        //Input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 
        Yaw += horizontalInput * YawAmount * Time.deltaTime;
        float FrwdBack = Mathf.Lerp(0, 90, Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput);
        float roll = Mathf.Lerp(0, 20, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);

        //rotation

        transform.localRotation = Quaternion.Euler(Vector3.up * Yaw + Vector3.right * FrwdBack + Vector3.forward * roll);

    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Collect")
        { 
                Destroy(other.gameObject);


        }
        
    }

}