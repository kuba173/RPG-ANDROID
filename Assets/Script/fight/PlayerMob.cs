using System.Collections;

using System.Collections.Generic;

using UnityEngine;


public class PlayerMob : MonoBehaviour

{
    private float timeBtwShots;

    public float startTimeBtwShots;
    public float speed;

    public Joystick joystick;

    Vector2 move;

    public Rigidbody2D rb;

    public Transform shootingPoint;
    public GameObject bullet;
    public float bulletSpeed;
    public float bulletForce = 20f;



   void Start()
    {
          timeBtwShots = startTimeBtwShots;
    }
    void Update()

    {
      
        move.x = joystick.Horizontal;

        move.y = joystick.Vertical;



        float hAxis = joystick.Horizontal;

        float vAxis = joystick.Vertical;

        float zAxis = Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg;

        transform.eulerAngles = new Vector3(0, 0, -zAxis);
        if((joystick.Horizontal  != 0|| joystick.Vertical!=0)&&timeBtwShots< 0)
        {
            Shoot();
          timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    private void FixedUpdate()

    {

        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);

    }
    public void Shoot()
    {
      GameObject bulletClone =  Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);
        Rigidbody2D bulletRigidBody = bulletClone.GetComponent<Rigidbody2D>();
        bulletRigidBody.AddForce(shootingPoint.up * bulletForce, ForceMode2D.Impulse);

    }
}
