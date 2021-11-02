using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    static Animator anim;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.playerInInventory && !player.playerInPickUp)
        {

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
                anim.SetBool("Idle", false);
                anim.SetBool("Walk", true);
            }
            else
            {
                anim.SetBool("Walk", false);
                anim.SetBool("Idle", true);
                anim.SetBool("Run", false);
            }
            if (!Input.anyKey && (!anim.GetCurrentAnimatorStateInfo(0).IsName("Watering") || !anim.GetCurrentAnimatorStateInfo(0).IsName("Planting 02")))
            {
                anim.SetBool("Walk", false);
                anim.SetBool("Idle", true);
                anim.SetBool("Run", false);
            }

            if (Input.GetKey(KeyCode.LeftShift) && anim.GetBool("Walk"))
            {
                anim.SetBool("Run", true);
                anim.SetBool("Walk", false);
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                anim.SetBool("Run", false);
                if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)))
                {
                    anim.SetBool("Idle", true);
                }
                else
                {
                    anim.SetBool("Walk", true);
                }
            }
        }

    }

    public static void GatherOn(string treename)
    {

        if (treename.Contains("Apple") || treename.Contains("Corn"))
        {
            anim.SetBool("Gathering Standing", true);
        }
        else
        {
            anim.SetBool("Gathering Kneeling", true);
        }
        anim.SetBool("Run", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", false);
    }

    public static void GatherOff()
    {
        anim.SetBool("Gathering Standing", false);
        anim.SetBool("Gathering Kneeling", false);
        anim.SetBool("Run", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", true);
    }

    public static void Water()
    {

        anim.SetBool("Idle", false);
        anim.Play("Watering");

    }

    public static void Eat()
    {
        anim.SetBool("Idle", false);
        anim.Play("Eat");
    }

    public static void Plant()
    {
        anim.SetBool("Idle", false);
        anim.Play("Planting 02");
    }
}
