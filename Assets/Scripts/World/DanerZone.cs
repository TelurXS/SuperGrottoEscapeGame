using Entities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace World
{
    public class DanerZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out Entity entity))
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                entity.Kill();
            }
        }
    }
}
