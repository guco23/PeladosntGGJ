using UnityEngine;

public class PlayerPlaceComponent : MonoBehaviour
{

    //El tag del place en el que se encuentra, de no ser ninguno, es ""
    string currentPlace;

    internal void enteredPlace(string placeTag)
    {
        currentPlace = placeTag;
    }

    internal void exitedPlace()
    {
        currentPlace = "";
    }

    // Start is called before the first frame update
    void Start()
    {
        currentPlace = "";
    }

    /**
     * Devuelve el tag del place en el que se encuentra
     */
    public string getCurrentPlace()
    { 
        return currentPlace;
    }

}
