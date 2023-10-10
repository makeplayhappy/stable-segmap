using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Animations;
using System.Collections.Generic;


[RequireComponent(typeof(Animator))]

public class PoseChanger : MonoBehaviour {

    public AnimationClip[] clips;
    PlayableGraph playableGraph;
    Animator _animator;
    private int currentIndex = 0;
    public int CurrentClip{
        get{
            return currentIndex;
        }
    }

    void Start() {
        if(clips != null && clips.Length > 0){
            _animator = GetComponent<Animator>();
            SetClip(currentIndex);
        }

    }

    public void SetClip(int index){
        if( index > -1 && index < clips.Length){
            currentIndex = index;
            AnimationPlayableUtilities.PlayClip(_animator, clips[currentIndex], out playableGraph);
        }else{
            Debug.Log(index + " is outside bounds not changing");
        }

    }

    public List<string> GetClipList(){
        List<string> options = new List<string>();
        for (int i = 0; i < clips.Length; i++) {
            options.Add( clips[i].name );
        }
        return options;

    }
/*
    public string[] GetClipName(){
        string[] clipNames = new string[ clips.Length ];
        for(int i = 0; i < clips.Length; i++){
            clipNames[i] = clips[i].name;
        }
        return clipNames;
    }
*/
    void OnDisable() {

        // Destroys all Playables and Outputs created by the graph.

        playableGraph.Destroy();

    }

}
