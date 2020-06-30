using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Duck: MonoBehaviour
{
    private Vector3 _initialPosition;
    private bool _birdLaunched;
    private float _timeSitting = 0;

    [SerializeField] private float _launchPower = 300;

    private void Awake()
    {
        _initialPosition = transform.position;
    }

    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        GetComponent<LineRenderer>().SetPosition(0, transform.position);

        if (_birdLaunched &&
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSitting += Time.deltaTime;
        }
        if (transform.position.y > 50 ||
            transform.position.x > 50 ||
            transform.position.y < -10 ||
            transform.position.x < -50 ||
            _timeSitting > 3)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.green;
        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdLaunched = true;
        GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}
