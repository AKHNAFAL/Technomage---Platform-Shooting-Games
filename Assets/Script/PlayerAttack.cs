using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public Transform shootingPoint; // Titik dari mana peluru akan ditembakkan
    public GameObject projectilePrefab; // Prefab peluru
    public float shootCooldown = 0.5f; // Waktu cooldown antara tembakan
    private float lastShootTime; // Waktu terakhir peluru ditembakkan
    AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        lastShootTime = -shootCooldown; // Inisialisasi agar bisa langsung menembak
    }

    void Update()
    {
        // Update logika lain jika diperlukan
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed && Time.time >= lastShootTime + shootCooldown)
        {
            GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, shootingPoint.rotation);  
            // Set waktu terakhir tembakan
            if (projectile != null)
            {
                // Set waktu terakhir tembakan
                lastShootTime = Time.time;
                audioManager.PlaySFX(audioManager.shootSound);
            }
        }
    }
}