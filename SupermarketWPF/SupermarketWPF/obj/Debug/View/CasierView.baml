   M S B A M L   `   `   `  ����  SupermarketWPF$    SupermarketWPF.View.CasierView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Casier��5   	   $	��450��6   $	��800��6%   .��5      � .+�5   
   �� .+�5      �� $	��200��6   $��10q�6#   ��6/   �� *SearchCriteria+ �� SelectedItem 6V   �� *
SearchBy+�� 5      $	��200��6   $��10q�6"   ��6.   �� *
SearchTerm+ �� UpdateSourceTrigger$ PropertyChanged=��� 5	      $��Search��6   $	��200��6H   $��10q�6T   ��6&   �� *SearchCommand+6T   &   System.Windows.Controls.DataGrid  5
         AutoGenerateColumns .  $	��750��6_   $��10q�6k   ��6   �� *FilteredProduseList+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Id+6L     5      $ Nume Produs��6)    .  6>   �� *
NumeProdus+6]     5      $ Cod De Bare��6)    .  6>   �� *	CodDeBare+6\     5      $ 	Categoria��6)    .  6<   �� *	Categoria+6Z     5      $ 
Producator��6)    .  6=   �� *Producatori.NumeProducator+6l   4  .System.Windows.Controls.DataGridTemplateColumn  5         CellTemplate 5      �� 5      .R�5   "   �� $��
Add to Bon��6)   ��6>   �� *DataContext.AddToBonCommand+	 �� RelativeSource	 �� 
 �� AncestorType$
 WindowL���6�   �� 5      5      5      �� 5      $	��Bon��6   $
��Bold"�6#   $��10q�65     5       .  $	��750��6S   $��10q�6_   ��6   �� *	BonList+ 5        5      $ Produs��6)    .  69   �� *Produs.NumeProdus+6_     5      $ 	Cantitate��6)    .  6<   �� *	Cantitate+6Z     5      $
 Pret��6)    .  67   �� *Pret+6P     5       $ Subtotal��6)    .  6;   �� *
Subtotal+6X   5"      �� 5#      $��10q�6O   ��6   �� *
TotalSum+ �� StringFormat$ Total: {0:C}��6O   �� 5$      $��	Emite Bon��6   $	��200��6L   $��10q�6X   ��6)   �� *EmitBonCommand+6X   5%      5&      5'      