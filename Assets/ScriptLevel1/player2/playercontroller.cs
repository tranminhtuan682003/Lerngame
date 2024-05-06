using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class playercontroller : MonoBehaviour
{
    public bool isDeath;
    Vector2 checkpoint;
    public static playercontroller Instance { get; private set; }
    [SerializeField] private Rigidbody2D rb;
    private BoxCollider2D colider;
    private SpriteRenderer spriteRenderer;
    public Animator animator;
    //di chuyen va lat anh
    public float horizontal;
    //public float vertical;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpingpower = 12f;
    private bool isfacingright = true;

    //t?o máu va damage 
    public float Health;
    public float maxHealth = 200;
    public int damage = 10;
    //toc bien
    private bool candash = true;
    private bool isDashing;
    [SerializeField] private float Dashingpower = 15f;
    private float dashingtime = 0.1f;
    private float Dashingcooldown = 1f;
    [SerializeField] private TrailRenderer tr;

    //cpray
    private float timepray = 4f;
    private float timepraydelay = 8f;

    private bool hasAttacked = false;
    //enemy
    public ChickyController chicky;
    public List<ArmyController> army;
    private string[] tagArmy;
    public CanongunController canon;
    public DroneHandle drone;
    public HealthIronBoss BossIron2;
    public PlaneAttack plane;
    //vatpham
    public GameObject Healthplus;
    //gamemanager
    public GameManager gamemanager;
    private bool isDead;
    //textpro
    public List<TextMeshProUGUI> textMeshList = new List<TextMeshProUGUI>();
    private string[] textItem;
    //slier
    [SerializeField] private Slider sliderHealth;
    // vat pham trong game
    private bool hasKey = false;
    private bool hasquykiem = false;
    private bool hasGiapHoMenh = false;
    private bool hasKiemFeny = false;

    int canJump = 0;
    void Start()
    {
        Physics2D.IgnoreLayerCollision(7, 13);
        checkpoint = transform.position;
        Health = maxHealth;
        sliderHealth.value =(float) maxHealth / 500;
        BoolItem();
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        colider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        Instance = this;
    }
    void Update()
    {
        move();
        TextItems();
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        rb.velocity = new Vector2(horizontal * speed,rb.velocity.y);
    }
    private void move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (isDashing)
            return;

        if (horizontal == 0)
        {
            timepray += Time.deltaTime;
            if (timepray >= timepraydelay)
                animator.SetBool("IsPray", true);
        }
        else
        {
            timepray = 4f;
            animator.SetBool("IsPray", false);
        }
        if (Mathf.Abs(rb.velocity.y)<.1f)
        {
            canJump = 1;
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) && canJump == 1) {
                rb.velocity = new Vector2(rb.velocity.x, jumpingpower);
                AudioManager.instance.OpenSFXSound("Jump");
                AudioManager.instance.sfxSource.volume = 0.1f;
                animator.SetBool("IsJump", true);
                canJump = 0;
            }
        }
        else
        {
            canJump = 0;
        }
        if (Mathf.Abs(rb.velocity.x) < .001f)
        {
            animator.SetBool("IsRun", false);
        }
        bool isrun = Mathf.Abs(horizontal) > 0.1f;
        if (isrun)
        {
            animator.SetBool("IsRun", true);
            if (Input.GetKeyDown(KeyCode.DownArrow))
                animator.SetBool("IsCroll", true);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
            StartCoroutine(Dash());

        flip();

        if (!isrun && canJump == 0 )
        {
            resetanimator();
        }
        Attack();
    }
    private void Attack()
    {
        bool isAttack1 = Input.GetKeyDown(KeyCode.J);
        bool isAttack2 = Input.GetKey(KeyCode.K);
        bool isAttack3 = Input.GetKey(KeyCode.L);
        bool isAttack4 = Input.GetKey(KeyCode.Space);

        if (isAttack1 && !hasAttacked)
        {
            AudioManager.instance.OpenSFXSound("Attack1");
            AudioManager.instance.sfxSource.volume = 10f;
            animator.SetBool("IsAttackDown", true);
            hasAttacked = true;
            StartCoroutine(ResetAttack());
        }
        if (isAttack2 && !hasAttacked)
        {
            AudioManager.instance.OpenSFXSound("Attack1");
            AudioManager.instance.sfxSource.volume = 10f;
            animator.SetBool("IsAttack1", true);
            hasAttacked = true;
            StartCoroutine(ResetAttack());
        }
        if (isAttack3 && !hasAttacked)
        {
            AudioManager.instance.OpenSFXSound("Attack1");
            AudioManager.instance.sfxSource.volume = 10f;
            animator.SetBool("IsAttack2", true);
            hasAttacked = true;
            StartCoroutine(ResetAttack());
        }
        if (isAttack4 && !hasAttacked)
        {
            AudioManager.instance.OpenSFXSound("Attack1");
            AudioManager.instance.sfxSource.volume = 10f;
            animator.SetBool("IsAttack1", true);
            hasAttacked = true;
            StartCoroutine(ResetAttack());
        }
    }
    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("IsAttackDown", false);
        animator.SetBool("IsAttack1", false);
        animator.SetBool("IsAttack2", false);
        hasAttacked = false;
    }
    private void resetanimator()
    {
        animator.SetBool("IsCroll", false);
        animator.SetBool("IsRun", false);
        animator.SetBool("IsJump", false);

    }
    private void flip()
    {
        if(isfacingright && horizontal < 0f || !isfacingright && horizontal > 0f)
        {
            isfacingright = !isfacingright;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1f;
            transform.localScale = localscale;
        }
    }
    public void Takedamage(float amount)
    {
        Health -= amount;
        sliderHealth.value -= (float) amount / maxHealth; 
        Debug.Log("Health con : " + Health);
        animator.SetBool("IsHurt", true);
        Debug.Log("Người chơi nhận: " + amount + " sát thương");

        if (Health <= 0 && !isDead /*&& hasGiapHoMenh == false*/)
        {
            gameObject.SetActive(false);
            isDead = true;
            AudioManager.instance.OpenSFXSound("Death");
            AudioManager.instance.sfxSource.volume = 5f;
        }
        //if (Health <= 0 && !isDead && hasGiapHoMenh == true)
        //{
        //    Die();
        //    StartCoroutine(WaitHoiSinh());
        //}
        else
        {
            animator.SetBool("IsHurt", true);
            StartCoroutine(ResetIsHurt());
        }
    }
    private IEnumerator ResetIsHurt()
    {
        yield return new WaitForSeconds(0.15f);
        animator.SetBool("IsHurt", false);
    }
    //cho hoi sinh
    private IEnumerator WaitHoiSinh()
    {
        yield return new WaitForSeconds(2);
        spriteRenderer.enabled = true;
        Debug.Log("da cong 150 mau"+ Health);
        Health = 150;
        hasGiapHoMenh = false;
        isDead = false;
    }

    private void Die()
    {
        spriteRenderer.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Health")
        {
            Health += 20;
            sliderHealth.value += 20 / maxHealth;
            Destroy(Healthplus);
            Debug.Log("da an mau");
        }
        if (hasquykiem == true)
        {
            //chicky
            if (collision.gameObject.tag == "chicky" && Input.GetKey(KeyCode.K))
            {
                chicky.TakeDamage(10);
                Health += 1;
            }
            if (collision.gameObject.tag == "chicky" && Input.GetKey(KeyCode.L))
            {
                chicky.TakeDamage(20);
                Health += 2;
            }
            //army2
            for(int i = 0; i < 5; i++)
            {
                if (collision.gameObject.CompareTag(tagArmy[i]) && Input.GetKey(KeyCode.K))
                {
                    army[i].TakeDamage(10);
                    Health += 1;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (collision.gameObject.CompareTag(tagArmy[i]) && Input.GetKey(KeyCode.K))
                {
                    army[i].TakeDamage(20);
                    Health += 2;
                }
            }
            //BossIron
            if (collision.gameObject.tag == "Drone" && Input.GetKey(KeyCode.K))
            {
                drone.TakeDamage(10);
                Health += 1;
            }
            if (collision.gameObject.tag == "Drone" && Input.GetKey(KeyCode.L))
            {
                drone.TakeDamage(20);
                Health += 2;
            }
            if (collision.gameObject.tag == "Spider" && Input.GetKey(KeyCode.K))
            {
                BossIron2.TakeDamage(10);
                Health += 1;
            }
            if (collision.gameObject.tag == "Spider" && Input.GetKey(KeyCode.L))
            {
                BossIron2.TakeDamage(20);
                Health += 2;
            }
        }
        if (hasKiemFeny == true)
        {
            //chicky
            if (collision.gameObject.tag == "chicky" && Input.GetKey(KeyCode.K))
            {
                chicky.TakeDamage(12);
            }
            if (collision.gameObject.tag == "chicky" && Input.GetKey(KeyCode.L))
            {
                chicky.TakeDamage(22);
            }
            //army2
            for (int i = 0; i < 5; i++)
            {
                if (collision.gameObject.CompareTag(tagArmy[i]) && Input.GetKey(KeyCode.K))
                {
                    army[i].TakeDamage(12);
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (collision.gameObject.CompareTag(tagArmy[i]) && Input.GetKey(KeyCode.L))
                {
                    army[i].TakeDamage(24);
                }
            }
            //BossIron1
            if (collision.gameObject.tag == "Drone" && Input.GetKey(KeyCode.K))
            {
                drone.TakeDamage(12);
            }
            if (collision.gameObject.tag == "Drone" && Input.GetKey(KeyCode.L))
            {
                drone.TakeDamage(24);
            }
            //BossIron1
            if (collision.gameObject.tag == "Spider" && Input.GetKey(KeyCode.K))
            {
                BossIron2.TakeDamage(12);
            }
            if (collision.gameObject.tag == "Spider" && Input.GetKey(KeyCode.L))
            {
                BossIron2.TakeDamage(24);
            }
            //plane
            if (collision.gameObject.tag == "Plane" && Input.GetKey(KeyCode.K))
            {
                plane.TakeDamage(12);
            }
            if (collision.gameObject.tag == "Plane" && Input.GetKey(KeyCode.L))
            {
                plane.TakeDamage(24);
            }
            //canon
            if (collision.gameObject.tag == "Canon" && Input.GetKey(KeyCode.K))
            {
                canon.TakeDamage(12);
            }
            if (collision.gameObject.tag == "Canon" && Input.GetKey(KeyCode.L))
            {
                canon.TakeDamage(24);
            }
        }
        else
        {
            //chicky
            if (collision.gameObject.tag == "chicky" && Input.GetKey(KeyCode.K))
            {
                chicky.TakeDamage(10);
            }
            if (collision.gameObject.tag == "chicky" && Input.GetKey(KeyCode.L))
            {
                chicky.TakeDamage(20);
            }
            //army2
            for (int i = 0; i < 5; i++)
            {
                if (collision.gameObject.CompareTag(tagArmy[i]) && Input.GetKey(KeyCode.K))
                {
                    army[i].TakeDamage(10);
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (collision.gameObject.CompareTag(tagArmy[i]) && Input.GetKey(KeyCode.L))
                {
                    army[i].TakeDamage(20);
                }
            }
            //canon
            if (collision.gameObject.tag == "Canon" && Input.GetKey(KeyCode.K))
            {
                canon.TakeDamage(10);
            }
            if (collision.gameObject.tag == "Canon" && Input.GetKey(KeyCode.L))
            {
                canon.TakeDamage(20);
            }
            //BossIron1
            if (collision.gameObject.tag == "Drone" && Input.GetKey(KeyCode.K))
            {
                drone.TakeDamage(10);
            }
            if (collision.gameObject.tag == "Drone" && Input.GetKey(KeyCode.L))
            {
                drone.TakeDamage(20);
            }
            //BossIron1
            if (collision.gameObject.tag == "Spider" && Input.GetKey(KeyCode.K))
            {
                BossIron2.TakeDamage(10);
            }
            if (collision.gameObject.tag == "Spider" && Input.GetKey(KeyCode.L))
            {
                BossIron2.TakeDamage(20);
            }
            //Plane
            if (collision.gameObject.tag == "Plane" && Input.GetKey(KeyCode.K))
            {
                plane.TakeDamage(10);
            }
            if (collision.gameObject.tag == "Plane" && Input.GetKey(KeyCode.L))
            {
                plane.TakeDamage(20);
            }
        }
    }
    private  IEnumerator Dash()
    {
        candash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * Dashingpower, 0f);
        tr.emitting = true;
        
        yield return new WaitForSeconds(dashingtime);
        tr.emitting = false;
        
        
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(Dashingcooldown);
        candash = true;
    }
    public void SetHasKey(bool value)
    {
        hasKey = value;
    }
    public bool HasKey()
    {
        return hasKey;
    }
    public void setquykiem( bool value)
    {
        hasquykiem = value;
    }
    public bool Hasquykiem()
    {
        return hasquykiem;
    }
    public void SetGiapHoMenh(bool value)
    {
        hasGiapHoMenh = value;
    }
    public bool HasGiapHoMenh()
    {
        return hasGiapHoMenh;
    }
    public void SetKiemFeny(bool value)
    {
        hasKiemFeny = value;
    }
    public bool HasKiemFeny()
    {
        return hasKiemFeny;
    }
    //text
    private void BoolItem()
    {
        textItem = new string[]
        {
            "da co chia khoa, dung de mo cua",
            "da co quy kiem,tang 20% hut mau",
            "da co giap ho menh,hoi sinh 1 lan",
            "da co kiem feny,tang 20% sat thuong"
        };
        tagArmy = new string[]
        {
            "army2","army3","army4","army5","army6"
        };
    }
    private void TextItems()
    {
        if (hasKiemFeny == true)
        {
            textMeshList[3].text = textItem[3];
        }
        else
        {
            textMeshList[3].text = "";
        }
        if (hasKey == true)
        {
            textMeshList[0].text = textItem[0];
        }
        else
        {
            textMeshList[0].text = "";
        }
        if (hasquykiem == true)
        {
            textMeshList[1].text = textItem[1];
        }
        else
        {
            textMeshList[1].text = "";
        }
        if (hasGiapHoMenh == true)
        {
            textMeshList[2].text = textItem[2];
        }
        else
        {
            textMeshList[2].text = "";
        }
    }
}
