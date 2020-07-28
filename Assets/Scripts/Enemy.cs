using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFx;
    [SerializeField] Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerMeshCollider();
       
    }

    private void AddNonTriggerMeshCollider()
    {
        MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();
        meshCollider.convex = true;
        meshCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        
        Die();
    }

    private void Die()
    {
        print("play deathfx");

        GameObject newFx = Instantiate(deathFx, this.transform.position, Quaternion.identity);
        newFx.transform.parent = parent;

        deathFx.transform.position = this.transform.position;
        Destroy(gameObject);
    }
}
