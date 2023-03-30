using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    // 필요속성 : 회전속도
    public float rotSpeed = 200;
    float mx;
    float my;
    // Start is called before the first frame update
    void Start()
    {
        // 처음 카메라의 각도
        mx = transform.localEulerAngles.y;
        my = -transform.localEulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        // 사용자의 마우스 입력에 따라 물체를 회전시키고 싶다.
        // 1. 마우스 입력으로
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        // 3.회전시키고 싶다.
        // P = P0 + vt
        //transform.eulerAngles += dir * rotSpeed * Time.deltaTime;
        mx += h * rotSpeed * Time.deltaTime;
        my += v * rotSpeed * Time.deltaTime;

        // 상하회전이 -60~60 도 까지만 회전되도록 하고 싶다
        // 만약 my가 -60 보다 작다면 my를 -60으로 지정하고 싶다

        if(my < -60)
        {
            my = -60;
        }

        // 그렇지 않다면 my를 60으로 지정하고 싶다
        else if (my > 60)
        {
            my = 60;
        }
        my = Mathf.Clamp(my, -60, 60);

        transform.localEulerAngles = new Vector3(-my, mx, 0);

    }
}
