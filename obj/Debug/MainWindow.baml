   M S B A M L   `   `   `  ����E  ABiblioteca, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Biblioteca
Biblioteca  5   	       Biblioteca.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Biblioteca     5   	   -   5          � Title$  
MainWindow��5   	   $
��1080��6   $
��1920��6*   .��5	      � .+�5
   
   �� -   5         ��Name$ 	BtnLivros��5
      $��Livros��6$   $
��Left=�65   $��	10,10,0,0q�6P   $	��Top=�6c   $��45��6{   $	��302��6�   $��24(�6�   $
��Bold"�6�   6�   �� 5   
   -   5        $ BtnUsuarios��5      $��	Usuários��6&   $
��Left=�69   $��
312,10,0,0q�6T   $	��Top=�6h   $��45��6�   $	��301��6�   $��24(�6�   $
��Bold"�6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DgLivrosUsuario��5         AutoGenerateColumns .  $��10,109,10,165q�6H      
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5      $
 Nome��6%    63   �� *Nome+  5      $ Autor��6%    64   �� *Autor+  5      $ Sinopse��6%    66   �� *	Sinopse+  5      $ Data de lançamento��6%    6A   �� *DataLancamento+5      �� 5   
   -   5         ��Name$ LblSeusLivros��5      $��Seus livros:��6'   $
��Left=�6>   $��	10,55,0,0q�6Y   $	��Top=�6l   $	��780��6�   $
��Bold"�6�   $��49��6�   $��20(�6�   �� 5   
   -   5        $ BtnDevolver��5      $��Devolver  Livro��6&   $
��Left=�6@   $��1584,904,0,0q�6[   $	��Top=�6q   $��69��6�   $	��326��6�   $��36(�6�   {�.  6�   �� 5   
   -   5        $ BtnAtualizar��5      $��	Atualizar��6'   $
��Left=�6;   $��1258,904,0,0q�6V   $	��Top=�6l   $��69��6�   $	��326��6�   $��36(�6�   6�   5      5      