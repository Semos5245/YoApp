   M S B A M L   `   `   `  ����K  GYo.WindowsClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Yo.WindowsClient.ViewsYo.WindowsClient.Views  5      I)clr-namespace:Yo.WindowsClient.ConvertersYo.WindowsClient.Converters  5      )    #Yo.WindowsClient.Views.SetEmailPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Yo.WindowsClient.Views     5      @
Converters)clr-namespace:Yo.WindowsClient.Converters     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-Fa$http://schemas.fontawesome.io/icons/  5        N� Title$  SetEmailPage��5       � 	Resources 5      9  3Yo.WindowsClient.Converters.BooleanInverseConverter   boolInverseConverter>   8Yo.WindowsClient.Converters.BooleanToVisibilityConverter  boolToVisibilityConverter�� 5   
   %:   &	        &	        5      61     5      66   5      .��5      �   MainBackgroundColor#���  6   {�6>   �� *IsBusy+ �� 	Converter# [   � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��3* �6   .+�5   
   � -   5         �Name$ popup��5"      $��Center=�5       � 	StaysOpen .  $	��175��5       $	��300��5!      ��5#      �� *
PopupWidth+��5$      �� *PopupHeight+��5%      �� *PopupOpened+.��5'      � #���  6    5)      �� 5*      $
��Auto �6$   �� 5+      $��* �6$   �� 5,      $��* �6$   .+�5/      �� $��0��6   $��Message��50      $��Center=�51        txtBlockStyle#���  52      �� 54      $��1��6   $��15(�55      $��Center=�58      $��Center=�59      #���  5:      ��56      �� *	Message+��57      �� *MessageColor+5:      � 5<      $��2��6    � ColumnDefinitions 5>      �� 5?      $��* �6+   �� 5@      $��3* �6+   �� 5A      $��* �6+   .+�5D      �� $��1��6   $��Ok��5E      
��� E��$	��0 5q�5G        btnStyle#���  5I      ��5H      �� *ClosePopupCommand+5I      5J      5K      5L      �� 5O   
   $��0��6   $
��Left=�5P      ��5Q      �� *BackCommand+��5R      �� 5S      $D��>D:\\Projects\Mine\YoApp\Yo.WindowsClient\Images\BackButton.png��6   $��50��6`   5U      �� 5W   
   $��1��6   $��Set A New Email��5X      #���  5Y      
����� �5Z      �� 5\   
   $��2��6     txtBoxStyle#���  5]      
��� � ���5_      �� *Email+�� 5b   
   $��3��6   $��
Tap To Set��5c      
����  �#���  5e      ��5f      �� *SetEmailCommand+"  FontAwesome.WPF.ImageAwesome  5h   
      Icon$ Refresh=�6      
Foreground
 �����$��50��5l      $��50��6&   $��4��5m      $��Center=�5n      $��Bottom=�5o      $��0 0 0 5q�5p      	   Spin	 5j      �� *IsBusy+y�5k      �� *IsBusy+# [ 5p      5q      5r      