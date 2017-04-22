using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSman : MonoBehaviour
{
    public Transform Muzzle;
    public GameObject Bullet;
    public float Force;
    public GameObject Flash;

    private float FlashMaxTimer = 0.075f;
    private float mFlashTimer = 0.0f;

    private bool mShoot = false;


	void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mShoot = true;
            Flash.SetActive(true);

            mFlashTimer = 0.0f;
        }

        if(mFlashTimer > FlashMaxTimer)
        {
            Flash.SetActive(false);
        }

        mFlashTimer += Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (mShoot)
        {
            var bulletObj = GameObject.Instantiate(Bullet, Muzzle.position, Quaternion.identity);
            bulletObj.GetComponent<Rigidbody>().AddForce(Muzzle.forward * Force, ForceMode.Impulse);

            mShoot = false;
        }
    }
}
