   M S B A M L   `   `   `  ����D  @GreenDraw, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GreenDraw.ViewGreenDraw.View  5   	   9!clr-namespace:GreenDraw.ViewModelGreenDraw.ViewModel  5   	   +clr-namespace:GreenDraw.UIGreenDraw.UI  5   	   !    GreenDraw.View.Registration   5   
   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:GreenDraw.View     5   	   0vm!clr-namespace:GreenDraw.ViewModel     5   	   )uiclr-namespace:GreenDraw.UI     5   	   -   5          �Name$  RegistrationWindow��5   
    � Title$ Regisztráció��5
   	   $	��380��6   $	��550��6+    � WindowStartupLocation$ CenterScreen=�67   ���#0A5581 � DataContext 5      /  )GreenDraw.ViewModel.RegistrationViewModel  5   
    � 	Resources 5          booleanToVisibilityConverter �� 
TargetType �� Property �� Value �� Triggers	 P� Property
 P� Value �� Self �� RelativeSource �� Path��%�  &	        '��      'G� T    �� 5   
   6'   �� 5   
   " ��6   .�5      ��  � ��$ 0,0,0,20q�6'   �� 5       �@=�ErrorTemplate 5      �� 5      .R�5      ]� .+�5      �� $��Right=�6(   $��5,0,0,0q�6?   
���  ��$
��Bold"�6a   *6v   �� 5      $��Bottom=�6F   
���  ����6(   �� *ErrorContent+6^   �� 5      
���  ��$��1q�67   ._�5   "   �� 5      5      5      5       5       P� 5!      	 �@=�HasError
 . . �5"      ��  �@�ToolTip 5#      �� # Z $) #(Validation.Errors)[0].ErrorContent�5%      5'      �� 5)   
   " G�6   .�5*      ��  � ��$ 0,0,0,20q�6'   �� 5+       �@=�ErrorTemplate 5,      �� 5-      .R�5.      ]� .+�5/      �� $��Right=�6(   $��5,0,0,0q�6?   
���  ��$
��Bold"�6a   *6v   �� 50      $��Bottom=�6F   
���  ����6(   �� *ErrorContent+6^   �� 51      
���  ��$��1q�67   ._�52   "   �� 53      54      55      57       58      P� 59      	 �@=�HasError
 . . �5:      ��  �@�ToolTip 5;      �� # Z $) #(Validation.Errors)[0].ErrorContent�5=      5?      5@      .��5B      �� ���#0D1920 �� CornerRadius$ 20��6"   $��20q�64   ._�5C   
   �� .+�5D      ��  �� Orientation$ 
Horizontal=�6   .+�5E      �� $��90��6   $��30��6$   $
��Left=�60   $��20,20,90,20q�6K   $��Vissza��6`   
�������
���������6q   �� *	ShowLogin+��6�   ��  �� ElementName$ RegistrationWindow��6�   5F      �� 5G      $ 
Horizontal=�6   $��30��62   $��	5,0,10,10q�6>   .+�5H      �� $	��100��6   $��30��6$   $
��Left=�60   $��	30,0,0,10q�6K   $��Felhasználónév��6^   
�������6w   �� 5I      -   5         ��Name$ username��5I      $	��250��6,   $��20��68   $
��Left=�6D   $��60,0,0,0q�6_   6q   5J      �� 5K      $ 
Horizontal=�6   $��30��62   $��	5,0,10,10q�6>   .+�5L      �� $	��100��6   $��30��6$   $
��Left=�60   $��	30,0,0,10q�6K   $��Jelszó��6^   
�������6o   G� 5M      -   5         G�Name$ password��5M      $	��250��60   $��20��6<   $
��Left=�6H   $��60,0,0,0q�6c   6u   5N      �� 5O      $ 
Horizontal=�6   $��30��62   $��	5,0,10,10q�6>   .+�5P      �� $	��110��6   $��30��6$   $
��Left=�60   $��30,0,0,0q�6K   $��Jelszó Mégegyszer��6]   
�������6y   G� 5Q      -   5        $ 	password2��5Q      $	��250��61   $��20��6=   $
��Left=�6I   $��50,0,0,0q�6d   6v   5R      �� 5S      $ 
Horizontal=�6   $��30��62   $��	5,0,10,10q�6>   .+�5T      �� $	��100��6   $��30��6$   $
��Left=�60   $��	30,0,0,10q�6K   $��E-mail��6^   
�������6o   �� 5U      -   5        $ email��5U      $	��250��6)   $��20��65   $
��Left=�6A   $��60,0,0,0q�6\   6n   5V      �� 5W      $��Center=�6   $��30��62   $��70��6>   $��Regisztráció��6I   $��10q�6`   
�������
���������6�   �� *DoRegistration+6�   �� 5X      $
��Wrap=�6   $��0,10,0,0q�6,   ��6>   �� *	Message+y�6W   �� *
MsgVisible+6{   5Y      5Z      5[      