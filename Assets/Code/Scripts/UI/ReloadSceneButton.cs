using UnityEngine;
using UnityEngine.SceneManagement;

namespace GalconTechDemo.UI
{
    public class ReloadSceneButton : MonoBehaviour
    {
        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

