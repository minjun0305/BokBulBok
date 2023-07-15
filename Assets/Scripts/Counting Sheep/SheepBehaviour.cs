using UnityEngine;

public class SheepBehaviour : MonoBehaviour
{
    private bool _isMoving = false;
    
    private float _movingTime;
    private float _movedTime;
    
    private Vector3 _initialPos;
    private Vector3 _finalPos;
    
    public void SheepMoveStart(float movingTime, Vector3 initialPos, Vector3 finalPos)
    {
        _movingTime = movingTime;
        _initialPos = initialPos;
        _finalPos = finalPos;
        
        transform.position = initialPos;
        _isMoving = true;
        _movedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isMoving)
        {
            if (_movedTime < _movingTime)
            {
                transform.position = _initialPos + (_finalPos - _initialPos) * (_movedTime / _movingTime);
            }
            else
            {
                _isMoving = false;
                Destroy(gameObject);
            }

            _movedTime += Time.deltaTime;
        }
    }
}
