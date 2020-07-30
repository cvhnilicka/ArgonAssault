using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFx;
    [SerializeField] Transform parent;

    [SerializeField] int hitsRemaining = 25;

    ScoreBoard scoreBoard;

    [SerializeField] int scoreForHit = 5;


    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerMeshCollider()
    {
        MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();
        meshCollider.convex = true;
        meshCollider.isTrigger = false;
    }

    private void AddNonTriggerBoxCollider()
    {
        BoxCollider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(scoreForHit);
        hitsRemaining -= 1;
        print(hitsRemaining);
        if (hitsRemaining <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        
        GameObject newFx = Instantiate(deathFx, this.transform.position, Quaternion.identity);
        newFx.transform.parent = parent;
        Destroy(gameObject);
        
    }
}
