   M S B A M L   `   `   `  ����K  GYo.WindowsClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Yo.WindowsClient.ViewsYo.WindowsClient.Views  5      I)clr-namespace:Yo.WindowsClient.ConvertersYo.WindowsClient.Converters  5      )    #Yo.WindowsClient.Views.SetPhonePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Yo.WindowsClient.Views     5      @
Converters)clr-namespace:Yo.WindowsClient.Converters     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-Fa$http://schemas.fontawesome.io/icons/  5        N� Title$  SetPhonePage��5       � 	Resources 5      9  3Yo.WindowsClient.Converters.BooleanInverseConverter   boolInverseConverter>   8Yo.WindowsClient.Converters.BooleanToVisibilityConverter  boolToVisibilityConverter��%:   &	        &	        5   
   6-     5   
   62   5      .��5      �   MainBackgroundColor#���  6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��1.5* �6   �� 5      $��2* �6   .+�5   
   � -   5         �Name$ popup��5"      $��Center=�5       � 	StaysOpen .  $	��175��5       $	��300��5!      ��5#      �� *
PopupWidth+��5$      �� *PopupHeight+��5%      �� *PopupOpened+.��5'      � #���  6    5)      �� 5*      $
��Auto �6$   �� 5+      $��* �6$   �� 5,      $��* �6$   .+�5/      �� $��0��6   $��Message��50      $��Center=�51        txtBlockStyle#���  52      �� 54      $��1��6   $��15(�55      $��Center=�58      $��Center=�59      #���  5:      ��56      �� *	Message+��57      �� *MessageColor+5:      � 5<      $��2��6    � ColumnDefinitions 5>      �� 5?      $��* �6+   �� 5@      $��3* �6+   �� 5A      $��* �6+   .+�5D      �� $��1��6   $��Ok��5E      
��� E��$	��0 5q�5G        btnStyle#���  5I      ��5H      �� *ClosePopupCommand+5I      5J      5K      5L      �� 5N   
   $��0��6   $��Enter Your Phone #��5O      
����� �#���  5Q      �� 5S   
   $��1��6   $��30(�5T      
����� �$
��Wrap=�5V      $����To find your friends and allow them to find you. Your contacts are not stored anywhere and will only be used to find your friends��5W      #���  5X      � 5Z   
   $��2��6   
��� � � 5\      �� 5^      $��* �6#   �� 5_      $��3* �6#   .+�5c      �� $��0��6   $��	20,0,20,0q�5d       �� Text$ 	+1 Change��5e      
��� � ���5g      �� *	Countries+��5h      �� 5i      .R�5j      �� 
���   ���6$   �� *Name+5k   $   5l      5n      �� 5p      $��1��6   
��� � � �� TextAlignment$
 Left=�5s      $��45(�5t        txtBoxStyle#���  5u      ��5q      �� *Phone+5u      5v      � 5x   
   $��3��6    5z      �� 5|      $
��1.1* �6#   �� 5}      $��* �6#   .+�5�      �� $��0��6   $��Cancel��5�      
��� E��#���  5�      ��5�      �� *CancelCommand+{�5�      �� *IsBusy+ �� 	Converter# [  �� 5�      $��1��6   $��Go��5�      
��� d �#���  5�      ��5�      �� *SetPhoneCommand+{�5�      �� *IsBusy+# [  5�      "  FontAwesome.WPF.ImageAwesome  5�   
   	   Icon$	 Refresh=�6   
   
Foreground

 �����$��50��5�      $��50��6&   $��4��5�      $��Center=�5�      $��Bottom=�5�      $��0 0 0 5q�5�         Spin 5�      �� *IsBusy+y�5�      �� *IsBusy+# [ 5�      5�      5�      