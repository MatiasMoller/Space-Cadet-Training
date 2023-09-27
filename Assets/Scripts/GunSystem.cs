using UnityEngine;
using TMPro;

public class GunSystem : MonoBehaviour
{
    //Gun stats
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

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
        MyInput();

        //SetText
        text.SetText(bulletsLeft + " / " + magazineSize);
    }
    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }
    private void Shoot()
    {
        readyToShoot = false;

        // Create a ray at the center of the camera, shooting outwards.
        Ray ray = new Ray(fpsCam.transform.position, fpsCam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * range, Color.red); // Optionally draw the ray for debugging.

        if (Physics.Raycast(ray, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);

            if (rayHit.collider.CompareTag("Enemy"))
            {
                // Perform actions for hitting an enemy.
            }
        }
    




    //Graphics
    Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.FromToRotation(Vector3.forward,rayHit.normal));
        //Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
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
