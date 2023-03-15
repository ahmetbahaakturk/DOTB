using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject[] guns;
    private GameObject fireBall;
    private AudioSource audio_source;
    public GameObject pause_menu;
    public float timer_aqua = 0;
    public float timer_orange = 0;
    public float timer_knife = 0;
    public float time_per_aqua = 1;
    public float time_per_orange = 1;
    public float time_per_knife = 1;
    public bool fire_permission_aqua = true;
    public bool fire_permission_orange = true;
    public bool fire_permission_knife = true;

    void Start() {
        audio_source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if ((timer_orange < time_per_orange) && ! fire_permission_orange) {
            timer_orange += Time.deltaTime;
            if (timer_orange > time_per_orange) {
                fire_permission_orange = true;
                timer_orange = 0;
            }
        }

        if ((timer_aqua < time_per_aqua) && ! fire_permission_aqua) {
            timer_aqua += Time.deltaTime;
            if (timer_aqua > time_per_aqua) {
                fire_permission_aqua = true;
                timer_aqua = 0;
            }
        }

        if ((timer_knife < time_per_knife) && ! fire_permission_knife) {
            timer_knife += Time.deltaTime;
            if (timer_knife > time_per_knife) {
                fire_permission_knife = true;
                timer_knife = 0;
            }
        }


        if (pause_menu.activeSelf == false) {
            if (Input.GetKeyDown("a") && fire_permission_aqua){
                fire_permission_aqua = false;
                audio_source.Play();
                fireBall = Instantiate(guns[0]);
                fireBall.transform.position = transform.parent.gameObject.transform.position + new Vector3(0.5f , 0, 0);
            }
            
            if (Input.GetKeyDown("s") && fire_permission_orange) {
                fire_permission_orange = false;
                audio_source.Play();
                fireBall = Instantiate(guns[1]);
                fireBall.transform.position = transform.parent.gameObject.transform.position + new Vector3(0.5f , 0, 0);
            }

            if (Input.GetKeyDown("d") && fire_permission_knife) {
                fire_permission_knife = false;
                fireBall = Instantiate(guns[2]);
                fireBall.transform.position = transform.parent.gameObject.transform.position + new Vector3(0.5f , 0.3f, 0);
            }
        }
    }
}
