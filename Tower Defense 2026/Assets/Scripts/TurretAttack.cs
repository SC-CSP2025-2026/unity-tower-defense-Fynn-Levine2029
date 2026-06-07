using UnityEngine;

public class TurretAttack : MonoBehaviour
{

    [field: SerializeField]
    public AreaOfEngagement AoE { get; private set; }
    [field: SerializeField]
    public Projectile ProjectilePrefab { get; private set; }
    [field: SerializeField]
    public float CooldownTime { get; private set; } = 3f;
    [field: SerializeField]
    public bool IsCoolingDown { get; private set; } = false;
    // Update is called once per frame
    void Update()
    {
        if (IsCoolingDown || AoE.Targets.Count == 0)
        {
            return;
        }

        Fire();
        IsCoolingDown = true;
        Invoke(nameof(SetIsCoolingDownToFalse), CooldownTime);

    }

    public void SetIsCoolingDownToFalse()
    {
        IsCoolingDown = false;
    }

    private void Fire()
    {
        Projectile newProjectile = Instantiate(ProjectilePrefab);
        // Sets the projectile's position to match the turret's position
        newProjectile.transform.position = transform.position;
        // Sets the projectile's target to the first target in the AoE
        newProjectile.Target = AoE.Targets[0].transform;
    }
}
