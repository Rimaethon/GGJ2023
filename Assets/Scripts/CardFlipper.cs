using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CardFlipper : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject cardBack;
    [SerializeField] private GameObject cardFront;
    private Animator _cardBackAnimator;
    private Animator _cardFrontAnimator;
    private Camera _camera;
    private Vector3 _initialPosition;
    private Quaternion _initialRotation;
    private Vector3 _initialScale;
    
    private Vector3 _targetPosition;
    private Quaternion _targetRotation= Quaternion.Euler(210,0,0);
    private Vector3 _targetScale= new Vector3(0.7f,0.7f,0.7f);
    private float _duration = 2f;

    private float _startTime;
    private bool _isTransforming = false;
    public static bool IsAnyCardFlipped;
    private float _elapsedTime;
    private float _t;
    private bool _isExitInputGiven;
    private bool _isFlipInputGiven;
    

    #endregion


    #region Unity Methods
    void Start()
    {
        
        _camera = Camera.main;
        _startTime = Time.time;
        _initialPosition = transform.position;
        _initialRotation = transform.rotation;
        _initialScale = transform.localScale;




    }


    void Update()
    {
        


        if (_isTransforming && !IsAnyCardFlipped)
        {
            _isFlipInputGiven = true;
        }

        if (_isFlipInputGiven)
        {
            FlipCard();
        }

        if (Input.anyKeyDown&& IsAnyCardFlipped&& !_isTransforming)
        {
            _isExitInputGiven = true;

        }
        if (IsAnyCardFlipped && _isExitInputGiven)
        {
            PutTheCardBack();
        }

        
    }
    
    #endregion

    private void OnMouseDown()
    {

        _isTransforming = true;
        _startTime = Time.time;

        // _cardBackAnimator.enabled=true;

    }

    private void FlipCard()
    {
        
        IsAnyCardFlipped = true;
        _elapsedTime = Time.time - _startTime;
        _t = _elapsedTime / _duration;
       
        
        if (_t >= 1f)
        {
            _t = 1f;
            _isTransforming = false;
            _isFlipInputGiven = false;

            return;
        }

        

        _targetPosition = _camera.transform.position + new Vector3(-9.2f, -5f, 10.5f);
        
        
        transform.position = Vector3.Lerp(transform.position, _targetPosition, _t);
        transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, _t);
        transform.localScale = Vector3.Lerp(transform.localScale, _targetScale, _t);
        
         
        
        
        
        

    }

    private void PutTheCardBack()
    {
        _elapsedTime = Time.time - _startTime;
        _t = _elapsedTime / _duration;
        
        
        
        if (_t >= 1f)
        {
            _t = 1f;
            _isTransforming = false;
            IsAnyCardFlipped = false;
            _isExitInputGiven = false;
        }
        transform.position = Vector3.Lerp(transform.position, _initialPosition, _t);
        transform.rotation = Quaternion.Slerp(transform.rotation, _initialRotation, _t);
        transform.localScale = Vector3.Lerp(transform.localScale, _initialScale, _t);
        

    }
    
}
