   M S B A M L   `   `   `  ����I  ETrafficMonitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:TrafficMonitor.ConvertersTrafficMonitor.Converters  5   	       TrafficMonitor.MainWindow   5   	   8d2http://schemas.microsoft.com/expression/blend/2008  5   	   localTrafficMonitor  5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   >
converters'clr-namespace:TrafficMonitor.Converters     5   	     � Title$  Traffic Monitor��5   	   $	��200��6!   $	��525��6.   $
��Bold"�6:    � WindowStyle$ ThreeDBorderWindow=�6L   ���	#FFB8B8B8.��5      � .+�5	   
   �� $
��Left=�6k   $��	10,10,0,0q�6�   $	��Top=�6�   $	��120��6�   ��6   �� *
Adapters+ �� SelectedValue 64   �� *SelectedAdapter+ �� Mode$ TwoWay=���5
      �� 5      .R�5      �� ��6    �� *AdapterName+6?   5      5      �� 5   
   $
��Left=�6�   $��	10,63,0,0q�6�   $
��Wrap=�6�   $	��Top=�6�   $	��120��6�   ���	#FFD80000 � DataContext 6   �� *SelectedAdapter+��6<   �� *BytesReceived+   ByteToGbFormatter �� 	Converter# [  6�   �� 5   
   $
��Left=�6�   $��
10,111,0,0q�6�   $
��Wrap=�6�   $	��Top=�6�   $	��120��6�   ���	#FF21EE00 6   �� *SelectedAdapter+��6<   �� *	BytesSent+# [  6�   �� 5   
   $
��Left=�6   $��	10,47,0,0q�6/   $
��Wrap=�6B   $��Bytes Received��6V   $	��Top=�6l   �� 5   
   $
��Left=�6   $��	10,90,0,0q�6/   $
��Wrap=�6B   $��
Bytes Sent��6V   $	��Top=�6h   �� 5   
   $
��Left=�6�   $��
153,47,0,0q�6�   $
��Wrap=�6�   $	��Top=�6�   $��95��6�    �� TextAlignment$ Right=�6�    6   �� *SelectedAdapter+��6<   �� *BytesReceivedDelta+  ByteToGbPerSFormatter# [ 6�   �� 5   
   $
��Left=�6�   $��
153,90,0,0q�6�   $
��Wrap=�6�   $	��Top=�6�    J� RenderTransformOrigin$ 0.625,1.438&�6�   $��95��6  $ Right=�6   6   �� *SelectedAdapter+��6<   �� *BytesSentDelta+# [ 6  � 5   
   $
��Left=�6�   $��16��6�   $��
153,63,0,0q�6�   $	��Top=�6�   $��95��6�    6   �� *SelectedAdapter+ � Maximum 6>   �� *ProgressBarMaxByte+	 � Value	 6e   �� *ProgressBarActValueReceived+6�   � 5   
   $
��Left=�6�   $��16��6�   $��153,106,0,0q�6�   $	��Top=�6�   $��95��6�    6   �� *SelectedAdapter+ 6>   �� *ProgressBarMaxByte+	 6e   �� *ProgressBarActValueSent+6�   5      5      