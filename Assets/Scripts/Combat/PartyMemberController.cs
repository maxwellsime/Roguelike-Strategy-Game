using UnityEngine;

public class PartyMemberController : MonoBehaviour {   
    private Vector2 desiredPosition;
    public PlayerCharacter character;
    public Status status;
    public GameObject attackHitBox;
    private WeaponItem equippedWeapon;  // calling this in both here and hitbox is redundant ??
    private PlayerCharacterStats stats;

    private void Start() {
        desiredPosition = transform.position;
        status = Status.NEUTRAL;
        character = new PlayerCharacter(); //gameObject.GetComponent<Character>();
        equippedWeapon = character.GetWeapon();
        attackHitBox = this.gameObject.transform.Find("AttackHitBox").gameObject;
    }

    private void Update() {
        this.transform.position = Vector2.MoveTowards(transform.position, desiredPosition, stats.speed * Time.deltaTime);
    }

    public void Move(Vector2 inputPosition, Bounds arenaBounds) {
        if(status != Status.IMMOBILIZED) {
            Vector2 memberSize  = this.gameObject.transform.Find("Sprite").GetComponent<SpriteRenderer>().bounds.size;
            Vector2 arenaMaximum = arenaBounds.max;
            Vector2 arenaMinimum = arenaBounds.min;
            Vector2 clampedPosition = new(
                Mathf.Clamp(inputPosition.x, arenaMinimum.x + memberSize.x / 2, arenaMaximum.x - memberSize.x / 2),
                Mathf.Clamp(inputPosition.y, arenaMinimum.y + memberSize.y / 2, arenaMaximum.y - memberSize.y / 2)
            );
            
            status = Status.MOVING;
            desiredPosition = clampedPosition;
            EnableAttacking(false);
        } else {
            Debug.Log("Party member cannot move when immobilized.");
        }
    }

    public void Attack(Vector2 inputPosition) {
        Debug.Log("Attack!");
        desiredPosition = this.transform.position;
        status = Status.ATTACKING;
        
        Vector2 attackVector;
        if(equippedWeapon.Range == 0) {
            attackVector = (Vector2)this.transform.position + inputPosition.normalized;
        } else {
            attackVector = inputPosition;
            // Make based on ranged input that needs to be normalized based on resolution??
        }
        
        attackHitBox.transform.position = attackVector;
        EnableAttacking(true);
    }

    public void EnableAttacking(bool enable) {
        attackHitBox.SetActive(enable);
    }

    public enum Status {
        NEUTRAL,
        MOVING,
        CHANNELING,
        ATTACKING,
        IMMOBILIZED
    }
}
