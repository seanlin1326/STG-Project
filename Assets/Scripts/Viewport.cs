using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viewport :Singleton<Viewport>
{
    float minX;
    float maxX;
    float minY;
    float maxY;
    private void Start()
    {
        Camera _mainCamera = Camera.main;
        Vector2 _bottomLeft = _mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f));
        Vector2 _topRight = _mainCamera.ViewportToWorldPoint(new Vector3(1f, 1f));

        minX = _bottomLeft.x;
        minY = _bottomLeft.y;
        maxX = _topRight.x;
        maxY = _topRight.y;
    }
    public Vector3 PlayerMovablePosition(Vector3 _playerPosition,float _paddingX,float _paddingY)
    {
        Vector3 _position = Vector3.zero;
        _position.x = Mathf.Clamp(_playerPosition.x, minX+_paddingX, maxX-_paddingX);
        _position.y = Mathf.Clamp(_playerPosition.y, minY+_paddingY, maxY-_paddingY);
        return _position;
    }
}
