Imports Newtonsoft.Json.Linq

Public Class Favori_Buton_Duzenleme_Formu
    Sub Ayarlari_Yerlestir()
        Favori_Text_1.Text = Sistem_Ayarlari.Favori1
        Favori_Text_2.Text = Sistem_Ayarlari.Favori2
        Favori_Text_3.Text = Sistem_Ayarlari.Favori3
        Favori_Text_4.Text = Sistem_Ayarlari.Favori4
        Favori_Text_5.Text = Sistem_Ayarlari.Favori5
        Favori_Text_6.Text = Sistem_Ayarlari.Favori6
        Favori_Text_7.Text = Sistem_Ayarlari.Favori7
        Favori_Text_8.Text = Sistem_Ayarlari.Favori8
        Favori_Text_9.Text = Sistem_Ayarlari.Favori9
        Favori_Text_10.Text = Sistem_Ayarlari.Favori10
        For Each st As String In Sistem_Ayarlari.FavoriListesi
            Favori_Listesi.AppendText(st & ",")
        Next
        Favori_Listesi.Text = Favori_Listesi.Text.TrimEnd(",")
    End Sub


    Private Sub Kaydet_Buton_Click(sender As Object, e As EventArgs) Handles Kaydet_Buton.Click

        Dim FList() As String = Favori_Listesi.Text.Split(",")
        For i = 0 To FList.Count - 1
            FList(i) = FList(i).TrimStart
            FList(i) = FList(i).TrimEnd
        Next

        Sistem_Ayarlari.Favori1 = Favori_Text_1.Text
        Sistem_Ayarlari.Favori2 = Favori_Text_2.Text
        Sistem_Ayarlari.Favori3 = Favori_Text_3.Text
        Sistem_Ayarlari.Favori4 = Favori_Text_4.Text
        Sistem_Ayarlari.Favori5 = Favori_Text_5.Text
        Sistem_Ayarlari.Favori6 = Favori_Text_6.Text
        Sistem_Ayarlari.Favori7 = Favori_Text_7.Text
        Sistem_Ayarlari.Favori8 = Favori_Text_8.Text
        Sistem_Ayarlari.Favori9 = Favori_Text_9.Text
        Sistem_Ayarlari.Favori10 = Favori_Text_10.Text


        Sistem_Ayarlari.FavoriListesi = New ArrayList(FList)

        Ayarlari_Yaz()
        For Each Formx As Object In Application.OpenForms
            If Formx.Name = "Obje_isimlendirme_Formu" Then
                Formx.Ayarlari_Yerlestir()
                Exit For
            End If

        Next


    End Sub

    Private Sub Favori_Buton_Duzenleme_Formu_Load(sender As Object, e As EventArgs) Handles Me.Load
        Ayarlari_Yerlestir()

    End Sub
End Class