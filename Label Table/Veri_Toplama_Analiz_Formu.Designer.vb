<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Veri_Toplama_Analiz_Formu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Chart_Control = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.Chart_Control, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart_Control
        '
        ChartArea3.AlignmentOrientation = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal
        ChartArea3.AlignmentStyle = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentStyles.PlotPosition
        ChartArea3.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[False]
        ChartArea3.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[False]
        ChartArea3.InnerPlotPosition.Auto = False
        ChartArea3.InnerPlotPosition.Height = 92.65293!
        ChartArea3.InnerPlotPosition.Width = 93.35384!
        ChartArea3.InnerPlotPosition.X = 5.52914!
        ChartArea3.InnerPlotPosition.Y = 1.67553!
        ChartArea3.IsSameFontSizeForAllAxes = True
        ChartArea3.Name = "ChartArea1"
        ChartArea3.Position.Auto = False
        ChartArea3.Position.Height = 94.0!
        ChartArea3.Position.Width = 94.0!
        ChartArea3.Position.X = 3.0!
        ChartArea3.Position.Y = 3.0!
        Me.Chart_Control.ChartAreas.Add(ChartArea3)
        Me.Chart_Control.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Chart_Control.Location = New System.Drawing.Point(3, 3)
        Me.Chart_Control.Name = "Chart_Control"
        Series3.ChartArea = "ChartArea1"
        Series3.IsValueShownAsLabel = True
        Series3.Label = "dd"
        Series3.LabelForeColor = System.Drawing.Color.IndianRed
        Series3.Name = "Series1"
        Me.Chart_Control.Series.Add(Series3)
        Me.Chart_Control.Size = New System.Drawing.Size(1042, 648)
        Me.Chart_Control.TabIndex = 2
        Me.Chart_Control.Text = "Chart1"
        Me.Chart_Control.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1056, 680)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.Chart_Control)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1048, 654)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Grafik Analiz"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.White
        Me.TabPage2.Controls.Add(Me.DataGridView1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1048, 654)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Liste"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1042, 648)
        Me.DataGridView1.TabIndex = 0
        '
        'Veri_Toplama_Analiz_Formu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(1056, 680)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Veri_Toplama_Analiz_Formu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Veri Toplama Analiz Formu"
        CType(Me.Chart_Control, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Chart_Control As DataVisualization.Charting.Chart
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents DataGridView1 As DataGridView
End Class
