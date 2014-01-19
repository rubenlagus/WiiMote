'////////////////////////////////////////////////////////////////////////////////
'	MultipleWiimoteForm.cs
'	Managed Wiimote Library Tester
'	Written by Brian Peek (http://www.brianpeek.com/)
'  for MSDN's Coding4Fun (http://msdn.microsoft.com/coding4fun/)
'	Visit http://blogs.msdn.com/coding4fun/archive/2007/03/14/1879033.aspx
'  and http://www.codeplex.com/WiimoteLib
'  for more information
'////////////////////////////////////////////////////////////////////////////////


Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms
Imports WiimoteLib

Namespace WiimoteTest
	Partial Public Class WiimoteInfo
		Inherits UserControl
		Private Delegate Sub UpdateWiimoteStateDelegate(ByVal args As WiimoteChangedEventArgs)
		Private Delegate Sub UpdateExtensionChangedDelegate(ByVal args As WiimoteExtensionChangedEventArgs)

        Private b As New Bitmap(1024, 768, PixelFormat.Format24bppRgb)
		Private g As Graphics
        Private mWiimote As Wiimote
        Private oldx As Integer 'Posición en el eje X del evento anterior
        Private ycintura As Integer 'Posición en el eje Y de la cintura
        Private ycabeza As Integer 'Posición aproximada en el eje Y de la cabeza
        Private initcintura As Boolean
        Private actual As Integer ' 0=none 1 = cintura 2 = cabeza
        Private modif As Date 'Tiempo desde el último cálculo del movimiento

		Public Sub New()
			InitializeComponent()
            g = Graphics.FromImage(b)
            initcintura = False
            oldx = 0
            actual = 0
            modif = DateTime.Now
            ycabeza = 0
		End Sub

		Public Sub New(ByVal wm As Wiimote)
			Me.New()
			mWiimote = wm
		End Sub

		Public Sub UpdateState(ByVal args As WiimoteChangedEventArgs)
			BeginInvoke(New UpdateWiimoteStateDelegate(AddressOf UpdateWiimoteChanged), args)
		End Sub

		Public Sub UpdateExtension(ByVal args As WiimoteExtensionChangedEventArgs)
			BeginInvoke(New UpdateExtensionChangedDelegate(AddressOf UpdateExtensionChanged), args)
		End Sub

        Private Sub UpdateWiimoteChanged(ByVal args As WiimoteChangedEventArgs)
            'Tratamiento de cada evento
            Dim ws As WiimoteState = args.WiimoteState
            Dim prueba As Boolean

            'Limpiar la pantalla donde se representan los puntos
            g.Clear(Color.White)

            'Representación de las fuentes infrarrojas
            UpdateIR(ws.IRState.IRSensors(0), Color.Red)
            UpdateIR(ws.IRState.IRSensors(1), Color.Blue)


            If Not initcintura Then
                'Si la posición inicial aún no se ha calculado (posición de la cintura)
                If ws.IRState.IRSensors(0).Found AndAlso ws.IRState.IRSensors(1).Found Then
                    'Si se reciben las dos fuentes LEDs de la barra

                    'Determinar que el mando se encuentra en posición horizontal y con los botones hacia arriba
                    prueba = ws.AccelState.Values.X > -0.34999999999999998 And ws.AccelState.Values.X < 0.34999999999999998
                    prueba = prueba And ws.AccelState.Values.Y > -0.14999999999999999 And ws.AccelState.Values.Y < 0.14999999999999999
                    prueba = prueba And ws.AccelState.Values.Z > 0.65000000000000002

                    If prueba Then
                        'Si es así, se guarda la posición actual como posición de la cintura
                        labelx.Text = " --> Detectando cintura"
                        ycintura = CInt(Fix(ws.IRState.RawMidpoint.Y))
                        oldx = CInt(Fix(ws.IRState.RawMidpoint.X))
                        'Calculo aproximado de la posición de la cabeza
                        ycabeza = ycintura - 440
                        If ycabeza < 0 Then
                            'Si la posición calculada sale de la pantalla simulada, se pone su valor a 0
                            ycabeza = 0
                        End If
                        initcintura = True
                    End If
                End If
            Else
                'Si la posición inicial se ha inicializado
                If ws.IRState.IRSensors(0).Found AndAlso ws.IRState.IRSensors(1).Found Then
                    'Si se reciben las dos fuentes LEDs de la barra

                    'Dibujar el lugar al que está apuntando el mando
                    Dim myBrush As New System.Drawing.SolidBrush(System.Drawing.Color.Black)
                    g.FillEllipse(myBrush, CInt(Fix(ws.IRState.RawMidpoint.X)), CInt(Fix(ws.IRState.RawMidpoint.Y)), 8, 8)

                    'Determinar que el mando se encuentra en posición horizontal y con los botones hacia arriba
                    prueba = ws.AccelState.Values.X > -0.34999999999999998 And ws.AccelState.Values.X < 0.34999999999999998
                    prueba = prueba And ws.AccelState.Values.Y > -0.14999999999999999 And ws.AccelState.Values.Y < 0.14999999999999999
                    prueba = prueba And ws.AccelState.Values.Z > 0.65000000000000002

                    If prueba Then
                        'Si es así, se guarda la posición actual como posición de la cintura

                        If CInt(Fix(ws.IRState.RawMidpoint.Y)) <= (ycabeza + 30) Then
                            'Si el punto actual se encuentra por encima de la posición aproximada de la cabeza
                            actual = 2
                            labelx.Text = "Posición: Cabeza" 'Mando por encima de la cabeza"
                        ElseIf CInt(Fix(ws.IRState.RawMidpoint.Y)) >= (ycintura - 30) Then
                            'Si el punto actual se encuentra por debajo de la posición aproximada de la cintura
                            actual = 1
                            labelx.Text = "Posición: Cintura" 'Mando por debajo de la cintura"
                        Else
                            'En cualquier otro caso
                            actual = 0
                            labelx.Text = "Posición: Otro" 'Mando entre la cabeza y la cintura"
                        End If
                    Else
                        'Si el mando no está en posición horizontal
                        labelx.Text = "Mantenga el mando en" & vbCr & "posición horizontal"
                    End If
                    If (DateTime.Now - modif).TotalMilliseconds > 500 Then
                        'Si ha pasado medio segundo desde la última vez que se comprobó movimiento
                        If CInt(Fix(ws.IRState.RawMidpoint.X)) < oldx Then
                            'Si la coordenada X ha cambiado en la dirección correcta (ha disminuido)
                            labely.Text = "Movimiento: Si" 'Sólo de izquierda a derecha
                        Else
                            labely.Text = "Movimiento: No"
                        End If
                        modif = DateTime.Now
                    End If
                End If
            End If
            oldx = CInt(Fix(ws.IRState.RawMidpoint.X))
            pbIR.Image = b

        End Sub

        Private Sub UpdateIR(ByVal irSensor As IRSensor, ByVal color As Color)

            If irSensor.Found Then
                g.DrawEllipse(New Pen(color), CInt(Fix(irSensor.RawPosition.X)), CInt(Fix(irSensor.RawPosition.Y)), irSensor.Size + 1, irSensor.Size + 1)
            End If
        End Sub

		Private Sub UpdateExtensionChanged(ByVal args As WiimoteExtensionChangedEventArgs)
		End Sub

		Public WriteOnly Property Wiimote() As Wiimote
			Set(ByVal value As Wiimote)
				mWiimote = value
			End Set
		End Property
	End Class
End Namespace
