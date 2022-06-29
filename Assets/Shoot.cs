using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform ShootPoint, Shootpoint2;
    float shoottime = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shoottime -= Time.deltaTime;
        if (shoottime <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                shoottime = 0.3f;
                ReadyBullet(ShootPoint);
                ReadyBullet(Shootpoint2);
            }
        }
    }
    public void ReadyBullet(Transform shootpoint)
    {
        if (spawner.Instance.poolobjects.Count <= 0)
            return;
        GameObject bullet = spawner.Instance.poolobjects[0];
        bullet.transform.localPosition = shootpoint.position;
        bullet.transform.localRotation = shootpoint.rotation;
        spawner.Instance.poolobjects.Remove(bullet);
        spawner.Instance.shootobject.Add(bullet);
        bullet.SetActive(true);
    }
}