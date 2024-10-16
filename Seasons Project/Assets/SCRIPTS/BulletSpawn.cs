using System.Collections;
using System.Collections.Generic;
using System.Security;
using Unity.VisualScripting;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    GameObject player;
    [SerializeField]
    float timer = 0;
    [SerializeField]
    float spawnDelay = 5f;
    [SerializeField]
    float spawnTime = 15;
    [SerializeField]
    float bulletPackLifetime = 0f;
    [SerializeField]
    float spawnAmount = 1f;
    [SerializeField]
    bool Spawned = false;
    [SerializeField]
    public bool pickedUp = false;
    GameObject bulletPack;
    // Start is called before the first frame update
    void Start()
    {
        Spawned = false;
        spawnAmount = 0f;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
   void Update()
    {
        Debug.Log(bulletPack);
        timer += Time.deltaTime;
        if (Spawned == false && timer > spawnDelay && spawnAmount >= 0)
        {
            spawnAmount += 1;
            bulletPack = Instantiate(prefab, transform.position, Quaternion.identity);
            Spawned = true;
        }
        if (Spawned == true && timer > spawnTime && spawnAmount >= 1)
        {
            spawnAmount -= 1;
            Destroy(bulletPack, bulletPackLifetime);
            timer = 0;
            Spawned = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            spawnAmount -= 1;
            Spawned = false;
        }
    }
}


