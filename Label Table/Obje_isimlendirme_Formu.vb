Public Class Obje_isimlendirme_Formu


    Private Sub Kaydet_Buton_Click(sender As Object, e As EventArgs) Handles Kaydet_Buton.Click
        Etiket_Ekle()
    End Sub

    Private Sub Obje_isimlendirme_Formu_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If Sistem_Ayarlari.SonEtiketiOtomatikYukle Then
            Etiket_Adi_Text.Text = SonEtiketAdi
        End If
        Etiket_Adi_Text.Focus()
    End Sub

    Private Sub Obje_isimlendirme_Formu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.Default
        Ayarlari_Yerlestir()
    End Sub

    Private Sub Favori_Etiketler_List_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Favori_Etiketler_List.SelectedIndexChanged
        If Favori_Etiketler_List.SelectedIndex > -1 Then
            Etiket_Adi_Text.Text = Favori_Etiketler_List.Items(Favori_Etiketler_List.SelectedIndex)
            Etiket_Ekle()
        End If

    End Sub

    Private Sub TableLayoutPanel2_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel2.Paint

    End Sub

    Sub Ayarlari_Yerlestir()
        Fav_Buton1.Text = Sistem_Ayarlari.Favori1
        Fav_Buton2.Text = Sistem_Ayarlari.Favori2
        Fav_Buton3.Text = Sistem_Ayarlari.Favori3
        Fav_Buton4.Text = Sistem_Ayarlari.Favori4
        Fav_Buton5.Text = Sistem_Ayarlari.Favori5
        Fav_Buton6.Text = Sistem_Ayarlari.Favori6
        Fav_Buton7.Text = Sistem_Ayarlari.Favori7
        Fav_Buton8.Text = Sistem_Ayarlari.Favori8
        Fav_Buton9.Text = Sistem_Ayarlari.Favori9
        Fav_Buton10.Text = Sistem_Ayarlari.Favori10
        Favori_Etiketler_List.Items.Clear()
        Favori_Etiketler_List.Items.AddRange(Sistem_Ayarlari.FavoriListesi.ToArray)
        Etiket_Adi_Text.Items.AddRange(Sistem_Ayarlari.YukluEtiketler.ToArray)
    End Sub

    Private Sub Favori_Duzenle_Buton_Click(sender As Object, e As EventArgs) Handles Favori_Duzenle_Buton.Click
        Favori_Buton_Duzenleme_Formu.Show(Me)
    End Sub

    Sub Etiket_Ekle()
        If Sistem_Ayarlari.TekHarfleriBuyukYap AndAlso Etiket_Adi_Text.Text.Length = 1 Then
            Etiket_Adi_Text.Text = Etiket_Adi_Text.Text.ToUpper
        End If
        Anasayfa.Etiket_CheckList.Items.Add(Etiket_Adi_Text.Text, True)
        Me.Close()
    End Sub
    Private Sub Fav_Buton1_Click(sender As Object, e As EventArgs) Handles Fav_Buton1.Click
        Etiket_Adi_Text.Text = Fav_Buton1.Text
        Etiket_Ekle()
    End Sub

    Private Sub Fav_Buton2_Click(sender As Object, e As EventArgs) Handles Fav_Buton2.Click
        Etiket_Adi_Text.Text = Fav_Buton2.Text
        Etiket_Ekle()
    End Sub

    Private Sub Fav_Buton3_Click(sender As Object, e As EventArgs) Handles Fav_Buton3.Click
        Etiket_Adi_Text.Text = Fav_Buton3.Text
        Etiket_Ekle()
    End Sub

    Private Sub Fav_Buton4_Click(sender As Object, e As EventArgs) Handles Fav_Buton4.Click
        Etiket_Adi_Text.Text = Fav_Buton4.Text
        Etiket_Ekle()
    End Sub

    Private Sub Fav_Buton5_Click(sender As Object, e As EventArgs) Handles Fav_Buton5.Click
        Etiket_Adi_Text.Text = Fav_Buton5.Text
        Etiket_Ekle()
    End Sub

    Private Sub Fav_Buton6_Click(sender As Object, e As EventArgs) Handles Fav_Buton6.Click
        Etiket_Adi_Text.Text = Fav_Buton6.Text
        Etiket_Ekle()
    End Sub

    Private Sub Fav_Buton7_Click(sender As Object, e As EventArgs) Handles Fav_Buton7.Click
        Etiket_Adi_Text.Text = Fav_Buton7.Text
        Etiket_Ekle()
    End Sub

    Private Sub Fav_Buton8_Click(sender As Object, e As EventArgs) Handles Fav_Buton8.Click
        Etiket_Adi_Text.Text = Fav_Buton8.Text
        Etiket_Ekle()
    End Sub

    Private Sub Fav_Buton9_Click(sender As Object, e As EventArgs) Handles Fav_Buton9.Click
        Etiket_Adi_Text.Text = Fav_Buton9.Text
        Etiket_Ekle()
    End Sub

    Private Sub Fav_Buton10_Click(sender As Object, e As EventArgs) Handles Fav_Buton10.Click
        Etiket_Adi_Text.Text = Fav_Buton10.Text
        Etiket_Ekle()
    End Sub

    Private Sub Num_Buton1_Click(sender As Object, e As EventArgs) Handles Num_Buton1.Click
        Etiket_Adi_Text.Text = Num_Buton1.Text
        Etiket_Ekle()
    End Sub

    Private Sub Num_Buton2_Click(sender As Object, e As EventArgs) Handles Num_Buton2.Click
        Etiket_Adi_Text.Text = Num_Buton2.Text
        Etiket_Ekle()
    End Sub

    Private Sub Num_Buton3_Click(sender As Object, e As EventArgs) Handles Num_Buton3.Click
        Etiket_Adi_Text.Text = Num_Buton3.Text
        Etiket_Ekle()
    End Sub

    Private Sub Num_Buton4_Click(sender As Object, e As EventArgs) Handles Num_Buton4.Click
        Etiket_Adi_Text.Text = Num_Buton4.Text
        Etiket_Ekle()
    End Sub

    Private Sub Num_Buton5_Click(sender As Object, e As EventArgs) Handles Num_Buton5.Click
        Etiket_Adi_Text.Text = Num_Buton5.Text
        Etiket_Ekle()
    End Sub

    Private Sub Num_Buton6_Click(sender As Object, e As EventArgs) Handles Num_Buton6.Click
        Etiket_Adi_Text.Text = Num_Buton6.Text
        Etiket_Ekle()
    End Sub

    Private Sub Num_Buton7_Click(sender As Object, e As EventArgs) Handles Num_Buton7.Click
        Etiket_Adi_Text.Text = Num_Buton7.Text
        Etiket_Ekle()
    End Sub

    Private Sub Num_Buton8_Click(sender As Object, e As EventArgs) Handles Num_Buton8.Click
        Etiket_Adi_Text.Text = Num_Buton8.Text
        Etiket_Ekle()
    End Sub

    Private Sub Num_Buton9_Click(sender As Object, e As EventArgs) Handles Num_Buton9.Click
        Etiket_Adi_Text.Text = Num_Buton9.Text
        Etiket_Ekle()
    End Sub

    Private Sub Num_Buton0_Click(sender As Object, e As EventArgs) Handles Num_Buton0.Click
        Etiket_Adi_Text.Text = Num_Buton0.Text
        Etiket_Ekle()
    End Sub

    Private Sub Etiket_Adi_Text_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Etiket_Adi_Text.SelectedIndexChanged

    End Sub

    Private Sub Etiket_Adi_Text_Leave(sender As Object, e As EventArgs) Handles Etiket_Adi_Text.Leave


    End Sub

    Private Sub Obje_isimlendirme_Formu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Etiket_Adi_Text.Text.Length > 0 Then

            SonEtiketAdi = Etiket_Adi_Text.Text
            If Sistem_Ayarlari.YukluEtiketler Is Nothing Then
                Sistem_Ayarlari.YukluEtiketler = New List(Of String) From {
                Etiket_Adi_Text.Text
            }
                Ayarlari_Yaz()
            Else
                If Sistem_Ayarlari.YukluEtiketler.Contains(Etiket_Adi_Text.Text) = False Then
                    Sistem_Ayarlari.YukluEtiketler.Add(Etiket_Adi_Text.Text)
                    Ayarlari_Yaz()
                End If
            End If

        End If
    End Sub

    Private Sub Listeyi_Bosalt_Buton_Click(sender As Object, e As EventArgs) Handles Listeyi_Bosalt_Buton.Click
        Etiket_Adi_Text.Items.Clear()
        Sistem_Ayarlari.YukluEtiketler.Clear()
        Ayarlari_Yaz()
    End Sub

    Private Sub Obje_isimlendirme_Formu_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Anasayfa.RenctList.RemoveAt(Anasayfa.RenctList.Count - 1)
            Me.Close()
        End If
    End Sub
End Class