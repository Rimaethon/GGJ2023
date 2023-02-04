using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public bool _isAnyCardFlipped;
    private float _elapsedTime;
    private float _t;
    

    #endregion


    #region Unity Methods
    void Start()
    {
        // _cardBackAnimator = cardBack.GetComponent<Animator>();
        // _cardFrontAnimator = cardFront.GetComponent<Animator>();
        // _cardBackAnimator.enabled = false;
        // _cardFrontAnimator.enabled = false;
        _camera = Camera.main;
        _startTime = Time.time;
        _initialPosition = transform.position;
        _initialRotation = transform.rotation;
        _initialScale = transform.localScale;




    }


    void Update()
    {
        //Debug.Log(_cardBackAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        
        // if (_cardBackAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        // {
        //     
        //     _cardBackAnimator.enabled = false;
        //     _cardFrontAnimator.enabled = true;
        // }


        if (_isTransforming && !_isAnyCardFlipped)
        {
            FlipCard();
        }

        //Debug.Log("_isAnyCardFlipped: " + _isAnyCardFlipped + "_isTransforming: " + _isTransforming);
        if (_isAnyCardFlipped && Input.GetMouseButtonDown(0)&& !_isTransforming)
        {
            _startTime = Time.time;
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
        _elapsedTime = Time.time - _startTime;
        _t = Mathf.Clamp(_elapsedTime / _duration, 0, 1);
        
        Debug.Log("_t: " + _t);
        if (_t >= 1f)
        {
            _t = 1f;
            _isTransforming = false;
        }



        _targetPosition = _camera.transform.position + new Vector3(-9.2f, -5f, 10.5f);
        
        transform.position = Vector3.Lerp(transform.position, _targetPosition, _t);
        transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, _t);
        transform.localScale = Vector3.Lerp(transform.localScale, _targetScale, _t);
        if (transform.localScale == _targetScale)
        {
            _isAnyCardFlipped = true;
        }
        
        Debug.Log("Im Working Again");
        

    }

    private void PutTheCardBack()
    {
            Debug.Log("putting the card back");
        _elapsedTime = Time.time - _startTime;
        _t = Mathf.Clamp(_elapsedTime / _duration, 0, 1);

        if (_t >= 1f)
        {
            _t = 1f;
            _isTransforming = false;
        }
        transform.position = Vector3.Lerp(transform.position, _initialPosition, _t);
        transform.rotation = Quaternion.Slerp(transform.rotation, _initialRotation, _t);
        transform.localScale = Vector3.Lerp(transform.localScale, _initialScale, _t);
        _isAnyCardFlipped = false;

    }
    
}
