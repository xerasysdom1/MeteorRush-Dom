using UnityEditor.Search;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after
    //  the MonoBehaviour is created
    public GameObject enemyBulletPrefab;
    public Transform emenyFirePoint;
    
    float fireRate = 1.5f;
    float nextFire = 0f;
    public float moveSpeed;
    public float waveAmount;
    public float waveSpeed;
    float startY;
    public bool moveRight;
    void Start()
    {
        moveSpeed = Random.Range(1.5f, 3f);
        waveAmount = Random.Range(0.2f, 1f);
        waveSpeed = Random.Range(1f, 3f);
        startY = transform.position.y;
        // moveRight = true;
        nextFire = Time.time + Random.Range(0.5f, fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        //transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        float Y = startY + Mathf.Sin(Time.time * waveSpeed) * waveAmount;
        transform.position = new Vector3(transform.position.x, Y, transform.position.z);
        if (Time.time >= nextFire)
        {
            Shoot();
            nextFire = Time.time + fireRate;
        }
        if (transform.position.x > 5f || transform.position.x < -5f)
        {
            Destroy(gameObject);
        }
    }
    void Shoot()
    {
        Instantiate(enemyBulletPrefab, emenyFirePoint.position, Quaternion.identity);
    }
}
