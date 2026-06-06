using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public AudioSource audioSource;
    public AudioClip shootClip;
    float fireRate = 0.25f;
    float nextFire = 0f;
    float moveSpeed = 5f;
    float currentLives;
    GameManager gm;
    Vector2 moveInput;
    float minX = -2.5f, maxX = 2.5f, minY = -4.5f, maxY = 4.5f;
    // Start is called once before the first execution of Update after
    // the MonoBehaviour is created
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    public void OnAttack()
    {
        if (Time.time >= nextFire)
        {
            audioSource.PlayOneShot(shootClip);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            nextFire = Time.time + fireRate;
        }
    }
    public void OnRestart(InputValue value)
    {
        if (value.isPressed && gm.getCurrentLives() <= 0)
        {
            Destroy(gameObject);
            gm.RestartGame();
        }
    }
    void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
        currentLives = gm.getMaxLives();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(moveInput.x, moveInput.y, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime;

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
        currentLives = gm.getCurrentLives();
    }
}
