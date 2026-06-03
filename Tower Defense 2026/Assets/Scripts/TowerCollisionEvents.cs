using UnityEngine;
using UnityEngine.Events;

public class TowerCollisionEvents : MonoBehaviour
{

    [field: SerializeField]
    public UnityEvent<EnemyAttack> OnEnemyHit { get; private set; }

    void OnTriggerEnter(Collider other)
    {
        EnemyAttack attackEnemy = other.GetComponentInParent<EnemyAttack>();
        other.GetComponentInParent<EnemyAttack>();
        if (attackEnemy == null) { return; }
        OnEnemyHit.Invoke(attackEnemy);
        Debug.Log(other);
    }

}
