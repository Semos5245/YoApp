   M S B A M L   `   `   `  ����K  GYo.WindowsClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Yo.WindowsClient.ViewsYo.WindowsClient.Views  5      I)clr-namespace:Yo.WindowsClient.ConvertersYo.WindowsClient.Converters  5      /    )Yo.WindowsClient.Views.BlockedFriendsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Yo.WindowsClient.Views     5      @
Converters)clr-namespace:Yo.WindowsClient.Converters     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-Fa$http://schemas.fontawesome.io/icons/  5        N� Title$  BlockedFriendsPage��5       � 	Resources 5      9  3Yo.WindowsClient.Converters.BooleanInverseConverter   boolInverseConverter>   8Yo.WindowsClient.Converters.BooleanToVisibilityConverter  boolToVisibilityConverter�� 5   
   %:   &	        &	        5      61     5      66   5      .��5      �   MainBackgroundColor#���  6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � -   5         �Name$ popup��5"      $��Center=�5       � 	StaysOpen .  $	��175��5       $	��300��5!      ��5#      �� *
PopupWidth+��5$      �� *PopupHeight+��5%      �� *PopupOpened+.��5'      � #���  6    5)      �� 5*      $
��Auto �6$   �� 5+      $��* �6$   �� 5,      $��* �6$   .+�5/      �� $��0��6   $��Message��50      $��Center=�51        txtBlockStyle#���  52      �� 54      $��1��6   $��15(�55      $��Center=�58      $��Center=�59      #���  5:      ��56      �� *	Message+��57      �� *MessageColor+5:      � 5<      $��2��6    � ColumnDefinitions 5>      �� 5?      $��* �6+   �� 5@      $��3* �6+   �� 5A      $��* �6+   .+�5D      �� $��1��6   $��Ok��5E      
��� E��$	��0 5q�5G        btnStyle#���  5I      ��5H      �� *ClosePopupCommand+5I      5J      5K      5L      �� 5M   
   $��0��6   $
��Left=�5N      #���  5O      ��5P      �� *BackCommand+��5Q      �� 5R      $D��>D:\\Projects\Mine\YoApp\Yo.WindowsClient\Images\BackButton.png��6   $��50��6`   5T      �� 5V   
   $��1��6   $��Blocked Friends��5W      
����� �#���  5Y      �� 5Z   
   -   5         ��Name$ lstBlockedFriends��5`      $��2��5Z       �� SelectionMode$ Single=�5^      $��Stretch=�5_      ��5[      �� *BlockedFriends+ �� SelectedItem 5\      �� *SelectedUser+{�5]      �� *IsBusy+	 �� 	Converter#	 [  ��5a      �� 5b      
 �� 
TargetType"
 ��6   .�5c      ��  �� Property � �� �� Value$ 2q�6/    �� Triggers 5e      P� 5f       P� Property �@J�IsKeyboardFocusWithin P� Value . . �5g      ��  �@��
IsSelected . 6;   5h      :� 5i       :� RoutedEvent$ 
MouseEnter��6'   .[�5j      �� .��5k   "   �� .��5l   &   W�  �� TargetProperty$ Opacity�66   	 W� To$	 0.8X�6Z    g� Duration$ 0:0:0.5D�6c   5m   #   5n      5o      :� 5p      $ 
MouseLeave��6'   .[�5q      �� .��5r   "   �� .��5s   &   W� $ Opacity�66   $	 1.0X�6Z   $ 0:0:0.5D�6c   5t   #   5u      5v      5x      ��5z      �� 5{      .R�5|      � #���  6    5}      �� 5~      $��* �6/   �� 5      $
��Auto �6/   .+�5�      �� #���  6$   ��5�       �� *
Username+�� 5�      #���  6!   
��� E��$��UnBlock��5�   !   $��1��5�   !   ��5�   !   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType$ ListViewL� �� Path$  DataContext.UnblockCommand�5�      5�      5�      "  FontAwesome.WPF.ImageAwesome  5�   
      Icon$ Refresh=�6      
Foreground
 �����$��50��5�      $��50��6&   $��3��5�      $��Center=�5�      $��Bottom=�5�      $��0 0 0 5q�5�         Spin 5�      �� *IsBusy+y�5�      �� *IsBusy+#	 [ 5�      5�      5�      