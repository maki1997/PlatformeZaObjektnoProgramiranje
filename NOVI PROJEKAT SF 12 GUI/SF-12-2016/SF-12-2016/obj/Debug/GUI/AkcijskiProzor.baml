   M S B A M L   `   `   `  ����E  ASF-12-2016, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SF_12_2016.GUISF_12_2016.GUI  5   	   #    SF_12_2016.GUI.AkcijskiProzor   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:SF_12_2016.GUI     5   	     � Title$  AkcijskiProzor��5   	   $	��300��6    $	��300��6-   .��5	      � $��	0,0,-8,-4q�6    � ColumnDefinitions 5
   
   �� 5      $	��146 �6   �� 5      $	��231 �6    � RowDefinitions 5   
   �� 5      $��42.748 �6   �� 5      $��0.252 �6   �� 5      $	��43* �6   �� 5      $	��42* �6   �� 5      $
��141* �6   .+�5   
   �� $��Popust:��6   $��2��6"   $��20(�6/   $��0,43,2,1q�6=   $��2��6O   �� 5   
   $��Pocetak:��6   $��13(�6#   $��1,0,1,43q�61    J� RenderTransformOrigin$ 0.5,0.5&�6C   $��3��6c   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 0.785Q�6&   T� 5      5      5       �� 5!   
   $��Istice:��6   $��2��6"   $��13(�6/   $��0,0,2,1q�6=   �� 5"   
   -   5        $��tbPopust��5"      $��3��6"   $��1��6/   $��15(�6?   $��
10,10,91,5q�6M   ��6a   ��  �� Path$ Popust��� 5#   
   -   5        $��Dodaj��5#   !   $��Dodaj��6   $��0��6B   $��4��6R   $��20,46,51,75q�6_   �� 5$   
   -   5        $��Izlaz��5$   !   $��Izlaz��6   $��4��6.   $��20,96,51,25q�6O   (  "System.Windows.Controls.DatePicker  5%   
   -   5        $	��dpP��5%      $��1��6    $
��Left=�60   $��22,9,0,0q�6K   $	��Top=�6]   $��24��6u   $	��102��6�      Text 6�   �� $ DatumPocetka�  5&   
   -   5        $	��dpK��5&      $��1��6    $
��Left=�60   $��	22,10,0,0q�6K   $��2��6^   $	��Top=�6k   $��24��6�   $	��102��6�    6�   �� $ 
DatumKraja�5'      5(      