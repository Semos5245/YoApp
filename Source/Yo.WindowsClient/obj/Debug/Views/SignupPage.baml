   M S B A M L   `   `   `  ����K  GYo.WindowsClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Yo.WindowsClient.ViewsYo.WindowsClient.Views  5      I)clr-namespace:Yo.WindowsClient.ConvertersYo.WindowsClient.Converters  5      '    !Yo.WindowsClient.Views.SignupPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Yo.WindowsClient.Views     5      @
Converters)clr-namespace:Yo.WindowsClient.Converters     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-Fa$http://schemas.fontawesome.io/icons/  5        N� Title$  
SignupPage��5       � 	Resources 5      9  3Yo.WindowsClient.Converters.BooleanInverseConverter   boolInverseConverter>   8Yo.WindowsClient.Converters.BooleanToVisibilityConverter  boolToVisibilityConverter��%:   &	        &	        5   
   6-     5   
   62   5      .��5      �   MainBackgroundColor#���  6   {�6>   �� *IsBusy+ �� 	Converter# [   � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��2* �6   .+�5   
   � -   5         �Name$ popup��5#      $��Center=�5       � 	StaysOpen .  $	��175��5!      $	��300��5"      ��5$      �� *
PopupWidth+��5%      �� *PopupHeight+��5&      �� *PopupOpened+.��5(      � #���  6    5*      �� 5+      $
��Auto �6$   �� 5,      $��* �6$   �� 5-      $��* �6$   .+�50      �� $��0��6   $��Message��51      $��Center=�52        txtBlockStyle#���  53      �� 55      $��1��6   $��15(�56      $��Center=�59      $��Center=�5:      #���  5;      ��57      �� *	Message+��58      �� *MessageColor+5;      � 5=      $��2��6    � ColumnDefinitions 5?      �� 5@      $��* �6+   �� 5A      $��3* �6+   �� 5B      $��* �6+   .+�5E      �� $��1��6   $��Ok��5F      
��� E��$	��0 5q�5H        btnStyle#���  5J      ��5I      �� *ClosePopupCommand+5J      5K      5L      5M      �� 5P   
   $��0��6   $
��Left=�5Q      ��5R      �� *BackCommand+��5S      �� 5T      $D��>D:\\Projects\Mine\YoApp\Yo.WindowsClient\Images\BackButton.png��6   $��50��6`   5V      �� 5Y   
   $��1��6   
������  txtBoxStyle#��[ 5\      ��5Z      �� *
Username+5\      �� 5_   
   $��2��6   
���"�"�#���  5b      ��5`      �� *
Password+5b      �� 5e   
   $��3��6   $��Tap To Signup��5f      
���   �#���  5h      ��5i      �� *SignupCommand+"  FontAwesome.WPF.ImageAwesome  5k   
      Icon$ Refresh=�6      
Foreground
 �����$��50��5o      $��50��6&   $��4��5p      $��Center=�5q      $��Bottom=�5r      $��0 0 0 5q�5s      	   Spin	 5m      �� *IsBusy+y�5n      �� *IsBusy+# [ 5s      5u      5v      