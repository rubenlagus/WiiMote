Imports Microsoft.VisualBasic
Imports System
Namespace WiimoteTest
	Partial Public Class MainForm
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.groupBox5 = New System.Windows.Forms.GroupBox()
            Me.labelx = New System.Windows.Forms.Label()
            Me.labely = New System.Windows.Forms.Label()
            Me.pbIR = New System.Windows.Forms.PictureBox()
			CType(Me.pbIR, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox5.SuspendLayout()
			Me.SuspendLayout()
			'
            ' label position
            '
            Me.labelx.AutoSize = True
            Me.labelx.location = New System.Drawing.Point(8,50)
            Me.labelx.Name = "labelpos"
            Me.labelx.Size = New System.Drawing.Size(24,13)
            Me.labelx.TabIndex = 40
            Me.labelx.Text = "Posición: "
            Me.labely.AutoSize = True
            Me.labely.location = New System.Drawing.Point(8, 150)
            Me.labely.Name = "labelmov"
            Me.labely.Size = New System.Drawing.Size(24, 13)
            Me.labely.TabIndex = 38
            Me.labely.Text = "Movimiento: "
			' 
			' pbIR
			' 
			Me.pbIR.Location = New System.Drawing.Point(8, 252)
			Me.pbIR.Name = "pbIR"
			Me.pbIR.Size = New System.Drawing.Size(1024, 768)
			Me.pbIR.TabIndex = 10
			Me.pbIR.TabStop = False
			' 
			' groupBox5
			' 
            Me.groupBox5.Controls.Add(Me.labelx)
            Me.groupBox5.Controls.Add(Me.labely)
			Me.groupBox5.Location = New System.Drawing.Point(1028, 0)
			Me.groupBox5.Name = "groupBox5"
			Me.groupBox5.Size = New System.Drawing.Size(176, 260)
			Me.groupBox5.TabIndex = 22
			Me.groupBox5.TabStop = False
			Me.groupBox5.Text = "NPI"
			' 
			' MainForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(1290, 790)
			Me.Controls.Add(Me.pbIR)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
			Me.MaximizeBox = False
			Me.Name = "MainForm"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Wiimote Tester"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
'			Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.Form1_FormClosing);
			CType(Me.pbIR, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox5.ResumeLayout(False)
			Me.groupBox5.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region
        Private labelx As System.Windows.Forms.Label
        Private labely As System.Windows.Forms.Label
		Private pbIR As System.Windows.Forms.PictureBox
		Private groupBox5 As System.Windows.Forms.GroupBox
	End Class
End Namespace

