using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class OnPropertychanged : MonoBehaviour
{
    public event PropertyChangedEventHandler PropertyChanged;
    
    public void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }    
}
