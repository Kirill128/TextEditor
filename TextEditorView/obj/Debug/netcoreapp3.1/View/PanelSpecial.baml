   M S B A M L   `   `   `  ����I  ETextEditorView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TextEditorView.ViewTextEditorView.View  5      &     TextEditorView.View.PanelSpecial   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:TextEditorView.View     5        � 	Resources  5	         OnOffToggleImageStyle �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%  &	        �� 5
   
   " d�6.    5      P� 5       �@d�	IsChecked$
 TrueY�6/   . �5      ��  � ��
 �   �63   5      P� 5       �@d�	IsChecked$ FalseY�6/   . �5      ��  � �� �	#ffdadada64   5      5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      .+�5"   
   �� -   5        $��cmbFontFamily��5"   0   $��0��6   $��0��6    $	��150��6I   $|�False��6�   	 � ToolTip$	 Font Family��6�   �� 5#   
   -   5        $��cmbFontSize��5#   0   $��1��6   $��0��6    $	��150��6I   $|�False��6�   $	 	Font Size��6�   �� 5$   
   -   5        $��cmbFontColor��5$   0   $��0��6   $��3��6    $	��150��6I   $|�False��6�   $	 
Font Color��6�   �� 5%   
   -   5        $��cmbFontBackColor��5%   0   $��1��6   $��3��6    $	��150��6I   $|�False��6�   $	 Font Background Color��6�   d� 5'   
   -   5        $��btnBold��5'   �   $��0��6   $��1��6%   $ ��EditingCommands.ToggleBold��65   #��[  6[   $
{�True��6�   .��5(      �� $��/View/text_bold.png��6   $��16��61   $��16��6<   5)      d� 5*   
   -   5        $��	btnItalic��5*   �   $��0��6   $��2��6$   $"��EditingCommands.ToggleItalic��64   #��[  6\   $
{�True��6�   .��5+      �� $��/View/text_italic.png��6   $��16��63   $��16��6>   5,      d� 5-   
   -   5        $��btnUnderline��5-   �   $��1��6   $��1��6$   $%��EditingCommands.ToggleUnderline��64   #��[  6^   $
{�True��6�   .��5.      �� $��/View/text_underline.png��6   $��16��66   $��16��6A   5/      �� 50   
   -   5        $��2��50      $��1��6!   $	��Img��6.   $��18(�6<   $��Stretch=�6J   $��Stretch=�6f   6�   52      53      