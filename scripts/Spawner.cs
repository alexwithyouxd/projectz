using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject sprite;
    public float interval = 1.0f;
    public float minDistance = 2.0f; // minimum distance between sprites
    private Camera mainCamera;
    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    void Start()
    {
        mainCamera = Camera.main;
        SetCameraBoundaries();
        InvokeRepeating("SpawnSprites", 0.0f, interval);
    }

    void Update()
    {
        SetCameraBoundaries();
    }

    void SetCameraBoundaries()
    {
        float distance = mainCamera.transform.position.z;
        Vector3 leftBottom = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightTop = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, distance));

        xMin = leftBottom.x;
        xMax = rightTop.x;
        yMin = leftBottom.y;
        yMax = rightTop.y;
    }

    void SpawnSprites()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 spawnPosition = GetRandomPosition();
            Instantiate(sprite, spawnPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomPosition()
    {
        bool validPosition = false;
        Vector3 position = Vector3.zero;
        while (!validPosition)
        {
            float x = Random.Range(xMin, xMax);
            float y = Random.Range(yMin, yMax);
            position = new Vector3(x, y, 0);
            position = mainCamera.ScreenToWorldPoint(position);
            validPosition = IsValidPosition(position);
        }
        return position;
    }

    bool IsValidPosition(Vector3 position)
    {
        Collider2D collider = Physics2D.OverlapCircle(position, minDistance);
        if (collider != null)
            return false;
        return true;
    }
}