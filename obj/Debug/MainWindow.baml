   M S B A M L   `   `   `  ����H  DBakaScheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:BakaSchedulerBakaScheduler  5   	       BakaScheduler.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:BakaScheduler     5   	     � Title$  
MainWindow��5   	   $	��222��6   $��214.659��6)    � AllowsTransparency .  � WindowStyle$
 None=�6S    � WindowStartupLocation$ Manual=�6f    � Left$
 1000��6�   
 � Top$ 50��6�   ��5	      �� 5   
    � ContextMenu 5      �� 5   
   -   5        $��cm��5       �� 	StaysOpen . .@�5      m� $��查看时间表��6   m� 5      $��修改时间表��6   m� 5      -   5        $��制作图片状态机��5      6(   m� 5      -   5        $��设置��5      6$   5      .��5      � -   5        $��94��5   E   $��Bottom=�6Q   $
��Left=�6l   $	��146��6�   ��5   
   �� 5       �� ImageSource$ background.png��6   	 J� Effect	 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5      
 � ColumnDefinitions
 5!   
   �� 5"      $
��313* �6   .+�5$   
   � -   5        $��dialog_grid��5$       J� Opacity$ 0Q�6"   .+�5%      �� -   5         ��Name$ 
dialog_png��5%      $��10,-96,-108,83q�6(   $��
dialog.png��6@   $
��Fill=�6T   $
��Left=�6c   $	��244��6~   �� 5&      -   5        $
��talk��5&      $��85,-77,-47,91q�66   ���	#FF4B4B4B$��15(�6d   $��Magneto)�6r    J� RenderTransformOrigin$ 0.5,0.5&�6�   ��6    Z� z�5'      V� 5(      .~�5)      �� �� 5*       �� AngleY$ -2.907Q�6(   �� 5+       �� Angle$ -8.787Q�6*   T� 5,       T� Y$ -5.561Q�6-   5-      .��5.   )   Hello world50      51      54      56      