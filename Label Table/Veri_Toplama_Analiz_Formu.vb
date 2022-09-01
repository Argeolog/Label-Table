Imports System.IO
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Veri_Toplama_Analiz_Formu
    Public Dosyaizleyici As FileSystemWatcher
    Private Sub Veri_Toplama_Analiz_Formu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Verileri_Say()
        Degisiklikleri_Algila()

    End Sub

    Sub Degisiklikleri_Algila()
        Try



            Dosyaizleyici = New FileSystemWatcher(Sistem_Ayarlari.KayitKlasoru & "\Crop")
            Dosyaizleyici.IncludeSubdirectories = True
            Dosyaizleyici.EnableRaisingEvents = True

            Dosyaizleyici.NotifyFilter = NotifyFilters.Attributes Or
                                       NotifyFilters.CreationTime Or
                                       NotifyFilters.DirectoryName Or
                                       NotifyFilters.FileName Or
                                       NotifyFilters.LastAccess Or
                                       NotifyFilters.LastWrite Or
                                       NotifyFilters.Security Or
                                       NotifyFilters.Size

            AddHandler Dosyaizleyici.Changed, AddressOf OnChanged
            AddHandler Dosyaizleyici.Deleted, AddressOf OnDeleted
        Catch ex As Exception
            Hata_Gonder_TryCatch(ex)
        End Try
    End Sub

    Private Sub OnChanged(sender As Object, e As FileSystemEventArgs)
        Try

            If e.ChangeType <> WatcherChangeTypes.Changed Then
                Return
            End If

            Invoke(New Action(Sub()
                                  Verileri_Say()
                              End Sub))
        Catch ex As Exception
            Hata_Gonder_TryCatch(ex)
        End Try
    End Sub

    Private Sub OnDeleted(sender As Object, e As FileSystemEventArgs)
        Try
            Invoke(New Action(Sub()
                                  Verileri_Say()
                              End Sub))

        Catch ex As Exception
            Hata_Gonder_TryCatch(ex)
        End Try
    End Sub

    Public Sub Verileri_Say()
        Try

            Chart_Control.Series.Clear()
            Chart_Control.Series.Add("Series1")
            Dim Stil As FontStyle = FontStyle.Regular
            Dim Fontx As Font = New Font(New FontFamily("Segoe UI"), 12, Stil)
            Dim Dt As New DataTable
            DataGridView1.Columns.Clear()

            Chart_Control.ResetAutoValues()

            Dim Klasorler() As String = Directory.GetDirectories(Sistem_Ayarlari.KayitKlasoru & "\Crop", "*.*", SearchOption.TopDirectoryOnly)
            Dim Dtrow As DataRow = Dt.NewRow()
            For i = 0 To Klasorler.Count - 1
                Dim DosyaAdi As String = Path.GetFileName(Klasorler(i).ToString)
                Dim DosyaSayisi As Integer = Directory.GetFiles(Klasorler(i), "*.jpg*", SearchOption.AllDirectories).Length
                Chart_Control.Series("Series1").Points.Add(DosyaSayisi)
                Chart_Control.Series("Series1").Points(i).Label = """" & DosyaAdi & """" & "  [" & DosyaSayisi & "]"
                Chart_Control.Series("Series1").Points(i).AxisLabel = DosyaAdi
                Chart_Control.Series("Series1").Points(i).Font = Fontx

                Dt.Columns.Add(DosyaAdi & " Etiketi")
                Dtrow(DosyaAdi & " Etiketi") = DosyaSayisi & " Adet"




            Next

            Dt.Rows.Add(Dtrow)

            Chart_Control.Series("Series1").IsValueShownAsLabel = True
            DataGridView1.DataSource = Dt
        Catch ex As Exception
            Hata_Gonder_TryCatch(ex)
        End Try


    End Sub

    Private Sub Veri_Toplama_Analiz_Formu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dosyaizleyici.Dispose()
    End Sub
End Class