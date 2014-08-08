Namespace DigitVer
    Public Class classDigitVer
        Public Function GetDB10Digit(ByVal referencia As String) As Integer
            Dim Multiplicador As Integer = 2
            Dim valor As Integer
            Dim sumando As Integer
            Dim suma As Integer
            Dim result As Integer

            Dim caracteres() As Char = referencia.ToCharArray
            Array.Reverse(caracteres)

            Dim i As Integer

            For i = 0 To UBound(caracteres)
                Select Case caracteres(i)
                    Case "A", "J", "1"
                        valor = 1
                    Case "B", "K", "S", "2"
                        valor = 2
                    Case "C", "L", "T", "3"
                        valor = 3
                    Case "D", "M", "U", "4"
                        valor = 4
                    Case "E", "N", "V", "5"
                        valor = 5
                    Case "F", "O", "W", "6"
                        valor = 6
                    Case "G", "P", "X", "7"
                        valor = 7
                    Case "H", "Q", "Y", "8"
                        valor = 8
                    Case "I", "R", "Z", "9"
                        valor = 9
                    Case "0"
                        valor = 0
                End Select

                sumando = Multiplicador * valor

                If sumando > 9 Then
                    Dim decenas As Integer
                    Dim unidades As Integer

                    decenas = sumando \ 10
                    unidades = sumando - 10
                    sumando = decenas + unidades
                End If

                If Multiplicador = 2 Then
                    Multiplicador = 1
                Else
                    Multiplicador = 2
                End If

                suma = suma + sumando

            Next

            result = ((suma \ 10) + 1) * 10 - suma

            If result = 10 Then
                result = 0
            End If


            'MsgBox("DV: " + CStr(result))

            GetDB10Digit = result
        End Function
    End Class
End Namespace
