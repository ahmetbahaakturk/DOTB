using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IndexFollower : MonoBehaviour{
    public int last_scene_index;
    void Start()
    {
        last_scene_index = SceneManager.GetActiveScene().buildIndex;
    }
}
