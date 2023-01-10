using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    MouseController mouseController;
    Vector3 mousePos;
    BulletVisualController bulletVisualController;
    public List<Bullet> bullets
    {
        get;
        protected set;
    }

    GameObject bulletPrefab;
    int qty = 2;
    void Start()
    {
        bullets = new List<Bullet>();
        mouseController = FindObjectOfType<MouseController>();
        bulletVisualController = FindObjectOfType<BulletVisualController>();
    }
    void Update()
    {
        mousePos = mouseController.mousePos;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressing mouse button");
            Shoot(qty);
        }

        if(bullets.Count > 0)
        {
//            Debug.Log("Updating bullet visuals");
            foreach (Bullet b in bullets)
            {
                b.Update(Time.deltaTime);
                bulletVisualController.OnBulletChanged(b);
            }
        }
    }

    void Shoot(int Qty)
    {
        if (Qty == 2)
        {   
            // TODO: Figure out how to calculate the target position for each bullet correctly
            Bullet bullet1 = new Bullet(mousePos);
            bullets.Add(bullet1);
            bulletVisualController.InstantiateBullet(bullet1);

            Bullet bullet2 = new Bullet(mousePos);
            bullets.Add(bullet2);
            bulletVisualController.InstantiateBullet(bullet2);
        }
    }

}
