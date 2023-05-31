using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnBullet;
    public float shootForce;
    public float shootRate;
    public float shootRateTime;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > shootRateTime)
            {
                GameObject newbullet;

                newbullet = Instantiate(bullet, spawnBullet.position, spawnBullet.rotation);

                newbullet.GetComponent<Rigidbody>().AddForce(spawnBullet.right * shootForce);

                shootRateTime = Time.time + shootRate;

                Destroy(newbullet, 1);

            }
        }
    }
}
