using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool RigidbodyProjectile = false;
    public float Speed = 80;
    public float SpeedMax = 80;
    public float SpeedMult = 1;
    private float speedTemp;
    public float Lifetime = 10f;
    public GameObject Target;
    private Rigidbody rigidBody;
    private void Awake()
    {
        rigidBody = this.GetComponent<Rigidbody>();
    }
    void Update ()
    {
        Lifetime -= Time.deltaTime;

        if(Lifetime <= 0)
        {
            ResetBullet();
        }
    }
    private void FixedUpdate()
    {
        if (!RigidbodyProjectile)
        {
            rigidBody.velocity = transform.forward * Speed;
        }
        else
        {
            if (rigidBody.velocity.normalized != Vector3.zero)
                this.transform.forward = rigidBody.velocity.normalized;
        }
        if (Speed < SpeedMax)
        {
            Speed += SpeedMult * Time.fixedDeltaTime;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bullet")
        {
            Debug.Log(collision.gameObject.name);
            ResetBullet();
        }
    }
    public void ResetBullet()
    {
        Lifetime = 10f;
        spawner.Instance.shootobject.Remove(gameObject);
        spawner.Instance.poolobjects.Add(gameObject);
        gameObject.SetActive(false);
    }
}