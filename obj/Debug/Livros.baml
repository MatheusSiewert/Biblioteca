   M S B A M L   `   `   `  ����E  ABiblioteca, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Biblioteca
Biblioteca  5   	       Biblioteca.Livros   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Biblioteca     5   	     � Title$  Livros��5   	   $	��600��6   $	��800��6%   .��5	      � .+�5
   
   �� -   5         ��Name$ 	LblTitulo��5
      $��Título��6#   $��Center=�64   $��0,10,0,0q�6Q   $	��Top=�6c   $	��780��6{   $
��Bold"�6�   $��26��6�   $��8(�6�   �� 5   
   -   5         ��Name$ 	TxtTitulo��5      $��Center=�6%   $��0,36,0,0q�6B    �� TextWrapping$
 Wrap=�6T   $	��Top=�6h   $	��780��6�   $��26��6�   $��8(�6�   �� 5   
   -   5        $ LblAutor��5      $��Autor��6"   $��Center=�62   $��0,67,0,0q�6O   $	��Top=�6a   $	��780��6y   $
��Bold"�6�   $��26��6�   $��8(�6�   �� 5   
   -   5        $ TxtAutor��5      $��Center=�6$   $��0,93,0,0q�6A   $
 Wrap=�6S   $	��Top=�6g   $	��780��6   $��27��6�   $��8(�6�   �� 5   
   -   5        $ LblDataLancamento��5      $��Data de Lançamento��6+   $��Center=�6H   $��	0,125,0,0q�6e   $	��Top=�6x   $	��780��6�   $
��Bold"�6�   $��26��6�   $��8(�6�   �� 5   
   -   5        $ 
LblSinopse��5      $��Sinopse��6$   $��Center=�66   $��	0,182,0,0q�6S   $	��Top=�6f   $	��780��6~   $
��Bold"�6�   $��26��6�   $��8(�6�   �� 5   
   -   5        $ 
TxtSinopse��5      $��Center=�6&   $��	0,208,0,0q�6C   $
 Wrap=�6V   $	��Top=�6j   $	��780��6�   $��70��6�   $��8(�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DgLivros��5         AutoGenerateColumns .  $��10,327,10,10q�6A      
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *Id+  5      $
 Nome��6%   	 63   �� *Nome+  5      $ Autor��6%   	 64   �� *Autor+  5      $ Sinopse��6%   	 66   �� *	Sinopse+  5      $ Data de lançamento��6%   	 6A   �� *DataLancamento+5      (  "System.Windows.Controls.DatePicker  5   
   -	   5        
  Name$
 DtpData��5      $��Center=�6&   $��	0,151,0,0q�6C   $	��Top=�6V   $	��780��6n   $
��Bold"�6z   $��26��6�   $��8(�6�   �� 5   
   -
   5         ��Name$ 
BtnInserir��5      $��Inserir��6%   $
��Left=�67   $��
10,292,0,0q�6R   $	��Top=�6f   $��30��6~   $	��111��6�   $��8(�6�   $
��Bold"�6�   6�   �� 5   
   -   5        $ 
BtnExcluir��5      $��Excluir��6%   $
��Left=�67   $��121,292,0,0q�6R   $	��Top=�6g   $��30��6   $	��112��6�   $��8(�6�   $
��Bold"�6�   {�.  6�   �� 5   
   -   5        $ BtnLocalizar��5      $��	Localizar��6'   $
��Left=�6;   $��233,292,0,0q�6V   $	��Top=�6k   $��30��6�   $	��112��6�   $��8(�6�   $
��Bold"�6�   6�   �� 5   
   -   5        $ 
BtnAlterar��5      $��Alterar��6%   $��Center=�67   $��	0,292,0,0q�6T   $	��Top=�6g   $��30��6   $	��110��6�   $��8(�6�   $
��Bold"�6�   {�.  6�   �� 5   
   -   5        $ 	BtnSalvar��5      $��Salvar��6$   $
��Left=�65   $��455,292,0,0q�6P   $	��Top=�6e   $��30��6}   $	��111��6�   $��8(�6�   $
��Bold"�6�   {�.  6�   �� 5    
   -   5        $ BtnCancelar��5       $��Cancelar��6&   $
��Left=�69   $��566,292,0,0q�6T   $	��Top=�6i   $��30��6�   $	��112��6�   $��8(�6�   $
��Bold"�6�   {�.  6�   �� 5!   
   -   5        $ BtnReservar��5!      $��Reservar��6&   $
��Left=�69   $��678,292,0,0q�6T   $	��Top=�6i   $��30��6�   $	��112��6�   $��8(�6�   $
��Bold"�6�   {�.  6�   5"      5#      