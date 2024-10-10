using System.Collections;
using System.Collections.Generic;
using System.Security;
using Unity.VisualScripting;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    float timer = 0;
    [SerializeField]
    float spawnDelay = 0.2f;
    [SerializeField]
    float bulletPackLifetime = 0.5f;
    [SerializeField]
    bool Spawned = false;
    [SerializeField]
    bool pickedUp = false;
    GameObject bulletPack;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
   void Update()
    {
        Debug.Log(bulletPack);
        timer += Time.deltaTime;
        if (bulletPack != null && timer > spawnDelay)
        {
            bulletPack = Instantiate(prefab, transform.position, Quaternion.identity);
            timer = 0;
            Destroy(bulletPack, bulletPackLifetime);
        }
        if (bulletPack == null)
        {
            timer = 0;
        }
    }
}


