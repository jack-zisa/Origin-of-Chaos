using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Attack attack;
    public Vector3 direction;
    public float speed;
    public float rate;
    private float damage;
    private float life;

    public Projectile SetProperties(Vector3 position, Attack attack, Vector3 direction, float minDamage, float maxDamage)
    {
        transform.position = position;
        this.attack = attack;
        speed = attack.speed;
        rate = attack.acceleration.rate;
        damage = Mathf.RoundToInt(Random.Range(minDamage, maxDamage));
        this.direction = direction;
        return this;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (attack.acceleration != null)
        {
            if (attack.acceleration.rate != 0f)
            {
                if (life >= attack.acceleration.offset)
                {
                    speed += rate * attack.acceleration.multiplier;
                }
            }
        }

        life += Time.deltaTime;
    }

    void OnEnable()
    {
        SpriteUtil.SetSprite(GetComponent<SpriteRenderer>(), "Sprites/Projectiles/" + attack.sprite);
        Invoke("Disable", attack.lifetime);
    }

    void Disable()
    {
        gameObject.SetActive(false);
        life = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Character") && gameObject.tag.Equals("EnemyProjectile"))
        {
            Character character = collision.gameObject.GetComponent<Character>();
            character.Damage(damage);
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag.Equals("Enemy") && gameObject.tag.Equals("PlayerProjectile"))
        {
            Entity entity = collision.gameObject.GetComponent<Entity>();
            entity.Damage(damage);
            gameObject.SetActive(false);
        }
    }
}
