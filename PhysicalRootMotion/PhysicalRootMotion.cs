using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PhysicalRootMotion : MonoBehaviour
{
    float startposx, startposy, startposz, starttime;
    bool start,canstart=true;
    string motionx, motiony, motionz;
    [TextArea(10, 10)]
    [SerializeField] string positionsx, positionsy, positionsz, times;
    [SerializeField] Animator anim;
    [SerializeField] float step = .1f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            start = !start;
            if (!start) canstart = true;
            Debug.Log(start);
            if (start&& canstart) 
            {
                anim.SetTrigger("1"); 
            }
            if (start) InvokeRepeating("copymotion", .1f, step);
            else CancelInvoke();
            if (!start)
            {
                if (motionx.EndsWith('\n'))
                {
                    motionx = motionx.Substring(0, motionx.Length - 1);
                }
                if (motiony.EndsWith('\n'))
                {
                    motiony = motiony.Substring(0, motiony.Length - 1);
                }
                if (motionz.EndsWith('\n'))
                {
                    motionz = motionz.Substring(0, motionz.Length - 1);
                }
                string[] temps = motionx.Split('\n');
                foreach (string item in temps)
                {
                    if (!string.IsNullOrEmpty(item))
                        times += item.Split(':')[1] + "\n";
                }
                foreach (string item in temps)
                {
                    if (!string.IsNullOrEmpty(item))
                        positionsx += item.Split(':')[0] + "\n";
                }
                string[] temps2 = motiony.Split('\n');
                foreach (string item in temps2)
                {
                    if (!string.IsNullOrEmpty(item))
                        positionsy += item.Split(':')[0] + "\n";
                }
                string[] temps3 = motionz.Split('\n');
                foreach (string item in temps3)
                {
                    if (!string.IsNullOrEmpty(item))
                        positionsz += item.Split(':')[0] + "\n";
                }
                if (positionsx.EndsWith('\n'))
                {
                    positionsx = positionsx.Substring(0, positionsx.Length - 1);
                }
                if (positionsy.EndsWith('\n'))
                {
                    positionsy = positionsy.Substring(0, positionsy.Length - 1);
                }
                if (positionsz.EndsWith('\n'))
                {
                    positionsz = positionsz.Substring(0, positionsz.Length - 1);
                }
                if (times.EndsWith('\n'))
                {
                    times = times.Substring(0, times.Length - 1);
                }
            }
        }
    }
    void copymotion()
    {
        if (canstart) 
        {
            canstart = false;
            starttime = Time.time;
            startposx = transform.position.x;
            startposy = transform.position.y;
            startposz = transform.position.z;
        }
        motionx += (transform.position.x - startposx) + ":" + (Time.time - starttime) + "\n";
        motiony += (transform.position.y - startposy) + ":" + (Time.time - starttime) + "\n";
        motionz += (transform.position.z - startposz) + ":" + (Time.time - starttime) + "\n";
    }

}
