Imports Microsoft.VisualBasic
Imports System
Namespace WiimoteTest
	Partial Public Class WiimoteInfo
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

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.groupBox5 = New System.Windows.Forms.GroupBox()
            Me.labelx = New System.Windows.Forms.Label()
            Me.labely = New System.Windows.Forms.Label()
            Me.pbIR = New System.Windows.Forms.PictureBox()
            Me.groupBox5.SuspendLayout()
            CType(Me.pbIR, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            ' label position
            '
            Me.labelx.AutoSize = True
            Me.labelx.Location = New System.Drawing.Point(8, 100)
            Me.labelx.Name = "labelpos"
            Me.labelx.Size = New System.Drawing.Size(24, 13)
            Me.labelx.TabIndex = 39
            Me.labelx.Text = "Posicion: "
            Me.labely.AutoSize = True
            Me.labely.Location = New System.Drawing.Point(8, 150)
            Me.labely.Name = "labelmov"
            Me.labely.Size = New System.Drawing.Size(24, 13)
            Me.labely.TabIndex = 38
            Me.labely.Text = "Movimiento: "
            ' 
            ' groupBox5
            ' 
            Me.groupBox5.Controls.Add(Me.labelx)
            Me.groupBox5.Controls.Add(Me.labely)
            Me.groupBox5.Location = New System.Drawing.Point(1032, 0)
            Me.groupBox5.Name = "groupBox5"
            Me.groupBox5.Size = New System.Drawing.Size(176, 260)
            Me.groupBox5.TabIndex = 34
            Me.groupBox5.TabStop = False
            Me.groupBox5.Text = "NPI"
            ' 
            ' pbIR
            ' 
            Me.pbIR.Location = New System.Drawing.Point(4, 4)
            Me.pbIR.Name = "pbIR"
            Me.pbIR.Size = New System.Drawing.Size(1024, 768)
            Me.pbIR.TabIndex = 28
            Me.pbIR.TabStop = False
            ' 
            ' WiimoteInfo
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.groupBox5)
            Me.Controls.Add(Me.pbIR)
            Me.Name = "WiimoteInfo"
            Me.Size = New System.Drawing.Size(1290, 890)
            Me.groupBox5.ResumeLayout(False)
            Me.groupBox5.PerformLayout()
            CType(Me.pbIR, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region
        Public labelx As System.Windows.Forms.Label
        Public labely As System.Windows.Forms.Label
		Public groupBox5 As System.Windows.Forms.GroupBox
		Public pbIR As System.Windows.Forms.PictureBox
	End Class
End Namespace
