   M S B A M L   `   `   `  ����K  GYo.WindowsClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Yo.WindowsClient.ViewsYo.WindowsClient.Views  5      I)clr-namespace:Yo.WindowsClient.ConvertersYo.WindowsClient.Converters  5      (    "Yo.WindowsClient.Views.FriendsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Yo.WindowsClient.Views     5      @
Converters)clr-namespace:Yo.WindowsClient.Converters     5        N� Title$  FriendsPage��5
       � 	Resources 5      9  3Yo.WindowsClient.Converters.BooleanInverseConverter   boolInverseConverter�� 5   
   %   &	          5      61   5      .��5      �   MainBackgroundColor#���  6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � -   5         �Name$ popup��5      $��Center=�5       � 	StaysOpen .  $	��200��5      $	��300��5      ��5      �� *
PopupWidth+��5       �� *PopupHeight+��5!      �� *PopupOpened+.��5#      � #���  6    5%      �� 5&      $
��Auto �6$   �� 5'      $��* �6$   �� 5(      $��* �6$   .+�5+      �� $��0��6   $��Message��5,      $��Center=�5-        txtBlockStyle#���  5.      �� 50      $��1��6   $��15(�51      $��Center=�54      $��Center=�55      #���  56      ��52      �� *	Message+��53      �� *MessageColor+56      � 58      $��2��6    � ColumnDefinitions 5:      �� 5;      $��* �6+   �� 5<      $��3* �6+   �� 5=      $��* �6+   .+�5@      �� $��1��6   $��Ok��5A      
��� E��$	��0 5q�5C        btnStyle#���  5E      ��5D      �� *ClosePopupCommand+5E      5F      5G      5H      �� 5K   
   -   5         ��Name$ 
lstFriends��5L      $��0��5K      $��Stretch=�5M      $��Stretch=�5N       �� SelectionMode$ Single=�5O      ��5P      �� *	Friends+ �� SelectedItem 5Q      �� *SelectedUser+��5R      �� 5S      	 �� 
TargetType"	 ��6   .�5T      �� 
 �� Property
 � �� �� Value$ 5q�6/    �� Triggers 5V      P� 5W       P� Property �@J�IsKeyboardFocusWithin P� Value . . �5X      �� 
 �@��
IsSelected . 6;   5Y      5[      ��5]      �� 5^      .R�5`      � #���  6    5a      �� 5b      $��* �6/   �� 5c      $
��Auto �6/   �� 5d      $
��Auto �6/   �� 5e      $
��Auto �6/   .+�5g      �� $��0��6$   $��Center=�5h   $   $��40(�5i   $   $��Center=�5j   $   #���  5k   $   ��5l   $   �� *
Username+�� 5m      $��1��6!   $��Send Yo��5n   !   
��� E��$��20(�5p   !   #���  5r   !   {�5q   !   �� *IsBusy+ �� 	Converter# [  ��5s   !   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType$ ListViewL� �� Path$ DataContext.SendYoCommand��� 5u      $��2��6!   $��Block��5v   !   
��� E��$��20(�5x   !   #���  5z   !   {�5y   !   �� *IsBusy+# [  ��5{   !   ��  �� *FindAncestor+$ ListViewL�$$ DataContext.BlockFriendCommand��� 5}      $��3��6!   $��Delete��5~   !   
���  ��$��20(�5�   !   #���  5�   !   {�5�   !   �� *IsBusy+# [  ��5�   !   ��  �� *FindAncestor+$ ListViewL�$% DataContext.DeleteFriendCommand�5�      5�      5�      �� 5�   
   $��1��6   #��[ 5�      $��Invite��5�      
����  �5�      �� 5�   
   -   5         ��Name$ 
mainBorder��5�      $��2��5�      ._�5�      �� -   5         ��Name$ btnAdd��5�      #��[ 5�      $��+��5�      
��� � �5�      5�      �� 5�   
   -   5        $ 	addBorder��5�      $��2��5�      ._�5�      �  5�      �� 5�      $��* �6'   �� 5�      $
��Auto �6'   .+�5�      �� -   5         ��Name$ txtAdd��5�      $��0��5�        txtBoxStyle#���  5�      
��� �����5�      �� *AddingUsername+�� 5�      $��1��6   $	��Add��5�      
���  ��#���  5�      ��5�      �� *AddUsernameCommand+5�      5�      �� 5�   
   $��3��6   $��40(�5�      $��Right=�5�      $��Bottom=�5�      $��Settings��5�      ��5�      �� *OpenSettingsCommand+��5�      �� 5�       �� 
TargetType" ��6"   .R�5�      ��  �� CornerRadius$ 50��6   
��� ���$��2q�6C   ._�5�      �� $��Center=�6+   $��Center=�6F   5�      5�      5�      �� 5�   
   $��3��6   $��40(�5�      $
��left=�5�      $��Bottom=�5�      $��Requests��5�      ��5�      �� *OpenFriendRequestsCommand+��5�      �� 5�      " ��6"   .R�5�      �� $ 50��6   
��� E��$��2q�6F   ._�5�      �� $��Center=�6+   $��Center=�6F   5�      5�      5�      5�      5�      