   M S B A M L   `   `   `  ����  SupermarketWPF#    SupermarketWPF.View.LoginView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Login��5   	   $	��300��6   $	��400��6$    � 	Resources 5         PlaceholderTextBoxStyle �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value j� 
AlignmentX	 j� 
AlignmentY
 j� Stretch !� Visual �� RelativeSource �� AncestorType��%�  &	        �� 5   
   " ��60    5      P� 5       � ��$  ��6*   . �5	      ��  � �� 5
      !� 5      $
 Left=�6*   $	 Center=�6<   $

 None=�6P    5   "   �� 5   &   
�������$��5,0,0,0q�6�   ��60   �� *Tag+ �� " ��6�   5      5      5      P� 5       �@J�	IsFocused . . �5      ��  � ��
 �����63   5      5      5      .��5      � .+�5   
   �� .+�5      �� -   5         ��Name$ txtUsername��5      $	��200��6+   $��5q�67   
 � Tag$ Username��6B   #��[  6Q   ��6�   �� *
Username+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�G� 5      -   5         G�Name$ txtPassword��5      $	��200��6/   $��5q�6;   $ Password��6F   6U   �� 5      $��Login��6   $	��200��6F   $��5q�6R   ��6%   �� *LoginCommand+6R   5      5      5       