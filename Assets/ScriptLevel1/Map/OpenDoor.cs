using System;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;

    private bool isOpenDoor;
    public OpenMessageDialog dialog;

    private BoxCollider2D boxCollider2D;
    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    public event EventHandler<OnOpenDoorCallMessageTaskEventArg> OnOpenDoorCallMessageTask;
    public class OnOpenDoorCallMessageTaskEventArg : EventArgs
    {
        public bool isOpenDoor { get; set; }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player2"))
        {
            playercontroller player = collision.gameObject.GetComponent<playercontroller>();
            if (player != null && player.HasKey())
            {
                Destroy(gameObject);
                dialog.Hide();
            }
        }
    }
    private void Update()
    {
        isOpenDoor = InteractionWithPlayer();
        OnOpenDoorCallMessageTask?.Invoke(this, new OnOpenDoorCallMessageTaskEventArg { isOpenDoor = isOpenDoor });
    }
    private bool InteractionWithPlayer()
    {
        Collider2D playerCollider2D = Physics2D.OverlapBox(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, playerMask);
        return playerCollider2D != null;
    }
}
