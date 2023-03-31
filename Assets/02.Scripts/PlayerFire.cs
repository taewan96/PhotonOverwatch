using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    /*enum Hall{
        No,
        YES
    }*/
    public Transform hand;
    public GameObject[] bulletImpactFactoryList;
    float fireTime = 0;
    float fireRate = 0.07f;
    /*[SerializeField] private Hall hall;*/
    public int ammoCount;
    public int ammoMaxCount = 100;
    public TextMeshProUGUI textAmmoInfo;
    // Start is called before the first frame update
    void Start()
    {
        ammoCount = ammoMaxCount;

        
    }

    // Update is called once per frame

    private IEnumerator Reload()
    {


        if (Input.GetKeyDown(KeyCode.R) || ammoCount <= 0)
        {
            yield return new WaitForSeconds(1);

            ammoCount = 40;

        }
    }




    /*void ReloadTime()
    {
        Reload();

        Invoke("Reload", 5);
        Debug.Log("Reload() Time : " + Time.time);

    }*/
    void Shoot()
    {
        fireTime += Time.deltaTime;
        if (fireTime > fireRate)
        {

            if (Input.GetButton("Fire1"))
            {
                if (ammoCount <= 0)

                    return;

                --ammoCount;

                fireTime = 0;


                // hand���� hand�� �չ�������
                Ray ray = new Ray(hand.position, hand.forward + new Vector3(Random.Range(-0.2f, 0.2f),Random.Range(-0.2f, 0.2f), 0f));
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

        StartCoroutine(Reload());


        textAmmoInfo.text = ammoCount + "/" + ammoMaxCount;
    }
}
