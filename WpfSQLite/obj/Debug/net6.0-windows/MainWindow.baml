   M S B A M L   `   `   `  ����D  @WpfSQLite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WpfSQLite	WpfSQLite  5   	       WpfSQLite.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:WpfSQLite     5   	     � Title$  
MainWindow��5   	   $	��400��6   $	��800��6)   .��5	      � ���#1a1a1a.+�5
   
   �� $��600px��6   .+�5      �� ���#fac864$��0 1 0 1q�6+    �� CornerRadius$ 20��6E   $
��0 20q�6W   ._�5      ��  �� Orientation$ 
Horizontal=�6   $��	0 20 0 20q�66   .+�5      �� -   5        $	��296��5   0   
�������$
��bold"�6O   $��2px 0q�6a   .��5      �� $ 
Horizontal=�6%   .+�5      �� $��SELECT��6(   $
��bold"�66   �� 5      $��src/select.png��6$   $��16��6<   $��5 0 0 0q�6G   5      5      �� 5      -   5        $	��296��5   /   
�������$
��bold"�6N   $��2px 0q�6`   .��5      �� $ 
Horizontal=�6%   .+�5      �� $��CLEAR��6(   $
��bold"�65   �� 5      $��src/clear.png��6$   $��16��6;   $��5 0 0 0q�6F   5      5      5      5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ mainDataGrid��5         AutoGenerateColumns$ False��6-   $   HorizontalScrollBarVisibility$
 Auto=�6I   "   VerticalScrollBarVisibility$
 Auto=�6n   $��200px��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6)   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 65   �� *Id+  5      $
 Name��6)   	 67   �� *Name+  5      $ Album��6)   	 68   �� *ATitle+  5       $ 	MediaType��6)   	 6<   �� *MName+  5!      $ Genre��6)   	 68   �� *GName+5#      5$      5%      5&      