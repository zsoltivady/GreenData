   M S B A M L   `   `   `  ����D  @GreenDraw, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GreenDraw	GreenDraw  5   	       GreenDraw.View.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'vm1clr-namespace:GreenDraw     5   	   -   5          �Name$  LoginWindow��5   	    � Title$ Login��5   	   $	��450��6   $	��350��6$    � WindowStartupLocation$ CenterScreen=�60   ���#0A5581$��14(�6j    � DataContext 5	         GreenDraw.LoginViewModel  5
   
    � 	Resources 5          booleanToVisibilityConverter �� 
TargetType �� Property �� Value �� Triggers	 P� Property
 P� Value �� Self �� RelativeSource �� Path��%�  &	        '��      'G� T    �� 5   
   6'   �� 5   
   " ��6   .�5      ��  � ��$ 0,0,0,20q�6'   �� 5       �@=�ErrorTemplate 5      �� 5      .R�5      ]� .+�5      �� $��Right=�6(   $��5,0,0,0q�6?   
���  ��$
��Bold"�6a   *6v   �� 5      $��Bottom=�6F   
���  ����6(   �� *ErrorContent+6^   �� 5      
���  ��$��1q�67   ._�5   "   �� 5      5      5      5       5      P� 5      	 �@=�HasError
 . . �5       ��  �@�ToolTip 5!      �� # Z $) #(Validation.Errors)[0].ErrorContent�5#      5%      �� 5'   
   " G�6   .�5(      ��  � ��$ 0,0,0,20q�6'   �� 5)       �@=�ErrorTemplate 5*      �� 5+      .R�5,      ]� .+�5-      �� $��Right=�6(   $��5,0,0,0q�6?   
���  ��$
��Bold"�6a   *6v   �� 5.      $��Bottom=�6F   
���  ����6(   �� *ErrorContent+6^   �� 5/      
���  ��$��1q�67   ._�50   "   �� 51      52      53      55       56      P� 57      	 �@=�HasError
 . . �58      ��  �@�ToolTip 59      �� # Z $) #(Validation.Errors)[0].ErrorContent�5;      5=      5>      .��5@      �� ���#0D1920 �� CornerRadius$ 20��6"   $��20q�64   ._�5A   
   �� $��20q�6   .+�5B      �� $��Bejelentkezés��6   
�������$��25(�6?   $��Center=�6M   6l   �� 5C      6   �� 5D      $��Felhasználónév��6   
�������6B   �� 5E      -   5        $��textb1��5E      
�������
�������6K   �� 5F      $��Jelszó��6   
�������6:   G� 5G      -   5         G�Name$ textb3��5G      
�������
�������6Q   �� 5H      $��	Belépés��6   
�������
�������$��10q�6i   $��30��6u   ��6(   �� *	DoLogin+6�   �� 5I      $��Regisztráció��6   
�������
�������$��10q�6�   $��90��6�   ��6-   �� *ShowRegistration+��6R   ��  �� ElementName$ LoginWindow��6�   �� 5J      -   5        $��Belépés vendégként��5J      
�������
�������$��10q�6l   $	��140��6x   6�   �� 5K      $
��Wrap=�6   $��0,10,0,0q�6,   ��6>   �� *	Message+y�6W   �� *
MsgVisible+ �� 	Converter# [  6�   5L      5N      5P      