using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPipes : MonoBehaviour
{
    public float time_per = 2;
    public float timer = 0;
    public GameObject pipe;
    public float min_height;
    public float max_height;
    public float flip_face;
    private float counter = 1;
    public float limit = 1000;

    void Start()
    {
        GameObject newpipe = Instantiate(pipe);
        counter += 1;
        Physics.gravity = new Vector3(0, 0, 0);
        newpipe.transform.position = new Vector3(transform.position.x , Random.Range(min_height, max_height), 0);
        
        if (flip_face == 1) {
            newpipe.transform.localScale = new Vector3(
                newpipe.transform.localScale.x * -1, 
                newpipe.transform.localScale.y, 
                newpipe.transform.localScale.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (counter != limit) {
            if (timer > time_per) {
                counter += 1;
                GameObject newpipe = Instantiate(pipe);
                newpipe.transform.position = new Vector3(transform.position.x , Random.Range(min_height, max_height), 0);
                Destroy(newpipe, 15);
                timer = 0;
            }
            timer += Time.deltaTime;
        }
    }
}
