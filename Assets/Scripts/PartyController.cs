using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.InputSystem;
using UnityEditor.U2D.Animation;

public class PartyController : MonoBehaviour
{
    public List<GameObject> party = new List<GameObject>();
    public GameObject selectedMember = null;
    private PlayerInputActions playerInputActions;
    private GameObject combatPauseObject;

    // Start is called before the first frame update
    void Start() {
        playerInputActions = new PlayerInputActions();
        combatPauseObject = GameObject.Find("Combat Pause");
        combatPauseObject.SetActive(false);

        // party should be saved beforehand and initialized into this array
        party.Add(GameObject.Find("Character 1"));
        party.Add(GameObject.Find("Character 2"));

        // start selecting the first member of the party - without a plan phase this is for alpha
        selectedMember = party[0];
        HighlightMember(true);
    }

    private void OnPartyMember1() {
        SelectPartyMember(party[0]);
        Debug.Log("Party member 1 selected");
    }

    private void OnPartyMember2() {
        SelectPartyMember(party[1]);
        Debug.Log("Party member 1 selected");
    }

    private void OnMove() {
        Vector2 inputPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        selectedMember.GetComponent<MemberController>().Move(inputPosition);
    }

    private void OnAttack() {
        Vector2 inputPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        selectedMember.GetComponent<MemberController>().Attack(inputPosition);
    }

    private void OnPause() {
        // Update is still called, FixedUpdate will not be when TimeScale = 0
        // Can use Update for options like decisions but FixedUpdate for spells/actions ? Make Spells inherently time-based with casting speed?
        if(Time.timeScale > 0) {
            Time.timeScale = 0;
            combatPauseObject.SetActive(true);
        } else {
            Time.timeScale = 1;
            combatPauseObject.SetActive(false);
        }
    }

    private void SelectPartyMember(GameObject character) {
        if(character != selectedMember) {
            HighlightMember(false);
            selectedMember = character;
            HighlightMember(true);
        }
    }

    private void HighlightMember(bool selected) {
        selectedMember.transform.Find("Highlight").gameObject.SetActive(selected);
    }
}
