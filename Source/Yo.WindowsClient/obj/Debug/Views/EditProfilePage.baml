   M S B A M L   `   `   `  ����K  GYo.WindowsClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Yo.WindowsClient.ViewsYo.WindowsClient.Views  5      I)clr-namespace:Yo.WindowsClient.ConvertersYo.WindowsClient.Converters  5      ,    &Yo.WindowsClient.Views.EditProfilePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Yo.WindowsClient.Views     5      @
Converters)clr-namespace:Yo.WindowsClient.Converters     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-Fa$http://schemas.fontawesome.io/icons/  5        N� Title$  EditProfilePage��5       � 	Resources 5      9  3Yo.WindowsClient.Converters.BooleanInverseConverter   boolInverseConverter>   8Yo.WindowsClient.Converters.BooleanToVisibilityConverter  boolToVisibilityConverter��%:   &	        &	        5   
   6-     5   
   62   5      .��5      �   MainBackgroundColor#���  6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $
��0.5* �6   �� 5      $��* �6   �� 5      $��2* �6   .+�5   
   � -   5         �Name$ popup��5!      $��Center=�5       � 	StaysOpen .  $	��175��5      $	��300��5       ��5"      �� *
PopupWidth+��5#      �� *PopupHeight+��5$      �� *PopupOpened+.��5&      � #���  6    5(      �� 5)      $
��Auto �6$   �� 5*      $��* �6$   �� 5+      $��* �6$   .+�5.      �� $��0��6   $��Message��5/      $��Center=�50        txtBlockStyle#���  51      �� 53      $��1��6   $��15(�54      $��Center=�57      $��Center=�58      #���  59      ��55      �� *	Message+��56      �� *MessageColor+59      � 5;      $��2��6    � ColumnDefinitions 5=      �� 5>      $��* �6+   �� 5?      $��3* �6+   �� 5@      $��* �6+   .+�5C      �� $��1��6   $��Ok��5D      
��� E��$	��0 5q�5F        btnStyle#���  5H      ��5G      �� *ClosePopupCommand+5H      5I      5J      5K      �� 5M   
   $��0��6   
����� �$��Set A Profile Picture��5O      #���  5P      �� 5R   
   $��1��6   
���2�2�$��Choose Image��5T      #���  5U      ��5V      �� *OpenFileDialogCommand+{�5W      �� *IsBusy+ �� 	Converter# [  � 5Y   
   $��2��6   
��� ��� 5[      �� 5\      $��* �6#   �� 5]      $��3* �6#   .+�5`      A� $��75��6   $��75��6!   ��5a      �� 5b       �� ImageSource 6!   �� *	ImagePath+5d      �� 5f      $��1��6    �� TextAlignment$
 Left=�5g      
��� ���  txtBoxStyle#���  5j      ��5h      �� *
FullName+5j      5k      �� 5m   
   $��3��6   
���iii�$[��UThis is what other users can see about you when they swip your username to the right.��5o      #���  5p      $��20(�5q      
�������5r      � 5t   
   $��4��6   {�6   �� *IsBusy+# [   5v      �� 5w      $��* �6#   �� 5x      $
��1.2* �6#   .+�5{      �� $��0��6   $
��Back��5|      
��� E��#���  5~      ��5      �� *CancelCommand+�� 5�      $��1��6   $
��Save��5�      
��� � �#���  5�      ��5�      �� *SaveCommand+5�      "  FontAwesome.WPF.ImageAwesome  5�   
   	   Icon$	 Refresh=�6   
   
Foreground

 �����$��50��5�      $��50��6&   $��5��5�      $��Center=�5�      $��Bottom=�5�      $��0 0 0 5q�5�         Spin 5�      �� *IsBusy+y�5�      �� *IsBusy+# [ 5�      5�      5�      