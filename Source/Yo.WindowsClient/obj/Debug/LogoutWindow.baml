   M S B A M L   `   `   `  ����K  GYo.WindowsClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Yo.WindowsClientYo.WindowsClient  5   	   #    Yo.WindowsClient.LogoutWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Yo.WindowsClient     5   	     � Title$  LogoutWindow��5   	   $	��200��6   $	��400��6+    � WindowStyle$
 None=�67   .��5	      � 
���� �� � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��2��5      $#��Are you sure you want logout?��5      $��25(�5      $��Center=�5         txtBlockStyle#���   5      �� 5   
   -   5         ��Name$ 	btnCancel��5       $��1��5      $��0��5      $��Cancel��5      
��� E��  btnStyle#���  5!      �� 5#   
   -   5        $ 	btnLogout��5'      $��1��5#      $��1��5$      $	��Yes��5%      
��� � �#���  5(      5*      5+      