using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    GameObject prefab;
    [SerializeField]
    float timer = 0;
    [SerializeField]
    float spawnDelay = 0.2f;
    [SerializeField]
    bool Spawned = true;
    [SerializeField]
    bool pickedUp = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
   void Update()
    {
        timer += Time.deltaTime;
        Vector3 bulletPack = transform.position;
        bulletPack.z = 0;
        bulletPack.Normalize();
    }
}
