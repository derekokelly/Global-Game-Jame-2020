using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    public Animator animator;

    private int positionToLoad;

    public GameObject Player;
    public GameObject Door;

    private Coroutine lastRoutine;

    void Start()
    {
        //Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    FadeToLevel();
        //}
    }

    public void FadeToLevel()
    {
        animator.SetBool("New Bool", false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            lastRoutine = StartCoroutine(Teleport());
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopCoroutine(lastRoutine);
        }
    }

    IEnumerator Teleport()
    {
        while (true)
        {
            if (Input.GetKeyDown("z"))
            {
                animator.SetBool("New Bool", true);
                yield return new WaitForSeconds(1);
                Player.transform.position = new Vector2(Door.transform.position.x, Door.transform.position.y - 1.5f);
                break;
            }
            yield return null;
        }
    }
}
