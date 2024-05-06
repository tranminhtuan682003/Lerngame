using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform leftLimit;
    [SerializeField] private Transform rightLimit;
    [SerializeField] private Transform triggeredPlayer;
    [SerializeField] private Transform enemy;
    [SerializeField] private Transform enemyGFX;
    [SerializeField] private float moveSpeed;


    private float moveDirec;
    private void Start()
    {
        moveDirec = -Mathf.Sign(enemyGFX.localScale.x);
    }
    private void Update()
    {
        HandleMovement();   
    }
    private void HandleMovement()
    {
        if (enemy.position.x < leftLimit.position.x || enemy.position.x > rightLimit.position.x) {
            moveDirec = -moveDirec;
        }
        enemy.position += new Vector3(moveDirec * moveSpeed * Time.deltaTime, 0f, 0f);
        enemy.localScale = new Vector3(-Mathf.Abs(transform.localScale.x) * moveDirec, transform.localScale.x, transform.localScale.z);
    }
}
