using UnityEngine;

public class PlayerPlaceComponent : MonoBehaviour
{

    //El tag del place en el que se encuentra, de no ser ninguno, es ""
    string currentPlace;
    PlaceComponent place;


    internal void enteredPlace(string placeTag,PlaceComponent _place)
    {
        currentPlace = placeTag;
        place = _place;
    }

    internal void exitedPlace()
    {
        currentPlace = "";
        place = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        place = null;
        currentPlace = "";
    }

    /**
     * Devuelve el tag del place en el que se encuentra
     */
    public string getCurrentPlace()
    { 
        return currentPlace;
    }

    public PlaceComponent getCurrentPlaceComponent()
    {
        return place;
    }
}
