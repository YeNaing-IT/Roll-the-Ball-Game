using UnityEngine;
using UnityEngine.SceneManagement;

namespace YeNaing
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public GameObject[] enemies;

        private int totalLevel;
        private int nextLevel;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            totalLevel = SceneManager.sceneCountInBuildSettings;
        }

        // Update is called once per frame
        void Update()
        {

        }

        // Load Next Level
        public void NextLevel()
        {
            SceneManager.LoadScene(nextLevel);
        }

        public void Retry()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void MainMenu()
        {
            SceneManager.LoadScene(0);
        }
        public void OnWin()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            // Player
            player.GetComponent<PlayerController>().playerSpeed = 0;
            player.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            nextLevel = SceneManager.GetActiveScene().buildIndex + 1;

            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length == 0) return;
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
        }
       
    }
}