<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Anasayfa
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Resim_Picturebox = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Sil_Buton = New System.Windows.Forms.Button()
        Me.Sonraki_Foto_Buton = New System.Windows.Forms.Button()
        Me.Onceki_Foto_Buton = New System.Windows.Forms.Button()
        Me.Kayit_Klasoru_Sec_Buton = New System.Windows.Forms.Button()
        Me.Resim_Klasoru_Sec_Buton = New System.Windows.Forms.Button()
        Me.Etiket_CheckList = New System.Windows.Forms.CheckedListBox()
        Me.Secim_1_Checkbox = New System.Windows.Forms.CheckBox()
        Me.Label_1_TextBox = New System.Windows.Forms.TextBox()
        Me.Label_2_TextBox = New System.Windows.Forms.TextBox()
        Me.Secim_2_Checkbox = New System.Windows.Forms.CheckBox()
        Me.Label_3_TextBox = New System.Windows.Forms.TextBox()
        Me.Secim_3_Checkbox = New System.Windows.Forms.CheckBox()
        Me.Label_4_TextBox = New System.Windows.Forms.TextBox()
        Me.Secim_4_Checkbox = New System.Windows.Forms.CheckBox()
        Me.Secilen_Dosyalar_Listbox = New System.Windows.Forms.ListBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Ayarlari_Kaydet = New System.Windows.Forms.Button()
        Me.Dosya_Sayisi_Label = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.Resim_Picturebox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Resim_Picturebox
        '
        Me.Resim_Picturebox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Resim_Picturebox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Resim_Picturebox.Location = New System.Drawing.Point(149, 8)
        Me.Resim_Picturebox.Name = "Resim_Picturebox"
        Me.Resim_Picturebox.Size = New System.Drawing.Size(854, 681)
        Me.Resim_Picturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Resim_Picturebox.TabIndex = 0
        Me.Resim_Picturebox.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Sil_Buton)
        Me.Panel1.Controls.Add(Me.Sonraki_Foto_Buton)
        Me.Panel1.Controls.Add(Me.Onceki_Foto_Buton)
        Me.Panel1.Controls.Add(Me.Kayit_Klasoru_Sec_Buton)
        Me.Panel1.Controls.Add(Me.Resim_Klasoru_Sec_Buton)
        Me.Panel1.Location = New System.Drawing.Point(8, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(135, 681)
        Me.Panel1.TabIndex = 1
        '
        'Sil_Buton
        '
        Me.Sil_Buton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Sil_Buton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Sil_Buton.ForeColor = System.Drawing.Color.Red
        Me.Sil_Buton.Location = New System.Drawing.Point(11, 615)
        Me.Sil_Buton.Name = "Sil_Buton"
        Me.Sil_Buton.Size = New System.Drawing.Size(109, 61)
        Me.Sil_Buton.TabIndex = 6
        Me.Sil_Buton.Text = "Bu Fotoğrafı Sil"
        Me.Sil_Buton.UseVisualStyleBackColor = True
        '
        'Sonraki_Foto_Buton
        '
        Me.Sonraki_Foto_Buton.Location = New System.Drawing.Point(11, 142)
        Me.Sonraki_Foto_Buton.Name = "Sonraki_Foto_Buton"
        Me.Sonraki_Foto_Buton.Size = New System.Drawing.Size(109, 61)
        Me.Sonraki_Foto_Buton.TabIndex = 5
        Me.Sonraki_Foto_Buton.Text = "Sonraki Fotoğrraf"
        Me.Sonraki_Foto_Buton.UseVisualStyleBackColor = True
        '
        'Onceki_Foto_Buton
        '
        Me.Onceki_Foto_Buton.Location = New System.Drawing.Point(11, 209)
        Me.Onceki_Foto_Buton.Name = "Onceki_Foto_Buton"
        Me.Onceki_Foto_Buton.Size = New System.Drawing.Size(109, 61)
        Me.Onceki_Foto_Buton.TabIndex = 4
        Me.Onceki_Foto_Buton.Text = "Önceki Fotoğraf"
        Me.Onceki_Foto_Buton.UseVisualStyleBackColor = True
        '
        'Kayit_Klasoru_Sec_Buton
        '
        Me.Kayit_Klasoru_Sec_Buton.Location = New System.Drawing.Point(11, 75)
        Me.Kayit_Klasoru_Sec_Buton.Name = "Kayit_Klasoru_Sec_Buton"
        Me.Kayit_Klasoru_Sec_Buton.Size = New System.Drawing.Size(109, 61)
        Me.Kayit_Klasoru_Sec_Buton.TabIndex = 3
        Me.Kayit_Klasoru_Sec_Buton.Text = "Kayıt Klasörü Seç"
        Me.Kayit_Klasoru_Sec_Buton.UseVisualStyleBackColor = True
        '
        'Resim_Klasoru_Sec_Buton
        '
        Me.Resim_Klasoru_Sec_Buton.Location = New System.Drawing.Point(11, 8)
        Me.Resim_Klasoru_Sec_Buton.Name = "Resim_Klasoru_Sec_Buton"
        Me.Resim_Klasoru_Sec_Buton.Size = New System.Drawing.Size(109, 61)
        Me.Resim_Klasoru_Sec_Buton.TabIndex = 2
        Me.Resim_Klasoru_Sec_Buton.Text = "Resim Klasörü Seç"
        Me.Resim_Klasoru_Sec_Buton.UseVisualStyleBackColor = True
        '
        'Etiket_CheckList
        '
        Me.Etiket_CheckList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Etiket_CheckList.FormattingEnabled = True
        Me.Etiket_CheckList.Location = New System.Drawing.Point(6, 147)
        Me.Etiket_CheckList.Name = "Etiket_CheckList"
        Me.Etiket_CheckList.Size = New System.Drawing.Size(277, 154)
        Me.Etiket_CheckList.TabIndex = 1
        '
        'Secim_1_Checkbox
        '
        Me.Secim_1_Checkbox.AutoSize = True
        Me.Secim_1_Checkbox.Location = New System.Drawing.Point(6, 7)
        Me.Secim_1_Checkbox.Name = "Secim_1_Checkbox"
        Me.Secim_1_Checkbox.Size = New System.Drawing.Size(128, 17)
        Me.Secim_1_Checkbox.TabIndex = 2
        Me.Secim_1_Checkbox.Text = "1. Seçimde Bunu Yaz"
        Me.Secim_1_Checkbox.UseVisualStyleBackColor = True
        '
        'Label_1_TextBox
        '
        Me.Label_1_TextBox.Location = New System.Drawing.Point(140, 6)
        Me.Label_1_TextBox.Name = "Label_1_TextBox"
        Me.Label_1_TextBox.Size = New System.Drawing.Size(141, 20)
        Me.Label_1_TextBox.TabIndex = 3
        '
        'Label_2_TextBox
        '
        Me.Label_2_TextBox.Location = New System.Drawing.Point(140, 32)
        Me.Label_2_TextBox.Name = "Label_2_TextBox"
        Me.Label_2_TextBox.Size = New System.Drawing.Size(141, 20)
        Me.Label_2_TextBox.TabIndex = 5
        '
        'Secim_2_Checkbox
        '
        Me.Secim_2_Checkbox.AutoSize = True
        Me.Secim_2_Checkbox.Location = New System.Drawing.Point(6, 33)
        Me.Secim_2_Checkbox.Name = "Secim_2_Checkbox"
        Me.Secim_2_Checkbox.Size = New System.Drawing.Size(128, 17)
        Me.Secim_2_Checkbox.TabIndex = 4
        Me.Secim_2_Checkbox.Text = "2. Seçimde Bunu Yaz"
        Me.Secim_2_Checkbox.UseVisualStyleBackColor = True
        '
        'Label_3_TextBox
        '
        Me.Label_3_TextBox.Location = New System.Drawing.Point(140, 58)
        Me.Label_3_TextBox.Name = "Label_3_TextBox"
        Me.Label_3_TextBox.Size = New System.Drawing.Size(141, 20)
        Me.Label_3_TextBox.TabIndex = 7
        '
        'Secim_3_Checkbox
        '
        Me.Secim_3_Checkbox.AutoSize = True
        Me.Secim_3_Checkbox.Location = New System.Drawing.Point(6, 59)
        Me.Secim_3_Checkbox.Name = "Secim_3_Checkbox"
        Me.Secim_3_Checkbox.Size = New System.Drawing.Size(128, 17)
        Me.Secim_3_Checkbox.TabIndex = 6
        Me.Secim_3_Checkbox.Text = "3. Seçimde Bunu Yaz"
        Me.Secim_3_Checkbox.UseVisualStyleBackColor = True
        '
        'Label_4_TextBox
        '
        Me.Label_4_TextBox.Location = New System.Drawing.Point(140, 84)
        Me.Label_4_TextBox.Name = "Label_4_TextBox"
        Me.Label_4_TextBox.Size = New System.Drawing.Size(141, 20)
        Me.Label_4_TextBox.TabIndex = 9
        '
        'Secim_4_Checkbox
        '
        Me.Secim_4_Checkbox.AutoSize = True
        Me.Secim_4_Checkbox.Location = New System.Drawing.Point(6, 85)
        Me.Secim_4_Checkbox.Name = "Secim_4_Checkbox"
        Me.Secim_4_Checkbox.Size = New System.Drawing.Size(128, 17)
        Me.Secim_4_Checkbox.TabIndex = 8
        Me.Secim_4_Checkbox.Text = "4. Seçimde Bunu Yaz"
        Me.Secim_4_Checkbox.UseVisualStyleBackColor = True
        '
        'Secilen_Dosyalar_Listbox
        '
        Me.Secilen_Dosyalar_Listbox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Secilen_Dosyalar_Listbox.FormattingEnabled = True
        Me.Secilen_Dosyalar_Listbox.HorizontalScrollbar = True
        Me.Secilen_Dosyalar_Listbox.Location = New System.Drawing.Point(6, 333)
        Me.Secilen_Dosyalar_Listbox.Name = "Secilen_Dosyalar_Listbox"
        Me.Secilen_Dosyalar_Listbox.Size = New System.Drawing.Size(277, 342)
        Me.Secilen_Dosyalar_Listbox.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.Ayarlari_Kaydet)
        Me.Panel2.Controls.Add(Me.Dosya_Sayisi_Label)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Etiket_CheckList)
        Me.Panel2.Controls.Add(Me.Label_4_TextBox)
        Me.Panel2.Controls.Add(Me.Label_1_TextBox)
        Me.Panel2.Controls.Add(Me.Secim_4_Checkbox)
        Me.Panel2.Controls.Add(Me.Secim_2_Checkbox)
        Me.Panel2.Controls.Add(Me.Secim_1_Checkbox)
        Me.Panel2.Controls.Add(Me.Label_3_TextBox)
        Me.Panel2.Controls.Add(Me.Label_2_TextBox)
        Me.Panel2.Controls.Add(Me.Secilen_Dosyalar_Listbox)
        Me.Panel2.Controls.Add(Me.Secim_3_Checkbox)
        Me.Panel2.Location = New System.Drawing.Point(1009, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(292, 677)
        Me.Panel2.TabIndex = 10
        '
        'Ayarlari_Kaydet
        '
        Me.Ayarlari_Kaydet.Location = New System.Drawing.Point(6, 108)
        Me.Ayarlari_Kaydet.Name = "Ayarlari_Kaydet"
        Me.Ayarlari_Kaydet.Size = New System.Drawing.Size(277, 35)
        Me.Ayarlari_Kaydet.TabIndex = 6
        Me.Ayarlari_Kaydet.Text = "Kaydet"
        Me.Ayarlari_Kaydet.UseVisualStyleBackColor = True
        '
        'Dosya_Sayisi_Label
        '
        Me.Dosya_Sayisi_Label.AutoSize = True
        Me.Dosya_Sayisi_Label.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Dosya_Sayisi_Label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.Dosya_Sayisi_Label.Location = New System.Drawing.Point(128, 302)
        Me.Dosya_Sayisi_Label.Name = "Dosya_Sayisi_Label"
        Me.Dosya_Sayisi_Label.Size = New System.Drawing.Size(42, 25)
        Me.Dosya_Sayisi_Label.TabIndex = 11
        Me.Dosya_Sayisi_Label.Text = "0\0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(7, 302)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 24)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Dosya Sayısı :"
        '
        'Anasayfa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1313, 701)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Resim_Picturebox)
        Me.Name = "Anasayfa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fotoğraf Etiketleme Yazılımı"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Resim_Picturebox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Resim_Picturebox As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Sonraki_Foto_Buton As Button
    Friend WithEvents Onceki_Foto_Buton As Button
    Friend WithEvents Kayit_Klasoru_Sec_Buton As Button
    Friend WithEvents Resim_Klasoru_Sec_Buton As Button
    Friend WithEvents Secim_1_Checkbox As CheckBox
    Friend WithEvents Etiket_CheckList As CheckedListBox
    Friend WithEvents Label_4_TextBox As TextBox
    Friend WithEvents Secim_4_Checkbox As CheckBox
    Friend WithEvents Label_3_TextBox As TextBox
    Friend WithEvents Secim_3_Checkbox As CheckBox
    Friend WithEvents Label_2_TextBox As TextBox
    Friend WithEvents Secim_2_Checkbox As CheckBox
    Friend WithEvents Label_1_TextBox As TextBox
    Friend WithEvents Secilen_Dosyalar_Listbox As ListBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Dosya_Sayisi_Label As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Ayarlari_Kaydet As Button
    Friend WithEvents Sil_Buton As Button
End Class
