using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour {
    [SerializeField]
    private AudioClip _correctClip;
    [SerializeField]
    private AudioClip _incorrectClip;
    private AudioSource _audioSource;

    public bool isCorrect = false;
    public QuizManager quizManager;


    public void Answer() {
        if(isCorrect) {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.clip = _correctClip;
            _audioSource.Play();
            Debug.Log("correct");
            quizManager.correct();
        }
        else {
            StartCoroutine(fail());
            Debug.Log("false");
        }
    }

    IEnumerator fail(){
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _incorrectClip;
        _audioSource.Play();
        yield return new WaitWhile (()=>_audioSource.isPlaying);
        quizManager.incorrect();
    }
}
