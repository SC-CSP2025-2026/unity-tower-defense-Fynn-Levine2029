using UnityEngine;

public class Projectile : MonoBehaviour
{
    [field: SerializeField]
    public float Speed { get; private set; } = 2;
    [field: SerializeField]
    public float Damage { get; private set; } = 1;
    [field: SerializeField]
    public Transform Target { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null)
        {
            Object.Destroy(gameObject);
            return;
        }

        transform.LookAt(Target.transform);
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, Target.transform.position);
        if (distance <= Mathf.Epsilon)
        {
            Health healthComponent = Target.GetComponentInParent<Health>();
            if (healthComponent != null)
            {
                healthComponent.ApplyHit(this);
            }
            Object.Destroy(gameObject);
        }
    }
}
