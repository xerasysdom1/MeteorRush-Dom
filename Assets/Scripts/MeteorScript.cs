using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    float speed = 3f;
    GameManager gm;
    float maxLives;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
        maxLives = gm.getMaxLives();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        
        if (transform.position.y > 6f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gm.TakeDamage(maxLives);
            // Destroy(gameObject);
        }
    }
}
