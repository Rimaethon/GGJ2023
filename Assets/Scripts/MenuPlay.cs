using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class MenuPlay : MonoBehaviour
{
    [SerializeField] PlayableDirector director;
    [SerializeField] string playLevelName;
    [SerializeField] float timingEndThreshold = -0.02f;
    [SerializeField] bool newSceneFired;
    public void StarAnim() {director.Play(); }
    void LoadGame(PlayableDirector aDirector) {
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if((director.time - director.duration > timingEndThreshold) && !newSceneFired ) 
        {
            newSceneFired = true;
            SceneManager.LoadScene(playLevelName);
        }
            
    }
}
