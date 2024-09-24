using DefaultNamespace.Music;
using UnityEngine;

namespace DefaultNamespace.Obstacles
{
    public class MusicStarter : MonoBehaviour
    {
        [SerializeField] private MusicController controller;
        [SerializeField] private int levelMusic;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                //Inicio la cutscene
                Debug.Log("Start cutscene");
                switch (levelMusic)
                {
                    case 1:
                        controller.PlayLevel1Music();
                        break;
                    case 2:
                    default:
                        controller.PlayLevel2Music();
                        break;
                }

                Destroy(gameObject);
            }
        }
    }
}