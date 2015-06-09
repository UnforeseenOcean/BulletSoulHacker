using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(DynamicGroupVariation))]
public class DynamicGroupVariationInspector : Editor {
	DynamicGroupVariation _variation;
	
	public override void OnInspectorGUI() {
        EditorGUIUtility.LookLikeControls();
		
		EditorGUI.indentLevel = 1;
		var isDirty = false;
		
		_variation = (DynamicGroupVariation)target;
		
		if (_variation.logoTexture != null) {
			GUIHelper.ShowHeaderTexture(_variation.logoTexture);
		}
	
        EditorGUI.indentLevel = 0;  // Space will handle this for the header
		
		DynamicSoundGroupCreator creator = null;
		if (_variation.transform.parent != null && _variation.transform.parent.parent != null) {
			creator = _variation.transform.parent.parent.GetComponent<DynamicSoundGroupCreator>();
		}
		
		if (creator == null) {
			GUIHelper.ShowRedError("This prefab must have DynamicSoundGroupCreator 2 parents up.");
			return;
		}
		
		EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
		GUI.contentColor = Color.green;
		if (GUILayout.Button(new GUIContent("Back to Group", "Select Group in Hierarchy"), EditorStyles.toolbarButton, GUILayout.Width(120))) {
			Selection.activeObject = _variation.transform.parent.gameObject;
		}	
		GUILayout.FlexibleSpace();
		GUI.contentColor = Color.white;
		
		var buttonPressed = GUIHelper.AddDynamicVariationButtons(_variation);
			
		switch (buttonPressed) {
			case GUIHelper.DTFunctionButtons.Play:
				isDirty = true;
				if (_variation.audLocation == MasterAudio.AudioLocation.ResourceFile) {
					creator.PreviewerInstance.Stop();
					creator.PreviewerInstance.PlayOneShot(Resources.Load(_variation.resourceFileName) as AudioClip);
				} else {
					PlaySound(_variation.GetComponent<AudioSource>());
				}
				break;
			case GUIHelper.DTFunctionButtons.Stop:
				if (_variation.audLocation == MasterAudio.AudioLocation.ResourceFile) {
					creator.PreviewerInstance.Stop();
				} else {
					StopSound(_variation.GetComponent<AudioSource>());
				}
				break;
		}
		
		EditorGUILayout.EndHorizontal();
		
		if (!Application.isPlaying) {
			GUIHelper.ShowColorWarning("*Fading & random settings are ignored by preview in edit mode.");
		}
		
		var oldLocation = _variation.audLocation;
		var newLocation = (MasterAudio.AudioLocation) EditorGUILayout.EnumPopup("Audio Origin", _variation.audLocation);

		if (newLocation != oldLocation) {
			UndoHelper.RecordObjectPropertyForUndo(_variation, "change Audio Origin");
			_variation.audLocation = newLocation;
		}
		
		switch (_variation.audLocation) {
			case MasterAudio.AudioLocation.Clip:
				var newClip = (AudioClip) EditorGUILayout.ObjectField("Audio Clip", _variation.GetComponent<AudioSource>().clip, typeof(AudioClip), false);
				
				if (newClip != _variation.GetComponent<AudioSource>().clip) {
					UndoHelper.RecordObjectPropertyForUndo(_variation.GetComponent<AudioSource>(), "assign Audio Clip");
					_variation.GetComponent<AudioSource>().clip = newClip; 
				}
				break;
			case MasterAudio.AudioLocation.ResourceFile:
				if (oldLocation != _variation.audLocation) {
					if (_variation.GetComponent<AudioSource>().clip != null) {
						Debug.Log("Audio clip removed to prevent unnecessary memory usage on Resource file Variation.");
					}
					_variation.GetComponent<AudioSource>().clip = null;
				}

				EditorGUILayout.BeginVertical();
				var anEvent = Event.current;
			
				GUI.color = Color.yellow;
				var dragArea = GUILayoutUtility.GetRect(0f, 20f,GUILayout.ExpandWidth(true));
				GUI.Box (dragArea, "Drag Resource Audio clip here to use its name!");
				GUI.color = Color.white;

				var newFilename = string.Empty;
				
				switch (anEvent.type) {
					case EventType.DragUpdated:
					case EventType.DragPerform:
						if(!dragArea.Contains(anEvent.mousePosition)) {
							break;
						}
						
						DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
						
						if(anEvent.type == EventType.DragPerform) {
							DragAndDrop.AcceptDrag();
							
							foreach (var dragged in DragAndDrop.objectReferences) {
								var aClip = dragged as AudioClip;
								if(aClip == null) {
									continue;
								}
								
								newFilename = GUIHelper.GetResourcePath(aClip);
								if (string.IsNullOrEmpty(newFilename)) {
									newFilename = aClip.name;
								}
						
								if (newFilename != 	_variation.resourceFileName) {
									UndoHelper.RecordObjectPropertyForUndo(_variation, "change Resource filename");
								    _variation.resourceFileName = aClip.name;
								}
								break;
							}
						}
						Event.current.Use();
						break;
				}
				EditorGUILayout.EndVertical();
			
				newFilename = EditorGUILayout.TextField("Resource Filename", _variation.resourceFileName);
				if (newFilename != 	_variation.resourceFileName) {
					UndoHelper.RecordObjectPropertyForUndo(_variation, "change Resource filename");
					_variation.resourceFileName = newFilename;
				}
				break;
		}
		
		var newVolume = EditorGUILayout.Slider("Volume", _variation.GetComponent<AudioSource>().volume, 0f, 1f);
		if (newVolume != _variation.GetComponent<AudioSource>().volume) {
			UndoHelper.RecordObjectPropertyForUndo(_variation.GetComponent<AudioSource>(), "change Volume");
			_variation.GetComponent<AudioSource>().volume = newVolume;
		}

		var newPitch = EditorGUILayout.Slider("Pitch", _variation.GetComponent<AudioSource>().pitch, -3f, 3f);
		if (newPitch!= _variation.GetComponent<AudioSource>().pitch) {
			UndoHelper.RecordObjectPropertyForUndo(_variation.GetComponent<AudioSource>(), "change Pitch");
			_variation.GetComponent<AudioSource>().pitch = newPitch;
		}

		var newLoop = EditorGUILayout.Toggle("Loop Clip", _variation.GetComponent<AudioSource>().loop);
		if (newLoop != _variation.GetComponent<AudioSource>().loop) {
			UndoHelper.RecordObjectPropertyForUndo(_variation.GetComponent<AudioSource>(), "toggle Loop");
			_variation.GetComponent<AudioSource>().loop = newLoop;
		}

		var newRandomPitch = EditorGUILayout.Slider("Random Pitch", _variation.randomPitch, 0f, 3f);
		if (newRandomPitch != _variation.randomPitch) {
			UndoHelper.RecordObjectPropertyForUndo(_variation, "change Random Pitch");
			_variation.randomPitch = newRandomPitch; 
		}

		var newRandomVolume = EditorGUILayout.Slider("Random Volume", _variation.randomVolume, 0f, 1f);
		if (newRandomVolume != _variation.randomVolume) {
			UndoHelper.RecordObjectPropertyForUndo(_variation, "change Random Volume");
			_variation.randomVolume = newRandomVolume;
		}

		var newWeight = EditorGUILayout.IntSlider("Weight (Instances)", _variation.weight, 0, 100);
		if (newWeight != _variation.weight) {
			UndoHelper.RecordObjectPropertyForUndo(_variation, "change Weight");
			_variation.weight = newWeight;
		}
		
		if (_variation.HasActiveFXFilter) {
			var newFxTailTime = EditorGUILayout.Slider("FX Tail Time", _variation.fxTailTime, 0f, 10f);
			if (newFxTailTime != _variation.fxTailTime) {
				UndoHelper.RecordObjectPropertyForUndo(_variation, "change FX Tail Time");
				_variation.fxTailTime = newFxTailTime;
			}
		}

		var newUseFades = EditorGUILayout.BeginToggleGroup("Use Custom Fading", _variation.useFades);
		if (newUseFades != _variation.useFades) {
			UndoHelper.RecordObjectPropertyForUndo(_variation, "toggle Use Custom Fading");
			_variation.useFades = newUseFades;
		}

		var newFadeIn = EditorGUILayout.Slider("Fade In Time (sec)", _variation.fadeInTime, 0f, 10f);
		if (newFadeIn != _variation.fadeInTime) {
			UndoHelper.RecordObjectPropertyForUndo(_variation, "change Fade In Time");
			_variation.fadeInTime = newFadeIn;
		}
		
		if (_variation.GetComponent<AudioSource>().loop) {
			GUIHelper.ShowColorWarning("*Looped clips cannot have a custom fade out.");
		} else {
			var newFadeOut = EditorGUILayout.Slider("Fade Out time (sec)", _variation.fadeOutTime, 0f, 10f);
			if (newFadeOut != _variation.fadeOutTime) {
				UndoHelper.RecordObjectPropertyForUndo(_variation, "change Fade Out Time");
				_variation.fadeOutTime = newFadeOut;
			}
		}

		EditorGUILayout.EndToggleGroup();
		
		var filterList = new List<string>() {
			MasterAudio.NO_GROUP_NAME,
			"Low Pass",
			"High Pass",
			"Distortion",
			"Chorus",
			"Echo",
			"Reverb"
		};
		
		var newFilterIndex = EditorGUILayout.Popup("Add Filter Effect", 0, filterList.ToArray());
		switch (newFilterIndex) {
			case 1:
				AddFilterComponent(typeof(AudioLowPassFilter));
				break;
			case 2:
				AddFilterComponent(typeof(AudioHighPassFilter));
				break;
			case 3:
				AddFilterComponent(typeof(AudioDistortionFilter));
				break;
			case 4:
				AddFilterComponent(typeof(AudioChorusFilter));
				break;
			case 5:
				AddFilterComponent(typeof(AudioEchoFilter));
				break;
			case 6:
				AddFilterComponent(typeof(AudioReverbFilter));
				break;
		}
		
		if (GUI.changed || isDirty) {
			EditorUtility.SetDirty(target);
		}

		this.Repaint();

		//DrawDefaultInspector();
    }

	private void AddFilterComponent(Type filterType) {
		_variation.gameObject.AddComponent(filterType);
	}
	
	private void PlaySound(AudioSource aud) {
		aud.Stop();
		aud.Play();
	}
	
	private void StopSound(AudioSource aud) {
		aud.Stop();
	}
}
