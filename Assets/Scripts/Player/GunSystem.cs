using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;
using System.Collections;

public class GunSystem : MonoBehaviour
{
    //Gun stats
    public float damage = 5f;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;
    

  

    [SerializeField] private ParticleSystem ImpactParticleSystem;
    [SerializeField] private TrailRenderer BulletTrail;
    [SerializeField] private ParticleSystem ShootingSystem;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private AudioSource laserShot;

    //bools 
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    //Graphics
    public GameObject  bulletHoleGraphic;
    
    //public GameObject muzzleFlash;


    public TextMeshProUGUI text;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void Update()
    {
       if (Input.GetMouseButtonDown(0))
        { 
           if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
                bulletsShot = bulletsPerTap;
            Shoot();
        }
    }

   



    private void Shoot()
    {
        muzzleFlash.Play();
        laserShot.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            TrailRenderer trail = Instantiate(BulletTrail, attackPoint.position, Quaternion.identity);

            StartCoroutine(SpawnTrail(trail, hit));


            Target target = hit.transform.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
      

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }


    private IEnumerator SpawnTrail(TrailRenderer Trail, RaycastHit hit)
    {
        float time = 0;
        Vector3 startPosition = Trail.transform.position;

        while(time< 1)
        {
            Trail.transform.position = Vector3.Lerp(startPosition, hit.point, time);
            time += Time.deltaTime / Trail.time;

            yield return null;
        }
        Trail.transform.position = hit.point;
        Instantiate(ImpactParticleSystem, hit.point, Quaternion.LookRotation(hit.normal));

        Destroy(Trail.gameObject, Trail.time);
    }
    private void ResetShot()
    {
        readyToShoot = true;
    }
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }

    private void OnDestroy()
    {
        // Unlock and show the cursor when the game ends or the script is destroyed
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

  
}
