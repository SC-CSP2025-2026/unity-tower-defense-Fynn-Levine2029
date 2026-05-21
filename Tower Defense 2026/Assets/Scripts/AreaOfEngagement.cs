using System.Collections.Generic;
using UnityEngine;

public class AreaOfEngagement : MonoBehaviour
{
    [field: SerializeField]
    public List<Transform> Targets { get; private set; } = new();

    void OnTriggerEnter(Collider other)
    {
        Targets.Add(other.transform);
    }

    void OnTriggerExit(Collider other)
    {
        Targets.Remove(other.transform);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
