using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject enemyBulletPrefab;
    public float startDelay = 2f;
    public float shootDelay = 0.5f;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShootBullet", startDelay, shootDelay);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }

    void ShootBullet()
    {
        Instantiate(enemyBulletPrefab, transform.position, enemyBulletPrefab.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        // detect getting hit by player attack, update score count + remove enemy and player projectile + display explosion effect
        if (other.gameObject.tag == "PlayerBullet")
        {
            Debug.Log("Enemy hit by bullet");
            Destroy(gameObject);
            Destroy(other.gameObject);
            gameManager.UpdateScore(1);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
    }
}
