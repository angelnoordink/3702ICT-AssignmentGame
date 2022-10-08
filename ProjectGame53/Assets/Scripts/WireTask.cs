using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WireTask : MonoBehaviour {

    public List<Color> _wireColors = new List<Color>(); // New list of type Color

    public List<Wire> _leftWires = new List<Wire>(); // New list of leftWires of type Wire

    public List<Wire> _rightWires = new List<Wire>(); // New list of rightWires of type Wire

    public Wire CurrentDraggedWire;

    public Wire CurrentHoveredWire;

    private List<Color> _availableColors; // Unitialised list of colors to be used

    private List<int> _availableLeftWireIndex; // Unitialised list of numbers which will assist in random sequence generation

    private List<int> _availableRightWireIndex; // Unitialised list of numbers which will assist in random sequence generation



    // Start is called before the first frame update
    private void Start() {
        _availableColors = new List<Color>(_wireColors); // Assign new list of colors
        _availableLeftWireIndex = new List<int>(); // This list will contain numbers for the total count of the wires
        _availableRightWireIndex = new List<int>();

        for (int i = 0; i < _leftWires.Count; i++)
        {
            _availableLeftWireIndex.Add(i);
        }
        for (int i = 0; i < _rightWires.Count; i++)
        {
            _availableRightWireIndex.Add(i);
        }

        while(_availableColors.Count > 0 && _availableLeftWireIndex.Count > 0 && _availableRightWireIndex.Count > 0){
            Color pickedColor = _availableColors[Random.Range(0, _availableColors.Count)];
            int pickedLeftWireIndex = Random.Range(0,_availableLeftWireIndex.Count);
            int pickedRightWireIndex = Random.Range(0, _availableRightWireIndex.Count);

            _leftWires[_availableLeftWireIndex[pickedLeftWireIndex]].SetColor(pickedColor);
            _rightWires[_availableRightWireIndex[pickedRightWireIndex]].SetColor(pickedColor);

            _availableColors.Remove(pickedColor);
            _availableLeftWireIndex.RemoveAt(pickedLeftWireIndex);
            _availableRightWireIndex.RemoveAt(pickedRightWireIndex);
        }
    }

    private void Update(){
        int successfulWires = 0;
        for (int i = 0; i < _rightWires.Count; i++) {
            if(_rightWires[i].IsSuccess){
                successfulWires++;
            }
        }
        if(successfulWires >= _rightWires.Count) {
            Debug.Log("TASK COMPLETE");
            SceneManager.LoadSceneAsync("SuccessScene");
        } else {
            // Debug.Log("TASK FAILED");
        }
    }
}

