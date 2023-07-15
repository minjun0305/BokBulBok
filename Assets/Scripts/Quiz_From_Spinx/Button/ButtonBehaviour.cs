using UnityEngine;
using UnityEngine.UIElements;

public class ButtonBehaviour : MonoBehaviour
{
    public int buttonOrder;
    [SerializeField] private AnswerButtonPosition _buttonPositionList;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePositionWithOrder()
    {
        Vector2 newPos = buttonOrder switch
        {
            1 => _buttonPositionList.PositionList[0],
            2 => _buttonPositionList.PositionList[1],
            3 => _buttonPositionList.PositionList[2],
            _ => Vector2.zero
        };

        transform.position = newPos;
    }

    public void Press()
    {
        // TODO: Implement some press logic
    }

    public void Unpress()
    {
        // TODO: Implement some unpress logic
    }
}
