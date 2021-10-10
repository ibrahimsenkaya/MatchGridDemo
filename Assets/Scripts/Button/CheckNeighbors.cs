using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;

public class CheckNeighbors : MonoBehaviour
{   
   private int SelfIndex;
   private GridController _gridController;
   [SerializeField] Sprite CheckedImage,NormalImage;
   private Image _image;

   private void OnEnable()
   {
      _image = GetComponent<Image>();
      _gridController = GetComponentInParent<GridController>();
   }

   public void Checkthem()
   {
      SelfIndex = int.Parse(transform.name);
      SetYourselfChecked();
      _gridController.checkLeadNeighbors(SelfIndex);

   }

   public void Reset()
   {
      _image.sprite= NormalImage;
      transform.tag = "Untagged";
      
   }


   void SetYourselfChecked()
   {
      GetComponent<Image>().sprite = CheckedImage;
      transform.tag = "Checked";
      
   }
}
