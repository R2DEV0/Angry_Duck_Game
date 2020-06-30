using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    AudioSource audioData;
    [SerializeField] private GameObject _enemyDiePrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Duck duck = collision.collider.GetComponent<Duck>();
        if (duck != null)
        {
            Instantiate(_enemyDiePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            audioData = GetComponent<AudioSource>();
            audioData.Play(0);
            return;
        }

        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            Instantiate(_enemyDiePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        if (collision.contacts[0].normal.y < -0.5 ||
            collision.contacts[0].normal.x < -0.5 ||
            collision.contacts[0].normal.x > 0.5)
        {
            Instantiate(_enemyDiePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
