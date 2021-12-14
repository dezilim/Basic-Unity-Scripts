using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionHere : MonoBehaviour
{
    public ParticleSystem expl;
    public Vector3 offset;
    // Start is called before the first frame update
    void OnTriggerEnter()
    {
        Debug.Log("Boom");
        ParticleSystem ps = Instantiate(expl, transform.position + offset, Quaternion.identity);
        ps.Play();
    }


}
