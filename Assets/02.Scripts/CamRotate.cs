using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    // �ʿ�Ӽ� : ȸ���ӵ�
    public float rotSpeed = 200;
    float mx;
    float my;
    // Start is called before the first frame update
    void Start()
    {
        // ó�� ī�޶��� ����
        mx = transform.localEulerAngles.y;
        my = -transform.localEulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        // ������� ���콺 �Է¿� ���� ��ü�� ȸ����Ű�� �ʹ�.
        // 1. ���콺 �Է�����
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        // 3.ȸ����Ű�� �ʹ�.
        // P = P0 + vt
        //transform.eulerAngles += dir * rotSpeed * Time.deltaTime;
        mx += h * rotSpeed * Time.deltaTime;
        my += v * rotSpeed * Time.deltaTime;

        // ����ȸ���� -60~60 �� ������ ȸ���ǵ��� �ϰ� �ʹ�
        // ���� my�� -60 ���� �۴ٸ� my�� -60���� �����ϰ� �ʹ�

        if(my < -60)
        {
            my = -60;
        }

        // �׷��� �ʴٸ� my�� 60���� �����ϰ� �ʹ�
        else if (my > 60)
        {
            my = 60;
        }
        my = Mathf.Clamp(my, -60, 60);

        transform.localEulerAngles = new Vector3(-my, mx, 0);

    }
}
