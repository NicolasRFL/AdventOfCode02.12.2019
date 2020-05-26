Imports System
Imports System.IO
Imports System.Text

Module Program

    Public Const nounParte1 As Integer = 12
    Public Const verbParte1 As Integer = 2

    Sub Main(args As String())
        Dim CurrentRow As Integer() = leerArchivo()
        CrearArchivoResultado("ResultadoParte1.txt", ParteUno(CurrentRow))
        CrearArchivoResultado("ResultadoParte2.txt", ParteDos(CurrentRow))
    End Sub

    Function buscarResultado(noun, verb, CurrentRow)
        Dim argumento1, argumento2, argumento3, resultado As Integer
        Dim genericList As New List(Of Integer)
        genericList.Clear()
        genericList.AddRange(CurrentRow)
        While genericList.Count < 500
            genericList.Add(1)
        End While
        genericList(1) = noun
        genericList(2) = verb
        For indice = 0 To (genericList.Count - 1) Step 4
            argumento1 = genericList(indice + 1)
            argumento2 = genericList(indice + 2)
            argumento3 = genericList(indice + 3)
            Select Case genericList(indice)
                Case 1
                    resultado = genericList(argumento1) + genericList(argumento2)
                    genericList(argumento3) = resultado
                Case 2
                    resultado = genericList(argumento1) * genericList(argumento2)
                    genericList(argumento3) = resultado
                Case 99
                    Exit For
            End Select
        Next
        Return resultado
    End Function

    Function leerArchivo()
        Dim CurrentRow As Integer()
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("incode.csv")
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            CurrentRow = Array.ConvertAll(MyReader.ReadFields(), Function(str) Int32.Parse(str))
        End Using
        Return CurrentRow
    End Function

    Function ParteUno(CurrentRow)
        Dim resultado As Integer = buscarResultado(nounParte1, verbParte1, CurrentRow)
        Return resultado
    End Function

    Function ParteDos(CurrentRow)
        Dim buscoNoun, buscoVerb, resultado As Integer
        For noun As Integer = 0 To 99
            For verb As Integer = 0 To 99
                resultado = buscarResultado(noun, verb, CurrentRow)
                If (resultado = 19690720) Then
                    buscoNoun = noun
                    buscoVerb = verb
                End If
            Next
        Next
        resultado = 100 * buscoNoun + buscoVerb
        Return (resultado)
    End Function

    Sub CrearArchivoResultado(nombreArchivo, StringContenido)
        Using sw As New StreamWriter(File.Open(nombreArchivo, FileMode.OpenOrCreate))
            sw.Write(StringContenido)
        End Using
    End Sub

End Module

