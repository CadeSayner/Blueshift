using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletVisualController : MonoBehaviour
{
    public GameObject bulletPrefab;
    List<Bullet> bullets;
    public Dictionary<Bullet, GameObject> bulletGameObjectMap;
    void Start()
    {
        bullets = FindObjectOfType<PlayerController>().bullets;
        bulletGameObjectMap = new Dictionary<Bullet, GameObject>();
    }
    // Update is called once per frame
    public void InstantiateBullet(Bullet bullet)
    {
        GameObject bulletgo = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
        bulletGameObjectMap[bullet] = bulletgo;
    }

    public void OnBulletChanged(Bullet bullet)
    {
        GameObject go = bulletGameObjectMap[bullet];
        go.transform.position = new Vector3 ( bullet.X, bullet.Y, 0 );
    }
}
