using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject prefabProjectile;
    public float velocityMulti = 8f;

    [Header("Set dynamically")]
    public GameObject launchPoint;

    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;
    private Rigidbody projectileRigidbody;


    // Use this for initialization
    void OnMouseEnter()
    {
        launchPoint.SetActive(true);
        //print("Slingshot:OnMouseEnter");
    }

    // Update is called once per frame
    void OnMouseExit()
    {
        launchPoint.SetActive(false);
        //print("OnMouseExit");
    }

    void Awake()
    {
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }

    void FixedUpdate()
    {
        //if slingshot is not in aimingMode
        if (!aimingMode) return;
    }

    void OnMouseDown()
    {
        //player has pressed mouse button down over slingshot
        aimingMode = true;
        //instantiating a proectile
        projectile = Instantiate(prefabProjectile) as GameObject;
        //start projectile at launch point
        projectile.transform.position = launchPos;
        //set projectile to isKinematic
        //projectile.GetComponent<Rigidbody>().isKinematic = true;
        projectileRigidbody = projectile.GetComponent<Rigidbody>();
        projectileRigidbody.isKinematic = true;
    }
}
