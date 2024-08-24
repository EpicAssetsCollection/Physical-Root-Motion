using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resaltmotionscript : MonoBehaviour
{
    [SerializeField] float endtime, step = 0.1f;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            StartCoroutine(startmotion());
        }
    }
    IEnumerator startmotion()
    {
        GetComponent<Animator>().SetTrigger("1");
        yield return new WaitForSeconds(.1f);
        float starttime = Time.time;
        for(float i = 0; i < endtime; i += step)
        {
            GetComponent<Rigidbody>().velocity = eqnz(Time.time-starttime) * transform.forward + eqnx(Time.time - starttime) * transform.right + eqny(Time.time - starttime) * transform.up;
            yield return new WaitForSeconds(step);
        }
    }

    private float eqnx(float Time)
    {
        return 0;
    }
    private float eqny(float Time)
    {
        return 0;
    }
    private float eqnz(float Time)
    {
        return -5.664300040000001f*Mathf.Cos(1.03955f*Time+ 2.52666f);
    }
}
