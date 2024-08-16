using UnityEngine;

public class coin : MonoBehaviour
{
    private void Update()
    {
        if (gamemanager.singleton.coin >= 50)
        {
            gamemanager.singleton.after_fifty =+ 1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gamemanager.singleton.coin += 1;
            gamemanager.singleton.winnigs = gamemanager.singleton.coin * gamemanager.singleton.coin_miltiplier;
            Destroy(this.gameObject);
        }
    }
}
