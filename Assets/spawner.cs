using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject projectile;
    public List<GameObject> poolobjects, shootobject;
    public int numberofammo = 10;
    public static spawner Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberofammo; i++)
        {
            GameObject bullets = Instantiate(projectile, transform, false);
            poolobjects.Add(bullets);
        }
    }
}
