using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PartyController : MonoBehaviour
{
    public List<GameObject> party = new List<GameObject>();
    public GameObject selectedCharacter = null;

    // Start is called before the first frame update
    void Start()
    {
        // party should be saved beforehand and initialized into this array
        party.Add(GameObject.Find("Character 1"));
        party.Add(GameObject.Find("Character 2"));

        // start selecting the first member of the party - without a plan phase this is for alpha
        selectPartyMember(party[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            selectPartyMember(party[0]);
        }
        if(Input.GetKey(KeyCode.Alpha2))
        {
            selectPartyMember(party[1]);
        }
    }

    void selectPartyMember(GameObject character) 
    {
        if(character != selectedCharacter) {
            selectedCharacter.transform.GetChild(0).gameObject.SetActive(false);
            selectedCharacter.GetComponent<CharacterController>().enabled = false;
            selectedCharacter = character;
            character.transform.GetChild(0).gameObject.SetActive(true);
            character.GetComponent<CharacterController>().enabled = true;
        }
    }
}
