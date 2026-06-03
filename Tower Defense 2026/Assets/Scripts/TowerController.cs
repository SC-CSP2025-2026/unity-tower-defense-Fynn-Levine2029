using UnityEngine;

public class TowerController : MonoBehaviour
{
    
    [field: SerializeField]
    public float BaseHealth { get; private set; } = 5;
    [field: SerializeField]
    public float Damage { get; private set; } = 0;

}
