   M S B A M L   `   `   `  ����J  FMediaTinLanh.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MediaTinLanh.UI.ControlsMediaTinLanh.UI.Controls  5   	   E'clr-namespace:MediaTinLanh.UI.ResourcesMediaTinLanh.UI.Resources  5   	   *    $MediaTinLanh.UI.Controls.IntroWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:MediaTinLanh.UI.Controls     5   	   =	recources'clr-namespace:MediaTinLanh.UI.Resources     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ IntroWindow��5
   	    � WindowStyle$
 None=�6   $	��450��60   $	��800��6=   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      GlassFrameThickness$ 0,0,0,1q�6      CornerRadius$ 0��65    � 	Resources 5      3   -MediaTinLanh.UI.Resources.PercentageConverter   PercentageConverter��%   &	          5   
   6(   5      ��5      L� 5   
    L� Drawing 5      I� 5      .��5      ��  �� Rect$ 	0,0,10,10�6#   	 �� ImageSource$E	 ?/MediaTinLanh.UI;component/Resources/images/main/background.png��64   I� 5      
 I� Opacity$	
 0.1Q�6#   .��5      �� $ 	0,0,10,10�6'   $J	 D/MediaTinLanh.UI;component/Resources/images/main/logo_background.png��68   5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��3* �6   �� 5       $��* �6   �� 5!      $��3* �6    � ColumnDefinitions 5#   
   �� 5$      $��* �6   �� 5%      $��2* �6   �� 5&      $��* �6   .+�5(   
   �� -   5         ��Name$ 
borderLogo��5(      $��1��6%   $��0��65   ._�5)      �� -   5         ��Name$
 logo��5)      $��5q�5.   "   $?��9/MediaTinLanh.UI;component/Resources/images/main/logo.png��5/   "   $��Center=�50   "   $��Bottom=�6?   ��5)   "   ��  �� 	Converter# [   �� ElementName$ 
borderLogo�� �� Path$ ActualWidth� �� ConverterParameter$	 0.7��50   ?   51      �� 52   
   -   5        $ borderCenterTitle��52      $��1��6,   $��1��6<   $��2q�6I   
�������._�53      �� -   5         ��Name$ TRÌNH_CHIẾU_CƠ_ĐỐC��53      
�������$��Center=�6G   $��Stretch=�6b     RobotoMedium#��[ 59       �� IsHyphenationEnabled .  �� LineStackingStrategy$ BlockLineHeight=�5:   8    �� TextAlignment$ Center=�5;      $
��Wrap=�63   $��TRÌNH CHIẾU CƠ ĐỐC��6G   $
��Bold"�6a   ��54      �� # [  $ borderCenterTitle��$ ActualWidth�$
 0.08��5;   a   5<      �� 5=   
   -   5        $ borderBottomTitle��5=      $��1��6,   $��2��6<   $	��Top=�6I   ._�5>      �� -   5        $ www_mediatinlanh_com��5>      
�������#��[ 5D      $��Center=�5E      $��Center=�65    . $ BlockLineHeight=�5F   4   $��www.mediatinlanh.com��6[   ��5?      �� # [  $ borderCenterTitle��$ ActualWidth�$
 0.06��5F   [   5G      5H      5I      