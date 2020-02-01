using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    public Animator animator;

    private int positionToLoad;

    private GameObject Player;

    void Start()
    {
        Player = GameObject.Find("Player");
    }

// Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            FadeToLevel(35);
        }
    }

    public void FadeToLevel(int position)
    {
        positionToLoad = position;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        Player.transform.position = new Vector2(positionToLoad, 0);
        //SceneManager.LoadScene(positionToLoad);
    }
}
