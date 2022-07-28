Imports System.IO
Imports Newtonsoft.Json

Module Genel_Modul
    Public ColorList As New List(Of Color)

    Sub Ana_Renkleri_Ekle()
        ColorList.Add(Color.Lime)
        ColorList.Add(Color.Yellow)
        ColorList.Add(SystemColors.HotTrack)
        ColorList.Add(Color.BlueViolet)
        ColorList.Add(Color.Aqua)
        ColorList.Add(Color.Fuchsia)
        ColorList.Add(Color.DeepPink)
        ColorList.Add(Color.Cyan)
        ColorList.Add(Color.Blue)
        ColorList.Add(Color.DarkMagenta)
        ColorList.Add(Color.DarkSalmon)
        ColorList.Add(Color.DarkSlateBlue)
        ColorList.Add(Color.DodgerBlue)
        ColorList.Add(Color.ForestGreen)
        ColorList.Add(Color.HotPink)
        ColorList.Add(Color.LightCoral)
        ColorList.Add(Color.LightGreen)
        ColorList.Add(Color.LightSkyBlue)
        ColorList.Add(Color.Orange)
        ColorList.Add(Color.NavajoWhite)
        ColorList.Add(Color.OliveDrab)
        ColorList.Add(Color.PaleGreen)
        ColorList.Add(Color.PaleVioletRed)
        ColorList.Add(Color.Plum)
        ColorList.Add(Color.RoyalBlue)
        ColorList.Add(Color.SeaGreen)
        ColorList.Add(Color.Sienna)
        ColorList.Add(Color.Yellow)
        ColorList.Add(Color.Turquoise)
        Dim rnd As New Random
        Dim RenkUzayi As Color

        For i = 0 To 122 ' Toplamda 150 Renkte Etiketleme İşlemi Yapılabilir.
            RenkUzayi = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255))
            ColorList.Add(RenkUzayi)
        Next


    End Sub

    Enum Cizim_Enum_Mode
        MoveMode = 1
        SolUst = 2
        SolAlt = 3
        SagUst = 4
        SagAlt = 5
        SecimYok = 6
    End Enum


    Public Sub Hata_Gonder_TryCatch(ByVal Ex As Exception)
        Try

            Dim HataAgacı As New StackTrace(Ex, True)
            Dim HataSatırı As String = Strings.Right(HataAgacı.ToString, 6)

            Dim ErrorEvent As String = ""
            For Each StackFramex As StackFrame In HataAgacı.GetFrames
                ErrorEvent = StackFramex.GetMethod().Name
            Next

            Dim HataCumlesi As String = "Oluşan Hata" & ":" & Ex.Message & vbCrLf & "Olay Yordamı" & ":" & ErrorEvent & vbCrLf & "Hatanın Oluştuğu Satır" & ":" & HataSatırı

            ' Dim HataCumlesi As String = OlusanHataLisan & ":" & Ex.Message


            MessageBox.Show(HataCumlesi, "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch exs As Exception
            MessageBox.Show(exs.Message, "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function Ayarlari_Okundu() As Boolean

        Try

            Dim AyarOku As New StreamReader(Application.StartupPath & "\Ayar.json")
            Sistem_Ayarlari = JsonConvert.DeserializeObject(Of Dosya_Ayarlari)(AyarOku.ReadToEnd)
            AyarOku.Close()
            Return True
        Catch ex As Exception
            Hata_Gonder_TryCatch(ex)
        End Try

        Return False

    End Function

    Sub Ayarlari_Yaz()
        Try

            Dim AyarYaz As New StreamWriter(Application.StartupPath & "\Ayar.json")
            AyarYaz.Write(JsonConvert.SerializeObject(Sistem_Ayarlari, Formatting.Indented))
            AyarYaz.WriteLine(Sistem_Ayarlari.KlasorYolu)
            AyarYaz.Close()
        Catch ex As Exception
            Hata_Gonder_TryCatch(ex)
        End Try

    End Sub


    Public Sistem_Ayarlari As New Dosya_Ayarlari
    Class Dosya_Ayarlari
        Property KlasorYolu As String
        Property KayitKlasoru As String
        Property Secim1Checkbox As Boolean
        Property Label1Text As String
        Property Secim2Checkbox As Boolean
        Property Label2Text As String
        Property Secim3Checkbox As Boolean
        Property Label3Text As String
        Property Secim4Checkbox As Boolean
        Property Label4Text As String



    End Class



End Module
