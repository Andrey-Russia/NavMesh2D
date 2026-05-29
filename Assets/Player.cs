using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 4f;
    public Vector2 targetPosition;
    public bool isMoving = false;

    public string enemyTag = "Enemy";

    public string finishTag = "Finish";

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition = new Vector2(mouseWorldPos.x, mouseWorldPos.y);
            isMoving = true;
        }

        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if ((Vector2)transform.position == targetPosition)
            {
                isMoving = false;
            }
        }

        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(enemyTag))
        {
            Debug.Log("Игрок пойман! Перезагрузка сцены...");
            ReloadScene();
        }

        if (collision.CompareTag(finishTag))
        {
            Debug.Log("Уровень пройден!");
            ReloadScene();
        }
    }

    private void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}