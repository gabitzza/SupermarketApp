   M S B A M L   `   `   `  ����  SupermarketWPF%    SupermarketWPF.View.ProduseView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  ProduseView��5   	   $	��450��6   $	��800��6*    � 	Resources 5         PlaceholderTextBoxStyle �� 
TargetType �� 	Resources  Key j� 
AlignmentX j� 
AlignmentY j� Stretch !� Visual �� RelativeSource	 �� AncestorType
 �� Path �� Triggers P� Property P� Value �� Property �� Value��%}  &	        �� 5   
   " ��60    5      ��!� 5      CueBannerBrush $
 Left=�65   $ Center=�6G   $
 None=�6[    5	      �� 5
      
�������$��5,0,0,0q�5      ��5      ��  �� "	 ��$	
 Tag�5      5      5       5      P� 5       � ��$  ��6*   . �5      ��  � �� 5      !� 5      $
 Left=�6*   $ Center=�6<   $
 None=�6P    5   "   �� 5   &   
�������$��5,0,0,0q�6�   ��60   �� *Tag+ �� "	 ��6�   5      5      5      P� 5       �@J�	IsFocused . . �5      ��  � ��
 �����63   5      5!      5"      .��5#      � .+�5$   
   �� .+�5%      �� -   5         ��Name$ txtNumeProdus��5%      $	��200��6-   $��5q�69   
 � Tag$ Nume Produs��6D   #��[  6V   ��6�   �� *
NumeProdus+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5&      -   5        $ txtCodDeBare��5&      $	��200��6,   $��5q�68   $ Cod De Bare��6C   #��[  6U   ��6�   �� *	CodDeBare+$ TwoWay=�$ PropertyChanged=��� 5'      -   5         ��Name$ cmbCategoria��5'      $	��200��6-   $��5q�69    �� DisplayMemberPath$ NumeCategorie��6j    �� SelectedValuePath$ NumeCategorie��6�   ��6D   �� *CategoriiList+ �� SelectedValue 6�   �� *	Categoria+$ TwoWay=�$ PropertyChanged=��� 5(      -   5        $ cmbProducatorId��5(      $	��200��60   $��5q�6<   $ NumeProducator��6o   $ Id��6�   ��6G   �� *ProducatoriList+ 6�   �� *ProducatorId+$ TwoWay=�$ PropertyChanged=��� 5)      $��Adaugă Produs��6   $	��200��6R   $��5q�6^   ��6-   �� *AddProdusCommand+6^   �� 5*      $��Actualizează Produs��6   $	��200��6[   $��5q�6g   ��63   �� *UpdateProdusCommand+6g   �� 5+      $��Șterge Produs��6   $	��200��6V   $��5q�6b   ��6.   �� *DeleteProdusCommand+6b   5,      &   System.Windows.Controls.DataGrid  5-   
      AutoGenerateColumns .  $	��750��6S   $��25,217,25,10q�6_   ��6   �� *ProduseList+ �� SelectedItem 6u   �� *SelectedProdus+$ TwoWay=�   Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     50      $ Nume Produs��6%    .  6:   �� *
NumeProdus+6Y     51      $ Cod De Bare��6%    .  6:   �� *	CodDeBare+6X     52      $ 	Categoria��6%    .  68   �� *	Categoria+6V     53      $ 
Producator��6%    .  69   �� *Producatori.NumeProducator+6h   55      56      57      