Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices

Public Class Anasayfa
    ReadOnly ResimFiltre As String = "*.jpg"
    ReadOnly ResimFiltre2 As String = "*.jpeg"
    Dim MouseAnlikRenct As Rectangle
    Private RenctList As New List(Of Rectangle)
    Dim CursorState As Byte
    Dim SonCursorDurumu As Byte
    Dim KaydirmaAktif As Boolean
    Dim FocuslananRectangleListindex As Integer = 0
    Dim FocuslananRectangle As Rectangle

    Dim ReferansXKoordinat, ReferansYKoordinat As Integer
    Dim SolUstxEksi, SolUstxArti, SolUstyEksi, SolUstyArti As Integer
    Dim SolAltxEksi, SolAltxArti, SolAltyEksi, SolAltyArti As Integer

    Dim SagUstxEksi, SagUstxArti, SagUstyEksi, SagUstyArti As Integer
    Dim SagAltxEksi, SagAltxArti, SagAltyEksi, SagAltyArti As Integer
    Dim MouseilkTiklanildigiNokta As Point

    Dim CizimAktif As Boolean


    Private Sub Anasayfa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Ana_Renkleri_Ekle()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)

        Try
            Me.DoubleBuffered = True

            If Ayarlari_Okundu() Then
                Secilen_Dosyalar_Listbox.Items.AddRange(Directory.GetFiles(Sistem_Ayarlari.KayitKlasoru, ResimFiltre))
                Secilen_Dosyalar_Listbox.Items.AddRange(Directory.GetFiles(Sistem_Ayarlari.KayitKlasoru, ResimFiltre2))
            End If

            Dosya_Sayisi_Label.Text = Secilen_Dosyalar_Listbox.Items.Count & "\0"
            Secim_1_Checkbox.Checked = Sistem_Ayarlari.Secim1Checkbox
            Secim_2_Checkbox.Checked = Sistem_Ayarlari.Secim2Checkbox
            Secim_3_Checkbox.Checked = Sistem_Ayarlari.Secim3Checkbox
            Secim_4_Checkbox.Checked = Sistem_Ayarlari.Secim4Checkbox

            Label_1_TextBox.Text = Sistem_Ayarlari.Label1Text
            Label_2_TextBox.Text = Sistem_Ayarlari.Label2Text
            Label_3_TextBox.Text = Sistem_Ayarlari.Label3Text
            Label_4_TextBox.Text = Sistem_Ayarlari.Label4Text

        Catch ex As Exception
            Hata_Gonder_TryCatch(ex)
        End Try



    End Sub






    Private Sub Resim_Klasoru_Sec_Buton_Click(sender As Object, e As EventArgs) Handles Resim_Klasoru_Sec_Buton.Click
        Dim Op As New FolderBrowserDialog
        If Op.ShowDialog = DialogResult.OK Then
            Sistem_Ayarlari.KayitKlasoru = Op.SelectedPath
            Ayarlari_Yaz()
            Secilen_Dosyalar_Listbox.Items.Clear()
            Secilen_Dosyalar_Listbox.Items.AddRange(Directory.GetFiles(Sistem_Ayarlari.KayitKlasoru, ResimFiltre))
            Secilen_Dosyalar_Listbox.Items.AddRange(Directory.GetFiles(Sistem_Ayarlari.KayitKlasoru, ResimFiltre2))

        End If

    End Sub



    Private Sub Kayit_Klasoru_Sec_Buton_Click(sender As Object, e As EventArgs) Handles Kayit_Klasoru_Sec_Buton.Click

        Dim Op As New FolderBrowserDialog
        If Op.ShowDialog = DialogResult.OK Then
            Sistem_Ayarlari.KlasorYolu = Op.SelectedPath
            Ayarlari_Yaz()
        End If
    End Sub

    Private Sub Ayarlari_Kaydet_Click(sender As Object, e As EventArgs) Handles Ayarlari_Kaydet.Click

        Sistem_Ayarlari.Secim1Checkbox = Secim_1_Checkbox.Checked
        Sistem_Ayarlari.Secim2Checkbox = Secim_2_Checkbox.Checked
        Sistem_Ayarlari.Secim3Checkbox = Secim_3_Checkbox.Checked
        Sistem_Ayarlari.Secim4Checkbox = Secim_4_Checkbox.Checked

        Sistem_Ayarlari.Label1Text = Label_1_TextBox.Text
        Sistem_Ayarlari.Label2Text = Label_2_TextBox.Text
        Sistem_Ayarlari.Label3Text = Label_3_TextBox.Text
        Sistem_Ayarlari.Label4Text = Label_4_TextBox.Text

        Ayarlari_Yaz()



    End Sub


    Dim SonTiklananID As Integer = -2
    Sub Foto_Sec(ByVal FotoID As Integer)
        If FotoID < 0 Then
            FotoID = 0
        End If

        If SonTiklananID <> FotoID Then
            SonTiklananID = FotoID
            Secilen_Dosyalar_Listbox.SelectedIndex = FotoID
            Dim SecilenDosya As String = Secilen_Dosyalar_Listbox.Items(FotoID)
            Resim_Picturebox.ImageLocation = SecilenDosya
            RenctList.Clear()
            Etiket_CheckList.Items.Clear()
        End If
    End Sub


    Private Sub Secilen_Dosyalar_Listbox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Secilen_Dosyalar_Listbox.SelectedIndexChanged
        Foto_Sec(Secilen_Dosyalar_Listbox.SelectedIndex)
    End Sub

    Private Sub Sonraki_Foto_Buton_Click(sender As Object, e As EventArgs) Handles Sonraki_Foto_Buton.Click
        Foto_Sec(Secilen_Dosyalar_Listbox.SelectedIndex + 1)

    End Sub

    Private Sub Onceki_Foto_Buton_Click(sender As Object, e As EventArgs) Handles Onceki_Foto_Buton.Click
        Foto_Sec(Secilen_Dosyalar_Listbox.SelectedIndex - 1)
    End Sub

    Private Sub Sil_Buton_Click(sender As Object, e As EventArgs) Handles Sil_Buton.Click
        Dim Secilen As Integer = Secilen_Dosyalar_Listbox.SelectedIndex
        If Secilen > -1 Then
            If MessageBox.Show(Me, "Seçilen Fotoğraf Silinsin Mi ?", "Uyarı !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                If Etiket_CheckList.Items.Count > 0 Then
                    MsgBox("Etiket xml Sil")
                End If
                File.Delete(Secilen_Dosyalar_Listbox.Items(Secilen_Dosyalar_Listbox.SelectedIndex))
                Secilen_Dosyalar_Listbox.Items.RemoveAt(Secilen)
                SonTiklananID = -2
                Foto_Sec(Secilen)
            End If
        End If


    End Sub


    Private Sub Resim_Picturebox_Paint(sender As Object, e As PaintEventArgs) Handles Resim_Picturebox.Paint

        Try
            If Cursor = Cursors.Default Then
                If CizimAktif Then
                    Using pen As New Pen(Color.Red, 2)
                        e.Graphics.DrawRectangle(pen, MouseAnlikRenct)
                    End Using
                    Resim_Picturebox.Invalidate()
                End If

            End If



            If RenctList.Count > 0 Then
                Dim CopyLocation(RenctList.Count - 1) As Rectangle
                TryCast(RenctList, ICollection).CopyTo(CopyLocation, 0)

                Dim i As Integer = 0
                For Each Renc As Rectangle In CopyLocation

                    Using pen As New Pen(ColorList(i), 2)
                        e.Graphics.DrawRectangle(pen, Renc)
                    End Using
                    e.Graphics.FillRectangles(Brushes.White, Koordinat_Hesapla(Renc))
                    e.Graphics.DrawRectangles(Pens.Black, Koordinat_Hesapla(Renc))
                    i += 1
                Next
                Resim_Picturebox.Invalidate()
                System.Threading.Thread.Sleep(5)
            End If



        Catch ex As Exception
            Hata_Gonder_TryCatch(ex)
        End Try



    End Sub

    Function Koordinat_Hesapla(ByVal Rect As Rectangle) As RectangleF()
        Dim KoordinatList(4) As RectangleF
        KoordinatList(0) = New RectangleF(Rect.X - 4, Rect.Y - 4, 8, 8)
        KoordinatList(1) = New RectangleF(Rect.X + Rect.Width - 4, Rect.Y - 4, 8, 8)
        KoordinatList(2) = New RectangleF(Rect.X + Rect.Width - 4, Rect.Y + Rect.Height - 4, 8, 8)
        KoordinatList(3) = New RectangleF(Rect.X - 4, Rect.Y + Rect.Height - 4, 8, 8)
        Return KoordinatList
    End Function




    Private Sub Resim_Picturebox_MouseMove(sender As Object, e As MouseEventArgs) Handles Resim_Picturebox.MouseMove


        If e.Button = MouseButtons.Left And Cursor = DefaultCursor Then
            MouseAnlikRenct = New Rectangle(MouseAnlikRenct.Left, MouseAnlikRenct.Top, e.X - MouseAnlikRenct.Left, e.Y - MouseAnlikRenct.Top)
            Resim_Picturebox.Invalidate()
        End If

        If e.Button = MouseButtons.Left Then
            If SonCursorDurumu = Cizim_Enum_Mode.SolUst Then
                FocuslananRectangle.Height -= e.Y - MouseilkTiklanildigiNokta.Y
                If Not FocuslananRectangle.Height < 5 Then
                    FocuslananRectangle.Y -= -e.Y + MouseilkTiklanildigiNokta.Y
                Else
                    FocuslananRectangle.Height = 5
                End If
                FocuslananRectangle.Width -= e.X - MouseilkTiklanildigiNokta.X
                If Not FocuslananRectangle.Width < 5 Then
                    FocuslananRectangle.X -= -e.X + MouseilkTiklanildigiNokta.X
                Else
                    FocuslananRectangle.Width = 5
                End If
                RenctList(FocuslananRectangleListindex) = FocuslananRectangle
                MouseilkTiklanildigiNokta = New Point(e.X, e.Y)

            ElseIf SonCursorDurumu = Cizim_Enum_Mode.SolAlt Then
                FocuslananRectangle.Height += e.Y - MouseilkTiklanildigiNokta.Y
                FocuslananRectangle.Height = Math.Max(5, FocuslananRectangle.Height)

                FocuslananRectangle.Width -= e.X - MouseilkTiklanildigiNokta.X
                If Not FocuslananRectangle.Width < 5 Then
                    FocuslananRectangle.X -= -e.X + MouseilkTiklanildigiNokta.X
                Else
                    FocuslananRectangle.Width = 5
                End If
                RenctList(FocuslananRectangleListindex) = FocuslananRectangle
                MouseilkTiklanildigiNokta = New Point(e.X, e.Y)

            ElseIf SonCursorDurumu = Cizim_Enum_Mode.SagUst Then

                FocuslananRectangle.Height -= e.Y - MouseilkTiklanildigiNokta.Y
                If Not FocuslananRectangle.Height < 5 Then
                    FocuslananRectangle.Y -= -e.Y + MouseilkTiklanildigiNokta.Y
                Else
                    FocuslananRectangle.Height = 5
                End If

                FocuslananRectangle.Width += e.X - MouseilkTiklanildigiNokta.X
                FocuslananRectangle.Width = Math.Max(5, FocuslananRectangle.Width)

                RenctList(FocuslananRectangleListindex) = FocuslananRectangle
                MouseilkTiklanildigiNokta = New Point(e.X, e.Y)

            ElseIf SonCursorDurumu = Cizim_Enum_Mode.SagAlt Then

                FocuslananRectangle.Width += e.X - MouseilkTiklanildigiNokta.X
                FocuslananRectangle.Width = Math.Max(5, FocuslananRectangle.Width)

                FocuslananRectangle.Height += e.Y - MouseilkTiklanildigiNokta.Y
                FocuslananRectangle.Height = Math.Max(5, FocuslananRectangle.Height)

                RenctList(FocuslananRectangleListindex) = FocuslananRectangle
                MouseilkTiklanildigiNokta = New Point(e.X, e.Y)


            End If


        End If









        If CizimAktif = False Then

            If e.Button <> MouseButtons.Left Then
                CursorState = 0
                FocuslananRectangleListindex = 0
                For Each Rect As Rectangle In RenctList

                    SolUstxEksi = Rect.X - 5
                    SolUstxArti = Rect.X + 5
                    SolUstyEksi = Rect.Y - 5
                    SolUstyArti = Rect.Y + 5

                    SolAltyEksi = (Rect.Height + Rect.Y) - 5
                    SolAltyArti = (Rect.Height + Rect.Y) + 5
                    SolAltxEksi = (Rect.X) - 5
                    SolAltxArti = (Rect.X) + 5


                    SagUstxEksi = (Rect.X + Rect.Width) - 5  ' Sağdan Sola
                    SagUstxArti = (Rect.X + Rect.Width) + 5
                    SagUstyEksi = Rect.Y - 5
                    SagUstyArti = Rect.Y + 5


                    SagAltxEksi = (Rect.X + Rect.Width) - 5
                    SagAltxArti = (Rect.X + Rect.Width) + 5
                    SagAltyEksi = Rect.Y + Rect.Height - 5
                    SagAltyArti = Rect.Y + Rect.Height + 5


                    If e.X > SolUstxEksi And e.X < SolUstxArti And e.Y > SolUstyEksi And e.Y < SolUstyArti Then ' Üst Sol
                        FocuslananRectangle = Rect
                        Resim_Picturebox.Invalidate()
                        CursorState = Cizim_Enum_Mode.SolUst
                        Exit For
                    ElseIf e.X > SolAltxEksi And e.X < SolAltxArti And e.Y > SolAltyEksi And e.Y < SolAltyArti Then ' Üst Sol
                        FocuslananRectangle = Rect
                        Resim_Picturebox.Invalidate()
                        CursorState = Cizim_Enum_Mode.SolAlt
                        Exit For

                    ElseIf e.X > SagUstxEksi And e.X < SagUstxArti And e.Y > SagUstyEksi And e.Y < SagUstyArti Then ' Üst Sol
                        FocuslananRectangle = Rect
                        Resim_Picturebox.Invalidate()
                        CursorState = Cizim_Enum_Mode.SagUst
                        Exit For

                    ElseIf e.X > SagAltxEksi And e.X < SagAltxArti And e.Y > SagAltyEksi And e.Y < SagAltyArti Then
                        FocuslananRectangle = Rect
                        Resim_Picturebox.Invalidate()
                        CursorState = Cizim_Enum_Mode.SagAlt
                        Exit For

                    ElseIf Rect.Contains(e.X - 5, e.Y - 5) Then
                        FocuslananRectangle = Rect
                        Resim_Picturebox.Invalidate()
                        CursorState = Cizim_Enum_Mode.MoveMode
                        Exit For
                    Else
                        CursorState = 6
                    End If
                    FocuslananRectangleListindex += 1
                Next
                If SonCursorDurumu <> CursorState Then ' Bunu Yapmamızın Sebebi Mouse Sürekli Cursor Değişimi Olmasın
                    SonCursorDurumu = CursorState
                    If SonCursorDurumu = Cizim_Enum_Mode.MoveMode Then
                        Cursor = Cursors.SizeAll
                    ElseIf CursorState = Cizim_Enum_Mode.SolUst Then
                        Cursor = Cursors.SizeNWSE
                    ElseIf CursorState = Cizim_Enum_Mode.SolAlt Then
                        Cursor = Cursors.SizeNESW
                    ElseIf CursorState = Cizim_Enum_Mode.SagUst Then
                        Cursor = Cursors.SizeNESW
                    ElseIf CursorState = Cizim_Enum_Mode.SagAlt Then
                        Cursor = Cursors.SizeNWSE
                    Else
                        Cursor = Cursors.Default
                    End If
                End If
            End If
        End If

        If Cursor = Cursors.SizeAll And KaydirmaAktif = True Then
            FocuslananRectangle.Location = New Point(Math.Abs(e.X - ReferansXKoordinat), Math.Abs(e.Y - ReferansYKoordinat)) ' Forumda Sağa Sola Gezdirme
            RenctList(FocuslananRectangleListindex) = FocuslananRectangle
            Resim_Picturebox.Invalidate()

        End If

    End Sub



    Private Sub Resim_Picturebox_MouseDown(sender As Object, e As MouseEventArgs) Handles Resim_Picturebox.MouseDown

        If Cursor = Cursors.Default Then
            MouseAnlikRenct = New Rectangle(e.X, e.Y, 0, 0)
        Else
            If Cursor = Cursors.SizeAll Then
                If KaydirmaAktif = False Then
                    ReferansXKoordinat = Math.Abs(FocuslananRectangle.X - e.Location.X)
                    ReferansYKoordinat = Math.Abs(FocuslananRectangle.Y - e.Location.Y)
                End If

                KaydirmaAktif = True
                MouseAnlikRenct = Nothing
            End If
        End If

        If e.Button = MouseButtons.Left Then
            CizimAktif = True
            MouseilkTiklanildigiNokta = New Point(e.X, e.Y)
        End If

        Resim_Picturebox.Invalidate()

    End Sub
    Private Sub Resim_Picturebox_MouseUp(sender As Object, e As MouseEventArgs) Handles Resim_Picturebox.MouseUp
        If e.Button = MouseButtons.Left And Cursor = DefaultCursor Then
            If MouseAnlikRenct.Height >= 10 And MouseAnlikRenct.Width >= 10 Then
                RenctList.Add(MouseAnlikRenct)
                If Secim_1_Checkbox.Checked = True And RenctList.Count = 1 Then
                    Etiket_CheckList.Items.Add(Label_1_TextBox.Text, True)
                ElseIf Secim_2_Checkbox.Checked = True And RenctList.Count = 2 Then
                    Etiket_CheckList.Items.Add(Label_2_TextBox.Text, True)
                ElseIf Secim_3_Checkbox.Checked = True And RenctList.Count = 3 Then
                    Etiket_CheckList.Items.Add(Label_3_TextBox.Text, True)
                ElseIf Secim_4_Checkbox.Checked = True And RenctList.Count = 4 Then
                    Etiket_CheckList.Items.Add(Label_4_TextBox.Text, True)
                End If


            Else
                    MouseAnlikRenct = Nothing
            End If
        End If

        KaydirmaAktif = False
        CizimAktif = False
    End Sub









End Class
