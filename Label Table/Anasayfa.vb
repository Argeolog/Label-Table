Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows
Imports System.Xml
Public Class Anasayfa
    ReadOnly ResimFiltre As String = "*.jpg"
    ReadOnly ResimFiltre2 As String = "*.jpeg"
    Public MouseAnlikRenct As Rectangle
    Public RenctList As New List(Of Rectangle) ' Sort Ettiğimizde Sırası Kayıyordu. Bu yüzden kopyasını aldık eklenenl


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

    Dim MousePozisyonCizimMode As Byte = 0 ' 1 Çizim Yapılıyor. 2 Mouse Picturebox A Çıktı
    ReadOnly PozisyonColor As Color = Color.FromArgb(80, 80, 80)
    ReadOnly MouseCursorReferans As Integer = 2 ' Sağ sol Kaydırma için mouse koordinatlarının eşik değeri


    Dim WTusuAktif As Boolean
    ' Dim MouseEvent As MouseEventArgs ' Son Mouse Hareketini Alıp W Basıldığında Tekrar Gönderiyoruz..

    Dim GirdiCikti As Boolean ' Klavyeden Tuş Girdi Çıktı Bilgisi Atanır
    Dim islemYapilanDosyaAdi As String


    Private Sub Anasayfa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.KeyPreview = True
        Ana_Renkleri_Ekle()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)


        Try
            Me.DoubleBuffered = True

            If Ayarlari_Okundu() Then
                Secilen_Dosyalar_Listbox.Items.AddRange(Directory.GetFiles(Sistem_Ayarlari.KlasorYolu, ResimFiltre))
                Secilen_Dosyalar_Listbox.Items.AddRange(Directory.GetFiles(Sistem_Ayarlari.KlasorYolu, ResimFiltre2))
            End If


            If Secilen_Dosyalar_Listbox.Items.Count > 0 Then
                Secilen_Dosyalar_Listbox.SelectedIndex = 0
            End If

            Dosya_Sayisi_Label.Text = Secilen_Dosyalar_Listbox.Items.Count & "\" & Secilen_Dosyalar_Listbox.SelectedIndex + 1
            Ayarlari_Yerlestir()

        Catch ex As Exception
            Hata_Gonder_TryCatch(ex)
        End Try



    End Sub
    Sub Ayarlari_Yerlestir()
        Secim_1_Checkbox.Checked = Sistem_Ayarlari.Secim1Checkbox
        Secim_2_Checkbox.Checked = Sistem_Ayarlari.Secim2Checkbox
        Secim_3_Checkbox.Checked = Sistem_Ayarlari.Secim3Checkbox
        Secim_4_Checkbox.Checked = Sistem_Ayarlari.Secim4Checkbox

        Label_1_TextBox.Text = Sistem_Ayarlari.Label1Text
        Label_2_TextBox.Text = Sistem_Ayarlari.Label2Text
        Label_3_TextBox.Text = Sistem_Ayarlari.Label3Text
        Label_4_TextBox.Text = Sistem_Ayarlari.Label4Text

        Mouse_Koordinat_Ciz_CheckBox.Checked = Sistem_Ayarlari.MouseKoordinatCiz
        Son_Etiketi_Default_Getir.Checked = Sistem_Ayarlari.SonEtiketiOtomatikYukle
        Tek_Harfleri_Buyuk_Yap_Check.Checked = Sistem_Ayarlari.TekHarfleriBuyukYap
    End Sub





    Private Sub Resim_Klasoru_Sec_Buton_Click(sender As Object, e As EventArgs) Handles Resim_Klasoru_Sec_Buton.Click
        Dim Op As New FolderBrowserDialog

        If Op.ShowDialog = DialogResult.OK Then
            Sistem_Ayarlari.KlasorYolu = Op.SelectedPath
            Ayarlari_Yaz()
            Secilen_Dosyalar_Listbox.Items.Clear()
            Secilen_Dosyalar_Listbox.Items.AddRange(Directory.GetFiles(Sistem_Ayarlari.KlasorYolu, ResimFiltre))
            Secilen_Dosyalar_Listbox.Items.AddRange(Directory.GetFiles(Sistem_Ayarlari.KlasorYolu, ResimFiltre2))

        End If

    End Sub



    Private Sub Kayit_Klasoru_Sec_Buton_Click(sender As Object, e As EventArgs) Handles Kayit_Klasoru_Sec_Buton.Click

        Dim Op As New FolderBrowserDialog
        If Op.ShowDialog = DialogResult.OK Then
            Sistem_Ayarlari.KayitKlasoru = Op.SelectedPath
            If Directory.Exists(Sistem_Ayarlari.KayitKlasoru & "\Crop") = False Then
                Directory.CreateDirectory(Sistem_Ayarlari.KayitKlasoru & "\Crop")
            End If
            If Directory.Exists(Sistem_Ayarlari.KayitKlasoru & "\Data") = False Then
                Directory.CreateDirectory(Sistem_Ayarlari.KayitKlasoru & "\Data")
            End If
            Ayarlari_Yaz()
            End If
    End Sub

    Private Sub Mouse_Koordinat_Ciz_CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles Mouse_Koordinat_Ciz_CheckBox.CheckedChanged




        Sistem_Ayarlari.MouseKoordinatCiz = Mouse_Koordinat_Ciz_CheckBox.Checked
        Ayarlari_Yaz()





    End Sub

    Private Sub Ayarlari_Kaydet_Click(sender As Object, e As EventArgs)








    End Sub



    Dim SonTiklananID As Integer = -2


    Sub Foto_Sec(ByVal FotoID As Integer, ByVal YinedeYukle As Boolean, FotoDefaultAl As Boolean)
        If FotoID < 0 Then
            FotoID = 0
        End If


        If SonTiklananID <> FotoID Or YinedeYukle Then
            If FotoDefaultAl = True Then
                Resim_Picturebox.Foto_Default()
            End If


            If SonTiklananID <> -2 Then

                Dim BirOncekiDosya As String = Secilen_Dosyalar_Listbox.Items(SonTiklananID)
                islemYapilanDosyaAdi = BirOncekiDosya.Substring(BirOncekiDosya.LastIndexOf("\"), BirOncekiDosya.Length - BirOncekiDosya.LastIndexOf("\"))
                islemYapilanDosyaAdi = islemYapilanDosyaAdi.TrimStart("\")
                Dim DosyaAdi() As String = islemYapilanDosyaAdi.Split(".")
                Dim FotoKlasoru() As String = BirOncekiDosya.Split("\")
                If RenctList.Count > 0 Then

                    For i = 0 To Etiket_CheckList.Items.Count - 1
                        Dim EtiketAdi As String = Etiket_CheckList.Items(i).ToString
                        Dim DosyaYolu As String = Sistem_Ayarlari.KayitKlasoru & "\Crop\" & EtiketAdi

                        Dim KlasorYoluVar As Boolean = Directory.Exists(DosyaYolu)
                        If KlasorYoluVar = False Then
                            Directory.CreateDirectory(DosyaYolu)   ' Resimler Klasörü Oluşturuluyor
                            KlasorYoluVar = Directory.Exists(DosyaYolu)
                        End If

                        If KlasorYoluVar = True Then

                            DosyaYolu &= "\" & DosyaAdi(0) & "-" & i & "." & DosyaAdi(1)
                            Foto_Kirp(Resim_Picturebox.Image, RenctList(i).Location.X, RenctList(i).Location.Y, RenctList(i).Width, RenctList(i).Height).Save(DosyaYolu)
                            Dim Str As New StringBuilder
                            Str.Append("<annotation>" & vbCrLf)
                            Str.Append("<folder>" & FotoKlasoru(FotoKlasoru.Count - 2) & "</folder>" & vbCrLf)
                            Str.Append("<filename>" & DosyaAdi(0) & "." & DosyaAdi(1) & "</filename>" & vbCrLf)
                            Str.Append("<path>" & BirOncekiDosya & "</path>" & vbCrLf)
                            Str.Append("<source>" & vbCrLf)
                            Str.Append("<database>" & "Unknown" & "</database>" & vbCrLf)
                            Str.Append("</source>" & vbCrLf)

                            Str.Append("<size>" & vbCrLf)
                            Str.Append("<width>" & Resim_Picturebox.Image.Width & "</width>" & vbCrLf)
                            Str.Append("<height>" & Resim_Picturebox.Image.Height & "</height>" & vbCrLf)
                            Str.Append("<depth>" & "3" & "</depth>" & vbCrLf)
                            Str.Append("</size>" & vbCrLf)
                            Str.Append("<segmented>" & 0 & "</segmented>" & vbCrLf)
                            Dim Say As Integer = 0
                            For Each Rec In RenctList
                                Str.Append("<object>" & vbCrLf)
                                Str.Append("<name>" & Etiket_CheckList.Items(Say).ToString & "</name>" & vbCrLf)
                                Str.Append("<pose>" & "Unspecified" & "</pose>" & vbCrLf)
                                Str.Append("<truncated>" & "0" & "</truncated>" & vbCrLf)
                                Str.Append("<difficult>" & 0 & "</difficult>" & vbCrLf)
                                Str.Append("<bndbox>" & vbCrLf)
                                Str.Append("<xmin>" & Rec.X & "</xmin>" & vbCrLf)
                                Str.Append("<ymin>" & Rec.Y & "</ymin>" & vbCrLf)
                                Str.Append("<xmax>" & Rec.Width & "</xmax>" & vbCrLf)
                                Str.Append("<ymax>" & Rec.Height & "</ymax>" & vbCrLf)
                                Str.Append("</bndbox>" & vbCrLf)
                                Str.Append("</object>" & vbCrLf)
                                Say += 1
                            Next
                            Str.Append("</annotation>" & vbCrLf)

                            Dim Strx As New StreamWriter(Sistem_Ayarlari.KayitKlasoru & "\Data\" & DosyaAdi(0) & ".xml", False, Encoding.UTF8)
                            Strx.WriteLine(Str.ToString)
                            Strx.Close()
                        Else

                            MessageBox.Show(Me, DosyaYolu & " Yolunda Klasör Oluşturulamadı !", "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If


                    Next
                Else
                    File.Delete(Sistem_Ayarlari.KayitKlasoru & "\Data\" & DosyaAdi(0) & ".xml")

                End If

            End If


            SonTiklananID = FotoID
            Dim SecilenDosya As String = Secilen_Dosyalar_Listbox.Items(FotoID)
            Resim_Picturebox.ImageLocation = SecilenDosya



            Resim_Picturebox.BackColor = Color.White
            If YinedeYukle = False Then
                RenctList.Clear()
                Etiket_CheckList.Items.Clear()
            End If
            Etiketleri_Yukle()
            Dosya_Sayisi_Label.Text = Secilen_Dosyalar_Listbox.Items.Count & "\" & Secilen_Dosyalar_Listbox.SelectedIndex + 1

        End If
    End Sub

    Sub Etiketleri_Yukle()
        Dim DosyaAdi() As String = Secilen_Dosyalar_Listbox.Items(Secilen_Dosyalar_Listbox.SelectedIndex).Split("\")
        Dim DosyaAdi2() As String = DosyaAdi(DosyaAdi.Count - 1).Split(".")
        Dim DosyaYolu As String = Sistem_Ayarlari.KayitKlasoru & "\Data\" & DosyaAdi2(0) & ".xml"
        Dim DosyaVar As Boolean = File.Exists(DosyaYolu)

        If DosyaVar Then

            Dim EtiketlerList As New DataTable
            Dim EtiketKonumlari As New DataTable
            Dim AyarDataset As New DataSet
            AyarDataset.ReadXml(DosyaYolu)

            EtiketlerList = AyarDataset.Tables("object")
            EtiketKonumlari = AyarDataset.Tables("bndbox")
            If RenctList.Count > 0 Then
                Etiket_CheckList.Items.Clear()
                RenctList.Clear()
            End If



            Dim Rc As Rectangle
            For i = 0 To EtiketlerList.Rows.Count - 1
                Etiket_CheckList.Items.Add(EtiketlerList.Rows(i).Item("name"), True)
                Dim Pt As New Point(EtiketKonumlari.Rows(i).Item("xmin"), EtiketKonumlari.Rows(i).Item("ymin"))
                Dim Sizex As New Size(EtiketKonumlari.Rows(i).Item("xmax"), EtiketKonumlari.Rows(i).Item("ymax"))
                Rc = New Rectangle(Pt, Sizex)
                RenctList.Add(Rc)
            Next
        End If
        Resim_Picturebox.Refresh()
    End Sub


    Private Function Foto_Kirp(ByRef KesilecekResim As Bitmap, ByVal RencX As Integer, ByVal RencY As Integer, ByVal RencWidth As Integer, ByVal RencHeight As Integer) As Bitmap
        Dim Rec As New Rectangle(RencX, RencY, RencWidth, RencHeight)
        Dim cropped As Bitmap = KesilecekResim.Clone(Rec, KesilecekResim.PixelFormat)
        Return cropped
    End Function


    Private Sub Dogrula_Buton_Click(sender As Object, e As EventArgs) Handles Dogrula_Buton.Click
        Resim_Picturebox.BackColor = Color.FromArgb(255, 46, 204, 113)
    End Sub

    Private Sub Resim_Picturebox_Click(sender As Object, e As EventArgs) Handles Resim_Picturebox.Click


    End Sub

    Private Sub Secilen_Dosyalar_Listbox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Secilen_Dosyalar_Listbox.SelectedIndexChanged
        Foto_Sec(Secilen_Dosyalar_Listbox.SelectedIndex, False, True)

    End Sub

    Private Sub Sonraki_Foto_Buton_Click(sender As Object, e As EventArgs) Handles Sonraki_Foto_Buton.Click
        Foto_Sec(Secilen_Dosyalar_Listbox.SelectedIndex + 1, False, True)

    End Sub

    Private Sub Onceki_Foto_Buton_Click(sender As Object, e As EventArgs) Handles Onceki_Foto_Buton.Click
        Foto_Sec(Secilen_Dosyalar_Listbox.SelectedIndex - 1, False, True)
    End Sub

    Private Sub Veri_Analiz_Buton_Click(sender As Object, e As EventArgs) Handles Veri_Analiz_Buton.Click
        If Application.OpenForms().OfType(Of Veri_Toplama_Analiz_Formu).Any = False Then ' Form Açıkmı Kontrolu..
            Veri_Toplama_Analiz_Formu.Show(Me)
        End If

    End Sub

    Sub Secimleri_Kaydet()
        Sistem_Ayarlari.Secim1Checkbox = Secim_1_Checkbox.Checked
        Sistem_Ayarlari.Secim2Checkbox = Secim_2_Checkbox.Checked
        Sistem_Ayarlari.Secim3Checkbox = Secim_3_Checkbox.Checked
        Sistem_Ayarlari.Secim4Checkbox = Secim_4_Checkbox.Checked

        Sistem_Ayarlari.Label1Text = Label_1_TextBox.Text
        Sistem_Ayarlari.Label2Text = Label_2_TextBox.Text
        Sistem_Ayarlari.Label3Text = Label_3_TextBox.Text
        Sistem_Ayarlari.Label4Text = Label_4_TextBox.Text
        Sistem_Ayarlari.SonEtiketiOtomatikYukle = Son_Etiketi_Default_Getir.Checked
        Sistem_Ayarlari.TekHarfleriBuyukYap = Tek_Harfleri_Buyuk_Yap_Check.Checked
        Ayarlari_Yaz()
    End Sub


    Private Sub Etiket_CheckList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Etiket_CheckList.SelectedIndexChanged

    End Sub

    Private Sub Label_2_TextBox_TextChanged(sender As Object, e As EventArgs) Handles Label_2_TextBox.TextChanged

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
                Etiket_CheckList.Items.RemoveAt(Secilen)
                SonTiklananID = -2
                Foto_Sec(Secilen, False, True)
            End If
        End If


    End Sub

    Private Sub Label_3_TextBox_TextChanged(sender As Object, e As EventArgs) Handles Label_3_TextBox.TextChanged

    End Sub

    Private Sub Resim_Picturebox_Paint(sender As Object, e As PaintEventArgs) Handles Resim_Picturebox.Paint

        Try



            If Cursor = Cursors.Default Then
                If CizimAktif Then
                    Using pen As New Pen(Color.Lime, 1)
                        e.Graphics.DrawRectangle(pen, MouseAnlikRenct)
                    End Using
                Else

                    If Sistem_Ayarlari.MouseKoordinatCiz And MousePozisyonCizimMode = 1 Then
                        Using penx As New Pen(PozisyonColor, 1)
                            Dim point1 As New PointF(9000, singlePoint(0).Y)
                            Dim point2 As New PointF(-9000, singlePoint(0).Y)
                            e.Graphics.DrawLine(penx, point1, point2)

                            Dim point3 As New PointF(singlePoint(0).X, 9000)
                            Dim point4 As New PointF(singlePoint(0).X, -9000)
                            e.Graphics.DrawLine(penx, point3, point4)

                        End Using
                    End If
                End If

            End If
        Catch ex As Exception
            Hata_Gonder_TryCatch(ex)
        End Try
        Try


            If RenctList.Count > 0 AndAlso RenctList.Count = Etiket_CheckList.Items.Count Then

                Dim CopyLocation(RenctList.Count - 1) As Rectangle
                TryCast(RenctList, ICollection).CopyTo(CopyLocation, 0)


                Dim i As Integer = 0
                For Each Renc As Rectangle In CopyLocation

                    If Etiket_CheckList.GetItemCheckState(i) = CheckState.Checked Then
                        Using pen As New Pen(ColorList(i), 1)
                            e.Graphics.DrawRectangle(pen, Renc)
                            Dim Str As String = Etiket_CheckList.Items(i).ToString
                            Dim sizeOfText As Size = TextRenderer.MeasureText(Str, New Font("Segoe UI", 5))
                            sizeOfText.Width -= 3
                            Dim rect As New Rectangle(New Point(Renc.X + 2, Renc.Y - 11), sizeOfText)
                            Dim TransParanMavi As Color = Color.FromArgb(120, 0, 0, 255)
                            Dim SolidBrushKalem As New SolidBrush(TransParanMavi)
                            e.Graphics.FillRectangle(SolidBrushKalem, rect)
                            e.Graphics.DrawString(Str, New Font("Segoe UI", 5, FontStyle.Bold), System.Drawing.Brushes.White, Renc.X + 2, Renc.Y - 11)

                        End Using

                        e.Graphics.FillRectangles(Brushes.Black, Koordinat_Hesapla(Renc))
                        e.Graphics.DrawRectangles(Pens.White, Koordinat_Hesapla(Renc))
                    End If
                    i += 1

                Next

                System.Threading.Thread.Sleep(5)
            End If



        Catch ex As Exception
            Hata_Gonder_TryCatch(ex)
        End Try



    End Sub

    Private Sub Label_4_TextBox_TextChanged(sender As Object, e As EventArgs) Handles Label_4_TextBox.TextChanged

    End Sub

    Function Koordinat_Hesapla(ByVal Rect As Rectangle) As RectangleF()
        Dim KoordinatList(4) As RectangleF
        KoordinatList(0) = New RectangleF(Rect.X - 1, Rect.Y - 1, 2, 2)
        KoordinatList(1) = New RectangleF(Rect.X + Rect.Width - 1, Rect.Y - 1, 2, 2)
        KoordinatList(2) = New RectangleF(Rect.X + Rect.Width - 1, Rect.Y + Rect.Height - 1, 2, 2)
        KoordinatList(3) = New RectangleF(Rect.X - 1, Rect.Y + Rect.Height - 1, 2, 2)
        Return KoordinatList
    End Function

    Private Sub Oto_Secimleri_Kaldir_CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles Oto_Secimleri_Kaldir_CheckBox.CheckedChanged
        If Oto_Secimleri_Kaldir_CheckBox.Checked = True Then
            Secim_1_Checkbox.Checked = False
            Secim_2_Checkbox.Checked = False
            Secim_3_Checkbox.Checked = False
            Secim_4_Checkbox.Checked = False
        Else
            Secim_1_Checkbox.Checked = Sistem_Ayarlari.Secim1Checkbox
            Secim_2_Checkbox.Checked = Sistem_Ayarlari.Secim2Checkbox
            Secim_3_Checkbox.Checked = Sistem_Ayarlari.Secim3Checkbox
            Secim_4_Checkbox.Checked = Sistem_Ayarlari.Secim4Checkbox
        End If

    End Sub

    Private Sub Resim_Picturebox_MouseMove(sender As Object, ex As MouseEventArgs) Handles Resim_Picturebox.MouseMove


        Try


            If Secilen_Dosyalar_Listbox.SelectedIndex > -1 Then


                Dim Pointx As Point = Resim_Picturebox.GetImagePoint(ex.Location)


                If MousePozisyonCizimMode = 2 Then
                    MousePozisyonCizimMode = 1

                End If



                If ex.Button = MouseButtons.Left And Cursor = DefaultCursor Then
                    MouseAnlikRenct = New Rectangle(MouseAnlikRenct.Left, MouseAnlikRenct.Top, Pointx.X - MouseAnlikRenct.Left, Pointx.Y - MouseAnlikRenct.Top)
                    Resim_Picturebox.Invalidate()
                End If

                If ex.Button = MouseButtons.Left Then
                    If SonCursorDurumu = Cizim_Enum_Mode.SolUst Then
                        FocuslananRectangle.Height -= Pointx.Y - MouseilkTiklanildigiNokta.Y
                        If Not FocuslananRectangle.Height < 5 Then
                            FocuslananRectangle.Y -= -Pointx.Y + MouseilkTiklanildigiNokta.Y
                        Else
                            FocuslananRectangle.Height = 5
                        End If
                        FocuslananRectangle.Width -= Pointx.X - MouseilkTiklanildigiNokta.X
                        If Not FocuslananRectangle.Width < 5 Then
                            FocuslananRectangle.X -= -Pointx.X + MouseilkTiklanildigiNokta.X
                        Else
                            FocuslananRectangle.Width = 5
                        End If
                        RenctList(FocuslananRectangleListindex) = FocuslananRectangle
                        MouseilkTiklanildigiNokta = New Point(Pointx.X, Pointx.Y)
                        Resim_Picturebox.Invalidate()
                    ElseIf SonCursorDurumu = Cizim_Enum_Mode.SolAlt Then
                        FocuslananRectangle.Height += Pointx.Y - MouseilkTiklanildigiNokta.Y
                        FocuslananRectangle.Height = Math.Max(5, FocuslananRectangle.Height)

                        FocuslananRectangle.Width -= Pointx.X - MouseilkTiklanildigiNokta.X
                        If Not FocuslananRectangle.Width < 5 Then
                            FocuslananRectangle.X -= -Pointx.X + MouseilkTiklanildigiNokta.X
                        Else
                            FocuslananRectangle.Width = 5
                        End If
                        RenctList(FocuslananRectangleListindex) = FocuslananRectangle
                        MouseilkTiklanildigiNokta = New Point(Pointx.X, Pointx.Y)
                        Resim_Picturebox.Invalidate()
                    ElseIf SonCursorDurumu = Cizim_Enum_Mode.SagUst Then

                        FocuslananRectangle.Height -= Pointx.Y - MouseilkTiklanildigiNokta.Y
                        If Not FocuslananRectangle.Height < 5 Then
                            FocuslananRectangle.Y -= -Pointx.Y + MouseilkTiklanildigiNokta.Y
                        Else
                            FocuslananRectangle.Height = 5
                        End If

                        FocuslananRectangle.Width += Pointx.X - MouseilkTiklanildigiNokta.X
                        FocuslananRectangle.Width = Math.Max(5, FocuslananRectangle.Width)

                        RenctList(FocuslananRectangleListindex) = FocuslananRectangle
                        MouseilkTiklanildigiNokta = New Point(Pointx.X, Pointx.Y)
                        Resim_Picturebox.Invalidate()
                    ElseIf SonCursorDurumu = Cizim_Enum_Mode.SagAlt Then

                        FocuslananRectangle.Width += Pointx.X - MouseilkTiklanildigiNokta.X
                        FocuslananRectangle.Width = Math.Max(5, FocuslananRectangle.Width)

                        FocuslananRectangle.Height += Pointx.Y - MouseilkTiklanildigiNokta.Y
                        FocuslananRectangle.Height = Math.Max(5, FocuslananRectangle.Height)

                        RenctList(FocuslananRectangleListindex) = FocuslananRectangle
                        MouseilkTiklanildigiNokta = New Point(Pointx.X, Pointx.Y)
                        Resim_Picturebox.Invalidate()
                    End If


                End If

                If CizimAktif = False Then
                    Resim_Picturebox.Invalidate()
                    If ex.Button <> MouseButtons.Left Then
                        CursorState = 0
                        FocuslananRectangleListindex = 0
                        For Each Rect As Rectangle In RenctList


                            SolUstxEksi = Rect.X - MouseCursorReferans
                            SolUstxArti = Rect.X + MouseCursorReferans
                            SolUstyEksi = Rect.Y - MouseCursorReferans
                            SolUstyArti = Rect.Y + MouseCursorReferans

                            SolAltyEksi = (Rect.Height + Rect.Y) - MouseCursorReferans
                            SolAltyArti = (Rect.Height + Rect.Y) + MouseCursorReferans
                            SolAltxEksi = (Rect.X) - MouseCursorReferans
                            SolAltxArti = (Rect.X) + MouseCursorReferans


                            SagUstxEksi = (Rect.X + Rect.Width) - MouseCursorReferans ' Sağdan Sola
                            SagUstxArti = (Rect.X + Rect.Width) + MouseCursorReferans
                            SagUstyEksi = Rect.Y - MouseCursorReferans
                            SagUstyArti = Rect.Y + MouseCursorReferans


                            SagAltxEksi = (Rect.X + Rect.Width) - MouseCursorReferans
                            SagAltxArti = (Rect.X + Rect.Width) + MouseCursorReferans
                            SagAltyEksi = Rect.Y + Rect.Height - MouseCursorReferans
                            SagAltyArti = Rect.Y + Rect.Height + MouseCursorReferans







                            If Pointx.X > SolUstxEksi And Pointx.X < SolUstxArti And Pointx.Y > SolUstyEksi And Pointx.Y < SolUstyArti Then ' Üst Sol
                                FocuslananRectangle = Rect
                                Resim_Picturebox.Invalidate()

                                Resim_Picturebox.Invalidate()
                                CursorState = Cizim_Enum_Mode.SolUst
                                Exit For
                            ElseIf Pointx.X > SolAltxEksi And Pointx.X < SolAltxArti And Pointx.Y > SolAltyEksi And Pointx.Y < SolAltyArti Then ' Üst Sol
                                FocuslananRectangle = Rect
                                Resim_Picturebox.Invalidate()
                                CursorState = Cizim_Enum_Mode.SolAlt
                                Exit For

                            ElseIf Pointx.X > SagUstxEksi And Pointx.X < SagUstxArti And Pointx.Y > SagUstyEksi And Pointx.Y < SagUstyArti Then ' Üst Sol
                                FocuslananRectangle = Rect

                                Resim_Picturebox.Invalidate()
                                CursorState = Cizim_Enum_Mode.SagUst
                                Exit For

                            ElseIf Pointx.X > SagAltxEksi And Pointx.X < SagAltxArti And Pointx.Y > SagAltyEksi And Pointx.Y < SagAltyArti Then
                                FocuslananRectangle = Rect
                                Resim_Picturebox.Invalidate()
                                CursorState = Cizim_Enum_Mode.SagAlt
                                Exit For

                            ElseIf Rect.Contains(Pointx.X - MouseCursorReferans, Pointx.Y - MouseCursorReferans) AndAlso WTusuAktif = True Then
                                Dim Listx As New List(Of Rectangle)
                                Listx = RenctList.OrderBy(Function(r) r.Width * r.Height).ToList() ' Burada Sort Ediyoruz. Büyük olan Önce İşaretlenmiş olsa Bile kaydırma yapılabilsin.

                                For i = 0 To Listx.Count - 1
                                    If Listx(i).Contains(Pointx.X - MouseCursorReferans, Pointx.Y - MouseCursorReferans) Then
                                        Rect = Listx(i)
                                        FocuslananRectangleListindex = RenctList.IndexOf(Rect)
                                        Exit For
                                    End If
                                Next

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

                    FocuslananRectangle.Location = New Point(Math.Abs(Pointx.X - ReferansXKoordinat), Math.Abs(Pointx.Y - ReferansYKoordinat)) ' Forumda Sağa Sola Gezdirme
                    RenctList(FocuslananRectangleListindex) = FocuslananRectangle

                    Resim_Picturebox.Invalidate()
                End If
            End If
        Catch exx As Exception
            Me.Text = exx.Message
        End Try

    End Sub



    Private Sub Resim_Picturebox_MouseDown(sender As Object, ex As MouseEventArgs) Handles Resim_Picturebox.MouseDown



        Dim Pointx As Point = Resim_Picturebox.GetImagePoint(ex.Location)



        If Cursor = Cursors.Default Then
            MouseAnlikRenct = New Rectangle(Pointx.X, Pointx.Y, 0, 0)
        Else
            If Cursor = Cursors.SizeAll Then
                If KaydirmaAktif = False Then
                    ReferansXKoordinat = Math.Abs(FocuslananRectangle.X - Pointx.X)
                    ReferansYKoordinat = Math.Abs(FocuslananRectangle.Y - Pointx.Y)
                End If

                KaydirmaAktif = True
                MouseAnlikRenct = Nothing
            End If
        End If

        If ex.Button = MouseButtons.Left Then
            CizimAktif = True
            MouseilkTiklanildigiNokta = New Point(Pointx.X, Pointx.Y)
        End If



    End Sub
    Private Sub Resim_Picturebox_MouseUp(sender As Object, er As MouseEventArgs) Handles Resim_Picturebox.MouseUp



        If er IsNot Nothing Then



            If er.Button = MouseButtons.Left And Cursor = DefaultCursor Then
                If MouseAnlikRenct.Height >= 5 And MouseAnlikRenct.Width >= 5 Then
                    EtiketKayitEdildi = True
                    If Secim_1_Checkbox.Checked = True And RenctList.Count = 0 Then
                        Etiket_CheckList.Items.Add(Label_1_TextBox.Text, True)
                    ElseIf Secim_2_Checkbox.Checked = True And RenctList.Count = 1 Then
                        Etiket_CheckList.Items.Add(Label_2_TextBox.Text, True)
                    ElseIf Secim_3_Checkbox.Checked = True And RenctList.Count = 2 Then
                        Etiket_CheckList.Items.Add(Label_3_TextBox.Text, True)
                    ElseIf Secim_4_Checkbox.Checked = True And RenctList.Count = 3 Then
                        Etiket_CheckList.Items.Add(Label_4_TextBox.Text, True)
                    Else
                        Dim Obj As New Obje_isimlendirme_Formu With {
                            .Location = New Point(Cursor.Position.X, Cursor.Position.Y)
                        }

                        Dim Locy As Integer = Cursor.Position.Y + Obj.Height
                        Dim Locx As Integer = Cursor.Position.X + Obj.Width

                        If Locy >= Screen.PrimaryScreen.WorkingArea.Size.Height Then
                            Obj.Location = New Point(Obj.Location.X, Math.Abs(Obj.Location.Y - Obj.Height))
                        End If

                        If Locx >= Screen.PrimaryScreen.WorkingArea.Size.Width Then
                            Obj.Location = New Point(Math.Abs(Obj.Location.X - Obj.Width), Obj.Location.Y)
                        End If
                        EtiketKayitEdildi = False
                        Obj.ShowDialog(Me)
                    End If

                    If EtiketKayitEdildi = True Then
                        RenctList.Add(MouseAnlikRenct)
                    End If
                    Resim_Picturebox.Refresh()
                Else
                    MouseAnlikRenct = Nothing
                End If
            End If

            KaydirmaAktif = False
            CizimAktif = False
        End If
    End Sub




    Private Sub Resim_Picturebox_MouseLeave(sender As Object, e As EventArgs)
        MousePozisyonCizimMode = 2

    End Sub

    Private Sub Son_Etiketi_Default_Getir_CheckedChanged(sender As Object, e As EventArgs) Handles Son_Etiketi_Default_Getir.CheckedChanged


    End Sub

    Private Sub Tek_Harfleri_Buyuk_Yap_Check_CheckedChanged(sender As Object, e As EventArgs) Handles Tek_Harfleri_Buyuk_Yap_Check.CheckedChanged

    End Sub

    Private Sub Anasayfa_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        MousePozisyonCizimMode = 1
    End Sub


    Private Sub Anasayfa_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.W Then
            If WTusuAktif = False Then
                WTusuAktif = True
                Resim_Picturebox.Refresh()
            End If
        ElseIf e.Control = True AndAlso e.KeyCode = Keys.Z AndAlso GirdiCikti = False Then
            GirdiCikti = True
            If RenctList.Count > 0 Then
                RenctList.RemoveAt(RenctList.Count - 1)
                Etiket_CheckList.Items.RemoveAt(Etiket_CheckList.Items.Count - 1)
                Foto_Sec(SonTiklananID, True, False)
            End If
        End If

    End Sub

    Private Sub Anasayfa_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        WTusuAktif = False
        GirdiCikti = False
    End Sub

    Private Sub Etiket_CheckList_MouseUp(sender As Object, e As MouseEventArgs) Handles Etiket_CheckList.MouseUp
        Resim_Picturebox.Refresh()
    End Sub


    Private Sub Etiket_CheckList_KeyUp(sender As Object, e As KeyEventArgs) Handles Etiket_CheckList.KeyUp
        If e.KeyCode = Keys.Space Then
            Resim_Picturebox.Refresh()
        ElseIf e.KeyCode = Keys.Delete Then
            If MessageBox.Show(Me, "Seçilen Etiket Silinsin Mi ?", "İşlem Onayı !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                RenctList.RemoveAt(Etiket_CheckList.SelectedIndex)
                Etiket_CheckList.Items.RemoveAt(Etiket_CheckList.SelectedIndex)
                Resim_Picturebox.Refresh()
                Foto_Sec(SonTiklananID, False, True)

            End If
        End If

    End Sub

    Private Sub Label_1_TextBox_Leave(sender As Object, e As EventArgs) Handles Label_1_TextBox.Leave
        Secimleri_Kaydet()
    End Sub

    Private Sub Label_2_TextBox_Leave(sender As Object, e As EventArgs) Handles Label_2_TextBox.Leave
        Secimleri_Kaydet()
    End Sub

    Private Sub Label_3_TextBox_Leave(sender As Object, e As EventArgs) Handles Label_3_TextBox.Leave
        Secimleri_Kaydet()
    End Sub

    Private Sub Label_4_TextBox_Leave(sender As Object, e As EventArgs) Handles Label_4_TextBox.Leave
        Secimleri_Kaydet()
    End Sub

    Private Sub Secim_2_Checkbox_Click(sender As Object, e As EventArgs) Handles Secim_2_Checkbox.Click

    End Sub

    Private Sub Secim_1_Checkbox_Click(sender As Object, e As EventArgs) Handles Secim_1_Checkbox.Click
        Secimleri_Kaydet()
    End Sub

    Private Sub Secim_3_Checkbox_Click(sender As Object, e As EventArgs) Handles Secim_3_Checkbox.Click
        Secimleri_Kaydet()
    End Sub

    Private Sub Secim_4_Checkbox_Click(sender As Object, e As EventArgs) Handles Secim_4_Checkbox.Click
        Secimleri_Kaydet()
    End Sub

    Private Sub Son_Etiketi_Default_Getir_Click(sender As Object, e As EventArgs) Handles Son_Etiketi_Default_Getir.Click
        Secimleri_Kaydet()
    End Sub

    Private Sub Tek_Harfleri_Buyuk_Yap_Check_Click(sender As Object, e As EventArgs) Handles Tek_Harfleri_Buyuk_Yap_Check.Click
        Secimleri_Kaydet()
    End Sub
End Class
