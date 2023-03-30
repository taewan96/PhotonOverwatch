using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    // �ʿ�Ӽ� : �̵��ӵ�
    public float speed = 5;
    CharacterController cc = null;
    // �ʿ�Ӽ� : �߷°��ӵ�, �����ӵ�
    public float gravity = -20;
    float yVelocity = 0;
    // �ʿ�Ӽ� : �����Ŀ�.
    public float jumpPower = 5;
    // ���߿� �ִ��� ����
    bool isInAir = false;
    public int jumpMaxCount = 1;
    public int jumpCount = 1;
    // Start is called before the first frame update

    public Transform bodyMesh;
    void Start()
    {
        cc = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        
        // ������� �Է¿����� �յ��¿�� �̵��ϰ� �ʹ�.
        // 1. ������� �Է¿�����
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");



        // ī�޶� ȸ���� �� ��ü�� ȸ����Ű�� �ʹ�.(ī�޶��������)
        // -> BodyMesh ���ϴ� ������ ī�޶� ���ϴ� �������� ����
        //�������ϴ� ���Ͱ� ī�޶� ���ϴ� ���������
        Vector3 bodyDir = Camera.main.transform.forward;
        bodyDir.y = 0;
        bodyMesh.forward = bodyDir;

        
 
        // 2. �������ʿ�
        Vector3 dir = new Vector3(h, 0, v);
        // ī�޶� ���ϴ� �������� �����ؾ��Ѵ�.
        dir = Camera.main.transform.TransformDirection(dir);

        // �߷��� ����޵��� �ϰ� �ʹ�.
        // ��ӿ v = v0 + at
        yVelocity += gravity * Time.deltaTime;
        // y = y0 + at
        // �����׷��� ���������� �Ѵ�.
        // �ٴڿ� ���� ���� 
        // above, side, below
        //if(cc.isGrounded)
        //print("collisionFlags : " + cc.collisionFlags);
        if (cc.collisionFlags == CollisionFlags.Below)
        {
            yVelocity = 0;
            //�����ӵ��� 0���� ����� �Ѵ�.
            jumpCount = 0;

        }

        // �ٴڿ� ���� ��
        // 0. ����ڰ� ������ư�� ������ ������ �ϰ� �ʹ�.
        // 1. �ִ�����Ƚ������ ���� �پ��� ����
        // -> ���� ���Ƚ���� �ִ�Ƚ�� ���϶��
        // 2. ������ư�� �������ϱ�
        // 3. ������ �ϰ�ʹ�

        if (jumpCount < jumpMaxCount && Input.GetButtonDown("Jump"))
        {
            jumpCount++;
            yVelocity = jumpPower;

        }

        dir.y = yVelocity;
        // 3. �̵��ϰ�ʹ�.
        // P = P0 + vt
        //transform.position += dir * speed * Time.deltaTime;
        cc.Move(dir * speed * Time.deltaTime);




    }
}

