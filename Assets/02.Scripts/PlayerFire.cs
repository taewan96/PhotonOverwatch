using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    enum Hall{
        No,
        YES
    }
    public Transform hand;
    public GameObject[] bulletImpactFactoryList;
    float fireTime = 0;
    float fireRate = 0.07f;
    [SerializeField] private Hall hall;
    public int ammoCount;
    public int ammoMaxCount = 100;
    // Start is called before the first frame update
    void Start()
    {
        ammoCount = ammoMaxCount;
    }

    // Update is called once per frame

    void Reload()
    {
        

        if(Input.GetKeyDown(KeyCode.R))
        {
            ammoCount = 40;
        }
    }



    void Shoot()
    {
        fireTime += Time.deltaTime;
        if (fireTime > fireRate)
        {

            if (/*fireTime > fireRate && */Input.GetButton("Fire1"))
            {
                if (ammoCount <= 0)

                    return;

                

                --ammoCount;
                fireTime = 0;
                // hand���� hand�� �չ�������
                Ray ray = new Ray(hand.position, hand.forward);
                RaycastHit hitInfo;
                // raycast�� �̿��ؼ� ���� ��� �ʹ�.
                if (Physics.Raycast(ray, out hitInfo))
                {
                    GameObject prefabs;
                    // �ε��� ��ġ�� �Ѿ��ڱ��� ����� �ʹ�.
                    if (hitInfo.transform.CompareTag("Enemy"))
                    {
                        prefabs = bulletImpactFactoryList[0];
                    }
                    else
                    {
                        prefabs = bulletImpactFactoryList[1];
                    }
                    GameObject bi = Instantiate(prefabs);

                    bi.transform.position = hitInfo.point;
                    bi.transform.up = hitInfo.point;

                }

            }
            
        }
    }
    void Update()
    {
        Shoot();

        Reload();

    }
}
