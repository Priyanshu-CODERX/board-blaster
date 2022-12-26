using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScoreCounter : MonoBehaviour
{
    public RandomPositioning PositionHelper;
    public GameObject ExplosionFX;
    private AudioSource SOURCE;
    public GameManager _GameManager { get; set; }

    private void Start()
    {
        PositionHelper = GameObject.Find("RandomPositioner").GetComponent<RandomPositioning>();
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        SOURCE = GameObject.Find("Board Audio Source").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            GameObject fx = Instantiate(ExplosionFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject, 0f);
            Destroy(fx, 1f);
            PositionHelper.instantiateAtRandom();
            Handheld.Vibrate();
            SOURCE.Play();
            _GameManager.IncrementScore(10);
        }
    }
}
