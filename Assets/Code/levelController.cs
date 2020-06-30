using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class levelController : MonoBehaviour
{
    private static int _nextLevelIndex = 1;
    private Enemy[] _enemies;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    void Update()
    {
        foreach (Enemy enemy in _enemies)
        {
            if (enemy != null)
                return;
        }
        StartCoroutine(Wait());
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        _nextLevelIndex++;
        string nextLevelName = "Level" + _nextLevelIndex;
        SceneManager.LoadScene(nextLevelName);
    }
}
