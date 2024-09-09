using UnityEngine;

namespace DefaultNamespace.Obstacles
{
    public class CutsceneStarter : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                //Inicio la cutscene
                Debug.Log("Start cutscene");
                Destroy(gameObject);
            }
        }
    }
}