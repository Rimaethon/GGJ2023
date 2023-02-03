using UnityEngine;
using UnityEngine.SceneManagement;
public class SimpleSceneLoader : MonoBehaviour
{
    public void LoadGivenScene(string sceneName) 
    {
        SceneManager.LoadScene(sceneName);
    }
}
