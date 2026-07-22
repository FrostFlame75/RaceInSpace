using UnityEngine;
using System.Collections.Generic;

public class Checkpoint : MonoBehaviour
{
    public bool hasBeenHit = false;
    [SerializeField] Checkpoint prev;
    [SerializeField] Material unclaimed;
    [SerializeField] Material nextUp;
    [SerializeField] Material claimed;
    MeshRenderer render;
    List<Material> current = new List<Material>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        render = gameObject.GetComponent<MeshRenderer>();
        current.Add(unclaimed);
        render.SetMaterials(current);
    }

    // Update is called once per frame
    void Update()
    {
       if (prev != null)
        {
            if (current[0] == unclaimed && prev.hasBeenHit && !hasBeenHit)
            {
                current[0] = nextUp;
                render.SetMaterials(current);
            }
        }
       else if (!hasBeenHit)
        {
            current[0] = nextUp;
            render.SetMaterials(current);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Checkpoint Hit");
        if (!hasBeenHit)
        {
            if (prev == null)
            {
                hasBeenHit = true;
                current[0] = claimed;
                render.SetMaterials(current);
            }
            else if (prev.hasBeenHit)
            {
                hasBeenHit = true;
                current[0] = claimed;
                render.SetMaterials(current);
            }
            
        }
    }
}
