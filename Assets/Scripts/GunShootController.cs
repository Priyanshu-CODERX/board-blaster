using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Niantic.ARDK.Utilities.Input.Legacy;

public class GunShootController : MonoBehaviour
{
    public Camera _Camera;
    public Transform spawnPoint;
    public GameObject bullet;
    public AudioSource GunShotAudioSource;
    public float shootForce = 200f;

    private void Update()
    {
        this.gameObject.transform.position = _Camera.transform.position;
        this.gameObject.transform.rotation = _Camera.transform.rotation;

        if (PlatformAgnosticInput.touchCount <= 0) return;

        var touch = PlatformAgnosticInput.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
            OnTouched();
    }

    public void OnTouched()
    {
        ShootBullet();
    }

    private void ShootBullet()
    {
        GameObject insbullet = Instantiate(bullet, spawnPoint.position, bullet.transform.rotation);
        Rigidbody rb = insbullet.GetComponent<Rigidbody>();
        rb.AddForce(spawnPoint.forward * shootForce, ForceMode.Impulse);
        GunShotAudioSource.Play();
    }
}
