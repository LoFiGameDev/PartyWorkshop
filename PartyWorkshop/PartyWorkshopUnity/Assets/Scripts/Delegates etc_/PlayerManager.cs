using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Player Player;

    private void OnEnable()
    {
        GameManager.OnMekGehmAkschn += SbaunPleha;
    }

    private void OnDisable()
    {
        GameManager.OnMekGehmAkschn -= SbaunPleha;
    }

    public void SbaunPleha(string value)
    {
        Player pleha = Instantiate(Player, Vector3.zero, Quaternion.identity, transform);
        pleha.name = value;
    }

}
