using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swiper : MonoBehaviour
{
    private Touch initTouch = new Touch();
    public Camera cam;
    private float width;
    private float height;
    public float forceMultiplier = 0.1f;
    public float positionMultiplier = 0.01f;

    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    Transform currentProjectile;
    public Transform Projectile;
    public Transform spawnPoint;
    public float projectileClampX;
    public float projectileClampY;
    float deltaX;
    float deltaY;

   

    private void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >=1)
        {
            Touch touch = Input.touches[0];

            if (touch.phase == TouchPhase.Began)
            {
                initTouch = touch;
                LoadProjectile();
            }

            else if (touch.phase == TouchPhase.Moved)
            {
                //swipe control
                deltaX = (initTouch.position.x - touch.position.x)/width;
                
                deltaY = (initTouch.position.y - touch.position.y)/height;
                

              

                currentProjectile.position = spawnPoint.position- new Vector3(deltaX/2,deltaY,deltaY)*positionMultiplier;
                currentProjectile.rotation = Quaternion.LookRotation(new Vector3(deltaX , deltaY * 1.2f, deltaY * 2f));
                DrawTrajectory.Instance.UpdateTrajectory(new Vector3(deltaX , deltaY*1.2f, deltaY*2f) * forceMultiplier,currentProjectile.GetComponent<Rigidbody>(),currentProjectile.position);
            }

            else if (touch.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
                ShootDart(deltaX,deltaY);

            }

        }
        
    }

    

    void ShootDart(float deltaX,float deltaY)
    {
        
        Rigidbody projectileRigidbody = currentProjectile.GetComponent<Rigidbody>();
        projectileRigidbody.isKinematic = false;
        projectileRigidbody.AddForce(new Vector3(deltaX , deltaY*1.2f, deltaY*2f) * forceMultiplier);
        currentProjectile.transform.parent = null;

        DrawTrajectory.Instance.HideLine();
    }

    void LoadProjectile()
    {
        currentProjectile = Instantiate(Projectile, spawnPoint.position, Quaternion.LookRotation(cam.transform.forward),cam.transform);
        

    }
}
